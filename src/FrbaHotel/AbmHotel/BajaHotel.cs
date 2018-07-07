using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.AbmHotel
{
    public partial class BajaHotel : Form
    {
        private SqlDataReader qry;
        public static MenuAbmHotel AbmHot;
        int hotelID = 0;
        string insert = "";

        private class Hotel
        {
            public int Valor;
            public string Nombre;

            public Hotel(int valor, string calle, int calle_nro)
            {
                Nombre = calle + " " + calle_nro.ToString();
                Valor = valor;
            }
            public override string ToString()
            {
                return Nombre;
            }
        }

        public BajaHotel(int hotel)
        {
            InitializeComponent();

            hotelID = hotel;
            qry = Index.BD.consultaGetPuntero("select distinct hot_calle, hot_calle_nro from EN_CASA_ANDABA.Hoteles where hot_id = " + hotelID);
            qry.Read();
            hotelActivo.Items.Add(qry.GetString(0) + " " + qry.GetInt32(1).ToString());
            qry.Close();

            bajaDesde.Value = DateTime.Today;
            bajaHasta.Value = DateTime.Today;
        }

        private bool checkCampos()
        {
            bool inconsistencias = false;
            string alerta = "";

            if (string.IsNullOrEmpty(bajaDesde.Text) || string.IsNullOrEmpty(bajaHasta.Text))
            {
                alerta = alerta + "Debe ingresar un período de baja válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(motivo.Text))
            {
                alerta = alerta + "Debe ingresar un motivo de baja válido\n";
                inconsistencias = true;
            }

            DateTime hasta, desde, hoy;
            desde = Convert.ToDateTime(bajaDesde.Value);
            hasta = Convert.ToDateTime(bajaHasta.Value);
            hoy = DateTime.Today;

            if (DateTime.Compare(desde, hasta) >= 0)
            {
                alerta = alerta + "La fecha de fin de la baja debe ser posterior al " + bajaDesde.ToString() + "\n";
                inconsistencias = true;
            }

            qry = Index.BD.consultaGetPuntero("exec EN_CASA_ANDABA.habitacionesReservadasHotel"); // SP QUE CHEQUEE SI TIENE RESERVAS UN HOTEL

            if (qry.Read())
            {
                alerta = alerta + "#error: En el período ingresado el Hotel tiene reservas activas\n";
                inconsistencias = true;
            }
                       
            if (inconsistencias)
            {
                MessageBox.Show(alerta);
            }
            return inconsistencias;
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (checkCampos())
            {
                insert = "insert into EN_CASA_ANDABA.BajasHotel ";
                insert = insert + "(baj_hot_id, baj_fecha_inicio, baj_fecha_fin, baj_motivo) ";
                insert = insert + "values (" + hotelID + ",'" + bajaDesde.Value.Date.ToString("yyyyMMdd HH:mm:ss") + "','" + bajaHasta.Value.Date.ToString("yyyyMMdd HH:mm:ss") + "','" + motivo.Text + "')";
                qry = Index.BD.consultaGetPuntero(insert);

                if (qry.Read())
                {
                    MessageBox.Show("El Hotel " + hotelActivo.Text + ", fue dado de baja /n desde el " + bajaDesde.Value + "/n" + "hasta el " + bajaHasta.Value);
                }
                qry.Close();
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            hotelActivo.Text = string.Empty;
            bajaDesde.ResetText();
            bajaHasta.ResetText();
            motivo.Text = string.Empty;
            bajaDesde.Focus();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmHot = new MenuAbmHotel();
            AbmHot.Show();
        }

    }
}

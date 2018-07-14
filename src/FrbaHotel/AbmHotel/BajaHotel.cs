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
        DateTime desde, hasta;
        string desdeS, hastaS;
        bool inconsistencias = false;

        public BajaHotel(string calleHot, string calleNroHot)
        {
            InitializeComponent();

            qry = Index.BD.consultaGetPuntero("select hot_id from EN_CASA_ANDABA.Hoteles where hot_calle = '" + calleHot + "' and hot_calle_nro = " + calleNroHot);
            if (qry.Read())
            {
                hotelID = qry.GetInt32(0);
            }
            qry.Close();

            hotelActivo.Items.Add(calleHot + " " + calleNroHot);

        }

        private bool checkCampos()
        {
            inconsistencias = false;
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

            desde = Convert.ToDateTime(bajaDesde.Value);
            hasta = Convert.ToDateTime(bajaHasta.Value);

            if (DateTime.Compare(desde, hasta) >= 0)
            {
                alerta = alerta + "La fecha de fin de la baja debe ser posterior a la fecha de inicio\n";
                inconsistencias = true;
            }
            
            int resultado = Index.BD.consultaGetInt("select EN_CASA_ANDABA.tieneReservaHotel ('" + desde.Date.ToString() + "', '" + hasta.Date.ToString() + "', " + hotelID.ToString() + ")");
            if (resultado == 1)
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

        private string insertString(string campo)
        {
            if (string.IsNullOrEmpty(campo))
            {
                insert = insert + "null,";
            }
            else
            {
                insert = insert + "'" + campo + "',";
            }
            return insert;
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (inconsistencias == false)
            {
                bool insertOk = true;
                desde = Convert.ToDateTime(bajaDesde.Value);
                desdeS = desde.Date.ToString("yyyyMMdd HH:mm:ss");
                hasta = Convert.ToDateTime(bajaHasta.Value);
                hastaS = hasta.Date.ToString("yyyyMMdd HH:mm:ss");
                qry = Index.BD.consultaGetPuntero("insert into EN_CASA_ANDABA.BajasHotel (baj_hot_id, baj_fecha_inicio, baj_fecha_fin, baj_motivo) values (" + hotelID.ToString() + ",'" + desdeS + "', '" + hastaS + "', '" + motivo.Text + "')");
                /*if (qry.Read())
                {
                    insertOk = qry.GetBoolean(0);
                }*/
                qry.Close();

                if (insertOk)
                {
                    MessageBox.Show("El Hotel " + hotelActivo.Text + ", fue dado de baja /n desde el " + bajaDesde.Value + "/n" + "hasta el " + bajaHasta.Value);
                }
                else
                {
                    MessageBox.Show("#error: no se ha podido realizar la operación");
                }
                limpiar.PerformClick();
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

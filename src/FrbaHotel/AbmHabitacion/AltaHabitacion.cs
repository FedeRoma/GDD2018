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

namespace FrbaHotel.AbmHabitacion
{
    public partial class AltaHabitacion : Form
    {
        private SqlDataReader qry;
        public static MenuAbmHabitacion AbmHab;

        private class TipoHabitacion
        {
            public string Nombre;
            public int Valor;
            public TipoHabitacion(int valor, string nombre)
            {
                Nombre = nombre;
                Valor = valor;
            }
            public override string ToString()
            {
                return Nombre;
            }
        }
        private class Vista
        {
            public string Nombre;
            public string Valor;
            public Vista(string valor, string nombre)
            {
                Nombre = nombre;
                Valor = valor;
            }
            public override string ToString()
            {
                return Nombre;
            }
        }

        public AltaHabitacion()
        {
            InitializeComponent();

            qry = Index.BD.consultaGetPuntero("select distinct tip_id, tip_nombre from EN_CASA_ANDABA.TiposHabitaciones");
            while (qry.Read())
            {
                tipoHabitacion.Items.Add(new TipoHabitacion(qry.GetInt32(0), qry.GetString(1)));
            }
            qry.Close();
            vista.Items.Add(new Vista("S", "S"));
            vista.Items.Add(new Vista("N", "N"));
        }

        private void AltaHabitacion_Load(object sender, EventArgs e)
        {
            qry = Index.BD.consultaGetPuntero("select distinct hot_calle, hot_calle_nro from EN_CASA_ANDABA.Hoteles where hot_id = " + Index.hotel);
            qry.Read();
            hotelActivo.Items.Add(qry.GetString(0) + " " + qry.GetInt32(1).ToString());
            qry.Close();
        }

        private void numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool checkCampos()
        {
            bool inconsistencias = false;
            string alerta = "";

            if (string.IsNullOrEmpty(numero.Text))
            {
                alerta = alerta + "Debe ingresar un número de habitación válido\n";
                inconsistencias = true;
            }
            else
            {
                qry = Index.BD.consultaGetPuntero("select * from EN_CASA_ANDABA.Habitaciones where hab_hot_id = " + Index.hotel + " and hab_numero = " + numero.Text);
                if (qry.Read())
                {
                    alerta = alerta + "Número de habitación ya existente\n";
                    inconsistencias = true;
                }
                qry.Close();
            }
            if (string.IsNullOrEmpty(piso.Text))
            {
                alerta = alerta + "Debe ingresar un piso válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(vista.Text))
            {
                alerta = alerta + "Debe ingresar una vista válida\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(tipoHabitacion.Text))
            {
                alerta = alerta + "Debe ingresar un tipo de habitación válido\n";
                inconsistencias = true;
            }
            
            if (inconsistencias)
            {
                MessageBox.Show(alerta);
            }
            return inconsistencias;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (!checkCampos())
            {
                bool insertOk = false;

                qry = Index.BD.consultaGetPuntero("exec EN_CASA_ANDABA.AltaHabitacion " + numero.Text + ", " + piso.Text + ", '" + vista.Text + "', '" + tipoHabitacion.Text + "', " + Index.hotel + ", '" + descripcion.Text + "'");
                if (qry.Read())
                {
                    insertOk = qry.GetBoolean(0);
                }
                qry.Close();

                if (!insertOk)
                {
                    MessageBox.Show("#error: no se ha podido realizar la operación");
                    return;
                }

                MessageBox.Show("Habitación dada de alta");
                limpiar.PerformClick();
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            numero.Text = string.Empty;
            piso.Text = string.Empty;
            vista.ResetText();
            tipoHabitacion.ResetText();
            descripcion.Text = string.Empty;
            numero.Focus();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmHab = new MenuAbmHabitacion();
            AbmHab.Show();
        }

    }
}

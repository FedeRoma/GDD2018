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
    public partial class ModificacionHabitacion : Form
    {
        private SqlDataReader qry;
        public static ListadoHabitaciones ListadoHab;
        int habitacionID = 0;
        string nroHabitacionInic;

        public ModificacionHabitacion(string numeroHab, string pisoHab, string vistaHab, 
                                        string tipoHab, string descripcionHab, string estadoHab)
        {
            InitializeComponent();

            nroHabitacionInic = numeroHab;

            tipoHabitacion.Text = tipoHab;

            qry = Index.BD.consultaGetPuntero("select hab_id from EN_CASA_ANDABA.Habitaciones where hab_numero = " + numeroHab + " and hab_piso = " + pisoHab + " and hab_hot_id = " + Index.hotel);
            if (qry.Read())
            {
                habitacionID = qry.GetInt32(0);
            }
            qry.Close();

            numero.Text = numeroHab;
            piso.Text = pisoHab;
            vista.Text = vistaHab;
            tipoHabitacion.Text = tipoHab;
            descripcion.Text = descripcionHab;
            if (estadoHab == "True")
            {
                estado.Checked = true;
            }
        }

        private void ModificacionHabitacion_Load(object sender, EventArgs e)
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
                    if ((numero.Text == nroHabitacionInic))
                    {

                    }
                    else
                    {
                        alerta = alerta + "Número de habitación ya existente\n";
                        inconsistencias = true;
                    }
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
                string nuevoEstado;
                if (estado.Checked)
                {
                    nuevoEstado = "1";
                }
                else
                {
                    nuevoEstado = "0";
                }

                bool insertOk = false;

                qry = Index.BD.consultaGetPuntero("exec EN_CASA_ANDABA.ModificacionHabitacion " + habitacionID.ToString() + ", " + numero.Text + ", " + piso.Text + ", '" + vista.Text + "', '" + tipoHabitacion.Text + "', " + Index.hotel + ", '" + descripcion.Text + "', " + nuevoEstado);
                if (qry.Read())
                {
                    insertOk = qry.GetBoolean(0);
                }
                qry.Close();

                if (insertOk)
                {
                    MessageBox.Show("Habitación modificada con éxito");
                    atras_Click(null, null);
                }
                else
                {
                    MessageBox.Show("#error: no se ha podido realizar la operación");
                }
            }
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListadoHab = new ListadoHabitaciones();
            ListadoHab.Show();
        }

    }
}

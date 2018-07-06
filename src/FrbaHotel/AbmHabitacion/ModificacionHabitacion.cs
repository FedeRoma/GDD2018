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
        public static MenuAbmHabitacion AbmHab;
        decimal idH;
        private SqlDataReader resultado;
        private SqlDataReader qry;

        public ModificacionHabitacion(decimal id, string numero, string piso, string ubicacion, string tipo, string descripcion, string estado)
        {
            InitializeComponent();
            idH = id;
            string consulta = "select hot_calle from EN_CASA_ANDABA.Hoteles where hot_id = " + Index.hotel;
            resultado = Index.BD.consultaGetPuntero(consulta);
            if (resultado.Read())
            {
                textBoxHotel.Text = resultado.GetString(0);
            }
            resultado.Close();
            textBoxNroHab.Text = numero;
            textBoxPiso.Text = piso;
            textBoxUbicacion.Text = ubicacion;
            textBoxDescripcion.Text = descripcion;
            comboBoxTipoHab.Text = tipo;
            if (estado == "True")
            {
                checkBoxEstado.Checked = true;

            }
            
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            int a = checkearCamposVacios();
            if (a == 0)
            {
                //MODIFICAR VALORES
                string insert = "EXEC EN_CASA_ANDABA.modificacionHabitacion ";
                insert = insert + idH.ToString() + ",";
                insert = insert + textBoxNroHab.Text + ",";
                insert = insert + textBoxPiso.Text + ",";
                insert = insert + "'" + textBoxUbicacion.Text + "',";
                insert = insert + "'" + textBoxDescripcion.Text + "',";
                insert = insert + Index.hotel + ",";
                /*if (!string.IsNullOrEmpty(textBox4.Text))
                {
                    insert = insert + "'" + textBox4.Text + "',";
                }
                else
                {
                    insert = insert + "NULL,";
                }
                 * */
                if (checkBoxEstado.Checked)
                {
                    insert = insert + "1";
                }
                else
                {
                    insert = insert + "0";
                }

                decimal resu = 0;
                resultado = Index.BD.consultaGetPuntero(insert);
                if (resultado.Read())
                {
                    resu = resultado.GetDecimal(0);
                }
                resultado.Close();
                if (resu != 0)
                {
                    MessageBox.Show("La habitacion fue guardada correctamente");
                    ListadoHabitacionesMod.ActiveForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al guardar, la habitacion ya existe con ese numero,piso,tipo y hotel");
                }
            }

        }
        private int checkearCamposVacios()
        {
            int a = 0;
            string mensaje = "";
            if (string.IsNullOrEmpty(textBoxNroHab.Text))
            {
                a = 1;
                mensaje = mensaje + "El campo numero es obligatorio\n";
            }
            if (string.IsNullOrEmpty(textBoxPiso.Text))
            {
                a = 1;
                mensaje = mensaje + "El campo piso es obligatorio\n";
            }
            if (string.IsNullOrEmpty(textBoxUbicacion.Text))
            {
                a = 1;
                mensaje = mensaje + "El campo ubicacion es obligatorio\n";
            }
            if (string.IsNullOrEmpty(textBoxHotel.Text))
            {
                a = 1;
                mensaje = mensaje + "El campo hotel es obligatorio\n";
            }
            if (string.IsNullOrEmpty(comboBoxTipoHab.Text))
            {
                a = 1;
                mensaje = mensaje + "El campo tipo es obligatorio\n";
            }


            if (a == 1)
            {
                MessageBox.Show(mensaje);
            }
            return a;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            textBoxNroHab.Text = string.Empty;
            textBoxPiso.Text = string.Empty;
            textBoxUbicacion.Text = string.Empty;
            comboBoxTipoHab.ResetText();
            textBoxDescripcion.Text = string.Empty;
            textBoxNroHab.Focus();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmHab = new MenuAbmHabitacion();
            AbmHab.Show();
        }

        private void checkBoxEstado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}

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
        public static MenuAbmHabitacion AbmHab;
        private SqlDataReader qry;
        private SqlDataReader resultado;

        public AltaHabitacion()
        {
            InitializeComponent();
            this.tiposHabitacionesTableAdapter.Fill(this.gD1C2018DataSet.TiposHabitaciones);
            string consulta = "select hot_calle from EN_CASA_ANDABA.Hoteles where hot_id = " + Index.hotel;
            qry = Index.BD.consultaGetPuntero(consulta);
            if (qry.Read())
            {
                textBoxHotel.Text = qry.GetString(0);
            }
            qry.Close();
        }

        public void AltaHabitacion_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gD1C2018DataSet.TiposHabitaciones' table. You can move, or remove it, as needed.


        }

        public void guardar_Click(object sender, EventArgs e)
        {

            int a = checkearCamposVacios();
            if (a == 0)
            {
                //INSERTAR VALORES
                string insert = "EXEC EN_CASA_ANDABA.altaHabitacion ";
                string aux = comboBoxTipoHab.ToString();

                insert = textBoxNroHab.Text ;
                insert = textBoxPiso.Text ;
                insert = textBoxUbicacion.Text;
               // insert = insert + comboBoxTipoHab.ToString();
                insert = Index.hotel;
                if (!string.IsNullOrEmpty(textBoxDescripcion.Text))
                {
                    insert = textBoxDescripcion.Text ;
                }
                else
                {
                    insert =  "NULL";
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
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al guardar, la habitacion ya existe con ese numero,piso,tipo y hotel");
                }
            }



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

        private void comboBoxTipoHab_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void textBoxHotel_TextChanged(object sender, EventArgs e)
        {

        }

        public int checkearCamposVacios()
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

        private void textBoxNroHab_TextChanged(object sender, EventArgs e)
        {

        }

    }
}

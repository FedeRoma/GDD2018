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

namespace FrbaHotel.AbmCliente
{
    public partial class AltaCliente : Form
    {
        private SqlDataReader resultado;
        public static MenuAbmCliente AbmCli;

        public AltaCliente()
        {
            InitializeComponent();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            textBoxDireccion.Text = string.Empty;
            textBoxNombre.Text = string.Empty;
            textBoxApellido.Text = string.Empty;
            textBoxTelefono.Text = string.Empty;
            textBoxEmail.Text = string.Empty;
            textBoxNacionalidad.Text = string.Empty;
            textBoxNroDoc.Text = string.Empty;
            comboBoxTipoDoc.ResetText();
            dateTimePickerFechaNac.ResetText();
            comboBoxTipoDoc.Focus();
        }

        private int checkVacios()
        {
            int a = 0;
            string mensaje = "";

            if (string.IsNullOrEmpty(textBoxNombre.Text))
            {
                a = 1;
                mensaje = mensaje + "El campo nombre es obligatorio\n";
            }
            if (string.IsNullOrEmpty(textBoxApellido.Text))
            {
                a = 1;
                mensaje = mensaje + "El campo apellido es obligatorio\n";
            }
            if (string.IsNullOrEmpty(textBoxNacionalidad.Text))
            {
                a = 1;
                mensaje = mensaje + "El campo nacionalidad es obligatorio\n";
            }

            if (string.IsNullOrEmpty(comboBoxTipoDoc.Text))
            {
                a = 1;
                mensaje = mensaje + "El campo tipo doc es obligatorio\n";
            }
            if (string.IsNullOrEmpty(textBoxTelefono.Text))
            {
                a = 1;
                mensaje = mensaje + "El campo telefono es obligatorio\n";
            }
            if (string.IsNullOrEmpty(textBoxNroDoc.Text))
            {
                a = 1;
                mensaje = mensaje + "El campo NroDoc es obligatorio\n";
            }
            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                a = 1;
                mensaje = mensaje + "El campo mail es obligatorio\n";
            }
            if (string.IsNullOrEmpty(textBoxDireccion.Text))
            {
                a = 1;
                mensaje = mensaje + "El campo direccion es obligatorio\n";
            }

            DateTime fecha;
            fecha = Convert.ToDateTime(dateTimePickerFechaNac.Value);

            DateTime s = DateTime.Today;

            int result = DateTime.Compare(fecha, s);

            if (result >= 0)
            {
                a = 1;
                mensaje = mensaje + "La fecha debe ser menor a la actual\n";
            }

            if (a == 1)
            {
                MessageBox.Show(mensaje);
            }
            return a;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            int a = checkVacios();
            if (a == 0)
            {
                string insert = "EXEC EN_CASA_ANDABA.altaCLiente ";
                insert = insert + "'" + textBoxNroDoc + "',";
                insert = insert + "'" + comboBoxTipoDoc.Text + "',";
                insert = insert + "'" + textBoxNombre.Text + "',";
                insert = insert + "'" + textBoxApellido.Text + "',";
                insert = insert + "'" + textBoxEmail.Text + "',";
                insert = insert + "'" + textBoxNacionalidad.Text + "',";

                DateTime fecha;

                fecha = Convert.ToDateTime(dateTimePickerFechaNac.Value);
                string fechaString = fecha.Date.ToString("yyyyMMdd HH:mm:ss");
                insert = insert + "'" + fechaString + "',";
                insert = insert + textBoxDireccion.Text + ","; // #Issue03
                insert = insert + textBoxTelefono.Text + ",";

                decimal ok = 0;
                decimal email = 0;

                resultado = Index.BD.consultaGetPuntero(insert);
                if (resultado.Read())
                {
                    ok = resultado.GetDecimal(0);
                }
                resultado.Close();

                resultado = Index.BD.consultaGetPuntero("select count (*) from EN_CASA_ANDABA.Clientes where mail = '" + textBoxEmail.Text + "'");
                if (resultado.Read())
                {
                    email = resultado.GetDecimal(0);
                }
                resultado.Close();

                if (ok == 1 && email == 0)
                {
                    MessageBox.Show("Operación realizada con éxito");                 
                }
                else if (ok == 2)
                {
                    MessageBox.Show("Error: no se pudo guardar");
                }
                else
                {
                    MessageBox.Show("Error: Email ya registrado");
                }
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmCli = new MenuAbmCliente();
            AbmCli.Show();
        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gD1C2018DataSet.Documentos' table. You can move, or remove it, as needed.
            this.documentosTableAdapter.Fill(this.gD1C2018DataSet.Documentos);

        }

    }
}
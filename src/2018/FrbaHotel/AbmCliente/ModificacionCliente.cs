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
    public partial class ModificacionCliente : Form
    {
        private SqlDataReader resultado;
        public static AbmCliente AbmCli;

        public ModificacionCliente()
        {
            InitializeComponent();
        }

        private void guardar_Click(object sender, EventArgs e)
        {

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

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmCli = new AbmCliente();
            AbmCli.Show();
        }
    }
}

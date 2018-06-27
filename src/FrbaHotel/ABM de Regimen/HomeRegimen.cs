using System;
using System.Windows.Forms;

namespace FrbaHotel.Regimen
{
    public partial class HomeRegimen : Form
    {
        public HomeRegimen()
        {
            InitializeComponent();
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            this.Hide();
            Regimen.Modificacion alta = new Regimen.Modificacion("Agregar", "INSERT INTO EN_CASA_ANDABA.Regimenes (reg_desc, reg_precio, reg_habilitado) VALUES ");
            alta.ShowDialog();
            this.Show();
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            this.Hide();
            Regimen.Listado baja = new Regimen.Listado("Borrar","DELETE FROM EN_CASA_ANDABA.Regimenes WHERE reg_id = ");
            baja.ShowDialog();
            this.Show();
        }

        private void buttonModi_Click(object sender, EventArgs e)
        {
            this.Hide();
            Regimen.Listado modificacion = new Regimen.Listado("Modificar", "UPDATE EN_CASA_ANDABA.Regimenes SET ");
            modificacion.ShowDialog();
            this.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void HomeRegimen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login.HomeLogin.mainFun.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.RegistrarConsumible
{
    public partial class Consumibles : Form
    {
        public static RegistrarConsumible.RegistrarConsumibles RegCons;
        public Consumibles(string estadia, string habitacion, string numero, string piso)
        {
            InitializeComponent();
            textBoxIdEstadia.Text = estadia;
            textBoxIdHabitacion.Text = habitacion;
            textBoxNumero.Text = numero;
            textBoxPiso.Text = piso;

        }

        private void Consumibles_Load(object sender, EventArgs e)
        {

        }

        private void textBoxIdEstadia_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegCons = new RegistrarConsumible.RegistrarConsumibles();
            RegCons.Show();
        }

        
    }
}

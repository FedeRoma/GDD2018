using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHabitacion
{
    public partial class BajaHabitacion : Form
    {
        public static MenuAbmHabitacion AbmHab;

        public BajaHabitacion()
        {
            InitializeComponent();
        }

        private void BajaHabitacion_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gD1C2018DataSet.TiposHabitaciones' table. You can move, or remove it, as needed.
            this.tiposHabitacionesTableAdapter.Fill(this.gD1C2018DataSet.TiposHabitaciones);

        }

        private void buscar_Click(object sender, EventArgs e)
        {

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
    }
}

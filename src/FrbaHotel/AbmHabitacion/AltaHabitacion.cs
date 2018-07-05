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
    public partial class AltaHabitacion : Form
    {
        public static MenuAbmHabitacion AbmHab;

        public AltaHabitacion()
        {
            InitializeComponent();
        }

        private void AltaHabitacion_Load(object sender, EventArgs e)
        {

        }

        private void guardar_Click(object sender, EventArgs e)
        {

        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            numero.Text = string.Empty;
            piso.Text = string.Empty;
            ubicacion.Text = string.Empty;
            tipoHabitacion.ResetText();
            descripcion.Text = string.Empty;
            numero.Focus();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmHab = new MenuAbmHabitacion();
            AbmHab.Show();
        }

    }
}

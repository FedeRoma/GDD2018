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
    public partial class MenuAbmHabitacion : Form
    {
        public static ListadoHabitaciones ListadoHab;
        public static AltaHabitacion AltaHab;
        public static BajaHabitacion BajaHab;
        public static Login.MenuFuncionalidades menuFuncionalidades;
        
        public MenuAbmHabitacion()
        {
            InitializeComponent();
        }

        private void listadoHabitaciones_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListadoHab = new ListadoHabitaciones();
            ListadoHab.Show();
        }

        private void altaHabitacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            AltaHab = new AltaHabitacion();
            AltaHab.Show();
        }

        private void bajaHabitacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            BajaHab = new BajaHabitacion();
            BajaHab.Show();
        }

        private void modificacionHabitacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListadoHab = new ListadoHabitaciones();
            ListadoHab.Show();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            menuFuncionalidades = new Login.MenuFuncionalidades();
            menuFuncionalidades.Show();
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHotel
{
    public partial class MenuAbmHotel : Form
    {
        //Instancio las ventanas que voy a llamar luego
        public static ListadoHoteles ListadoHot;
        public static AltaHotel AltaHot;
        public static BajaHotel BajaHot;
        public static Login.MenuFuncionalidades menuFuncionalidades;



        public MenuAbmHotel()
        {
            InitializeComponent();
        }

        private void listadoHoteles_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListadoHot = new ListadoHoteles();
            ListadoHot.Show();
        }

        private void altaHotel_Click(object sender, EventArgs e)
        {
            this.Hide();
            AltaHot = new AltaHotel();
            AltaHot.Show();
        }

        private void bajaHotel_Click(object sender, EventArgs e)
        {
            this.Hide();
            BajaHot = new BajaHotel();
            BajaHot.Show();
        }

        private void modificacionHotel_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListadoHot = new ListadoHoteles();
            ListadoHot.Show();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            menuFuncionalidades = new Login.MenuFuncionalidades();
            menuFuncionalidades.Show();
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmRol
{
    public partial class MenuAbmRol : Form
    {
        public static AltaRol AltaRol;
        public static BajaRol BajaRol;
        public static ListadoRoles ListadoRoles;
        public static Login.MenuFuncionalidades menuFuncionalidades;

        public MenuAbmRol()
        {
            InitializeComponent();
        }

        private void listadoRoles_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListadoRoles = new ListadoRoles();
            ListadoRoles.Show();
        }

        private void altaRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            AltaRol = new AltaRol();
            AltaRol.Show();
        }

        private void bajaRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            BajaRol = new BajaRol();
            BajaRol.Show();
        }

        private void modificacionRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListadoRoles = new ListadoRoles();
            ListadoRoles.Show();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            menuFuncionalidades = new Login.MenuFuncionalidades();
            menuFuncionalidades.Show();
            this.Close();
        }

    }
}

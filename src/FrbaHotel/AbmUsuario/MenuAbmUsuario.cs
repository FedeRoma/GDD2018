using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmUsuario
{
    public partial class MenuAbmUsuario : Form
    {
        public static ListadoUsuarios ListadoUsu;
        public static AltaUsuario AltaUsu;
        public static BajaUsuario BajaUsu;
        public static Login.MenuFuncionalidades menuFuncionalidades;

        public MenuAbmUsuario()
        {
            InitializeComponent();
        }

        private void listadoUsuarios_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListadoUsu = new ListadoUsuarios();
            ListadoUsu.Show();
        }

        private void altaUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            AltaUsu = new AltaUsuario();
            AltaUsu.Show();
        }

        private void bajaUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            BajaUsu = new BajaUsuario();
            BajaUsu.Show();
        }

        private void modificacionUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListadoUsu = new ListadoUsuarios();
            ListadoUsu.Show();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            menuFuncionalidades = new Login.MenuFuncionalidades();
            menuFuncionalidades.Show();
            this.Close();
        }
    }
}

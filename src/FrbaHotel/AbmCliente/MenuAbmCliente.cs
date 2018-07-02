using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmCliente
{
    public partial class MenuAbmCliente : Form
    {
        public static ListadoClientes ListadoCli;
        public static AltaCliente AltaCli;
        public static BajaCliente BajaCli;
        public static ListadoClientesMod ListadoModificacionCli;
        public static Login.MenuFuncionalidades menuFuncionalidades;
        
        public MenuAbmCliente()
        {
            InitializeComponent();
        }

        private void listadoClientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListadoCli = new ListadoClientes();
            ListadoCli.Show();
        }

        private void altaCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            AltaCli = new AltaCliente();
            AltaCli.Show();
        }

        private void bajaCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            BajaCli = new BajaCliente();
            BajaCli.Show();
        }

        private void modificacionCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListadoModificacionCli = new ListadoClientesMod();
            ListadoModificacionCli.Show();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            menuFuncionalidades = new Login.MenuFuncionalidades();
            menuFuncionalidades.Show();
            this.Close();
        }

    }
}

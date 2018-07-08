using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmRegimen
{
    public partial class MenuAbmRegimen : Form
    {
        public static Login.MenuFuncionalidades menuFuncionalidades;
        
        public MenuAbmRegimen()
        {
            InitializeComponent();
        }

        private void listadoRegimenes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A fin de simplificar el TP, se determina que este abm no debe ser desarrollado");
        }

        private void altaRegimen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A fin de simplificar el TP, se determina que este abm no debe ser desarrollado");
        }

        private void bajaRegimen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A fin de simplificar el TP, se determina que este abm no debe ser desarrollado");
        }

        private void modificacionRegimen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A fin de simplificar el TP, se determina que este abm no debe ser desarrollado");
        }

        private void atras_Click(object sender, EventArgs e)
        {
            menuFuncionalidades = new Login.MenuFuncionalidades();
            menuFuncionalidades.Show();
            this.Close();
        }
    }
}

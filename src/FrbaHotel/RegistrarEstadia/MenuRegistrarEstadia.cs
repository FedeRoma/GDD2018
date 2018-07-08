using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.RegistrarEstadia
{
    public partial class MenuRegistrarEstadia : Form
    {
        public static CheckIn chkIn;
        public static CheckOut chkOut;
        public static Login.MenuFuncionalidades menuFuncionalidades;

        public MenuRegistrarEstadia()
        {
            InitializeComponent();
        }

        private void checkIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            chkIn = new CheckIn();
            chkIn.Show();
        }

        private void checkOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            chkOut = new CheckOut();
            chkOut.Show();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            menuFuncionalidades = new Login.MenuFuncionalidades();
            menuFuncionalidades.Show();
            this.Close();
        }

    }
}

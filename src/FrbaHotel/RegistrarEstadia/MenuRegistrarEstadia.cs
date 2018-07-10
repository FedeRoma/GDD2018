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
        public static CheckIn ChkIn;
        public static CheckOut ChkOut;
        public static Login.MenuFuncionalidades MenuFuncionalidades;

        public MenuRegistrarEstadia()
        {
            InitializeComponent();
        }

        private void checkIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChkIn = new CheckIn();
            ChkIn.Show();
        }

        private void checkOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChkOut = new CheckOut();
            ChkOut.Show();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            MenuFuncionalidades = new Login.MenuFuncionalidades();
            MenuFuncionalidades.Show();
            this.Close();
        }

    }
}

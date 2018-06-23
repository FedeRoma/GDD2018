using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Login
{
    public partial class Login : Form
    {
        private int cantIntentos = 0;
        public Login()
        {
            InitializeComponent();
            nombreUsuario.Clear();
            password.Clear();
            nombreUsuario.Focus();
            cantIntentos = 0;
            SqlDataReader resultado;
            // RESERVAS ANTERIORES

        }

        private void cancelar_Click(object sender, EventArgs e)
        {

        }
    }
}

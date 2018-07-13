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

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class MenuModificacionReserva : Form
    {
        private SqlDataReader qry;
        public static Login.Login login;
        public static Login.MenuFuncionalidades menuFuncionalidades;

        public MenuModificacionReserva()
        {
            InitializeComponent();
        }

        private void reserva_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(reserva.Text))
            {
                MessageBox.Show("Debe ingresar un número de reserva para continuar");
                return;
            }

            qry = Index.BD.consultaGetPuntero("select res_fecha from EN_CASA_ANDABA.Reservas where res_id = " + reserva.Text);
            if (qry.Read())
            {
                if ((qry.GetDateTime(0).Date >= DateTime.Today))
                {
                    qry.Close();
                    ModificacionReserva modificacionReserva = new ModificacionReserva(reserva.Text);
                    modificacionReserva.Show();
                    this.Close();
                }
                else
                {
                    qry.Close();
                    MessageBox.Show("Ya no es posible modificar la reserva");
                    return;
                }
            }
            else
            {
                qry.Close();
                MessageBox.Show("Número de reserva Inválido");
                return;
            }
            
        }

        private void atras_Click(object sender, EventArgs e)
        {
            if (Index.rol == "Guest")
            {
                login = new Login.Login();
                login.Show();
            }
            else
            {
                menuFuncionalidades = new Login.MenuFuncionalidades();
                menuFuncionalidades.Show();
            }
            this.Close();
        }

    }
}
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
    public partial class CambiarContrasenia : Form
    {
        private SqlDataReader qry;
        public static Login login;
        public static MenuFuncionalidades menuFuncionalidades;
        private string usuario = "";

        public CambiarContrasenia()
        {
            InitializeComponent();
        }

        private void CambiarContrasenia_Load(object sender, EventArgs e)
        {
            qry = Index.BD.consultaGetPuntero("select distinct usu_username from EN_CASA_ANDABA.Usuarios where usu_id = " + Index.usuarioID.ToString());
            qry.Read();
            usuario = qry.GetString(0);
            usuarioActivo.Items.Add(qry.GetSqlString(0));
            qry.Close();
            contraseniaActual.Focus();
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(contraseniaActual.Text))
            {
                MessageBox.Show("#error: debe ingresar su clave actual para continuar");
                contraseniaActual.Focus();
                return;
            }
            if (string.IsNullOrEmpty(contraseniaNueva.Text))
            {
                MessageBox.Show("#error: debe ingresar su nueva clave para continuar");
                contraseniaNueva.Focus();
                return;
            }
            qry = Index.BD.consultaGetPuntero("select usu_id from EN_CASA_ANDABA.Usuarios where usu_username = '" + usuario + "' and usu_password = hashbytes('SHA2_256', '" + contraseniaActual.Text + "')");
            if (qry.Read() == true)
            {
                int id = qry.GetInt32(0);
                qry.Close();

                qry = Index.BD.consultaGetPuntero("update EN_CASA_ANDABA.Usuarios set usu_password = hashbytes('SHA2_256', '" + contraseniaNueva.Text + "') where usu_id = " + id);
                qry.Read();
                MessageBox.Show("La nueva contraseña se ha guardado con éxito");
                qry.Close();

                login = new Login();
                login.Show();
                this.Close();
            }
            else
            {
                qry.Close();
                MessageBox.Show("#error: clave incorrecta");
                contraseniaActual.Clear();
                contraseniaNueva.Clear();
                contraseniaActual.Focus();
            }

        }
        
        private void atras_Click(object sender, EventArgs e)
        {
            menuFuncionalidades = new MenuFuncionalidades();
            menuFuncionalidades.Show();
            this.Close();
        }

    }
}

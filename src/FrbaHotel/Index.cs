using FrbaHotel.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class Index : Form
    {
        public static MenuFuncionalidades funcionalidadesUsuarios;
        public static Login.Login login;
        public static SQLConnector BD = new SQLConnector();
        private SqlDataReader qry;
        public static int usuarioId = 0;
       
        public Index()
        {
            InitializeComponent();
        }

        private void iniciarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            login = new Login.Login();
            login.Show();
        }

        private void invitado_Click(object sender, EventArgs e)
        {
            qry = Index.BD.consultaGetPuntero("select usu_id FROM EN_CASA_ANDABA.Usuarios where usu_username = 'Guest'");
            qry.Read();
            usuarioId = qry.GetInt32(0);
            qry.Close();
            qry = Index.BD.consultaGetPuntero("select distinct R.rol_nombre from EN_CASA_ANDABA.Roles_Usuarios RU, EN_CASA_ANDABA.Roles R where RU.ryu_rol_id = R.rol_id and RU.ryu_usu_id = " + usuarioId.ToString() + " and R.rol_estado = 1");
            if (qry.Read() == true)
            {
                Login.Login.rol = "Guest";
                Login.Login.hotel = "";
                Login.Login.funcionalidadesUsuarios = new MenuFuncionalidades();
                Login.Login.funcionalidadesUsuarios.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Rol de Guest inhabilitado");
            }
            qry.Close();
        }

    }
}
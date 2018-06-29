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
        public static SQLConnector BD = new SQLConnector();
        private SqlDataReader qry;
        public static Login.Login login;
        public static RolesUsuario rolesUsuario;
        public static int usuarioID = 0;
        public static string rol = "";
        public static string hotel = "";
       
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
            usuarioID = qry.GetInt32(0);
            qry.Close();

            qry = Index.BD.consultaGetPuntero("select distinct R.rol_nombre from EN_CASA_ANDABA.Roles_Usuarios RU, EN_CASA_ANDABA.Roles R where RU.ryu_rol_id = R.rol_id and RU.ryu_usu_id = " + usuarioID.ToString() + " and R.rol_estado = 1");
            if (qry.Read() == true)
            {
                rol = qry.GetString(0);
                qry.Close();
                this.Hide();
                rolesUsuario = new RolesUsuario();
                rolesUsuario.Show();            
            }
            else
            {
                MessageBox.Show("#error: Rol de Guest inhabilitado");
            }
        }

    }
}
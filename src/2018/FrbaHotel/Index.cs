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
        public static FuncionalidadesUsuarios funcionalidadesUsuarios;
        public static Login.Login login;
        public static SQLConnector BD = new SQLConnector();
        public static int usuarioId;
        public static int rol = 0;
       
        public Index()
        {
            InitializeComponent();
            usuarioId = 0;
        }

        private void iniciarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            login = new Login.Login();
            login.Show();
        }

        private void invitado_Click(object sender, EventArgs e)
        {
            SqlDataReader resultado;
            resultado = Index.BD.comando("SELECT usu_id FROM EN_CASA_ANDABA.Usuarios where usu_username = 'Guest'");
            resultado.Read();
            usuarioId = resultado.GetInt32(0);
            resultado.Close();

            string consulta = "select ryu_rol_id from EN_CASA_ANDABA.Roles_Usuarios where ryu_usu_id = " + usuarioId + ";";
            
            resultado = Index.BD.comando(consulta);
            resultado.Read();
            FrbaHotel.Index.rol = resultado.GetInt32(0);
            resultado.Close();
            if (rol > 0)
            {
                funcionalidadesUsuarios = new FuncionalidadesUsuarios();
                funcionalidadesUsuarios.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Rol de Guest inhabilitado");
            }            
        }

    }
}
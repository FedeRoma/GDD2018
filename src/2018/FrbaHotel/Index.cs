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
        public static FuncionalidadesClientes funCli;
        public static Login.Login Login;
        public static SQLConnector BD = new SQLConnector();
        public static decimal usuarioId;
        public static string rol = "";
        public Index()
        {
            InitializeComponent();
            usuarioId = 0;
        }

        private void iniciarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login = new Login.Login();
            Login.Show();
        }

        private void invitado_Click(object sender, EventArgs e)
        {
            SqlDataReader resultado;
            resultado = Index.BD.comando("SELECT usu_id FROM EN_CASA_ANDABA.Usuarios where usu_username = 'Guest'");
            if (resultado.Read())
            {
                usuarioId = resultado.GetDecimal(0);
            }
            resultado.Close();
            string consulta = "select distinct Rol.rol_nombre from EN_CASA_ANDABA.Roles Rol where Rol.rol_estado = 1 = " + usuarioId.ToString() + ";";
            resultado = Index.BD.comando(consulta);
            resultado.Read();
            FrbaHotel.Index.rol = resultado.GetString(0);
            resultado.Close();
            if (rol != "")
            {
                funCli = new FuncionalidadesClientes();
                funCli.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Rol de Guest inhabilitado");
            }            
        }
    }
}

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
        public static Index index;
        public static RolesUsuario rolesUsuario;
        public static MenuFuncionalidades funcionalidadesUsuarios;
        private int cantIntentos = 0;
        public static int usuarioId;
        public static string rol = "";
        public static string hotel = "";

        public Login()
        {
            InitializeComponent();
            nombreUsuario.Clear();
            password.Clear();
            nombreUsuario.Focus();
            usuarioId = 0;
        }

        private void ingresar_Click(object sender, EventArgs e)
        {
            cantIntentos++;
            SqlDataReader qry;
            qry = Index.BD.consultaGetPuntero("select usu_estado, usu_id from EN_CASA_ANDABA.Usuarios where usu_username = '"+ nombreUsuario.Text +"' and usu_password = hashbytes('SHA2_256', '"+ password.Text +"')");
            
            if (nombreUsuario.Text == "guest" || nombreUsuario.Text == "Guest")
            {
                MessageBox.Show("Continuando como invitado...");
                funcionalidadesUsuarios = new MenuFuncionalidades();
                funcionalidadesUsuarios.Show();
                this.Hide();
            }
            else
            {
                if (qry.Read() == true && cantIntentos <= 4)
                {
                    if (qry.GetBoolean(0) == true)
                    {
                        usuarioId = qry.GetInt32(1);
                        cantIntentos = 0;
                        qry.Close();

                        string consulta = "select count (*) ryu_rol_id from EN_CASA_ANDABA.Roles_Usuarios where ryu_usu_id = " + usuarioId + "";
                        qry = Index.BD.consultaGetPuntero(consulta);
                        qry.Read();
                        int cantRoles = qry.GetInt32(0);
                        qry.Close();

                        if (cantRoles > 1)
                        {
                            this.Hide();
                            rolesUsuario = new RolesUsuario();
                            rolesUsuario.Show();
                        }
                        if (cantRoles == 1)
                        {
                            consulta = "select rol_nombre from EN_CASA_ANDABA.Roles where rol_id = (select ryu_rol_id from EN_CASA_ANDABA.Roles_Usuarios where ryu_usu_id = " + usuarioId + ")";
                            qry = Index.BD.consultaGetPuntero(consulta);
                            qry.Read();
                            Login.rol = qry.GetString(0);
                            qry.Close();
                            this.Hide();
                            RolesUsuario rolesUsuario = new RolesUsuario();
                            rolesUsuario.Show();
                        }
                        else
                        {
                            MessageBox.Show("#error: El usuario seleccionado no tiene ningún Rol asignado");
                            nombreUsuario.Clear();
                            password.Clear();
                            nombreUsuario.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("#error: El usuario seleccionado se encuentra inhabilitado");
                        nombreUsuario.Clear();
                        password.Clear();
                        nombreUsuario.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("#error: Nombre de Usuario o Contraseña incorrectos");
                    nombreUsuario.Clear();
                    password.Clear();
                    nombreUsuario.Focus();
                    if (cantIntentos > 3)
                    {
                        MessageBox.Show("#error: Ha sobrepasado la cantidad de intentos fallidos");
                        this.Hide();
                        index = new Index();
                        index.Show();
                    }
                }
                qry.Close();
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            index = new Index();
            index.Show();
        }

    }
}

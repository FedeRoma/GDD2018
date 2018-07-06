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
        private SqlDataReader qry;
        public static Index index;
        public static RolesUsuario rolesUsuario;
        public static MenuFuncionalidades funcionalidadesUsuarios;
        private int cantIntentos = 0;

        public Login()
        {
            InitializeComponent();
            nombreUsuario.Clear();
            contrasenia.Clear();
            nombreUsuario.Focus();
            Index.usuarioID = 0;
            Index.rol = "";
            Index.hotel = "";
        }

        private void ingresar_Click(object sender, EventArgs e)
        {
            cantIntentos++;

            qry = Index.BD.consultaGetPuntero("select usu_estado, usu_id from EN_CASA_ANDABA.Usuarios where usu_username = '"+ nombreUsuario.Text +"' and usu_password = hashbytes('SHA2_256', '"+ contrasenia.Text +"')");
           
            if (nombreUsuario.Text == "guest" || nombreUsuario.Text == "Guest")
            {
                qry.Close();
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
                        Index.usuarioID = qry.GetInt32(1);
                        cantIntentos = 0;
                        qry.Close();

                        qry = Index.BD.consultaGetPuntero("select count (*) ryu_rol_id from EN_CASA_ANDABA.Roles_Usuarios where ryu_usu_id = " + Index.usuarioID.ToString());
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
                            Index.rol = Index.BD.consultaGetString("select rol_nombre from EN_CASA_ANDABA.Roles where rol_id = (select ryu_rol_id from EN_CASA_ANDABA.Roles_Usuarios where ryu_usu_id = " + Index.usuarioID.ToString() + ")");
                            this.Hide();
                            rolesUsuario = new RolesUsuario();
                            rolesUsuario.Show();
                        }
                        else
                        {
                            MessageBox.Show("#error: El usuario seleccionado no tiene ningún Rol asignado");
                            nombreUsuario.Clear();
                            contrasenia.Clear();
                            nombreUsuario.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("#error: El usuario seleccionado se encuentra inhabilitado");
                        nombreUsuario.Clear();
                        contrasenia.Clear();
                        nombreUsuario.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("#error: Nombre de Usuario o Contraseña incorrectos");
                    nombreUsuario.Clear();
                    contrasenia.Clear();
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

        private void atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            index = new Index();
            index.Show();
        }

    }
}

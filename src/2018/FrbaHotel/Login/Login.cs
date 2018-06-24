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
        public static FuncionalidadesUsuarios funcionalidadesUsuarios;
        private int cantIntentos = 0;
        public static int usuarioId;
        public static int rol = 0;
        public static Index index;

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
            SqlDataReader resultado;
            resultado = Index.BD.comando("SELECT usu_estado, usu_id FROM EN_CASA_ANDABA.Usuarios where usu_username = '" + nombreUsuario.Text + "'and usu_password = '" + getHash(password.Text) + "'");
            if (nombreUsuario.Text == "guest" || nombreUsuario.Text == "Guest")
            {
                MessageBox.Show("Continuando como Invitado...");
                funcionalidadesUsuarios = new FuncionalidadesUsuarios();
                funcionalidadesUsuarios.Show();
                this.Hide();
            }
            else if (resultado.Read() == true && cantIntentos <= 4)
            {
                if (resultado.GetBoolean(0) == true)
                {
                    string mensaje = "BIENVENIDO" + nombreUsuario.Text;
                    MessageBox.Show(mensaje);
                    usuarioId = resultado.GetInt32(1);
                    cantIntentos = 0;
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
                    if (rol == 1)
                    {
                        // #Issue01
                    }
                    else
                    {
                        MessageBox.Show("Error: El usuario seleccionado no tiene ningún Rol asignado");
                        nombreUsuario.Clear();
                        password.Clear();
                        nombreUsuario.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Error: El usuario seleccionado se encuentra inhabilitado");
                    nombreUsuario.Clear();
                    password.Clear();
                    nombreUsuario.Focus();
                }
            }
            else
            {
                MessageBox.Show("Error: Datos incorrectos");
                nombreUsuario.Clear();
                password.Clear();
                nombreUsuario.Focus();
                if (cantIntentos > 3)
                {
                    MessageBox.Show("Error: Ha sobrepasado la cantidad de intentos fallidos");
                    this.Hide();
                    index = new Index();
                    index.Show();
                }
            }
            resultado.Close();

        }

        public static string getHash(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);

            System.Security.Cryptography.SHA256Managed sha256hashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256hashstring.ComputeHash(bytes);
            string hashstring = string.Empty;
            foreach (byte x in hash)
            {
                hashstring += String.Format("{0:x2}", x);
            }
            return hashstring;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            index = new Index();
            index.Show();
        }

    }
}

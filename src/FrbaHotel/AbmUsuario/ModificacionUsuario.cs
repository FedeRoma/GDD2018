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

namespace FrbaHotel.AbmUsuario
{
    public partial class ModificacionUsuario : Form
    {
        private SqlDataReader qry;
        public static ListadoUsuarios ListadoUsu;
        bool inconsistencias = false;
        string usernameUsuario;
        int usuId = 0;
        String calle = "";
        int calleNro = 0;
        string update = "";


        private class TipoDocumento
        {
            public string Nombre;
            public int Valor;
            public TipoDocumento(int valor, string nombre)
            {
                Nombre = nombre;
                Valor = valor;
            }
            public override string ToString()
            {
                return Nombre;
            }
        }

        private class Rol
        {
            public string Nombre;
            public int Valor;
            public Rol(int valor, string nombre)
            {
                Nombre = nombre;
                Valor = valor;
            }
            public override string ToString()
            {
                return Nombre;
            }
        }

        public ModificacionUsuario(string usernameU,
                                    string nombreU,
                                    string apellidoU,
                                    string emailU,
                                    string telefonoU,
                                    string tipoDocU,
                                    string numeroDocU,
                                    string fechaNacU,                                    
                                    string direccionU,
                                    string rolU,
                                    string estadoU)
        {
            InitializeComponent();
            usernameUsuario = usernameU;
            nroDocumento.Text = numeroDocU;
            tipoDocumento.Text = tipoDocU;
            qry = Index.BD.consultaGetPuntero("select distinct doc_id, doc_desc from EN_CASA_ANDABA.Documentos");
            while (qry.Read())
            {
                tipoDocumento.Items.Add(new TipoDocumento(qry.GetInt32(0), qry.GetString(1)));
            }
            qry.Close();

            rol.Text = rolU;

            qry = Index.BD.consultaGetPuntero("select distinct rol_id, rol_nombre from EN_CASA_ANDABA.Roles where rol_estado = 1");
            while (qry.Read())
            {
                // solo se pueden dar de Alta "Recepcionistas" y "Administradores"
                if ((qry.GetString(1) != "Administrador General") && (qry.GetString(1) != "Guest"))
                {
                    rol.Items.Add(new Rol(qry.GetInt32(0), qry.GetString(1)));
                }
            }
            qry.Close();
            
            nombre.Text = nombreU;
            apellido.Text = apellidoU;
            eMail.Text = emailU;
            telefono.Text = telefonoU;
            nombreUsuario.Text = usernameU;
            fechaNacimiento.Text = fechaNacU;
            direccion.Text = direccionU;
            if (estadoU == "True")
            {
                estado.Checked = true;
            }
           
        }

        private void numeroDocumento_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void calleNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private bool checkCampos()
        {
            bool inconsistencias = false;
            string alerta = "";

            if (string.IsNullOrEmpty(tipoDocumento.Text))
            {
                alerta = alerta + "Debe ingresar un tipo de documento válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(nroDocumento.Text))
            {
                alerta = alerta + "Debe ingresar un número de documento válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(nombre.Text))
            {
                alerta = alerta + "Debe ingresar un nombre válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(apellido.Text))
            {
                alerta = alerta + "Debe ingresar un apellido válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(eMail.Text))
            {
                alerta = alerta + "Debe ingresar un eMail válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(telefono.Text))
            {
                alerta = alerta + "Debe ingresar un teléfono válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(rol.Text))
            {
                alerta = alerta + "Debe seleccionar al menos un rol\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(nombreUsuario.Text))
            {
                alerta = alerta + "Debe ingresar un nombre de usuario válido\n";
                inconsistencias = true;
            }
            /*if (string.IsNullOrEmpty(clave.Text))
            {
                alerta = alerta + "Debe ingresar una contraseña válida\n";
                inconsistencias = true;
            }
            if (clave.Text != confirmacionClave.Text)
            {
                alerta = alerta + "Debe confirmar la contraseña correctamente\n";
                inconsistencias = true;
            }*/
            if (string.IsNullOrEmpty(direccion.Text))
            {
                alerta = alerta + "Debe ingresar una dirección válida\n";
                inconsistencias = true;
            }

            if (string.IsNullOrEmpty(fechaNacimiento.Text))
            {
                alerta = alerta + "Debe ingresar una fecha válida\n";
                inconsistencias = true;
            }

            DateTime fechaNac, hoy;
            fechaNac = Convert.ToDateTime(fechaNacimiento.Value);
            hoy = DateTime.Today;

            if (DateTime.Compare(fechaNac, hoy) >= 0)
            {
                alerta = alerta + "Debe ingresar una fecha de nacimiento válida\n";
                inconsistencias = true;
            }

            if (inconsistencias)
            {
                MessageBox.Show(alerta);
            }
            return inconsistencias;
        }

        private string updateString(string campo)
        {
            if (string.IsNullOrEmpty(campo))
            {
                update = update + "null,";
            }
            else
            {
                update = update + "'" + campo + "',";
            }
            return update;
        }

        private string updateNro(string campo)
        {
            if (string.IsNullOrEmpty(campo))
            {
                update = update + "null,";
            }
            else
            {
                update = update + "" + campo + ",";
            }
            return update;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (!checkCampos())
            {

                qry = Index.BD.consultaGetPuntero("select usu_id from EN_CASA_ANDABA.Usuarios where usu_username = '" + usernameUsuario + "'");
                if (qry.Read())
                {

                    usuId = qry.GetInt32(0);
                    
                    
                }
                qry.Close();

                qry = Index.BD.consultaGetPuntero("select hot_calle, hot_calle_nro from EN_CASA_ANDABA.Hoteles where hot_id = '" + Index.hotel + "'");
                if (qry.Read())
                {

                    calle = qry.GetString(0);
                    calleNro = qry.GetInt32(1);
                }
                qry.Close();
                /*
                @userId int,
		        @rol varchar(50), 
		        @hotelCalle varchar(50), 
		        @hotelNumero int, 
		        @username varchar(50), 
		        @nombre varchar(50),
		        @apellido varchar(50), 
		        @email varchar(50), 
		        @tel varchar(50), 
		        @tipoDocumento varchar(50), 
		        @nroDocumento bigint,
		        @fechaNacimiento date, 
		        @direccion varchar(50), 
		        @estado bit
                 * */
                update = "exec EN_CASA_ANDABA.modificacionUsuario ";
                update = updateNro(usuId.ToString());
                update = updateString(rol.Text);
                update = updateString(calle);
                update = updateString(calleNro.ToString());
                update = updateString(nombreUsuario.Text);
                //update = updateString(usuPass);
                update = updateString(nombre.Text);
                update = updateString(apellido.Text);
                update = updateString(eMail.Text);
                update = updateString(telefono.Text);
                update = updateString(tipoDocumento.Text);
                update = updateNro(nroDocumento.Text);
                DateTime fecha;
                fecha = Convert.ToDateTime(fechaNacimiento.Value);
                update = updateString(fecha.Date.ToString("yyyyMMdd HH:mm:ss"));
                update = updateString(direccion.Text);
              
                if (estado.Text == "True")
                {
                    update = updateNro("1");
                }
                else
                {
                    update = updateNro("0");
                }

                update = update.Remove(update.Length - 1);

                bool insertOk = false;

                qry = Index.BD.consultaGetPuntero(update);
                if (qry.Read())
                {
                    insertOk = qry.GetBoolean(0);
                }
                qry.Close();

                if (insertOk)
                {
                    MessageBox.Show("Usuario modificado con éxito");
                    atras_Click(null, null);
                }
                else
                {
                    MessageBox.Show("#error: no se ha podido realizar la operación");
                }
            }
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListadoUsu = new ListadoUsuarios();
            ListadoUsu.Show();
        }



    }
}

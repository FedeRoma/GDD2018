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
    public partial class AltaUsuario : Form
    {

        private SqlDataReader qry;
        public static MenuAbmUsuario AbmUsu;
        String calle = "";
        int calleNro = 0;
        string insert = "";

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

        private class Hotel
        {
            public string Calle;
            public int CalleNro;
            public Hotel(string calle, int calleNro)
            {
                Calle = calle;
                CalleNro = calleNro;
            }
            public override string ToString()
            {
                return Calle;
            }
        }
        
        public AltaUsuario()
        {
            InitializeComponent();
            qry = Index.BD.consultaGetPuntero("select distinct doc_id, doc_desc from EN_CASA_ANDABA.Documentos");
            while (qry.Read())
            {
                tipoDocumento.Items.Add(new TipoDocumento(qry.GetInt32(0), qry.GetString(1)));
            }
            qry.Close();

            qry = Index.BD.consultaGetPuntero("select distinct rol_id, rol_nombre from EN_CASA_ANDABA.Roles where rol_estado = 1");
            while (qry.Read())
            {
                // solo se pueden dar de Alta "Recepcionistas" y "Administradores"
                if ((qry.GetString(1) != "Administrador General") || (qry.GetString(1) != "Guest"))
                {
                    rol.Items.Add(new Rol(qry.GetInt32(0), qry.GetString(1)));
                }  
            }
            qry.Close();

            fechaNacimiento.Value = DateTime.Today;
        }

        private void numeroDocumento_Keypress(object sender, KeyPressEventArgs e)
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
            else
            {
                qry = Index.BD.consultaGetPuntero("select * from EN_CASA_ANDABA.Usuarios where usu_username = '" + nombreUsuario.Text + "'");
                if (qry.Read())
                {
                    alerta = alerta + "Nombre de usuario ya registrado\n";
                    inconsistencias = true;
                }
                qry.Close();
            }


            if (string.IsNullOrEmpty(clave.Text))
            {
                alerta = alerta + "Debe ingresar una contraseña válida\n";
                inconsistencias = true;
            }
            if (clave.Text != confirmacionClave.Text)
            {
                alerta = alerta + "Debe confirmar la contraseña correctamente\n";
                inconsistencias = true;
            }
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

        private string insertString(string campo)
        {
            if (string.IsNullOrEmpty(campo))
            {
                insert = insert + "null,";
            }
            else
            {
                insert = insert + "'" + campo + "',";
            }
            return insert;
        }
        private string insertNro(string campo)
        {
            if (string.IsNullOrEmpty(campo))
            {
                insert = insert + "null,";
            }
            else
            {
                insert = insert + "" + campo + ",";
            }
            return insert;
        }
        private string insertPass(string campo)
        {
            insert = insert + "hashbytes('SHA2_256', '" + campo + "'), ";
            return insert;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (!checkCampos())
            {
                qry = Index.BD.consultaGetPuntero("select hot_calle, hot_calle_nro from EN_CASA_ANDABA.Hoteles where hot_id = '" + Index.hotel + "'");
                if (qry.Read())
                {

                    calle = qry.GetString(0);
                    calleNro = qry.GetInt32(1);
                }
                qry.Close();

                insert = "exec EN_CASA_ANDABA.altaUsuario ";
                insert = insertNro(rol.Text);
                insert = insertString(calle);
                insert = insertString(calleNro.ToString());
                insert = insertString(nombreUsuario.Text);
                insert = insertPass(clave.Text);
                insert = insertString(nombre.Text);
                insert = insertString(apellido.Text);
                insert = insertString(eMail.Text);
                insert = insertString(telefono.Text);
                insert = insertString(tipoDocumento.Text);
                insert = insertString(nroDocumento.Text);
                DateTime fecha;
                fecha = Convert.ToDateTime(fechaNacimiento.Value);
                insert = insertString(fecha.Date.ToString("yyyyMMdd HH:mm:ss"));
                insert = insertString(direccion.Text);
                insert = insert.Remove(insert.Length - 1);

                bool insertOk = false;

                qry = Index.BD.consultaGetPuntero(insert);
                if (qry.Read())
                {
                    insertOk = qry.GetBoolean(0);
                }
                qry.Close();

                if (insertOk)
                {
                    MessageBox.Show("Usuario dado de alta");
                }
                else
                {
                    MessageBox.Show("#error: no se ha podido realizar la operación");
                }
                limpiar.PerformClick();
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            tipoDocumento.ResetText();
            nroDocumento.ResetText();
            rol.ResetText();
            nombre.Text = string.Empty;
            nombreUsuario.Text = string.Empty;
            apellido.Text = string.Empty;
            eMail.Text = string.Empty;
            clave.Text = string.Empty;
            confirmacionClave.Text = string.Empty;
            fechaNacimiento.ResetText();
            telefono.Text = string.Empty;
            direccion.Text = string.Empty;
            tipoDocumento.Focus();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmUsu = new MenuAbmUsuario();
            AbmUsu.Show();
        }

    }
}

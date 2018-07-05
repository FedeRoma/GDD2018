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

namespace FrbaHotel.AbmCliente
{
    public partial class ModificacionCliente : Form
    {
        private SqlDataReader qry;
        public static ListadoClientes ListadoCli;
        bool inconsistencias = false;
        string eMailOriginal;
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

        public ModificacionCliente(string nombreCli, string apellidoCli, string docTipoCli, 
                                    string docNumeroCli, string eMailCli, string telefonoCli,
                                    string nacionalidadCli, string fecha_nacCli, string estadoCli, 
                                    string calleCli, string calleNumeroCli, string pisoCli, 
                                    string deptoCli, string localidadCli, string paisCli)
        {
            InitializeComponent();

            qry = Index.BD.consultaGetPuntero("select distinct doc_id, doc_desc from EN_CASA_ANDABA.Documentos");
            while (qry.Read())
            {
                tipoDocumento.Items.Add(new TipoDocumento(qry.GetInt32(0), qry.GetString(1)));
            }
            qry.Close();

            tipoDocumento.Text = docTipoCli;
            nroDocumento.Text = docNumeroCli;
            nombre.Text = nombreCli;
            apellido.Text = apellidoCli;
            eMail.Text = eMailCli;
            telefono.Text = telefonoCli;
            nacionalidad.Text = nacionalidadCli;
            fechaNacimiento.Value = Convert.ToDateTime(fecha_nacCli);
            if (estadoCli == "True")
            {
                estado.Checked = true;
            }
            calle.Text = calleCli;
            calleNumero.Text = calleNumeroCli;
            piso.Text = pisoCli;
            departamento.Text = deptoCli;
            localidad.Text = localidadCli;
            pais.Text = paisCli;

            eMailOriginal = eMailCli;
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
            inconsistencias = false;
            string alerta = "";

            if (string.IsNullOrEmpty(tipoDocumento.Text))
            {
                alerta = alerta + "Debe ingresar un Tipo de Documento válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(nroDocumento.Text))
            {
                alerta = alerta + "Debe ingresar un Número de Documento válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(nombre.Text))
            {
                alerta = alerta + "Debe ingresar un Nombre válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(apellido.Text))
            {
                alerta = alerta + "Debe ingresar un Apellido válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(eMail.Text))
            {
                alerta = alerta + "Debe ingresar un eMail válido\n";
                inconsistencias = true;
            }
            else
            {
                qry = Index.BD.consultaGetPuntero("select * from EN_CASA_ANDABA.Clientes where cli_mail = '" + eMail.Text + "'");
                if (qry.Read())
                {
                    if (!(eMail.Text == eMailOriginal))
                    {
                        alerta = alerta + "eMail ya registrado\n";
                        inconsistencias = true;
                    }
                }
                qry.Close();
            }
            if (string.IsNullOrEmpty(nacionalidad.Text))
            {
                alerta = alerta + "Debe ingresar una Nacionalidad válida\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(calle.Text) || string.IsNullOrEmpty(calleNumero.Text))
            {
                alerta = alerta + "Debe ingresar una Dirección válida\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(telefono.Text))
            {
                alerta = alerta + "Debe ingresar un Teléfono válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(localidad.Text) || string.IsNullOrEmpty(pais.Text))
            {
                alerta = alerta + "Debe ingresar una Localidad y/o Pais válidos\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(fechaNacimiento.Text))
            {
                alerta = alerta + "Debe ingresar un nombre válido\n";
                inconsistencias = true;
            }

            DateTime fechaNac, hoy;
            fechaNac = Convert.ToDateTime(fechaNacimiento.Value);
            hoy = DateTime.Today;

            if (DateTime.Compare(fechaNac, hoy) >= 0)
            {
                alerta = alerta + "Debe ingresar una Fecha de Nacimiento válida\n";
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
                update = "exec EN_CASA_ANDABA.modificacionCliente ";
                update = updateNro(nroDocumento.Text);
                update = updateString(nombre.Text);
                update = updateString(apellido.Text);
                update = updateString(eMail.Text);
                update = updateString(nacionalidad.Text);

                DateTime fecha;
                fecha = Convert.ToDateTime(fechaNacimiento.Value);
                update = updateString(fecha.Date.ToString("yyyyMMdd HH:mm:ss"));

                update = updateString(calle.Text);
                update = updateNro(calleNumero.Text);
                update = updateString(piso.Text);
                update = updateString(departamento.Text);
                update = updateString(localidad.Text);
                update = updateString(pais.Text);
                update = updateString(telefono.Text);
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
                    MessageBox.Show("Cliente modificado con éxito");
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
            ListadoCli = new ListadoClientes();
            ListadoCli.Show();
        }
    }
}

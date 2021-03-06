﻿using System;
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
    public partial class AltaCliente : Form
    {
        private SqlDataReader qry;
        public static MenuAbmCliente AbmCli;
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

        public AltaCliente()
        {
            InitializeComponent();

            qry = Index.BD.consultaGetPuntero("select distinct doc_id, doc_desc from EN_CASA_ANDABA.Documentos");
            while (qry.Read())
            {
                tipoDocumento.Items.Add(new TipoDocumento(qry.GetInt32(0), qry.GetString(1)));
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

            if ((string.IsNullOrEmpty(tipoDocumento.Text) || string.IsNullOrEmpty(nroDocumento.Text)))
            {
                alerta = alerta + "Debe ingresar un documento válido\n";
                inconsistencias = true;
            }
            else
            {
                qry = Index.BD.consultaGetPuntero("select * from EN_CASA_ANDABA.Clientes, EN_CASA_ANDABA.Documentos where cli_doc_id = doc_id and doc_desc = '" + tipoDocumento.Text + "' and cli_documento = " + nroDocumento.Text);
                if (qry.Read())
                {
                    alerta = alerta + "Tipo y nro de documento ya registrado\n";
                    inconsistencias = true;
                }
                qry.Close();
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
            else
            {     
                qry = Index.BD.consultaGetPuntero("select * from EN_CASA_ANDABA.Clientes where cli_mail = '" + eMail.Text + "'");
                if (qry.Read())
                {
                    alerta = alerta + "eMail ya registrado\n";
                    inconsistencias = true;
                }
                qry.Close();
            }
            if (string.IsNullOrEmpty(nacionalidad.Text))
            {
                alerta = alerta + "Debe ingresar una nacionalidad válida\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(calle.Text) || string.IsNullOrEmpty(calleNumero.Text))
            {
                alerta = alerta + "Debe ingresar una dirección válida\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(telefono.Text))
            {
                alerta = alerta + "Debe ingresar un teléfono válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(localidad.Text) || string.IsNullOrEmpty(pais.Text))
            {
                alerta = alerta + "Debe ingresar una localidad y/o pais válidos\n";
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

        private void guardar_Click(object sender, EventArgs e)
        {
            if (!checkCampos())
            {
                insert = "exec EN_CASA_ANDABA.altaCliente ";
                insert = insertNro(nroDocumento.Text);
                insert = insertString(tipoDocumento.Text);
                insert = insertString(nombre.Text);
                insert = insertString(apellido.Text);
                insert = insertString(eMail.Text);
                insert = insertString(nacionalidad.Text);

                DateTime fecha;
                fecha = Convert.ToDateTime(fechaNacimiento.Value);
                insert = insertString(fecha.Date.ToString("yyyyMMdd HH:mm:ss"));

                insert = insertString(calle.Text);
                insert = insertNro(calleNumero.Text);
                insert = insertString(piso.Text);
                insert = insertString(departamento.Text);
                insert = insertString(localidad.Text);
                insert = insertString(pais.Text);
                insert = insertString(telefono.Text);

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
                    MessageBox.Show("Cliente dado de alta");
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
            nombre.Text = string.Empty;
            apellido.Text = string.Empty;
            eMail.Text = string.Empty;
            nacionalidad.Text = string.Empty;
            fechaNacimiento.ResetText();
            calle.Text = string.Empty;
            calleNumero.Text = string.Empty;
            piso.Text = string.Empty;
            departamento.Text = string.Empty;
            telefono.Text = string.Empty;
            localidad.Text = string.Empty;
            pais.Text = string.Empty;
            tipoDocumento.Focus();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmCli = new MenuAbmCliente();
            AbmCli.Show();
        }

    }
}
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
    public partial class BajaCliente : Form
    {
        private SqlDataReader qry;
        public static MenuAbmCliente AbmCli;
        DataTable tablaClientes;

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

        public BajaCliente()
        {
            InitializeComponent();

            qry = Index.BD.consultaGetPuntero("select distinct doc_id, doc_desc from EN_CASA_ANDABA.Documentos");
            while (qry.Read())
            {
                tipoDocumento.Items.Add(new TipoDocumento(qry.GetInt32(0), qry.GetString(1)));
            }
            qry.Close();
        }

        private void BajaCliente_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn botonBaja = new DataGridViewButtonColumn();
            botonBaja.Name = "baja";
            listaClientes.Columns.Add(botonBaja);

            tablaClientes = Index.BD.consultaGetTabla("select C.cli_nombre NOMBRE, C.cli_apellido APELLIDO, D.doc_desc TIPO_DOCUMENTO, C.cli_documento NRO_DOCUMENTO, C.cli_mail EMAIL, C.cli_telefono TELEFONO, C.cli_nacionalidad NACIONALIDAD, C.cli_fecha_nac FECHA_DE_NACIMIENTO, C.cli_habilitado HABILITADO, C.cli_calle CALLE, C.cli_calle_nro NUMERO, C.cli_piso PISO, C.cli_depto DEPTO, C.cli_dir_localidad LOCALIDAD, C.cli_dir_pais PAIS from EN_CASA_ANDABA.Clientes C, EN_CASA_ANDABA.Documentos D where C.cli_doc_id = D.doc_id");
            BindingSource bindingSourceListaClientes = new BindingSource();
            bindingSourceListaClientes.DataSource = tablaClientes;
            listaClientes.DataSource = bindingSourceListaClientes;
        }

        private void listaClientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.listaClientes.Columns[e.ColumnIndex].Name == "baja" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonBaja = this.listaClientes.Rows[e.RowIndex].Cells["baja"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\cross-script.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);
                
                this.listaClientes.Rows[e.RowIndex].Height = icono.Height + 5;
                this.listaClientes.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }
        }

        private void listaClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listaClientes.Columns[e.ColumnIndex].Name == "baja")
            {
                if (listaClientes.CurrentRow.Cells[9].Value.ToString() == "False")
                {
                    MessageBox.Show("#error: el cliente seleccionado ya se encuentra deshabilitado");
                    return;
                }
                
                Int64 clienteDocumento = 0;
                Int32 clienteDocID = 0;
                string eMail = listaClientes.CurrentRow.Cells[5].Value.ToString();

                qry = Index.BD.consultaGetPuntero("select cli_documento, cli_doc_id from EN_CASA_ANDABA.Clientes where cli_mail = '" + eMail + "'");
                if (qry.Read())
                {
                    clienteDocumento = qry.GetInt64(0);
                    clienteDocID = qry.GetInt32(1);
                }
                qry.Close();

                if (MessageBox.Show("Esta seguro que quiere inhabilitar el cliente?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    qry = Index.BD.consultaGetPuntero("update EN_CASA_ANDABA.Clientes set cli_habilitado = 0 where cli_documento = " + clienteDocumento.ToString() + " and cli_doc_id = " + clienteDocID.ToString());
                }
                qry.Close();
                /*
                tablaClientes = Index.BD.consultaGetTabla("select C.cli_nombre, C.cli_apellido, D.doc_desc, C.cli_documento, C.cli_mail, C.cli_telefono, C.cli_nacionalidad, C.cli_fecha_nac, C.cli_habilitado, C.cli_calle, C.cli_calle_nro, C.cli_piso, C.cli_depto, C.cli_dir_localidad, C.cli_dir_pais from EN_CASA_ANDABA.Clientes C, EN_CASA_ANDABA.Documentos D where C.cli_doc_id = D.doc_id");
                BindingSource bindingSourceListaClientes = new BindingSource();
                bindingSourceListaClientes.DataSource = tablaClientes;
                listaClientes.DataSource = bindingSourceListaClientes;*/
            }
        }

        private void numeroDocumento_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private string esExactamente(string col, string clave)
        {
            if (!string.IsNullOrEmpty(clave))
            {
                return col + " = '" + clave + "' and ";
            }
            return "";
        }
        private string esAproximadamente(string col, string clave)
        {
            if (!string.IsNullOrEmpty(clave))
            {
                return col + " like '%" + clave + "%' and ";
            }
            return "";
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            DataView vistaClientes = new DataView(tablaClientes);
            string filtro = "";
            filtro = filtro + this.esExactamente("TIPO_DOCUMENTO", tipoDocumento.Text);
            filtro = filtro + this.esExactamente("NRO_DOCUMENTO", nroDocumento.Text);
            filtro = filtro + this.esAproximadamente("NOMBRE", nombre.Text);
            filtro = filtro + this.esAproximadamente("APELLIDO", apellido.Text);
            filtro = filtro + this.esAproximadamente("EMAIL", eMail.Text);

            if (filtro.Length > 0)
            {
                filtro = filtro.Remove(filtro.Length - 4);
            }

            vistaClientes.RowFilter = filtro;
            listaClientes.DataSource = vistaClientes;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            tipoDocumento.ResetText();
            nroDocumento.ResetText();
            nombre.Text = string.Empty;
            apellido.Text = string.Empty;
            eMail.Text = string.Empty;
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

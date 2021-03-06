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

namespace FrbaHotel.RegistrarEstadia
{
    public partial class BuscarClientes : Form
    {
        private SqlDataReader qry;
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

        public BuscarClientes()
        {
            InitializeComponent();

            qry = Index.BD.consultaGetPuntero("select distinct doc_id, doc_desc from EN_CASA_ANDABA.Documentos");
            while (qry.Read())
            {
                tipoDocumento.Items.Add(new TipoDocumento(qry.GetInt32(0), qry.GetString(1)));
            }
            qry.Close();
        }

        private void BuscarClientes_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn botonAgregar = new DataGridViewButtonColumn();
            botonAgregar.Name = "agregar";
            listaClientes.Columns.Add(botonAgregar);

            tablaClientes = Index.BD.consultaGetTabla("select C.cli_nombre NOMBRE, C.cli_apellido APELLIDO, D.doc_desc [TIPO DOCUMENTO], C.cli_documento [NRO DOCUMENTO], C.cli_mail EMAIL, C.cli_telefono TELEFONO, C.cli_nacionalidad NACIONALIDAD, C.cli_fecha_nac [FECHA DE NACIMIENTO], C.cli_habilitado HABILITADO, C.cli_calle CALLE, C.cli_calle_nro NUMERO, C.cli_piso PISO, C.cli_depto DEPTO, C.cli_dir_localidad LOCALIDAD, C.cli_dir_pais PAIS from EN_CASA_ANDABA.Clientes C, EN_CASA_ANDABA.Documentos D where C.cli_doc_id = D.doc_id");
            BindingSource bindingSourceListaClientes = new BindingSource();
            bindingSourceListaClientes.DataSource = tablaClientes;
            listaClientes.DataSource = bindingSourceListaClientes;
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

        private void listaClientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.listaClientes.Columns[e.ColumnIndex].Name == "agregar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonAgregar = this.listaClientes.Rows[e.RowIndex].Cells["agregar"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\plus.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.listaClientes.Rows[e.RowIndex].Height = icono.Height + 5;
                this.listaClientes.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }
        }

        private void listaClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listaClientes.Columns[e.ColumnIndex].Name == "agregar")
            {
                DataRow fila = AsignarClientesEstadia.tablaClientes.NewRow();
                fila["TIPO DOCUMENTO"] = listaClientes.CurrentRow.Cells[3].Value.ToString();
                fila["NRO DOCUMENTO"] = listaClientes.CurrentRow.Cells[4].Value.ToString();
                fila["NOMBRE"] = listaClientes.CurrentRow.Cells[1].Value.ToString();
                fila["APELLIDO"] = listaClientes.CurrentRow.Cells[2].Value.ToString();
                try
                {
                    AsignarClientesEstadia.tablaClientes.Rows.Add(fila);
                    AsignarClientesEstadia.plazasDisponibles--;
                }
                catch
                {
                    MessageBox.Show("El cliente ya ha sido agregado");
                }
                AsignarClientesEstadia.ActiveForm.Show();
                this.Close();
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            DataView vistaClientes = new DataView(tablaClientes);
            string filtro = "";
            filtro = filtro + this.esExactamente("[TIPO DOCUMENTO]", tipoDocumento.Text);
            filtro = filtro + this.esExactamente("[NRO DOCUMENTO]", nroDocumento.Text);
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
            nroDocumento.Text = string.Empty;
            nombre.Text = string.Empty;
            apellido.Text = string.Empty;
            eMail.Text = string.Empty;
            tipoDocumento.Focus();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            string reservaID = AsignarClientesEstadia.reservaID;
            string estadiaID = AsignarClientesEstadia.estadiaID;

            this.Hide();
            AsignarClientesEstadia ClientesEstadia = new AsignarClientesEstadia(reservaID, estadiaID);
            ClientesEstadia.Show();
        }

    }
}

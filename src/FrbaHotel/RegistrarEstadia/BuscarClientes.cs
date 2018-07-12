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

        private void ListadoClientes_Load(object sender, EventArgs e)
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
                DataRow columna = AsignarClientesEstadia.tablaClientes.NewRow();
                columna["ID"] = listaClientes.CurrentRow.Cells[1].Value.ToString();
                columna["NOMBRE"] = listaClientes.CurrentRow.Cells[2].Value.ToString();
                columna["APELLIDO"] = listaClientes.CurrentRow.Cells[3].Value.ToString();
                try
                {
                    AsignarClientesEstadia.tablaClientes.Rows.Add(columna);
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

    }
}

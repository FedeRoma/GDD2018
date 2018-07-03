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
    public partial class ListadoClientes : Form
    {
        private SqlDataReader qry;
        public static MenuAbmCliente AbmCli;
        public static ModificacionCliente ModifCli;
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

        public ListadoClientes()
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
            DataGridViewButtonColumn botonColumna = new DataGridViewButtonColumn();
            botonColumna.Name = "";
            listaClientes.Columns.Add(botonColumna);

            tablaClientes = Index.BD.consultaGetTabla("select C.cli_nombre Nombre, C.cli_apellido Apellido, D.doc_desc TipoDoc, C.cli_documento NroDoc, C.cli_mail eMail, C.cli_telefono Telefono, C.cli_nacionalidad Nacionalidad, C.cli_fecha_nac Fecha_Nacimiento, C.cli_habilitado Habilitado, C.cli_calle Calle, C.cli_calle_nro Numero_Calle, C.cli_piso Piso, C.cli_depto Departamento, C.cli_dir_localidad Localidad, C.cli_dir_pais Pais from EN_CASA_ANDABA.Clientes C, EN_CASA_ANDABA.Documentos D where C.cli_doc_id = D.doc_id");
            BindingSource bindingSourceListaClientes = new BindingSource();
            bindingSourceListaClientes.DataSource = tablaClientes;
            listaClientes.DataSource = bindingSourceListaClientes;  
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
            if (e.ColumnIndex >= 0 && this.listaClientes.Columns[e.ColumnIndex].Name == "" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonColumna = this.listaClientes.Rows[e.RowIndex].Cells[""] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\modificar.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.listaClientes.Rows[e.RowIndex].Height = icono.Height + 5;
                this.listaClientes.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }
        }

        private void listaClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string nombre = listaClientes.CurrentRow.Cells[1].Value.ToString();
                string apellido = listaClientes.CurrentRow.Cells[2].Value.ToString();
                string docTipo = listaClientes.CurrentRow.Cells[3].Value.ToString();
                string docNro = listaClientes.CurrentRow.Cells[4].Value.ToString();
                string eMail = listaClientes.CurrentRow.Cells[5].Value.ToString();
                string telefono = listaClientes.CurrentRow.Cells[6].Value.ToString();
                string nacionalidad = listaClientes.CurrentRow.Cells[7].Value.ToString();
                string fecha_nac = listaClientes.CurrentRow.Cells[8].Value.ToString();
                string estado = listaClientes.CurrentRow.Cells[9].Value.ToString();
                string calle = listaClientes.CurrentRow.Cells[10].Value.ToString();
                string calleNro = listaClientes.CurrentRow.Cells[11].Value.ToString();
                string piso = listaClientes.CurrentRow.Cells[12].Value.ToString();
                string depto = listaClientes.CurrentRow.Cells[13].Value.ToString();
                string localidad = listaClientes.CurrentRow.Cells[14].Value.ToString();
                string pais = listaClientes.CurrentRow.Cells[15].Value.ToString();

                ModifCli = new ModificacionCliente(nombre, apellido, docTipo, docNro, eMail, 
                                                    telefono, nacionalidad, fecha_nac, estado,
                                                    calle, calleNro, piso, depto, localidad, pais);
                ModifCli.Show();
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            DataView vistaClientes = new DataView(tablaClientes);
            string filtro = "";
            filtro = filtro + this.esExactamente("TipoDoc", tipoDocumento.Text);
            filtro = filtro + this.esExactamente("NroDoc", nroDocumento.Text);
            filtro = filtro + this.esAproximadamente("Nombre", nombre.Text);
            filtro = filtro + this.esAproximadamente("Apellido", apellido.Text);
            filtro = filtro + this.esAproximadamente("eMail", eMail.Text);

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

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmCli = new MenuAbmCliente();
            AbmCli.Show();
        }

    }
}

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
            tablaClientes = Index.BD.consultaGetTabla("select C.cli_nombre Nombre, C.cli_apellido Apellido, D.doc_desc TipoDoc, C.cli_documento NroDoc, C.cli_mail eMail, C.cli_telefono Telefono, C.cli_nacionalidad Nacionalidad, C.cli_fecha_nac Fecha_Nacimiento, C.cli_habilitado Habilitado, C.cli_calle Calle, C.cli_calle_nro Numero_Calle, C.cli_depto Departamento, C.cli_dir_localidad Localidad, C.cli_dir_pais Pais from EN_CASA_ANDABA.Clientes C, EN_CASA_ANDABA.Documentos D where C.cli_doc_id = D.doc_id");
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

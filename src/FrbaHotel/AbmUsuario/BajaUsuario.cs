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
    public partial class BajaUsuario : Form
    {

        private SqlDataReader qry;
        public static MenuAbmUsuario AbmUsu;
        DataTable tablaUsuarios;

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

        public BajaUsuario()
        {
            InitializeComponent();
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
        }

        private void BajaUsuario_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn botonBaja = new DataGridViewButtonColumn();
            botonBaja.Name = "baja";
            listaUsuarios.Columns.Add(botonBaja);

            tablaUsuarios = Index.BD.consultaGetTabla("select usu_username USERNAME, usu_nombre NOMBRE,usu_apellido APELLIDO,usu_mail MAIL,usu_tel TELEFONO, usu_documento DOC,usu_estado HABILITA from EN_CASA_ANDABA.Usuarios");
            BindingSource bindingSourceListaUsuarios = new BindingSource();
            bindingSourceListaUsuarios.DataSource = tablaUsuarios;
            listaUsuarios.DataSource = bindingSourceListaUsuarios;
        }

        private void listaUsuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.listaUsuarios.Columns[e.ColumnIndex].Name == "baja" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonBaja = this.listaUsuarios.Rows[e.RowIndex].Cells["baja"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\cross-script.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.listaUsuarios.Rows[e.RowIndex].Height = icono.Height + 5;
                this.listaUsuarios.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }
        }

        private void listaUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listaUsuarios.Columns[e.ColumnIndex].Name == "baja")
            {
                if (listaUsuarios.CurrentRow.Cells[7].Value.ToString() == "False")
                {
                    MessageBox.Show("#error: el usuario seleccionado ya se encuentra deshabilitado");
                    return;
                }

                Int64 clienteDocumento = 0;
                Int32 clienteDocID = 0;
                string eMail = listaUsuarios.CurrentRow.Cells[4].Value.ToString();

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

                tablaClientes = Index.BD.consultaGetTabla("select C.cli_nombre Nombre, C.cli_apellido Apellido, D.doc_desc TipoDoc, C.cli_documento NroDoc, C.cli_mail eMail, C.cli_telefono Telefono, C.cli_nacionalidad Nacionalidad, C.cli_fecha_nac Fecha_Nacimiento, C.cli_habilitado Habilitado, C.cli_calle Calle, C.cli_calle_nro Numero_Calle, C.cli_depto Departamento, C.cli_dir_localidad Localidad, C.cli_dir_pais Pais from EN_CASA_ANDABA.Clientes C, EN_CASA_ANDABA.Documentos D where C.cli_doc_id = D.doc_id");
                BindingSource bindingSourcelistaUsuarios = new BindingSource();
                bindingSourcelistaUsuarios.DataSource = tablaClientes;
                listaUsuarios.DataSource = bindingSourcelistaUsuarios;
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





    }
}

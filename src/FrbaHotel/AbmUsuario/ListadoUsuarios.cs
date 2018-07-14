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
    public partial class ListadoUsuarios : Form
    {
        public static MenuAbmUsuario AbmUsu;
        public static ModificacionUsuario ModifUsu;
        DataTable tablaUsuarios;

        public ListadoUsuarios()
        {
            InitializeComponent();

        }

        private void ListadoUsuarios_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn botonModif = new DataGridViewButtonColumn();
            botonModif.Name = "modif";
            listaUsuarios.Columns.Add(botonModif);

            tablaUsuarios = Index.BD.consultaGetTabla("select usu_username USERNAME, usu_nombre NOMBRE,usu_apellido APELLIDO,usu_mail MAIL,usu_tel TELEFONO,doc_desc TIPO_DOC ,usu_documento NUMERO_DOC,usu_fecha_nac FECHA_NAC,usu_direccion DIRECCION,rol_nombre ROL,usu_estado HABILITA from EN_CASA_ANDABA.Usuarios,EN_CASA_ANDABA.Documentos,EN_CASA_ANDABA.Roles_Usuarios,EN_CASA_ANDABA.Roles where doc_id=usu_doc_id and ryu_usu_id = usu_id and ryu_rol_id = rol_id");
            BindingSource bindingSourceListaUsuarios = new BindingSource();
            bindingSourceListaUsuarios.DataSource = tablaUsuarios;
            listaUsuarios.DataSource = bindingSourceListaUsuarios; 
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

        private void ListadoUsuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.listaUsuarios.Columns[e.ColumnIndex].Name == "modif" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonModif = this.listaUsuarios.Rows[e.RowIndex].Cells["modif"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\pencil.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.listaUsuarios.Rows[e.RowIndex].Height = icono.Height + 5;
                this.listaUsuarios.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }
        }

        private void listaClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listaUsuarios.Columns[e.ColumnIndex].Name == "modif")
            {   
                string username=listaUsuarios.CurrentRow.Cells[1].Value.ToString();
                string nombre=listaUsuarios.CurrentRow.Cells[2].Value.ToString();
                string apellido=listaUsuarios.CurrentRow.Cells[3].Value.ToString();
                string email=listaUsuarios.CurrentRow.Cells[4].Value.ToString();
                string telefono=listaUsuarios.CurrentRow.Cells[5].Value.ToString();
                string tipoDoc = listaUsuarios.CurrentRow.Cells[6].Value.ToString();
                string numeroDoc = listaUsuarios.CurrentRow.Cells[7].Value.ToString();
                string fechaNac = listaUsuarios.CurrentRow.Cells[8].Value.ToString();
                string direccion = listaUsuarios.CurrentRow.Cells[9].Value.ToString();
                string rol = listaUsuarios.CurrentRow.Cells[10].Value.ToString(); 
                string estado = listaUsuarios.CurrentRow.Cells[11].Value.ToString(); 
                ModifUsu = new ModificacionUsuario(username,
                                                    nombre,
                                                    apellido,
                                                    email,
                                                    telefono,
                                                    tipoDoc,
                                                    numeroDoc,
                                                    fechaNac,
                                                    direccion,
                                                    rol,
                                                    estado);
                ModifUsu.Show();
                this.Hide();
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            DataView vistaUsuarios = new DataView(tablaUsuarios);
            string filtro = "";
            
            filtro = filtro + this.esExactamente("NUMERO_DOC", nroDocumento.Text);
            filtro = filtro + this.esAproximadamente("NOMBRE", nombre.Text);
            filtro = filtro + this.esAproximadamente("APELLIDO", apellido.Text);
            filtro = filtro + this.esAproximadamente("MAIL", eMail.Text);
            

            if (filtro.Length > 0) 
            { 
                filtro = filtro.Remove(filtro.Length - 4); 
            }

            vistaUsuarios.RowFilter = filtro;
            listaUsuarios.DataSource = vistaUsuarios;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nroDocumento.Text = string.Empty;
            nombre.Text = string.Empty;
            apellido.Text = string.Empty;
            eMail.Text = string.Empty;
            nombre.Focus();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmUsu = new MenuAbmUsuario();
            AbmUsu.Show();
        }
    }
}

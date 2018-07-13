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
        DataTable tablaUsuario;
        string rolModif = "";

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
        
        public BajaUsuario()
        {
            InitializeComponent();
        }

        private void BajaUsuario_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn botonBaja = new DataGridViewButtonColumn();
            botonBaja.Name = "baja";
            listaUsuarios.Columns.Add(botonBaja);

            tablaUsuario = Index.BD.consultaGetTabla("select usu_username USERNAME, usu_nombre NOMBRE,usu_apellido APELLIDO,usu_mail MAIL,usu_tel TELEFONO, usu_documento NUMERO_DOC,usu_estado HABILITA from EN_CASA_ANDABA.Usuarios");
            BindingSource bindingSourceListaUsuarios = new BindingSource();
            bindingSourceListaUsuarios.DataSource = tablaUsuario;
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
                    MessageBox.Show("#error:  el usuario seleccionado ya se encuentra deshabilitado");
                    return;
                }

                string username = listaUsuarios.CurrentRow.Cells[1].Value.ToString();
                string eMail = listaUsuarios.CurrentRow.Cells[4].Value.ToString();

                if (MessageBox.Show("Esta seguro que quiere inhabilitar el usuario?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Obtengo el rol del usuario a eliminar
                    qry = Index.BD.consultaGetPuntero("select top 1 rol_nombre from EN_CASA_ANDABA.Roles,EN_CASA_ANDABA.Roles_Usuarios,EN_CASA_ANDABA.Usuarios where usu_id = ryu_usu_id and rol_id = ryu_rol_id and usu_username = '" + username + "'");
                    if (qry.Read())
                    {
                        rolModif = qry.GetString(0);
                    }
                    qry.Close();


                    if (rolModif != "Administrador General")
                    {
                        qry = Index.BD.consultaGetPuntero("update EN_CASA_ANDABA.Usuarios set usu_estado=0 where usu_username = '" + username + "'");
                        MessageBox.Show("Usuario Inhabilitado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        qry.Close();
                    }
                    else
                    {
                        MessageBox.Show("No podes dar de baja un usuario administrador general", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
                
                tablaUsuario = Index.BD.consultaGetTabla("select usu_username USERNAME, usu_nombre NOMBRE,usu_apellido APELLIDO,usu_mail MAIL,usu_tel TELEFONO, usu_documento NUMERO_DOC,usu_estado HABILITA from EN_CASA_ANDABA.Usuarios");
                BindingSource bindingSourceListaUsuarios = new BindingSource();
                bindingSourceListaUsuarios.DataSource = tablaUsuario;
                listaUsuarios.DataSource = bindingSourceListaUsuarios;
            }
        }


        private void buscar_Click(object sender, EventArgs e)
        {
            DataView vistaUsuario = new DataView(tablaUsuario);
            string filtro = "";
            filtro = filtro + this.esExactamente("NUMERO_DOC", nroDocumento.Text);
            filtro = filtro + this.esAproximadamente("NOMBRE", nombre.Text);
            filtro = filtro + this.esAproximadamente("APELLIDO", apellido.Text);
            filtro = filtro + this.esAproximadamente("MAIL", eMail.Text);

            if (filtro.Length > 0)
            {
                filtro = filtro.Remove(filtro.Length - 4);
            }

            vistaUsuario.RowFilter = filtro;
            listaUsuarios.DataSource = vistaUsuario;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nroDocumento.ResetText();
            nombre.Text = string.Empty;
            apellido.Text = string.Empty;
            eMail.Text = string.Empty;
            nroDocumento.Focus();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmUsu = new MenuAbmUsuario();
            AbmUsu.Show();
        }


    }
}

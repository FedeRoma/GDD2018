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

namespace FrbaHotel.AbmRol
{
    public partial class ListadoRoles : Form
    {
        private SqlDataReader qry;
        public static MenuAbmRol AbmRol;
        DataTable tablaRoles;
        DataTable tablaFuncionalidades;

        public ListadoRoles()
        {
            InitializeComponent();
        }

        private void ListadoRoles_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn botonEditar = new DataGridViewButtonColumn();
            botonEditar.Name = "EDITAR";
            listaRoles.Columns.Add(botonEditar);

            DataGridViewButtonColumn botonBorrar = new DataGridViewButtonColumn();
            botonBorrar.Name = "BORRAR";
            listaRoles.Columns.Add(botonBorrar);

            tablaRoles = Index.BD.consultaGetTabla("select rol_id ID, rol_nombre NOMBRE, rol_estado ESTADO from EN_CASA_ANDABA.Roles");
            BindingSource bindingSourceListaRoles = new BindingSource();
            bindingSourceListaRoles.DataSource = tablaRoles;
            listaRoles.DataSource = bindingSourceListaRoles;

            DataGridViewButtonColumn botonFuncionalidades = new DataGridViewButtonColumn();
            botonFuncionalidades.Name = "FUNCIONALIDADES";
            listaRoles.Columns.Add(botonFuncionalidades);
        }

        private void listaRoles_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.listaRoles.Columns[e.ColumnIndex].Name == "EDITAR" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonEditar = this.listaRoles.Rows[e.RowIndex].Cells["EDITAR"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\pencil.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.listaRoles.Rows[e.RowIndex].Height = icono.Height + 5;
                this.listaRoles.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }

            if (e.ColumnIndex >= 0 && this.listaRoles.Columns[e.ColumnIndex].Name == "BORRAR" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonBorrar = this.listaRoles.Rows[e.RowIndex].Cells["BORRAR"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\eraser.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.listaRoles.Rows[e.RowIndex].Height = icono.Height + 5;
                this.listaRoles.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }

            if (e.ColumnIndex >= 0 && this.listaRoles.Columns[e.ColumnIndex].Name == "FUNCIONALIDADES" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonFuncionalidades = this.listaRoles.Rows[e.RowIndex].Cells["FUNCIONALIDADES"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\menu.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.listaRoles.Rows[e.RowIndex].Height = icono.Height + 5;
                this.listaRoles.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {

        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmRol = new MenuAbmRol();
            AbmRol.Show();
        }

    }
}

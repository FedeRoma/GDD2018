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

namespace FrbaHotel.AbmRol
{
    public partial class ListadoRoles : Form
    {
        public static MenuAbmRol AbmRol;
        public static ModificacionRol ModifRol;
        DataTable tablaRoles;
        DataTable tablaFuncionalidades;

        public ListadoRoles()
        {
            InitializeComponent();
        }

        private void ListadoRoles_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn botonModif = new DataGridViewButtonColumn();
            botonModif.Name = "modif";
            listaRoles.Columns.Add(botonModif);

            tablaRoles = Index.BD.consultaGetTabla("select rol_id ID, rol_nombre NOMBRE, rol_estado HABILITADO from EN_CASA_ANDABA.Roles");
            BindingSource bindingSourceListaRoles = new BindingSource();
            bindingSourceListaRoles.DataSource = tablaRoles;
            listaRoles.DataSource = bindingSourceListaRoles;

            DataGridViewButtonColumn botonFuncionalidades = new DataGridViewButtonColumn();
            botonFuncionalidades.Name = "FUNCIONALIDADES";
            listaRoles.Columns.Add(botonFuncionalidades);
        }

        private void listaRoles_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.listaRoles.Columns[e.ColumnIndex].Name == "modif" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonModif = this.listaRoles.Rows[e.RowIndex].Cells["modif"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\pencil.ico");
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

        private void listaRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listaRoles.Columns[e.ColumnIndex].Name == "modif")
            {
                string id = listaRoles.CurrentRow.Cells[1].Value.ToString();
                string nombre = listaRoles.CurrentRow.Cells[2].Value.ToString();
                string estado = listaRoles.CurrentRow.Cells[3].Value.ToString();

                ModifRol = new ModificacionRol(id, nombre, estado);
                ModifRol.Show();
                this.Hide();
            }

            if (listaRoles.Columns[e.ColumnIndex].Name == "FUNCIONALIDADES")
            {
                tablaFuncionalidades = Index.BD.consultaGetTabla("select F.fun_id ID, F.fun_desc DESCRIPCION from EN_CASA_ANDABA.Funcionalidades F, EN_CASA_ANDABA.Funcionalidades_Roles FR where F.fun_id = FR.fyr_fun_id and FR.fyr_rol_id = " + listaRoles.CurrentRow.Cells[1].Value.ToString());
                BindingSource bindingSourceListaFuncionalidades = new BindingSource();
                bindingSourceListaFuncionalidades.DataSource = tablaFuncionalidades;
                listaFuncionalidades.DataSource = bindingSourceListaFuncionalidades;
            }
        }
        
        private void limpiar_Click(object sender, EventArgs e)
        {
            listaRoles.ClearSelection();
            listaFuncionalidades.DataSource = null;
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmRol = new MenuAbmRol();
            AbmRol.Show();
        }

    }
}

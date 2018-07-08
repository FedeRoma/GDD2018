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
    public partial class AltaRol : Form
    {
        private SqlDataReader qry;
        public static MenuAbmRol AbmRol;
        private DataTable tablaFuncionalidades;
        private DataTable tablaFuncionalidadesAsig;
        private string funcionalidades = "";
        private int cantFuncionalidades = 0;

        public AltaRol()
        {
            InitializeComponent();
        }

        private void AltaRol_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn botonAsignar = new DataGridViewButtonColumn();
            botonAsignar.Name = "asignar";
            listaFuncionalidades.Columns.Add(botonAsignar);

            tablaFuncionalidades = Index.BD.consultaGetTabla("select distinct fun_id ID, fun_desc DESCRIPCION from EN_CASA_ANDABA.Funcionalidades except select fun_id, fun_desc from EN_CASA_ANDABA.Funcionalidades where fun_desc = 'ABM Rol'");  // la funcionalidad ABM Rol es exclusiva del SysAdmin
            BindingSource bindingSourceListaFuncionalidades = new BindingSource();
            bindingSourceListaFuncionalidades.DataSource = tablaFuncionalidades;
            listaFuncionalidades.DataSource = bindingSourceListaFuncionalidades;
            
            tablaFuncionalidadesAsig = new DataTable();
            tablaFuncionalidadesAsig.Columns.Add("ID");
            tablaFuncionalidadesAsig.Columns.Add("DESCRIPCION");
            BindingSource bindingSourceListaFuncionalidadesAsig = new BindingSource();
            bindingSourceListaFuncionalidadesAsig.DataSource = tablaFuncionalidadesAsig;
            listaFuncionalidadesAsig.DataSource = bindingSourceListaFuncionalidadesAsig;
        }

        private void listaFuncionalidades_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.listaFuncionalidades.Columns[e.ColumnIndex].Name == "asignar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonColumna = this.listaFuncionalidades.Rows[e.RowIndex].Cells["asignar"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\plus.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.listaFuncionalidades.Rows[e.RowIndex].Height = icono.Height + 5;
                this.listaFuncionalidades.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }
        }

        private void listaFuncionalidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listaFuncionalidades.Columns[e.ColumnIndex].Name == "asignar")
            {
                string funcionalidadID = listaFuncionalidades.CurrentRow.Cells[1].Value.ToString();
                string funcionalidadDesc = listaFuncionalidades.CurrentRow.Cells[2].Value.ToString();
                listaFuncionalidades.Rows.RemoveAt(listaFuncionalidades.CurrentRow.Index);
                
                DataRow row = tablaFuncionalidadesAsig.NewRow();
                row["ID"] = funcionalidadID;
                row["DESCRIPCION"] = funcionalidadDesc;
                tablaFuncionalidadesAsig.Rows.Add(row);
                bindingSourceListaFuncionalidadesAsig.DataSource = tablaFuncionalidadesAsig;
                bindingSourceListaFuncionalidadesAsig.ResetBindings(true);

                if (cantFuncionalidades == 0)
                {
                    funcionalidades = funcionalidades + funcionalidadID.ToString();
                }
                else
                {
                    funcionalidades = funcionalidades + "," + funcionalidadID.ToString();
                }
                cantFuncionalidades++;
               
                listaFuncionalidadesAsig.DataSource = bindingSourceListaFuncionalidadesAsig;
            }
        }

        private bool checkCampos()
        {
            bool inconsistencias = false;
            string alerta = "";

            if (funcionalidades == "")
            {
                alerta = alerta + "Se debe asignar por lo menos una funcionalidad\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(nombre.Text))
            {
                alerta = alerta + "Debe ingresar un Nombre válido\n";
                inconsistencias = true;
            }
            else
            {
                qry = Index.BD.consultaGetPuntero("select * from EN_CASA_ANDABA.Roles where rol_nombre = '" + nombre.Text + "'");
                if (qry.Read())
                {
                    alerta = alerta + "Rol ya registrado\n";
                    inconsistencias = true;
                }
                qry.Close();
            }

            if (inconsistencias)
            {
                MessageBox.Show(alerta);
            }
            return inconsistencias;

        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (!checkCampos())
            {
                bool insertOk = false;

                qry = Index.BD.consultaGetPuntero("exec EN_CASA_ANDABA.AltaRol '" + nombre.Text + "'");
                if (qry.Read())
                {
                    insertOk = qry.GetBoolean(0);
                }
                qry.Close();

                if (!insertOk)
                {
                    MessageBox.Show("#error: no se ha podido realizar la operación");

                }

                Int32 rolID = 0;
                qry = Index.BD.consultaGetPuntero("select rol_id from EN_CASA_ANDABA.Roles where rol_nombre = '" + nombre.Text + "'");
                if (qry.Read())
                {
                    rolID = qry.GetInt32(0);
                }
                qry.Close();

                string[] funcionalidadesArr = null;
                funcionalidadesArr = funcionalidades.Split(',');

                for (int i = 0; i <= funcionalidadesArr.Length - 1; i++)
                {
                    qry = Index.BD.consultaGetPuntero("exec EN_CASA_ANDABA.altaFuncionalidadRol " + rolID.ToString() + "," + funcionalidadesArr[i]);
                    if (!qry.Read())
                    {
                        MessageBox.Show("#error: no se ha podido asignar la funcionalidad elegida al rol");
                        return;
                    }
                    qry.Close();

                }

                MessageBox.Show("Rol dado de alta");
                limpiar.PerformClick();
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Clear();
            nombre.Focus();

            tablaFuncionalidades = Index.BD.consultaGetTabla("select distinct F.fun_id ID,F.fun_desc DESCRIPCION from EN_CASA_ANDABA.Funcionalidades F");
            BindingSource bindingSourceListaFuncionalidades = new BindingSource();
            bindingSourceListaFuncionalidades.DataSource = tablaFuncionalidades;
            listaFuncionalidades.DataSource = bindingSourceListaFuncionalidades;

            tablaFuncionalidadesAsig.Clear();
            listaFuncionalidadesAsig.DataSource = bindingSourceListaFuncionalidadesAsig;
            funcionalidades = null;
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmRol = new MenuAbmRol();
            AbmRol.Show();
        }

    }
}

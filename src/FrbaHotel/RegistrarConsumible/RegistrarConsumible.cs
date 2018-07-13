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

namespace FrbaHotel.RegistrarConsumible
{
    public partial class RegistrarConsumible : Form
    {
        DataTable tablaConsumibles, tablaConsumiblesAsig;
        public static ListadoEstadias regConsumible;

        public RegistrarConsumible(string estadiaID, string habitacionID, string numeroHab, string pisoHab, string regimenHab)
        {
            InitializeComponent();

            estadia.Text = estadiaID;
            habitacion.Text = habitacionID;
            numero.Text = numeroHab;
            piso.Text = pisoHab;
            tablaConsumiblesAsig = new DataTable();
            tablaConsumiblesAsig.Columns.Add("ID");
            tablaConsumiblesAsig.Columns.Add("PRECIO");
            tablaConsumiblesAsig.Columns.Add("DESCRIPCION");

            bindingSourceListaConsumiblesAsig = new BindingSource();
            bindingSourceListaConsumiblesAsig.DataSource = tablaConsumiblesAsig;
            listaConsumiblesAsig.DataSource = bindingSourceListaConsumiblesAsig;
            
            allInclusive.Checked = false;
            if (regimenHab == "4")
            {
                allInclusive.Checked = true;
            }
        }

        private void Consumibles_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn botonAsignar = new DataGridViewButtonColumn();
            botonAsignar.Name = "asignar";
            listaConsumibles.Columns.Add(botonAsignar);

            tablaConsumibles = Index.BD.consultaGetTabla("select con_id Id,con_precio Precio, con_desc Nombre from EN_CASA_ANDABA.Consumibles");
            bindingSourceListaConsumibles = new BindingSource();
            bindingSourceListaConsumibles.DataSource = tablaConsumibles;
            listaConsumibles.DataSource = bindingSourceListaConsumibles;
        }

        private void listaFuncionalidades_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.listaConsumibles.Columns[e.ColumnIndex].Name == "asignar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonColumna = this.listaConsumibles.Rows[e.RowIndex].Cells["asignar"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\plus.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.listaConsumibles.Rows[e.RowIndex].Height = icono.Height + 5;
                this.listaConsumibles.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }
        }

        private void listaConsumibles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listaConsumibles.Columns[e.ColumnIndex].Name == "asignar")
            {
                string id = listaConsumibles.CurrentRow.Cells[1].Value.ToString();
                string precio = listaConsumibles.CurrentRow.Cells[2].Value.ToString();
                string descripcion = listaConsumibles.CurrentRow.Cells[3].Value.ToString();
                DataRow row = tablaConsumiblesAsig.NewRow();
                row["ID"] = id;
                row["PRECIO"] = precio;
                row["DESCRIPCION"] = descripcion;
                tablaConsumiblesAsig.Rows.Add(row);
                bindingSourceListaConsumiblesAsig.DataSource = tablaConsumiblesAsig;
                bindingSourceListaConsumiblesAsig.ResetBindings(true);
                listaConsumiblesAsig.DataSource = bindingSourceListaConsumiblesAsig;
            }
        }

        private void listaConsumiblesAsig_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int item = listaConsumiblesAsig.CurrentRow.Index;
                tablaConsumiblesAsig.Rows.RemoveAt(item);
            }
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (tablaConsumiblesAsig.Rows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar por lo menos un consumible");
                return;
            }
            foreach (DataRow fila in tablaConsumiblesAsig.Rows)
            {
                int resultado = Index.BD.consultaGetInt("exec EN_CASA_ANDABA.registrarConsumibleEstadia " + estadia.Text + "," + fila["ID"].ToString());
        
                if (resultado != 0)
                {
                    MessageBox.Show("Consumibles cargados correctamente");
                }
                else
                {
                    MessageBox.Show("#error: no se ha podido asignar el consumible elegida a la estadía");
                }
            }

            if (allInclusive.Checked == true)
            {
                MessageBox.Show("Descuento por régimen de estadía");
            }
            this.Close();
            regConsumible = new ListadoEstadias();
            regConsumible.Show();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            tablaConsumibles = Index.BD.consultaGetTabla("select con_id Id,con_precio Precio, con_desc Nombre from EN_CASA_ANDABA.Consumibles");
            bindingSourceListaConsumibles = new BindingSource();
            bindingSourceListaConsumibles.DataSource = tablaConsumibles;
            listaConsumibles.DataSource = bindingSourceListaConsumibles;

            tablaConsumiblesAsig.Clear();
            listaConsumiblesAsig.DataSource = bindingSourceListaConsumibles;
        }

    }
}

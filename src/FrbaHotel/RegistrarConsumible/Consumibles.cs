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
    public partial class Consumibles : Form
    {
        DataTable tablaReg;
        BindingSource bSource2;
        private SqlDataReader resultado;
        SqlDataAdapter sAdapter;
        DataTable tablaConsu;
        private SqlDataReader qry;
       
        public static RegistrarConsumible.RegistrarConsumibles RegCons;
        public Consumibles(string estadia, string habitacion, string numero, string piso,String Regimen)
        {
            InitializeComponent();
            textBoxIdEstadia.Text = estadia;
            textBoxIdHabitacion.Text = habitacion;
            textBoxNumero.Text = numero;
            textBoxPiso.Text = piso;
            tablaReg = new DataTable();
            tablaReg.Columns.Add("Id");
            tablaReg.Columns.Add("Precio");
            tablaReg.Columns.Add("Descripcion");
            bSource2 = new BindingSource();
            bSource2.DataSource = tablaReg;
            //set the DataGridView DataSource
            dataGridView2.DataSource = bSource2;
            Int32 aux = Convert.ToInt32(Regimen);
            checkBox1.Enabled = false;

            
            if (aux == 4)
            {
                checkBox1.Checked = true;
            }
            


        }

        private void Consumibles_Load(object sender, EventArgs e)
        {
            /*list = Index.BD.consultaGetTabla("select con_id,con_precio,con_desc from EN_CASA_ANDABA.Consumibles");

            BindingSource bindingSourceListaComestibles = new BindingSource();
            bindingSourceListaComestibles.DataSource = ListaDeConsumibles;
            listaEstadias.DataSource = bindingSourceListaComestibles;  */
            string query = "select con_id Id,con_precio Precio, con_desc Nombre from EN_CASA_ANDABA.Consumibles";
            sAdapter = FrbaHotel.Index.BD.dameDataAdapter(query);
            tablaConsu = FrbaHotel.Index.BD.dameDataTable(sAdapter);
            //BindingSource to sync DataTable and DataGridView
            BindingSource bSource = new BindingSource();
            //set the BindingSource DataSource
            bSource.DataSource = tablaConsu;
            //set the DataGridView DataSource
            dataGridView1.DataSource = bSource;

            

        }

        private void textBoxIdEstadia_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegCons = new RegistrarConsumible.RegistrarConsumibles();
            RegCons.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tablaReg.Clear();
        }

        private void ListaDeConsumibles_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string precio = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string descripcion = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                DataRow row = tablaReg.NewRow();
                row["Id"] = id;
                row["Precio"] = precio;
                row["Descripcion"] = descripcion;
                tablaReg.Rows.Add(row);
                dataGridView2.DataSource = bSource2;
            }

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dataGridView1.Columns[e.ColumnIndex].Name == "Id" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonColumna = this.dataGridView1.Rows[e.RowIndex].Cells["Id"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\plus.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.dataGridView1.Rows[e.RowIndex].Height = icono.Height + 5;
                this.dataGridView1.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int item = dataGridView2.CurrentRow.Index;
                tablaReg.Rows.RemoveAt(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tablaReg.Rows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar por lo menos 1 Consumible");
                return;
            }
            foreach (DataRow fila in tablaReg.Rows)
            {
                resultado = Index.BD.consultaGetPuntero("EXEC EN_CASA_ANDABA.RegistrarConsumibleEstadia " + textBoxIdEstadia.Text + "," + fila["Id"].ToString());
                if (resultado.Read())
                {
                    if (resultado.GetDecimal(0) == 0)
                    {
                        MessageBox.Show("Error. El consumible ya estaba agregado");
                    }
                }
                else
                {
                    MessageBox.Show("Error. El consumible ya estaba agregado");
                }
                resultado.Close();
            }
            MessageBox.Show("El proceso de carga de consumibles finalizo correctamente");
            this.Close();
            RegCons = new RegistrarConsumible.RegistrarConsumibles();
            RegCons.Show();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        
    }
}

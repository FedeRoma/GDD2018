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
    public partial class RegistrarConsumibles : Form
    {
        
        public static Login.MenuFuncionalidades AbmMenu;
        public static RegistrarConsumible.Consumibles RegConsumible;
        DataTable tablaEstadias;
        public RegistrarConsumibles()
        {
            InitializeComponent();
           
        }
       

        private void RegistrarConsumibles_Load(object sender, EventArgs e)
        {
            
            DataGridViewButtonColumn botonRegCons = new DataGridViewButtonColumn();
            botonRegCons.Name = "regCons";
            listaEstadias.Columns.Add(botonRegCons);

            tablaEstadias = Index.BD.consultaGetTabla("select distinct CE.cye_cye_id IdEstadia, CE. cye_hab_id IdHabitacion, H. hab_numero NUMERO, H.hab_piso PISO from EN_CASA_ANDABA.Estadias E, EN_CASA_ANDABA.Clientes_Estadias CE, EN_CASA_ANDABA.Habitaciones H where CE. cye_cye_id = E. est_res_id and CE. cye_hab_id=H.hab_id and H. hab_hot_id =" + Index.hotel);

            BindingSource bindingSourceListaEstadias = new BindingSource();
            bindingSourceListaEstadias.DataSource = tablaEstadias;
            listaEstadias.DataSource = bindingSourceListaEstadias;  

        }       

       
        
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmMenu = new FrbaHotel.Login.MenuFuncionalidades();
            AbmMenu.Show();
        }

      

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxIdEstadia.Clear();
            textBoxIdHabitacion.Clear();
            textBoxNumero.Clear();
            textBoxPiso.Clear();
            
        }
        private void listaEstadias_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.listaEstadias.Columns[e.ColumnIndex].Name == "regCons" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonRegCons = this.listaEstadias.Rows[e.RowIndex].Cells["regCons"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\pencil.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.listaEstadias.Rows[e.RowIndex].Height = icono.Height + 5;
                this.listaEstadias.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }
        }

        private void listaEstadias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            DataView vistaEstadias = new DataView(tablaEstadias);
            string filtro = "";
            filtro = filtro + this.filtrarExactamentePor("IdEstadia", textBoxIdEstadia.Text);
            filtro = filtro + this.filtrarExactamentePor("IdHabitacion", textBoxIdHabitacion.Text);
            filtro = filtro + this.filtrarExactamentePor("NUMERO", textBoxNumero.Text);
            filtro = filtro + this.filtrarExactamentePor("PISO", textBoxPiso.Text);

            if (filtro.Length > 0)
            {
                filtro = filtro.Remove(filtro.Length - 4);
            }

            vistaEstadias.RowFilter = filtro;
            listaEstadias.DataSource = vistaEstadias;
        }

        private void listaEstadias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             if (listaEstadias.Columns[e.ColumnIndex].Name == "regCons")
            {
                string IdEstadia = listaEstadias.CurrentRow.Cells[1].Value.ToString();
                string IdHabitacion = listaEstadias.CurrentRow.Cells[2].Value.ToString();
                string NUMERO = listaEstadias.CurrentRow.Cells[3].Value.ToString();
                string PISO = listaEstadias.CurrentRow.Cells[4].Value.ToString();            

                RegConsumible = new RegistrarConsumible.Consumibles(IdEstadia, IdHabitacion, NUMERO, PISO);
                RegConsumible.Show();
                this.Hide();
            }

        }
        private string filtrarExactamentePor(string columna, string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                return columna + " = '" + valor + "' AND ";
            }
            return "";
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

                

     
    }
}

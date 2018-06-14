using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class RegistrarConsumibles : Form
    {
        int cerrate = 0;
       
        SqlDataAdapter sAdapter;
        DataTable dTable;
        public RegistrarConsumibles()
        {
            InitializeComponent();
            textBox1.Focus();
        }
        private string filtrarExactamentePor(string columna, string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                return columna + " = '" + valor + "' AND ";
            }
            return "";
        }


        private void RegistrarConsumibles_Load(object sender, EventArgs e)
        {
            string query = "select distinct CE.cye_cye_id idEstadia,CE.cye_hab_id idHabitacion,Hab.hab_numero Numero,Hab.hab_piso Piso from EN_CASA_ANDABA.Estadias Est, EN_CASA_ANDABA.Clientes_Estadias CE, EN_CASA_ANDABA.Habitaciones Hab where Est.est_checkout is null and Est.est_ingreso <= '" + Home.fecha.Date + "' and CE.cye_cye_id = E.est_res_id and CE.cye_hab_id = Hab.hab_id and Hab.hab_hot_id = " + Login.HomeLogin.hotel;
            sAdapter = FrbaHotel.Home.BD.dameDataAdapter(query);
            dTable = FrbaHotel.Home.BD.dameDataTable(sAdapter);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dTable;
            dataGridView1.DataSource = bSource;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
            this.button2_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataView dvData = new DataView(dTable);
            string query = "";
            query = query + this.filtrarExactamentePor("idEstadia", textBox1.Text);
            query = query + this.filtrarExactamentePor("idHabitacion", textBox2.Text);
            query = query + this.filtrarExactamentePor("Numero", textBox3.Text);
            query = query + this.filtrarExactamentePor("Piso", textBox4.Text);
            if (query.Length > 0) { query = query.Remove(query.Length - 4); }
            dvData.RowFilter = query;
            dataGridView1.DataSource = dvData;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string idEstadia = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string idHabitacion = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string numero = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string piso = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                Consumibles consu = new Consumibles(idEstadia, idHabitacion, numero, piso);
                consu.Show();
                cerrate = 1;
                this.Close();
            }
        }

        private void RegistrarConsumibles_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrate == 0)
            {
                Login.HomeLogin.mainFun.Show();
            }
            else
            {
            }
            
        }
    }
}

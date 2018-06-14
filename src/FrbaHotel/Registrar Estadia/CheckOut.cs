using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class CheckOut : Form
    {
        string consulta;
        SqlDataReader resultado;
        SqlDataAdapter sAdapter;
        DataTable dTable;
        public CheckOut()
        {
            InitializeComponent();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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

        private void CheckOut_Load(object sender, EventArgs e)
        {
            string query = "select distinct CE.cye_cye_id idEstadia,CE.cye_hab_i idHabitacion,Hab.hab_numero Numero,Hab.hab_piso Piso from EN_CASA_ANDABA.Estadias Est, EN_CASA_ANDABA.Clientes_Estadias CE, EN_CASA_ANDABA.Habitaciones Hab where Est.est_checkout is null and Est.est_checkin<= '" + Home.fecha.Date + "' and CE.cye_cye_id = Est.est_res_id and CE.cye_hab_id = Hab.hab_id and Hab.hab_hot_id = " + Login.HomeLogin.hotel;
            sAdapter = FrbaHotel.Home.BD.dameDataAdapter(query);
            dTable = FrbaHotel.Home.BD.dameDataTable(sAdapter);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dTable;
            dataGridView1.DataSource = bSource;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
            this.button2_Click(null, null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                consulta = "EXEC EN_CASA_ANDABA.altaCheckoutEstadia ";
                consulta = consulta + dataGridView1.CurrentRow.Cells[1].Value.ToString();
                consulta = consulta + ",'" + Home.fecha.Date.ToString("yyyyMMdd HH:mm:ss") + "',";
                consulta = consulta + Login.HomeLogin.idUsuario;
                resultado = Home.BD.comando(consulta);
                resultado.Read();
                if (resultado.GetDecimal(0) == 1)
                {
                    
                    resultado.Close();
                    Facturar_Estadia.Facturacion factu = new FrbaHotel.Facturar_Estadia.Facturacion(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    MessageBox.Show("El checkout se ha realizado correctamente. Se procede a la facturacion");
                    factu.Show();
                }
                else
                {
                    resultado.Close();
                    MessageBox.Show("El checkout no se pudo realizar correctamente");
                }
                this.Close();
            }
        }


    }
}

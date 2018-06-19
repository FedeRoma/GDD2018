using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class ListadoModif : Form
    {
        string consulta;
        SqlDataReader resultado;
        SqlDataAdapter sAdapter;
        DataTable dTable;
        public ListadoModif()
        {
            InitializeComponent();
            consulta = "select distinct tip_nombre from EN_CASA_ANDABA.TiposHabitaciones";
            resultado = Home.BD.comando(consulta);
            while (resultado.Read() == true)
            {
                comboBox1.Items.Add(resultado.GetSqlString(0));
            }
            resultado.Close();
            consulta = "select hot_calle + hot_calle_nro from EN_CASA_ANDABA.Hoteles where hot_id = " + Login.HomeLogin.hotel;
            resultado = Home.BD.comando(consulta);
            if (resultado.Read())
            {
                textBox6.Text = resultado.GetString(0);
            }
            resultado.Close();
            textBox1.Focus();
        }

        private void ListadoModif_Load(object sender, EventArgs e)
        {
            string query = "select hab.hab_numero Numero,hab.hab_piso Piso,hab.hab_des Descripcion,hab.hab_habilitado Estado from EN_CASA_ANDABA.Habitaciones hab, EN_CASA_ANDABA.Hoteles hot where hab.hab_hot_id = hot.hot_id and hot.hot_id = " + Login.HomeLogin.hotel;
            sAdapter = FrbaHotel.Home.BD.dameDataAdapter(query);
            dTable = FrbaHotel.Home.BD.dameDataTable(sAdapter);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dTable;
            dataGridView1.DataSource = bSource;
        }
        private string filtrarExactamentePor(string columna, string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                return columna + " = '" + valor + "' AND ";
            }
            return "";
        }

        private string filtrarAproximadamentePor(string columna, string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                return columna + " LIKE '%" + valor + "%' AND ";
            }
            return "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

            comboBox1.ResetText();
            textBox1.Focus();
            button2_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataView dvData = new DataView(dTable);
            string query = "";
            query = query + this.filtrarExactamentePor("Numero", textBox1.Text);
            query = query + this.filtrarExactamentePor("Piso", textBox2.Text);
            query = query + this.filtrarAproximadamentePor("Ubicacion", textBox3.Text);
            query = query + this.filtrarAproximadamentePor("Descripcion", textBox4.Text);
            query = query + this.filtrarExactamentePor("Tipo", comboBox1.Text);

            if (checkBox1.Checked)
            {
                query = query + "Estado = 1 and";
            }
            else
            {
                query = query + "Estado = 0 and";
            }

            if (query.Length > 0) { query = query.Remove(query.Length - 4); }
            dvData.RowFilter = query;
            dataGridView1.DataSource = dvData;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                
                string numero = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string piso = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string ubicacion = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string tipo = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                string descripcion = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                string estado = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                decimal id = 0;
                decimal tipoT = 0;
                consulta = "select tip_id from EN_CASA_ANDABA.TiposHabitaciones where tip_nombre = '" + tipo + "'";
                resultado = Home.BD.comando(consulta);
                if (resultado.Read())
                {
                    tipoT = resultado.GetDecimal(0);
                }
                resultado.Close();
                consulta = "select hab_id from EN_CASA_ANDABA.Habitaciones where hab_numero = " + numero + " and hab_piso = "+piso+" and hab_hotel = "+Login.HomeLogin.hotel+" and tip_nombre = "+tipoT;
                resultado = Home.BD.comando(consulta);
                if (resultado.Read())
                {
                    id = resultado.GetDecimal(0);
                }
                resultado.Close();

                Modificacion modif = new Modificacion(id,numero, piso,ubicacion,tipo,descripcion, estado);
                modif.Show();
            }
        }

        private void ListadoModif_Activated(object sender, EventArgs e)
        {
            string query = "select hab.hab_numero Numero,hab.hab_piso Piso,hab.hab_des Descripcion,hab.hab_habilitado Estado from EN_CASA_ANDABA.Habitaciones hab, EN_CASA_ANDABA.Hoteles hot where hab.hab_hot_id = hot.hot_id and hot.hot_id = " + Login.HomeLogin.hotel;
            sAdapter = FrbaHotel.Home.BD.dameDataAdapter(query);
            dTable = FrbaHotel.Home.BD.dameDataTable(sAdapter);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dTable;
            dataGridView1.DataSource = bSource;
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Cliente
{
    
    public partial class Baja : Form
    {
        string consulta;
        SqlDataReader resultado;
        SqlDataAdapter sAdapter;
        DataTable dTable;
        public Baja()
        {
            InitializeComponent();
            consulta = "select distinct doc_desc from EN_CASA_ANDABA.Documentos";
            resultado = Home.BD.comando(consulta);
            while (resultado.Read() == true)
            {
                comboBox1.Items.Add(resultado.GetSqlString(0));
            }
            resultado.Close();
            textBox1.Focus();
        }

        private void Baja_Load(object sender, EventArgs e)
        {
            string query = "select Cli.cli_nombre Nombre,Cli.cli_apellido Apellido,doc.doc_desc TipoDoc,Cli.cli_documento NroDoc,Cli.cli_mail Mail,Cli.cli_telefono Telefono,Cli.cli_nacionalidad Nacionalidad,Cli.cli_calle Calle, Cli.cli_calle_nro NumeroCalle,Cli.cli_fecha_nac Fecha_Nac from EN_CASA_ANDABA.Clientes Cli,EN_CASA_ANDABA.Documentos doc where	Cli.cli_documento = doc.doc_id";
            sAdapter = FrbaHotel.Home.BD.dameDataAdapter(query);
            dTable = FrbaHotel.Home.BD.dameDataTable(sAdapter);
            //BindingSource to sync DataTable and DataGridView
            BindingSource bSource = new BindingSource();
            //set the BindingSource DataSource
            bSource.DataSource = dTable;
            //set the DataGridView DataSource
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
            query = query + this.filtrarAproximadamentePor("Nombre", textBox1.Text);
            query = query + this.filtrarExactamentePor("TipoDoc", comboBox1.Text);
            query = query + this.filtrarAproximadamentePor("Apellido", textBox2.Text);
            query = query + this.filtrarExactamentePor("NroDoc", textBox4.Text);
            query = query + this.filtrarAproximadamentePor("Mail", textBox3.Text);
            if (query.Length > 0) { query = query.Remove(query.Length - 4); }
            dvData.RowFilter = query;
            dataGridView1.DataSource = dvData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.ResetText();
            textBox1.Focus();
            this.button2_Click(null, null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Direccion.mostraDir mostrar = new Direccion.mostraDir(dataGridView1.CurrentRow.Cells[9].Value.ToString());
                mostrar.Show();
            }
            if (e.ColumnIndex == 1)
            {
                if (dataGridView1.CurrentRow.Cells[11].Value.ToString() == "False")
                {
                    MessageBox.Show("El cliente ya esta dado de baja");
                    return;
                }
                decimal id=0; 
                
                string mail = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                consulta = "select cli_doc_id from EN_CASA_ANDABA.Clientes where cli_mail = '"+mail+"'";
                resultado = Home.BD.comando(consulta);
                if (resultado.Read() == true)
                {
                    id = resultado.GetDecimal(0);
                }
                resultado.Close();
                if (MessageBox.Show("Esta seguro que quiere inhabilitar el cliente?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    consulta = "update EN_CASA_ANDABA.Clientes set cli_habilitado=0 where cli_doc_id = " + id;

                    resultado = Home.BD.comando(consulta);
                    if (resultado.Read() == true)
                    {
                    }
                    resultado.Close();
                }
                dTable = FrbaHotel.Home.BD.dameDataTable(sAdapter);
                //BindingSource to sync DataTable and DataGridView
                BindingSource bSource = new BindingSource();
                //set the BindingSource DataSource
                bSource.DataSource = dTable;
                //set the DataGridView DataSource
                dataGridView1.DataSource = bSource;
                
            }

        
        }

        private void Baja_Activated(object sender, EventArgs e)
        {
    
        }
    }
}

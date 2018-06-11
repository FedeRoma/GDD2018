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
    public partial class ListadoModif : Form
    {
        public static decimal direccion = 0;
        string consulta;
        SqlDataReader resultado;
        SqlDataAdapter sAdapter;
        DataTable dTable;
        public ListadoModif()
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

        private void ListadoModif_Load(object sender, EventArgs e)
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
                decimal id=0; 
              
                string nombre = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string apellido = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string tipoDoc = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                string nroDoc = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                string mail = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                consulta = "select cli_doc_id from EN_CASA_ANDABA.Clientes where cli_mail = '"+mail+"'";
                resultado = Home.BD.comando(consulta);
                if (resultado.Read() == true)
                {
                    id = resultado.GetDecimal(0);
                }
                resultado.Close();
                string telefono= dataGridView1.CurrentRow.Cells[7].Value.ToString();
                string nacionalidad = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                string direccion=dataGridView1.CurrentRow.Cells[9].Value.ToString(); 
                string fecha_nac = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                string habilitado = dataGridView1.CurrentRow.Cells[11].Value.ToString();
               
                Modificacion modif = new Modificacion(id,nombre, apellido, tipoDoc, nroDoc, mail, telefono, nacionalidad, direccion, fecha_nac, habilitado);
                modif.Show();
                
            }
        }

        private void ListadoModif_Activated(object sender, EventArgs e)
        {
            ListadoModif_Load(null, null);
        }

    }
}

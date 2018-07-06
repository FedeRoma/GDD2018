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

namespace FrbaHotel.AbmHabitacion
{
    public partial class BajaHabitacion : Form
    {
        public static MenuAbmHabitacion AbmHab;
        private SqlDataReader qry;
        private SqlDataReader resultado;
        DataTable dTable;
        SqlDataAdapter sAdapter;
        string consulta;

        public BajaHabitacion()
        {
            
            InitializeComponent();
            this.tiposHabitacionesTableAdapter.Fill(this.gD1C2018DataSet.TiposHabitaciones);
            string consulta = "select hot_calle from EN_CASA_ANDABA.Hoteles where hot_id = " + Index.hotel;
            qry = Index.BD.consultaGetPuntero(consulta);
            if (qry.Read())
            {
                textBoxHotel.Text = qry.GetString(0);
            }
            qry.Close();
        }

        private void BajaHabitacion_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gD1C2018DataSet.TiposHabitaciones' table. You can move, or remove it, as needed.
           // this.tiposHabitacionesTableAdapter.Fill(this.gD1C2018DataSet.TiposHabitaciones);
            string query = "select hab.hab_numero Numero,hab.hab_piso Piso,hab.hab_desc Descripcion,hab.hab_habilitado Estado from EN_CASA_ANDABA.Habitaciones hab, EN_CASA_ANDABA.Hoteles hot where hab.hab_hot_id = hot.hot_id and hot.hot_id=" + Index.hotel;
            sAdapter = FrbaHotel.Index.BD.dameDataAdapter(query);
            dTable = FrbaHotel.Index.BD.dameDataTable(sAdapter);

            BindingSource bSource = new BindingSource();

            bSource.DataSource = dTable;

            dataGridView1.DataSource = bSource;


        }

        private void buscar_Click(object sender, EventArgs e)
        {

            DataView dvData = new DataView(dTable);
            string query = "";
            query = query + this.filtrarExactamentePor("Numero", textBoxNroHab.Text);
            query = query + this.filtrarExactamentePor("Piso", textBoxPiso.Text);
            query = query + this.filtrarAproximadamentePor("Ubicacion", textBoxUbicacion.Text);
            query = query + this.filtrarAproximadamentePor("Descripcion", textBoxDescripcion.Text);
            //query = query + this.filtrarExactamentePor("Tipo", comboBoxTipoHab.Text);  
          


            if (query.Length > 0) { query = query.Remove(query.Length - 4); }
            dvData.RowFilter = query;
            dataGridView1.DataSource = dvData;

        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            textBoxNroHab.Text = string.Empty;
            textBoxPiso.Text = string.Empty;
            textBoxUbicacion.Text = string.Empty;
            comboBoxTipoHab.ResetText();
            textBoxDescripcion.Text = string.Empty;
            textBoxNroHab.Focus();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmHab = new MenuAbmHabitacion();
            AbmHab.Show();
        }

        private string filtrarAproximadamentePor(string columna, string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                return columna + " LIKE '%" + valor + "%' AND ";
            }
            return "";
        }
        private string filtrarExactamentePor(string columna, string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                return columna + " = '" + valor + "' AND ";
            }
            return "";
        }

        private void Baja_Activated(object sender, EventArgs e)
        {
            string query = "select hab.hab_numero Numero,hab.hab_piso Piso,hab.hab_des Descripcion,hab.hab_habilitado Estado from EN_CASA_ANDABA.Habitaciones hab, EN_CASA_ANDABA.Hoteles hot where hab.hab_hot_id = hot.hot_id and hot.hot_id= " + Index.hotel;
            sAdapter = FrbaHotel.Index.BD.dameDataAdapter(query);
            dTable = FrbaHotel.Index.BD.dameDataTable(sAdapter);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dTable;
            dataGridView1.DataSource = bSource;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                string numero = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string piso = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string tipo = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                string estado = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                if (estado == "False")
                {
                    MessageBox.Show("No se puede eliminar porque ya esta en estado inactivo");
                    return;
                }

                if (MessageBox.Show("Estas seguro que desea eliminar?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    decimal id = 0;
                    decimal tipoT = 0;
                    consulta = "select tip_id from EN_CASA_ANDABA.TiposHabitaciones where tip_nombre = '" + tipo + "'";
                    resultado = Index.BD.consultaGetPuntero(consulta);
                    if (resultado.Read())
                    {
                        tipoT = resultado.GetDecimal(0);
                    }
                    resultado.Close();
                    consulta = "select hab_id from EN_CASA_ANDABA.Habitaciones where hab_numero = " + numero + " and hab_piso = " + piso + " and hab_hot_id = " + Index.hotel + " and hab_tip_id = " + tipoT;
                    resultado = Index.BD.consultaGetPuntero(consulta);
                    if (resultado.Read())
                    {
                        id = resultado.GetDecimal(0);
                    }
                    resultado.Close();

                    consulta = "update EN_CASA_ANDABA.Habitaciones set hab_habilitado=0 where hab_id = " + id;

                    resultado = Index.BD.consultaGetPuntero(consulta);
                    if (resultado.Read() == true)
                    {
                    }
                    resultado.Close();
                }
                BajaHabitacion_Load(null, null);

            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}

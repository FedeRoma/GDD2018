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
    public partial class ListadoHabitacionesMod : Form
    {
        string consulta;
        SqlDataReader resultado;
        SqlDataAdapter sAdapter;
        DataTable dTable;
        public static MenuAbmHabitacion AbmHab;

        public ListadoHabitacionesMod()
        {
            InitializeComponent();
            consulta = "select distinct tip_nombre from EN_CASA_ANDABA.TiposHabitaciones";
            resultado = Index.BD.consultaGetPuntero(consulta);
            while (resultado.Read() == true)
            {
                comboBoxTipoHab.Items.Add(resultado.GetSqlString(0));
            }
            resultado.Close();
            consulta = "select hot_calle from EN_CASA_ANDABA.Hoteles where hot_id = " + Index.hotel;
            resultado = Index.BD.consultaGetPuntero(consulta);
            if (resultado.Read())
            {
                textBoxHotel.Text = resultado.GetString(0);
            }
            resultado.Close();
            
        }
        private void ListadoHabitacionesMod_Load(object sender, EventArgs e)
        {
            string query = "select hab.hab_numero Numero,hab.hab_piso Piso,hab.hab_desc Descripcion,hab.hab_habilitado Estado from EN_CASA_ANDABA.Habitaciones hab, EN_CASA_ANDABA.Hoteles hot where hab.hab_hot_id = hot.hot_id and hot.hot_id = " + Index.hotel;
            sAdapter = FrbaHotel.Index.BD.dameDataAdapter(query);
            dTable = FrbaHotel.Index.BD.dameDataTable(sAdapter);
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

        private void ListadoHabitacionesMod_Load_1(object sender, EventArgs e)
        {

        }

        private void buscar_Click(object sender, EventArgs e)
        {
            DataView dvData = new DataView(dTable);
            string query = "";
            query = query + this.filtrarExactamentePor("Numero", textBoxNroHab.Text);
            query = query + this.filtrarExactamentePor("Piso", textBoxPiso.Text);
            query = query + this.filtrarAproximadamentePor("Ubicacion", textBoxUbicacion.Text);
            query = query + this.filtrarAproximadamentePor("Descripcion", textBoxDescripcion.Text);
            query = query + this.filtrarExactamentePor("Tipo", comboBoxTipoHab.Text);


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
                resultado = Index.BD.consultaGetPuntero(consulta);
                if (resultado.Read())
                {
                    tipoT = resultado.GetDecimal(0);
                }
                resultado.Close();
                consulta = "select hab_id from EN_CASA_ANDABA.Habitaciones where hab_numero = " + numero + " and hab_piso = " + piso + " and hab_hotel = " + Index.hotel + " and tip_nombre = " + tipoT;
                resultado = Index.BD.consultaGetPuntero(consulta);
                if (resultado.Read())
                {
                    id = resultado.GetDecimal(0);
                }
                resultado.Close();

                ModificacionHabitacion modif = new ModificacionHabitacion(id, numero, piso, ubicacion, tipo, descripcion, estado);
                modif.Show();
            }


        }
        private void ListadoModihabitacionesMod_Activated(object sender, EventArgs e)
        {
            string query = "select hab.hab_numero Numero,hab.hab_piso Piso,hab.hab_des Descripcion,hab.hab_habilitado Estado from EN_CASA_ANDABA.Habitaciones hab, EN_CASA_ANDABA.Hoteles hot where hab.hab_hot_id = hot.hot_id and hot.hot_id = " + Index.hotel;
            sAdapter = FrbaHotel.Index.BD.dameDataAdapter(query);
            dTable = FrbaHotel.Index.BD.dameDataTable(sAdapter);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dTable;
            dataGridView1.DataSource = bSource;
        }
    }
}

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
    public partial class ListadoHabitaciones : Form
    {
        public static MenuAbmHabitacion AbmHab;
        string consulta;
        SqlDataReader resultado;
        SqlDataAdapter sAdapter;
        DataTable dTable;
        public ListadoHabitaciones()
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
            textBoxHotel.Focus();


        }

        private void Listado_Load(object sender, EventArgs e)
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

        private void comboBoxTipoHab_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxHotel_TextChanged(object sender, EventArgs e)
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


            if (checkBoxEstado.Checked)
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

        private void limpiar_Click(object sender, EventArgs e)
        {
            textBoxNroHab.Clear();
            textBoxUbicacion.Clear();
            textBoxPiso.Clear();
            textBoxDescripcion.Clear();

            comboBoxTipoHab.ResetText();
            
            
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmHab = new MenuAbmHabitacion();
            AbmHab.Show();
        }

        private void checkBoxEstado_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

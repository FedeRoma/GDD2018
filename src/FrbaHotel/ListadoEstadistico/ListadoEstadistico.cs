using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Listado_Estadistico
{
    public partial class ListadoEstadistico : Form
    {
        SqlDataAdapter sAdapter;
        DataTable dTable;
        public ListadoEstadistico()
        {
            InitializeComponent();
            trimestre.Items.Add("1");
            trimestre.Items.Add( "2");
            trimestre.Items.Add( "3");
            trimestre.Items.Add( "4");
            
            int i = 0;
            for (i = 2009; i <= 2018; i++)
                anio.Items.Add(i);

            tipoListado.Items.Insert(0, "Hotel con mas reservas canceladas");
            tipoListado.Items.Insert(1, "Hotel con mas consumibles  facturados");
            tipoListado.Items.Insert(2, "Hotel con mas dias fuera de servicio");
            tipoListado.Items.Insert(3, "Cliente con mas puntos");
            tipoListado.Items.Insert(4, "Habitaciones mas ocupadas");

        }

        private void tipoListado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void anio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void trimestre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(anio.Text))
            {
                MessageBox.Show("Debe seleccionar un anio");
                return;
            }
            if(string.IsNullOrEmpty(trimestre.Text))
            {
                MessageBox.Show("Debe seleccionar un anio");
                return;
            }
            if(string.IsNullOrEmpty(tipoListado.Text))
            {
                MessageBox.Show("Debe seleccionar un anio");
                return;
            }
            String tipoSeleccionado = "";
            switch (tipoListado.SelectedIndex)
            {
                case 0:
                    tipoSeleccionado = "EXEC EN_CASA_ANDABA.top5_hoteles_reservas_canceladas " + trimestre.Text + ", " + anio.Text;
                    break;
                case 1:
                    tipoSeleccionado = "EXEC EN_CASA_ANDABA.top5_hoteles_consumibles_facturados " + trimestre.Text + ", " + anio.Text;
                    break;
                case 2:
                    tipoSeleccionado = "EXEC EN_CASA_ANDABA.top5_hoteles_dias_fuera_de_servicio " + trimestre.Text + ", " + anio.Text;
                    break;
                case 3:
                    tipoSeleccionado = "EXEC EN_CASA_ANDABA.top5_clientes_puntos " + (trimestre.Text) + ", " + anio.Text;
                    break;
                case 4:
                    tipoSeleccionado = "EXEC EN_CASA_ANDABA.top5_habitaciones_veces_ocupadas " + (trimestre.Text) + "," + anio.Text;
                    break;
            }
            
            sAdapter = FrbaHotel.Home.BD.dameDataAdapter(tipoSeleccionado);
            dTable = FrbaHotel.Home.BD.dameDataTable(sAdapter);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dTable;
            dataGridView1.DataSource = bSource;
        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dTable.Clear();

        }

        private void ListadoEstadistico_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login.HomeLogin.mainFun.Show();
        }

        private void button_cerrar_Click_1(object sender, EventArgs e)
        {
            
            this.Close();
            
        }
    }
}

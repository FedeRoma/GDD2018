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

namespace FrbaHotel.ListadoEstadistico
{
    public partial class ListadosEstadisticos : Form
    {
        public static Login.MenuFuncionalidades menuFuncionalidades;
        DataTable tablaListados;
        private int i;
        private string sp = "";
        
        public ListadosEstadisticos()
        {
            InitializeComponent();

            for (i = 2000; i <= 2018; i++)
            {
                anio.Items.Add(i);
            }

            for (i = 1; i < 5; i++)
            {
                trimestre.Items.Add(i);
            }

            top5.Items.Insert(0, "Hoteles con mayor cantidad de reservas canceladas");
            top5.Items.Insert(1, "Hoteles con mayor cantidad de consumibles facturados");
            top5.Items.Insert(2, "Hoteles con mayor cantidad de días fuera de servicio");
            top5.Items.Insert(3, "Habitaciones con mayor cantidad de días y veces que fueron ocupadas");
            top5.Items.Insert(4, "Cliente con mayor cantidad de puntos");
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(anio.Text))
            {
                MessageBox.Show("#error: debe seleccionar un año para continuar");
                anio.Focus();
                return;
            }
            if (string.IsNullOrEmpty(trimestre.Text))
            {
                MessageBox.Show("#error: debe seleccionar un trimestre para continuar");
                trimestre.Focus();
                return;
            }
            if (string.IsNullOrEmpty(top5.Text))
            {
                MessageBox.Show("#error: debe seleccionar un top 5 para continuar");
                top5.Focus();
                return;
            }
  
            switch (top5.SelectedIndex)
            {
                case 0:
                    sp = "exec EN_CASA_ANDABA.top5_hoteles_reservas_canceladas " + trimestre.Text + "," + anio.Text;
                    break;
                case 1:
                    sp = "exec EN_CASA_ANDABA.top5_hoteles_consumibles_facturados " + trimestre.Text + "," + anio.Text;
                    break;
                case 2:
                    sp = "exec EN_CASA_ANDABA.top5_hoteles_dias_fuera_de_servicio " + trimestre.Text + "," + anio.Text;
                    break;
                case 3:
                    sp = "exec EN_CASA_ANDABA.top5_habitaciones_veces_ocupadas " + trimestre.Text + "," + anio.Text;
                    break;
                case 4:
                    sp = "exec EN_CASA_ANDABA.top5_clientes_puntos " + trimestre.Text + "," + anio.Text;
                    break;
            }

            tablaListados = Index.BD.consultaGetTabla(sp);
            BindingSource bindingSourceTop5 = new BindingSource();
            bindingSourceTop5.DataSource = tablaListados;
            topFive.DataSource = bindingSourceTop5;        
            
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            anio.ResetText();
            trimestre.ResetText();
            top5.ResetText();
            topFive.DataSource = null;
            topFive.Rows.Clear();
            anio.Focus();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            menuFuncionalidades = new Login.MenuFuncionalidades();
            menuFuncionalidades.Show();
            this.Close();
        }
    }
}

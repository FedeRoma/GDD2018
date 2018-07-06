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
        private SqlDataReader qry;
        public static MenuAbmHabitacion AbmHab;
        public static ModificacionHabitacion ModifHab;
        DataTable tablaHabitaciones;

        private class TipoHabitacion
        {
            public string Nombre;
            public int Valor;
            public TipoHabitacion(int valor, string nombre)
            {
                Nombre = nombre;
                Valor = valor;
            }
            public override string ToString()
            {
                return Nombre;
            }
        }
        
        public ListadoHabitaciones()
        {
            InitializeComponent();

            qry = Index.BD.consultaGetPuntero("select distinct tip_id, tip_nombre from EN_CASA_ANDABA.TiposHabitaciones");
            while (qry.Read())
            {
                tipoHabitacion.Items.Add(new TipoHabitacion(qry.GetInt32(0), qry.GetString(1)));
            }
            qry.Close();
        }

        private void ListadoHabitaciones_Load(object sender, EventArgs e)
        {
            qry = Index.BD.consultaGetPuntero("select distinct hot_calle, hot_calle_nro from EN_CASA_ANDABA.Hoteles where hot_id = " + Index.hotel);
            qry.Read();
            hotelActivo.Items.Add(qry.GetString(0) + " " + qry.GetInt32(1).ToString());
            qry.Close();

            DataGridViewButtonColumn botonModif = new DataGridViewButtonColumn();
            botonModif.Name = "modif";
            listaHabitaciones.Columns.Add(botonModif);

            tablaHabitaciones = Index.BD.consultaGetTabla("select Ha.hab_numero NUMERO, Ha.hab_piso PISO, Ha.hab_vista VISTA, T.tip_nombre TIPO, Ha.hab_desc DESCRIPCION, Ha.hab_habilitado HABILITADO from	EN_CASA_ANDABA.Habitaciones Ha, EN_CASA_ANDABA.Hoteles H, EN_CASA_ANDABA.TiposHabitaciones T where Ha.hab_hot_id = H.hot_id and T.tip_id = Ha.hab_tip_id and H.hot_id = " + Index.hotel);
            BindingSource bindingSourceListaHabitaciones = new BindingSource();
            bindingSourceListaHabitaciones.DataSource = tablaHabitaciones;
            listaHabitaciones.DataSource = bindingSourceListaHabitaciones;  
        }

        private string esExactamente(string col, string clave)
        {
            if (!string.IsNullOrEmpty(clave))
            {
                return col + " = '" + clave + "' and ";
            }
            return "";
        }
        private string esAproximadamente(string col, string clave)
        {
            if (!string.IsNullOrEmpty(clave))
            {
                return col + " like '%" + clave + "%' and ";
            }
            return "";
        }

        private void listaHabitaciones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.listaHabitaciones.Columns[e.ColumnIndex].Name == "modif" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonModif = this.listaHabitaciones.Rows[e.RowIndex].Cells["modif"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\pencil.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.listaHabitaciones.Rows[e.RowIndex].Height = icono.Height + 5;
                this.listaHabitaciones.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }
        }

        private void listaHabitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listaHabitaciones.Columns[e.ColumnIndex].Name == "modif")
            {
                string numero = listaHabitaciones.CurrentRow.Cells[1].Value.ToString();
                string piso = listaHabitaciones.CurrentRow.Cells[2].Value.ToString();
                string vista = listaHabitaciones.CurrentRow.Cells[3].Value.ToString();
                string tipo = listaHabitaciones.CurrentRow.Cells[4].Value.ToString();
                string descripcion = listaHabitaciones.CurrentRow.Cells[5].Value.ToString();
                string estado = listaHabitaciones.CurrentRow.Cells[6].Value.ToString();

                ModifHab = new ModificacionHabitacion(numero, piso, vista, tipo, descripcion, estado);
                ModifHab.Show();
                this.Hide();
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            DataView vistaHabitaciones = new DataView(tablaHabitaciones);
            string filtro = "";
            filtro = filtro + this.esExactamente("NUMERO", numero.Text);
            filtro = filtro + this.esExactamente("PISO", piso.Text);
            filtro = filtro + this.esExactamente("VISTA", vista.Text);
            filtro = filtro + this.esExactamente("TIPO", tipoHabitacion.Text);

            if (filtro.Length > 0) 
            { 
                filtro = filtro.Remove(filtro.Length - 4); 
            }
            
            vistaHabitaciones.RowFilter = filtro;
            listaHabitaciones.DataSource = vistaHabitaciones;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            numero.Text = string.Empty;            
            piso.Text = string.Empty;
            vista.Text = string.Empty;
            tipoHabitacion.ResetText();
            numero.Focus();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmHab = new MenuAbmHabitacion();
            AbmHab.Show();
        }

    }
}

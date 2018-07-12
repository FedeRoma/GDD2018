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
        private SqlDataReader qry;
        public static MenuAbmHabitacion AbmHab;
        DataTable tablaHabitaciones;
        String estaReservada = "0";
        int resultado = 0;
        
        

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

        public BajaHabitacion()
        {
            InitializeComponent();

            qry = Index.BD.consultaGetPuntero("select distinct tip_id, tip_nombre from EN_CASA_ANDABA.TiposHabitaciones");
            while (qry.Read())
            {
                tipoHabitacion.Items.Add(new TipoHabitacion(qry.GetInt32(0), qry.GetString(1)));
            }
            qry.Close();
        }

        private void BajaHabitacion_Load(object sender, EventArgs e)
        {
            qry = Index.BD.consultaGetPuntero("select distinct hot_calle, hot_calle_nro from EN_CASA_ANDABA.Hoteles where hot_id = " + Index.hotel);
            qry.Read();
            hotelActivo.Items.Add(qry.GetString(0) + " " + qry.GetInt32(1).ToString());
            qry.Close();

            DataGridViewButtonColumn botonBaja = new DataGridViewButtonColumn();
            botonBaja.Name = "baja";
            listaHabitaciones.Columns.Add(botonBaja);

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
            if (e.ColumnIndex >= 0 && this.listaHabitaciones.Columns[e.ColumnIndex].Name == "baja" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonBaja = this.listaHabitaciones.Rows[e.RowIndex].Cells["baja"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\cross-script.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.listaHabitaciones.Rows[e.RowIndex].Height = icono.Height + 5;
                this.listaHabitaciones.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }
        }

        private void listaHabitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listaHabitaciones.Columns[e.ColumnIndex].Name == "baja")
            {
                if (listaHabitaciones.CurrentRow.Cells[6].Value.ToString() == "False")
                {
                    MessageBox.Show("#error: la habitación seleccionada ya se encuentra deshabilitada");
                    return;
                }

                string habitacionNro = listaHabitaciones.CurrentRow.Cells[1].Value.ToString();
                string habitacionPiso = listaHabitaciones.CurrentRow.Cells[2].Value.ToString();
                int habitacionID = 0;

                qry = Index.BD.consultaGetPuntero("select hab_id from EN_CASA_ANDABA.Habitaciones where hab_numero = " + habitacionNro + " and hab_piso = " + habitacionPiso + " and hab_hot_id = " + Index.hotel);
                if (qry.Read())
                {
                    habitacionID = qry.GetInt32(0);
                }
                qry.Close();

                if (MessageBox.Show("Esta seguro que quiere inhabilitar la habitación?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DateTime desde = DateTime.Today;
                    DateTime hasta = desde.AddYears(10);
                    //qry = Index.BD.consultaGetPuntero("select EN_CASA_ANDABA.estaReservadaHabitacion(" + desde.Date.ToString() + "," + hasta.Date.ToString() + "," + habitacionID.ToString() + ")");
                    //qry = Index.BD.consultaGetPuntero("select EN_CASA_ANDABA.estaReservadaHabitacion ('" + desde.Date.ToString() + "','" + hasta.Date.ToString() + "'," + habitacionID.ToString() + ")");
                    int resultado = Index.BD.consultaGetInt("select EN_CASA_ANDABA.estaReservadaHabitacion ('" + desde.Date.ToString() + "','" + hasta.Date.ToString() + "'," + habitacionID.ToString() + ")");

                    if (resultado == 0)
                    {
                        qry = Index.BD.consultaGetPuntero("update EN_CASA_ANDABA.Habitaciones set hab_habilitado = 0 where hab_id = " + habitacionID.ToString());
                        qry.Close();
                    }
                    else
                    {
                        MessageBox.Show("La Habitacion no se puede eliminar ya que tiene reservas", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                

                tablaHabitaciones = Index.BD.consultaGetTabla("select Ha.hab_numero NUMERO, Ha.hab_piso PISO, Ha.hab_vista VISTA, T.tip_nombre TIPO, Ha.hab_desc DESCRIPCION, Ha.hab_habilitado HABILITADO from	EN_CASA_ANDABA.Habitaciones Ha, EN_CASA_ANDABA.Hoteles H, EN_CASA_ANDABA.TiposHabitaciones T where Ha.hab_hot_id = H.hot_id and T.tip_id = Ha.hab_tip_id and H.hot_id = " + Index.hotel);
                BindingSource bindingSourceListaHabitaciones = new BindingSource();
                bindingSourceListaHabitaciones.DataSource = tablaHabitaciones;
                listaHabitaciones.DataSource = bindingSourceListaHabitaciones;        
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            DataView vistaHabitaciones = new DataView(tablaHabitaciones);
            string filtro = "";
            filtro = filtro + this.esExactamente("NUMERO", numero.Text);
            filtro = filtro + this.esExactamente("PISO", piso.Text);
            filtro = filtro + this.esAproximadamente("VISTA", vista.Text);
            filtro = filtro + this.esAproximadamente("TIPO", tipoHabitacion.Text);

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

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

namespace FrbaHotel.RegistrarEstadia
{
    public partial class AsignarClientesHabitacion : Form
    {
        private SqlDataReader qry;
        DataTable tablaClientes;
        public static AsignarClientesEstadia ClientesEstadia;
        string numeroReserva, numeroEstadia;
        int cantHuespedes = 0;

        public AsignarClientesHabitacion(DataTable tablaCli, string reserva, string estadia)
        {
            InitializeComponent();

            numeroEstadia = estadia;
            numeroReserva = reserva;

            DataGridViewButtonColumn botonAsignar = new DataGridViewButtonColumn();
            botonAsignar.Name = "asignar";
            listaClientes.Columns.Add(botonAsignar);

            tablaClientes = tablaCli;
            listaClientes.DataSource = tablaClientes;

            qry = Index.BD.consultaGetPuntero("select ryh_hab_id from EN_CASA_ANDABA.Reservas_Habitaciones where ryh_res_id = " + numeroReserva);
            while (qry.Read())
            {
                habitacion.Items.Add(qry.GetInt32(0));
            }
            qry.Close();
        }

        private void habitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            qry = Index.BD.consultaGetPuntero("select H.hab_numero, H.hab_piso, TH.tip_nombre, TH.tip_personas from EN_CASA_ANDABA.Habitaciones H, EN_CASA_ANDABA.TiposHabitaciones TH where H.hab_tip_id = TH.tip_id and H.hab_id = " + habitacion.Text);
            if (qry.Read())
            {
                numeroHabitacion.Text = qry.GetInt32(0).ToString();
                pisoHabitacion.Text = qry.GetInt32(1).ToString();
                tipoHabitacion.Text = qry.GetString(2).ToString();
                capacidadHabitacion.Text = qry.GetInt32(3).ToString();
            }
            else
            {
                MessageBox.Show("#error: la habitación no existe");
            }
            qry.Close();
        }

        private void listaClientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.listaClientes.Columns[e.ColumnIndex].Name == "asignar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonAsignar = this.listaClientes.Rows[e.RowIndex].Cells["asignar"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\plus.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.listaClientes.Rows[e.RowIndex].Height = icono.Height + 5;
                this.listaClientes.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }
        }

        private void listaClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listaClientes.Columns[e.ColumnIndex].Name == "asignar")
            {
                if (Convert.ToInt32(habitacion.SelectedIndex) == -1)
                {
                    MessageBox.Show("Debe seleccionar una habitacion");
                    return;
                }

                int indice = listaClientes.CurrentRow.Index;
                qry = Index.BD.consultaGetPuntero("select count (*) from EN_CASA_ANDABA.Clientes_Estadias where cye_est_res_id = " + numeroEstadia + " and cye_hab_id = " + habitacion.Text);
                if (qry.Read())
                {
                    cantHuespedes = qry.GetInt32(0);
                }
                qry.Close();

                if (cantHuespedes < Convert.ToInt32(capacidadHabitacion.Text))
                {
                    string tipoDocumento = listaClientes.CurrentRow.Cells[1].Value.ToString();
                    string nroDocumento = listaClientes.CurrentRow.Cells[2].Value.ToString();
                    
                    int resultado = Index.BD.consultaGetInt("exec EN_CASA_ANDABA.modificacionClientes_Estadias " + nroDocumento + ", '" + tipoDocumento + "', " + numeroEstadia + ", " + habitacion.Text + ", " + Index.hotel);
                    if (resultado == 0)
                    {
                        MessageBox.Show("#error: el cliente ya está asignado a la estadía");
                        return;
                    }
                    MessageBox.Show("El cliente se ha asignado correctamente");
                    tablaClientes.Rows.RemoveAt(indice);
                    listaClientes.DataSource = tablaClientes;
                }
                else
                {
                    MessageBox.Show("#error: la habitación ya se encuentra completa");
                }
            }
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (tablaClientes.Rows.Count == 0)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Aún hay clientes pendientes de agregar a la estadía");
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            ClientesEstadia = new AsignarClientesEstadia(numeroReserva, numeroEstadia);
            ClientesEstadia.Show();
        }

    }
}

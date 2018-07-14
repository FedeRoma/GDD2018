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
    public partial class AsignarClientesEstadia : Form
    {
        private SqlDataReader qry;
        public static MenuRegistrarEstadia MenuEstadia;
        public static RegistrarEstadia.AsignarClientesHabitacion AsignarCliHab;
        public static string reservaID, estadiaID;
        public static int plazasTotales, plazasDisponibles;
        Int64 clienteNroDocumento;
        string clienteTipoDocumento, clienteNombre, clienteApellido;
        public static DataTable tablaClientes;

        public AsignarClientesEstadia(string reserva, string estadia)
        {
            InitializeComponent();

            reservaID = reserva;
            estadiaID = estadia;

            tablaClientes = new DataTable();
            tablaClientes.Columns.Add("TIPO DOCUMENTO");
            tablaClientes.Columns.Add("NRO DOCUMENTO");
            tablaClientes.Columns.Add("NOMBRE");
            tablaClientes.Columns.Add("APELLIDO");
                        
            BindingSource bindingSourcelistaClientes = new BindingSource();
            bindingSourcelistaClientes.DataSource = tablaClientes;
            listaClientes.DataSource = bindingSourcelistaClientes;

            qry = Index.BD.consultaGetPuntero("select sum(TH.tip_personas) from EN_CASA_ANDABA.Reservas_Habitaciones RH, EN_CASA_ANDABA.Habitaciones H, EN_CASA_ANDABA.TiposHabitaciones TH where RH.ryh_hab_id = H.hab_id and TH.tip_id = H.hab_tip_id and RH.ryh_res_id = " + reservaID);
            if (qry.Read())
            {
                plazasTotales = qry.GetInt32(0);
                capacidadHabitacion.Text = plazasTotales.ToString();
            }
            else
            {
                MessageBox.Show("#error: No hay especificada una habitación en la reserva");
            }
            qry.Close();

            qry = Index.BD.consultaGetPuntero("select D.doc_desc [TIPO DOCUMENTO], C.cli_documento [NRO DOCUMENTO], C.cli_nombre NOMBRE, C.cli_apellido APELLIDO from EN_CASA_ANDABA.Reservas R, EN_CASA_ANDABA.Clientes C, EN_CASA_ANDABA.Documentos D where R.res_cli_doc_id = C.cli_doc_id and r.res_cli_documento = c.cli_documento and C.cli_doc_id = D.doc_id and R.res_id = " + reservaID);
            if (qry.Read())
            {
                clienteTipoDocumento = qry.GetString(0);
                clienteNroDocumento = qry.GetInt64(1);
                clienteNombre = qry.GetString(2);
                clienteApellido = qry.GetString(3); 
                titularEstadia.Text = qry.GetString(2) + " " + qry.GetString(3);
                plazasDisponibles = plazasTotales - 1;
                plazasRestantes.Text = (plazasDisponibles).ToString();

                DataRow fila = tablaClientes.NewRow();

                fila["TIPO DOCUMENTO"] = clienteTipoDocumento;
                fila["NRO DOCUMENTO"] = clienteNroDocumento;
                fila["NOMBRE"] = clienteNombre;
                fila["APELLIDO"] = clienteApellido;
                tablaClientes.Rows.Add(fila);
                numeroReserva.Text = reservaID;
            }
            qry.Close();
        }

        private void nuevoCliente_Click(object sender, EventArgs e)
        {
            if (plazasDisponibles > 0)
            {
                AbmCliente.AltaCliente altaCliente= new AbmCliente.AltaCliente();
                altaCliente.Show();
            }
            else
            {
                MessageBox.Show("Ya se han completado las plazas");
            }
        }

        private void seleccionarCliente_Click(object sender, EventArgs e)
        {
            if (plazasDisponibles > 0)
            {
                BuscarClientes buscarClientes = new BuscarClientes();
                buscarClientes.Show();
            }
            else
            {
                MessageBox.Show("Ya se han completado las plazas");
            }
        }

        private void AsignarClientesEstadia_Activated(object sender, EventArgs e)
        {
            bindingSourcelistaClientes.DataSource = tablaClientes;
            plazasRestantes.Text = plazasDisponibles.ToString();
        }

        private void listaClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int item = listaClientes.CurrentRow.Index;
                if (listaClientes.CurrentRow.Cells[3].Value.ToString() == clienteTipoDocumento && listaClientes.CurrentRow.Cells[4].Value.ToString() == clienteNroDocumento.ToString())
                {
                    MessageBox.Show("No se puede eliminar al titular de la reserva");
                    return;
                }
                plazasDisponibles++;
                tablaClientes.Rows.RemoveAt(item);
                listaClientes.DataSource = tablaClientes;
            }
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            foreach (DataRow fila in tablaClientes.Rows)
            {
                qry = Index.BD.consultaGetPuntero("exec EN_CASA_ANDABA.altaClientes_Estadias " + clienteNroDocumento.ToString() + ", '" + clienteTipoDocumento + "', " + estadiaID + ", 1, " + Index.hotel);
                if (qry.Read())
                {
                    if (qry.GetInt32(0) == 0)
                    {
                        MessageBox.Show("El cliente ya se encuentra asignado");
                    }
                }
                else
                {
                    MessageBox.Show("#error: No se ha podido dar de alta el cliente");
                }
                qry.Close();
            }

            MessageBox.Show("Se han cargado todos los clientes");
            AsignarCliHab = new RegistrarEstadia.AsignarClientesHabitacion(tablaClientes, reservaID, estadiaID);
            AsignarCliHab.Show();

            this.Close();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            tablaClientes.Clear();
            plazasDisponibles = plazasTotales - 1;
            DataRow fila = tablaClientes.NewRow();
            fila["TIPO DOCUMENTO"] = clienteTipoDocumento;
            fila["NRO DOCUMENTO"] = clienteNroDocumento;
            fila["NOMBRE"] = clienteNombre;
            fila["APELLIDO"] = clienteApellido;
            tablaClientes.Rows.Add(fila);
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuEstadia = new MenuRegistrarEstadia();
            MenuEstadia.Show();
        }

    }
}

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

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class GenerarReserva : Form
    {
        private SqlDataReader qry;
        public static Login.Login login;
        public static Login.MenuFuncionalidades menuFuncionalidades;
        public static AbmCliente.AltaCliente nuevoCli;
        DataTable tablaHabitaciones;
        string calle;
        int calleNumero, i, j, dias, totalH, totalHA;
        string habitaciones, habitacionesAsig, insert;

        private class TipoDocumento
        {
            public string Nombre;
            public int Valor;
            public TipoDocumento(int valor, string nombre)
            {
                Nombre = nombre;
                Valor = valor;
            }
            public override string ToString()
            {
                return Nombre;
            }
        }

        public GenerarReserva()
        {
            InitializeComponent();

            tablaHabitaciones = new DataTable();

            qry = Index.BD.consultaGetPuntero("select distinct doc_id, doc_desc from EN_CASA_ANDABA.Documentos");
            while (qry.Read())
            {
                tipoDocumento.Items.Add(new TipoDocumento(qry.GetInt32(0), qry.GetString(1)));
            }
            qry.Close();

            desde.Value = DateTime.Today;
            hasta.Value = DateTime.Today;

            qry = Index.BD.consultaGetPuntero("select distinct hot_calle, hot_calle_nro from EN_CASA_ANDABA.Hoteles where hot_id = " + Index.hotel);
            qry.Read();
            calle = qry.GetString(0);
            calleNumero = qry.GetInt32(1);
            hotelActivo.Text = calle + " " + calleNumero;
            qry.Close();

            qry = Index.BD.consultaGetPuntero("exec EN_CASA_ANDABA.buscarRegimenesHotel '" + calle + "', " + calleNumero.ToString());
            while (qry.Read())
            {
                regimen.Items.Add(qry.GetString(0));
            }
            qry.Close();

            qry = Index.BD.consultaGetPuntero("exec EN_CASA_ANDABA.buscarTiposHabitacionesHotel '" + calle + "', " + calleNumero.ToString());
            while (qry.Read())
            {
                tipoHabitacion.Items.Add(qry.GetString(0));
            }
            qry.Close();

            tablaHabitaciones.Columns.Add("ID");
            DataColumn columna = tablaHabitaciones.Columns["ID"];
            columna.Unique = true;
            tablaHabitaciones.Columns.Add("PRECIO");
        }

        private void tipoHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            qry = Index.BD.consultaGetPuntero("select tip_personas from EN_CASA_ANDABA.TiposHabitaciones where tip_nombre = '" + tipoHabitacion.SelectedItem.ToString() + "'");
            if (qry.Read())
            {
                cantidadPersonas.Text = qry.GetInt32(0).ToString();
            }
            qry.Close();
        }

        private void listaHabitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string idHab = listaHabitaciones.CurrentRow.Cells[1].Value.ToString();
                string precioHab = listaHabitaciones.CurrentRow.Cells[3].Value.ToString();
                string regimenHab = listaHabitaciones.CurrentRow.Cells[4].Value.ToString();
                int item = listaHabitaciones.CurrentRow.Index;

                DataRow fila = tablaHabitaciones.NewRow();
                fila["ID"] = idHab;
                fila["PRECIO"] = precioHab;
                try
                {
                    tablaHabitaciones.Rows.Add(fila);

                    if (j == 0)
                    {
                        habitaciones = habitaciones + idHab;
                        if (string.IsNullOrEmpty(regimen.Text))
                        {
                            regimen.Text = regimenHab;
                        }
                        regimen.Enabled = false;
                        desde.Enabled = false;
                        hasta.Enabled = false;
                        dias = hasta.Value.Date.Subtract(desde.Value.Date).Days;
                    }
                    else
                    {
                        habitacionesAsig = habitacionesAsig + "," + idHab;
                    }
                    totalHA = totalHA + (((int)listaHabitaciones.CurrentRow.Cells[3].Value) * dias);
                    listaHabitaciones.Rows.RemoveAt(item);
                    total.Text = totalHA.ToString();
                    j++;
                    listaHabitacionesAsig.DataSource = bindingSourceListaHabitacionesAsig;
                }
                catch
                {
                    MessageBox.Show("La habitación seleccionada ya fue agregada con anterioridad");
                }
            }
        }

        private void numeroDocumento_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private string insertString(string campo)
        {
            if (string.IsNullOrEmpty(campo))
            {
                insert = insert + "null,";
            }
            else
            {
                insert = insert + "'" + campo + "',";
            }
            return insert;
        }

        private string insertNro(string campo)
        {
            if (string.IsNullOrEmpty(campo))
            {
                insert = insert + "null,";
            }
            else
            {
                insert = insert + "" + campo + ",";
            }
            return insert;
        }

        private void buscarHabitaciones_Click(object sender, EventArgs e)
        {
            listaHabitaciones.DataSource = null;

            if (string.IsNullOrEmpty(regimen.Text))
            {
                MessageBox.Show("Debe seleccionar un régimen");
                return;
            }
            if (string.IsNullOrEmpty(tipoHabitacion.Text))
            {
                MessageBox.Show("Debe seleccionar un tipo de habitación");
                return;
            }
            if (DateTime.Compare(Convert.ToDateTime(desde.Value), Convert.ToDateTime(hasta.Value)) >= 0)
            {
                MessageBox.Show("La fecha de inicio debe ser menor a la fecha de fin\n");
                return;
            }
            if (DateTime.Compare(Convert.ToDateTime(desde.Value), DateTime.Today) < 0)
            {
                MessageBox.Show("La fecha de inicio debe ser posterior a la fecha actual\n");
                return;
            }

            insert = "exec EN_CASA_ANDABA.buscarHabitacionesDisponibles ";
            insert = insertString(calle);
            insert = insertString(calleNumero.ToString());
            
            DateTime fechaDesde;
            fechaDesde = Convert.ToDateTime(desde.Value);
            insert = insertString(fechaDesde.Date.ToString("yyyyMMdd HH:mm:ss"));
            DateTime fechaHasta;
            fechaHasta = Convert.ToDateTime(desde.Value);
            insert = insertString(fechaHasta.Date.ToString("yyyyMMdd HH:mm:ss"));

            insert = insertString(regimen.Text);
            insert = insertString(tipoHabitacion.Text);

            insert = insert.Remove(insert.Length - 1);

            tablaHabitaciones = Index.BD.consultaGetTabla(insert);
            BindingSource bindingSourceListaHabitaciones = new BindingSource();
            bindingSourceListaHabitaciones.DataSource = tablaHabitaciones;
            listaHabitaciones.DataSource = bindingSourceListaHabitaciones;
        }

        private void regimen_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaHabitacionesAsig.DataSource = null;
            j = 0;
            habitacionesAsig = "";
            totalHA = 0;
            tablaHabitaciones.Clear();
        }

        private void desde_ValueChanged(object sender, EventArgs e)
        {
            regimen_SelectedIndexChanged(null, null);
        }
        private void hasta_ValueChanged(object sender, EventArgs e)
        {
            regimen_SelectedIndexChanged(null, null);
        }

        private bool checkCampos()
        {
            bool inconsistencias = false;
            string alerta = "";

            if ((string.IsNullOrEmpty(tipoDocumento.Text) || string.IsNullOrEmpty(nroDocumento.Text)))
            {
                alerta = alerta + "Debe ingresar un documento válido\n";
                inconsistencias = true;
            }
            else
            {
                qry = Index.BD.consultaGetPuntero("select * from EN_CASA_ANDABA.Clientes, EN_CASA_ANDABA.Documentos where cli_doc_id = doc_id and doc_desc = '" + tipoDocumento.Text + "' and cli_documento = " + nroDocumento.Text);
                if (!qry.Read())
                {
                    alerta = alerta + "Cliente no registrado\n";
                    inconsistencias = true;
                }
                qry.Close();
            }
           
            if (inconsistencias)
            {
                MessageBox.Show(alerta);
            }
            return inconsistencias;
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (habitacionesAsig == "" || j == 0)
            {
                MessageBox.Show("Debe seleccionar por lo menos una habitacion");
                return;
            }
            if (string.IsNullOrEmpty(tipoDocumento.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente");
                return;
            }

            if (!checkCampos())
            {
                insert = "exec EN_CASA_ANDABA.AltaReserva ";

                DateTime fechaHoy;
                fechaHoy = Convert.ToDateTime(DateTime.Today);
                insert = insertString(fechaHoy.Date.ToString("yyyyMMdd HH:mm:ss"));
                DateTime fechaDesde;
                fechaDesde = Convert.ToDateTime(desde.Value);
                insert = insertString(fechaDesde.Date.ToString("yyyyMMdd HH:mm:ss"));
                DateTime fechaHasta;
                fechaHasta = Convert.ToDateTime(desde.Value);
                insert = insertString(fechaHasta.Date.ToString("yyyyMMdd HH:mm:ss"));

                insert = insertString(tipoHabitacion.Text);
                insert = insertString(regimen.Text);
                insert = insertNro(nroDocumento.Text);
                insert = insertString(tipoDocumento.Text);
                insert = insertNro(Index.usuarioID.ToString());

                insert = insert.Remove(insert.Length - 1);

                int resultado = Index.BD.consultaGetInt(insert);
                if (resultado == 0)
                {
                    MessageBox.Show("#error!");
                }
                else
                {
                    MessageBox.Show("Reserva modificada con éxito");
                }
                atras_Click(null, null);
            }
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Close();
            login = new Login.Login();
            login.Show();
        }

        private void nuevoCliente_Click(object sender, EventArgs e)
        {
            this.Close();
            nuevoCli = new AbmCliente.AltaCliente();
            nuevoCli.Show();
        }

    }
}

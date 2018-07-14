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
    public partial class ModificacionReserva : Form
    {
        private SqlDataReader qry;
        public static Login.Login login;
        public static Login.MenuFuncionalidades menuFuncionalidades;
        DataTable tablaHabitaciones;
        string calle, tipo;
        int calleNumero, capacidad, cambio, contHabitaciones, contHabitacionesAsig = 0, dias, totalH, totalHA, reservaID;
        string habitaciones, habitacionesAsig, insert;
        DataGridViewButtonColumn botonAsignar = new DataGridViewButtonColumn();
        
            
        
        public ModificacionReserva(string reservaID)
        {
            InitializeComponent();
            
            tablaHabitaciones = new DataTable();
            reserva.Text = reservaID;

            qry = Index.BD.consultaGetPuntero("select HO.hot_calle, HO.hot_calle_nro, RS.res_inicio, RS.res_fin, RG.reg_desc, D.doc_desc, RS.res_cli_documento,TH.tip_nombre, TH.tip_personas,((RG.reg_precio * HA.hab_tipo_porcentual) + ((HO.hot_estrellas * HO.hot_recarga_estrellas) * (select datediff(day, res_inicio, res_fin) from EN_CASA_ANDABA.Reservas where res_id = "+ reservaID+"))) from EN_CASA_ANDABA.Reservas RS, EN_CASA_ANDABA.Hoteles HO,EN_CASA_ANDABA.Regimenes RG, EN_CASA_ANDABA.Habitaciones HA, EN_CASA_ANDABA.Reservas_Habitaciones RSHA,EN_CASA_ANDABA.TiposHabitaciones TH, EN_CASA_ANDABA.Documentos D where RG.reg_id = RS.res_reg_id and RSHA.ryh_res_id = RS.res_id and RSHA.ryh_hab_id = HA.hab_id and HA.hab_hot_id = HO.hot_id and TH.tip_id = HA.hab_tip_id and RS.res_cli_doc_id = D.doc_id and res_id =" + reservaID);
            if (qry.Read())
            {
                calle = qry.GetString(0);
                calleNumero = qry.GetInt32(1);
                hotel.Text =  calle+ " " + calleNumero;
                desde.Value = qry.GetDateTime(2);
                hasta.Value = qry.GetDateTime(3);
                regimen.Text = qry.GetString(4);
                tipoDocumento.Text = qry.GetString(5);
                nroDocumento.Text = qry.GetInt64(6).ToString();
                tipo = qry.GetString(7);
                capacidad = qry.GetInt32(8);
                total.Text = qry.GetInt32(9).ToString();
                qry.Close();
            }
            else
            {
                qry.Close();
                MessageBox.Show("#error!");
                this.Close();
            }

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


            qry = Index.BD.consultaGetPuntero("exec EN_CASA_ANDABA.buscarReservaHabitacion " + reservaID);
            while (qry.Read())
            {
                DataRow fila = tablaHabitaciones.NewRow();
                fila["ID"] = qry.GetInt32(0).ToString();
                fila["PRECIO"] = qry.GetInt32(1).ToString();
                tablaHabitaciones.Rows.Add(fila);
                if (contHabitaciones == 0)
                {
                    habitaciones = habitaciones + qry.GetInt32(0).ToString();
                }
                else
                {
                    habitaciones = habitaciones + "," + qry.GetInt32(0).ToString();
                    
                }
                contHabitaciones++;
                totalH = totalH + qry.GetInt32(1);
            }
            cambio = 0;
            qry.Close();

            BindingSource bindingSourceListaHabitaciones = new BindingSource();
            bindingSourceListaHabitaciones.DataSource = tablaHabitaciones;
            listaHabitaciones.DataSource = bindingSourceListaHabitaciones;

            DataGridViewButtonColumn botonAsignar = new DataGridViewButtonColumn();
            botonAsignar.Name = "asignar";
            listaHabitaciones.Columns.Add(botonAsignar);
        }

        private void ModificacionReserva_Load(object sender, EventArgs e)
        {
            tipoHabitacion.SelectedText = tipo;
            cantidadPersonas.SelectedText = capacidad.ToString();       
        }

        private void listaHabitaciones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.listaHabitaciones.Columns[e.ColumnIndex].Name == "asignar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonColumna = this.listaHabitaciones.Rows[e.RowIndex].Cells["asignar"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\plus.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.listaHabitaciones.Rows[e.RowIndex].Height = icono.Height + 5;
                this.listaHabitaciones.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }
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
            if (listaHabitaciones.Columns[e.ColumnIndex].Name == "asignar")
            {
                
                string idHab = listaHabitaciones.CurrentRow.Cells[1].Value.ToString();
                string precioHab = listaHabitaciones.CurrentRow.Cells[2].Value.ToString();
                string regimenHab = regimen.Text;
                int item = listaHabitaciones.CurrentRow.Index;

                DataRow fila = tablaHabitaciones.NewRow();
                fila["ID"] = idHab;
                fila["PRECIO"] = precioHab;
                try
                {
                    tablaHabitaciones.Rows.Add(fila);

                    if (contHabitacionesAsig == 0)
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
                    totalHA = totalHA + (((int)listaHabitaciones.CurrentRow.Cells[2].Value) * dias);
                    listaHabitaciones.Rows.RemoveAt(item);
                    total.Text = totalHA.ToString();
                    contHabitacionesAsig++;
                    listaHabitacionesAsig.DataSource = bindingSourceListaHabitacionesAsig;
                }
                catch
                {
                    MessageBox.Show("La habitación seleccionada ya fue agregada con anterioridad");
                    
                }
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
            string consulta;
            consulta = insertString(calle);
            consulta = insertNro(calleNumero.ToString());

            DateTime fechaDesde;
            fechaDesde = Convert.ToDateTime(desde.Value);
            consulta = insertString(fechaDesde.Date.ToString("yyyyMMdd HH:mm:ss"));
            DateTime fechaHasta;
            fechaHasta = Convert.ToDateTime(desde.Value);
            consulta = insertString(fechaHasta.Date.ToString("yyyyMMdd HH:mm:ss"));

            consulta = insertString(regimen.Text);
            consulta = insertString(tipoHabitacion.Text);

            consulta = consulta.Remove(consulta.Length - 1);

            tablaHabitaciones = Index.BD.consultaGetTabla("exec EN_CASA_ANDABA.buscarHabitacionesDisponibles " + consulta);
            BindingSource bindingSourceListaHabitaciones = new BindingSource();
            bindingSourceListaHabitaciones.DataSource = tablaHabitaciones;
            listaHabitaciones.DataSource = bindingSourceListaHabitaciones;
        }

        private void regimen_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaHabitacionesAsig.DataSource = null;
            contHabitacionesAsig = 0;
            habitacionesAsig = "";
            cambio = 1;
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

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (habitacionesAsig == "" || contHabitacionesAsig == 0)
            {
                MessageBox.Show("Debe seleccionar por lo menos una habitacion");
                return;
            }
            if (string.IsNullOrEmpty(tipoDocumento.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente");
                return;
            }

            bool estado = false;

            qry = Index.BD.consultaGetPuntero("select cli_habilitado from EN_CASA_ANDABA.Clientes, EN_CASA_ANDABA.Documentos where doc_desc = '" + tipoDocumento.Text + "' and cli_documento = " + nroDocumento.Text+" and doc_id = cli_doc_id");
            if (qry.Read())
            {
                estado = qry.GetBoolean(0);
            }
            qry.Close();

            if (estado == false)
            {
                MessageBox.Show("El cliente se encuentra inhabilitado para realizar reservas");
                return;
            }

            string update;
            update = insertNro(reserva.Text);

            DateTime fechaHoy;
            fechaHoy = Convert.ToDateTime(DateTime.Today);
            update = insertString(fechaHoy.Date.ToString("yyyyMMdd HH:mm:ss"));
            DateTime fechaDesde;
            fechaDesde = Convert.ToDateTime(desde.Value);
            update = insertString(fechaDesde.Date.ToString("yyyyMMdd HH:mm:ss"));
            DateTime fechaHasta;
            fechaHasta = Convert.ToDateTime(desde.Value);
            update = insertString(fechaHasta.Date.ToString("yyyyMMdd HH:mm:ss"));

            update = insertString(tipoHabitacion.Text);
            update = insertString(regimen.Text);
            update = insertNro(nroDocumento.Text);
            update = insertNro(Index.usuarioID.ToString());
            update = insertString(tipoDocumento.Text);

            update = update.Remove(update.Length - 1);

            string resultado = Index.BD.consultaGetString("exec EN_CASA_ANDABA.modificacionReserva " + update);
            if (resultado == "0")
            {
                MessageBox.Show("#error!");
                this.Close();
                atras_Click(null, null);
            }
            else
            {
                reservaID = Convert.ToInt32(reserva.Text);
            }

            string insert = "";
            string[] strArr = null;
            int i = 0;
            char[] coma = { ',' };
            if (cambio == 1)
            {
                insert = "exec EN_CASA_ANDABA.bajaReservaHabitacion " + reservaID + ", ";
                if (contHabitaciones > 1)
                {
                    strArr = habitaciones.Split(coma);

                    for (i = 0; i <= strArr.Length - 1; i++)
                    {
                        qry = Index.BD.consultaGetPuntero(insert + strArr[i]);

                        if (!qry.Read())
                        {
                            MessageBox.Show("#error");
                            qry.Close();
                            return;
                        }
                        if (qry.GetInt32(0) == 0)
                        {
                            MessageBox.Show("#error: no se pudo borrar habitación duplicada");
                            qry.Close();
                        }
                    }
                }
                else
                {
                    qry = Index.BD.consultaGetPuntero(insert + habitaciones);
                    if (!qry.Read())
                    {
                        MessageBox.Show("#error");
                        qry.Close();
                        return;
                    }
                    if (qry.GetInt32(0) == 0)
                    {
                        MessageBox.Show("#error: no se pudo borrar habitación duplicada");
                        qry.Close();
                    }
                    qry.Close();
                }
            }

            insert = "exec EN_CASA_ANDABA.altaReservaHabitacion " + reservaID + ", ";

            if (contHabitacionesAsig > 1)
            {
                strArr = null;
                i = 0;
                strArr = habitacionesAsig.Split(coma);

                for (i = 0; i <= strArr.Length -1; i++)
                {
                    qry = Index.BD.consultaGetPuntero(insert + strArr[i]);

                    if (!qry.Read())
                    {
                        MessageBox.Show("#error");
                        qry.Close();
                        return;
                    }
                    if (qry.GetInt32(0) == 0)
                    {
                        MessageBox.Show("#error: no se pudo borrar habitación duplicada");
                        qry.Close();
                        return;
                    }
                    qry.Close();
                }
            }
            else
                {
                    qry = Index.BD.consultaGetPuntero(insert + habitaciones);
                    if (!qry.Read())
                    {
                        MessageBox.Show("#error");
                        qry.Close();
                        return;
                    }
                    if (qry.GetInt32(0) == 0)
                    {
                        MessageBox.Show("#error: no se pudo borrar habitación duplicada");
                        qry.Close();
                    }
                    qry.Close();
                }
            MessageBox.Show("Reserva modificada con éxito");
            this.Close();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            if (Index.rol == "Guest")
            {
                login = new Login.Login();
                login.Show();
            }
            else
            {
                menuFuncionalidades = new Login.MenuFuncionalidades();
                menuFuncionalidades.Show();
            }
            this.Close();
        }

    }
}

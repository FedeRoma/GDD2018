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

namespace FrbaHotel.CancelarReserva
{
    public partial class CancelarReserva : Form
    {
        public static Login.MenuFuncionalidades menuFuncionalidades;
        SqlDataReader qry;
        int noshowCancID = 0;
        int usuCancID = 0;
        int cliCancID = 0;
        DateTime fechaCanc, hoy;

        public CancelarReserva()
        {
            InitializeComponent();
            codigoReserva.Clear();
            codigoReserva.Focus();

            qry = Index.BD.consultaGetPuntero("select estados_id from EN_CASA_ANDABA.Estados where estados_desc = 'RESERVA CANCELADA POR NO-SHOW'");
            qry.Read();
            noshowCancID = qry.GetInt32(0);
            qry.Close();

            qry = Index.BD.consultaGetPuntero("select estados_id from EN_CASA_ANDABA.Estados where estados_desc = 'RESERVA CANCELADA POR RECEPCION'");
            qry.Read();
            usuCancID = qry.GetInt32(0);
            qry.Close();

            qry = Index.BD.consultaGetPuntero("select estados_id from EN_CASA_ANDABA.Estados where estados_desc = 'RESERVA CANCELADA POR CLIENTE'");
            qry.Read();
            cliCancID = qry.GetInt32(0);
            qry.Close();
        }

        private void codigoReserva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool checkCampos()
        {
            bool inconsistencias = false;
            string alerta = "";

            if (string.IsNullOrEmpty(codigoReserva.Text))
            {
                alerta = alerta + "Debe ingresar un código de reserva válido\n";
                inconsistencias = true;
            }

            fechaCanc = Convert.ToDateTime(fechaCancelacion.Value);
            hoy = DateTime.Today;

            if (DateTime.Compare(fechaCanc, hoy) >= 0)
            {
                alerta = alerta + "Debe ingresar una fecha de cancelación válida";
                inconsistencias = true;
            }

            if (inconsistencias)
            {
                MessageBox.Show(alerta);
            }
            return inconsistencias;
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (!checkCampos())
            {
                qry = Index.BD.consultaGetPuntero("select res_estados_id, res_inicio from EN_CASA_ANDABA.Reservas where res_id = " + codigoReserva.Text);
                if (qry.Read())
                {
                    int estado = qry.GetInt32(0);
                    DateTime fechaInicio = qry.GetDateTime(1);
                    qry.Close();

                    if (fechaInicio.Date <= fechaCancelacion.Value)
                    {
                        MessageBox.Show("La reserva no puede cancelarse ya que se encuentra dentro del plazo mínino de cancelación");
                        return;
                    }
                    if (estado == noshowCancID || estado == cliCancID || estado == usuCancID)
                    {
                        MessageBox.Show("La reserva ya ha sido cancelada con anterioridad");
                        return;
                    }

                    qry = Index.BD.consultaGetPuntero("exec EN_CASA_ANDABA.bajaReserva " + codigoReserva.Text + ", " + Index.usuarioID + ", " + estado + ", '" + fechaCanc.Date.ToString("yyyyMMdd HH:mm:ss") + "', '" + motivoCancelacion.Text + "'");
                    if (qry.Read())
                    {
                        if (qry.GetInt32(0) == 1)
                        {
                            MessageBox.Show("La reserva se ha cancelado con éxito");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("#error: no se ha podido realizar la operación");
                            return;
                        }
                    }
                    qry.Close();
                }
                qry.Close();
            }
            else
            {
                MessageBox.Show("#error: no se ha encontrado una reserva con ese número");
                return;
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            codigoReserva.ResetText();
            motivoCancelacion.ResetText();
            fechaCancelacion.ResetText();
            codigoReserva.Focus();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            menuFuncionalidades = new Login.MenuFuncionalidades();
            menuFuncionalidades.Show();
            this.Close();
        }

    }
}
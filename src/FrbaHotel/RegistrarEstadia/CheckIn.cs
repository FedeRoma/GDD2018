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
    public partial class CheckIn : Form
    {
        private SqlDataReader qry;
        public static AsignarClientesEstadia ClientesEstadia;
        public static MenuRegistrarEstadia MenuEstadia;
        int reservaCorrectaID = 0;
        int reservaModificadaID = 0;

        public CheckIn()
        {
            InitializeComponent();

            reservaCorrectaID = Index.BD.consultaGetInt("select estados_id from EN_CASA_ANDABA.Estados where estados_desc = 'RESERVA CORRECTA'");
            reservaModificadaID = Index.BD.consultaGetInt("select estados_id from EN_CASA_ANDABA.Estados where estados_desc = 'RESERVA CORRECTA'");
        }

        private void numeroReserva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(reserva.Text))
            {
                MessageBox.Show("Debe ingresar un numero de reserva válido");
                return;
            }

            qry = Index.BD.consultaGetPuntero("select res_id, res_estados_id, res_inicio from EN_CASA_ANDABA.Reservas where res_id = " + reserva.Text);
            if (qry.Read())
            {
                int estado = qry.GetInt32(1);
                DateTime fechaInicioReserva = qry.GetDateTime(2);
                qry.Close();

                if (DateTime.Compare(fechaInicioReserva, DateTime.Today) > 0)
                {
                    MessageBox.Show("#error: Reserva vencida");
                    return;
                }
                if (DateTime.Compare(fechaInicioReserva, DateTime.Today) < 0)
                {
                    MessageBox.Show("#error: Aún no ha comenzando el período de reserva");
                    return;
                }
                if (estado != reservaModificadaID && estado != reservaCorrectaID)
                {
                    MessageBox.Show("#error: La reserva no está disponible");
                    return;
                }

                qry = Index.BD.consultaGetPuntero("select hot_id from EN_CASA_ANDABA.Habitaciones HA, EN_CASA_ANDABA.Hoteles HO, EN_CASA_ANDABA.Reservas_Habitaciones RH where RH.ryh_hab_id = HA.hab_id and HA.hab_hot_id = HO.hot_id and RH.ryh_res_id = " + reserva.Text);
                int idHotel = 0;
                if (qry.Read())
                {
                    idHotel = qry.GetInt32(0);
                    qry.Close();
                }
                else
                {
                    qry.Close();
                    MessageBox.Show("#error: La reserva no está asociada a ningún hotel");
                    return;
                }
                if (idHotel.ToString() != Index.hotel)
                {
                    MessageBox.Show("#error: la reserva no pertenece a este hotel");
                    return;
                }

                int idEstadia = 0;
                idEstadia = Index.BD.consultaGetInt("exec EN_CASA_ANDABA.altaCheckInEstadia " + reserva.Text + ", " + Index.usuarioID + ", '" + fechaInicioReserva.ToString("yyyyMMdd HH:mm:ss") + "'");
                
                if (idEstadia == 0)
                {
                    MessageBox.Show("#error!");
                    return;
                }
                else
                {
                    MessageBox.Show("CheckIn realizado correctamente");
                }

                int idFactura = 0;
                idFactura = Index.BD.consultaGetInt("exec EN_CASA_ANDABA.altaFactura " + idEstadia.ToString() + ", 1, '" + DateTime.Today.ToString("yyyyMMdd HH:mm:ss") + "'");

                if (idFactura == 0)
                {
                    MessageBox.Show("#error: factura ya realizada");
                    return;
                }
                else
                {
                    MessageBox.Show("La factura se ha generado correctamente");
   
                    AsignarClientesEstadia ClientesEstadia = new AsignarClientesEstadia(reserva.Text, idEstadia.ToString());
                    ClientesEstadia.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("#error: no existe ninguna reserva con ese número");
                qry.Close();
                return;
            }
            qry.Close();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuEstadia = new MenuRegistrarEstadia();
            MenuEstadia.Show();
        }

    }
}

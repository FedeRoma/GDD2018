using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class Checkin : Form
    {
        SqlDataReader resultado;
        decimal resok;
        decimal resmodif;
        decimal estadia = 0;
        public Checkin()
        {
            InitializeComponent();
            textBox1.Clear();
            textBox1.Focus();
            
            resok = 0;
            resultado = Home.BD.comando("Select estados_id from EN_CASA_ANDANA.Estados where estados_desc = 'RESERVA CORRECTA'");
            resultado.Read();
            resok = resultado.GetDecimal(0);
            resultado.Close();
            resmodif = 0;
            resultado = Home.BD.comando("Select estados_id from EN_CASA_ANDABA.Estados where estados_desc = 'RESERVA MODIFICADA'");
            resultado.Read();
            resmodif = resultado.GetDecimal(0);
            resultado.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Debe ingresar un numero de reserva");
                return;
            }
            resultado = Home.BD.comando("Select res_id,res_estados_id,res_inicio from EN_CASA_ANDABA.Reservas where res_id = " + textBox1.Text);
            if (resultado.Read() == true)
            {
                decimal estado = resultado.GetDecimal(1);
                DateTime fechaIni = resultado.GetDateTime(2);
                resultado.Close();

                if (fechaIni.Date < Home.fecha.Date)
                {
                    MessageBox.Show("No se puede hacer el check in porque ya vencio la fecha de check in");
                    return;
                }
                if (fechaIni.Date > Home.fecha.Date)
                {
                    MessageBox.Show("No se puede hacer el check in porque no es la fecha todavia");
                    return;
                }
                if (estado != resmodif && estado != resok)
                {
                    MessageBox.Show("La reserva no tiene el estado Correcto. Posiblemente cancelada");
                    return;
                }
                resultado = Home.BD.comando("select Hot.hot_id from EN_CASA_ANDABA.Habitaciones Hab,EN_CASA_ANDABA.Hoteles Hot,EN_CASA_ANDABA.Reservas_Habitaciones RH where RH.ryh_hab_id = Hab.hab_id and Hab.hab_hot_id = Hot.hot_id and RH.ryh_res_id = " + textBox1.Text);
                decimal hotel = 0;
                if(resultado.Read())
                {
                    hotel = resultado.GetDecimal(0);
                    resultado.Close();
                }
                else
                {
                    resultado.Close();
                    MessageBox.Show("Error. La reserva no tiene asignadas habitaciones");
                    return;
                }
                if(hotel.ToString()!=Login.HomeLogin.hotel)
                {
                    MessageBox.Show("Error. Solo pueden hacer checks-in los empleados del hotel donde se hizo la reserva");
                    return;
                }
                string cancelacion = "EXEC EN_CASA_ANDABA.altaCheckinEstadia ";
                cancelacion = cancelacion + textBox1.Text + ",";
                cancelacion = cancelacion + Login.HomeLogin.idUsuario + ",";
                cancelacion = cancelacion + "'" + Home.fecha.Date.ToString("yyyyMMdd HH:mm:ss") + "'";
                resultado = Home.BD.comando(cancelacion);
                resultado.Read();
                estadia = resultado.GetDecimal(0);
                resultado.Close();
                if (estadia != 0)
                {
                    MessageBox.Show("Se ha realizado el check-in correctamente");
                    string factu = "EXEC EN_CASA_ANDABA.altaFactura " + estadia.ToString() + ",1,'" + Home.fecha.Date.ToString("yyyyMMdd HH:mm:ss") + "'";
                    resultado = Home.BD.comando(factu);
                    resultado.Read();
                    decimal factura = resultado.GetDecimal(0);
                    if (factura == 0)
                    {
                        resultado.Close();
                        MessageBox.Show("Error al insertar factura, ya esta generada");
                        return;
                    }
                    resultado.Close();
                    ClientesEstadia cliest = new ClientesEstadia(textBox1.Text,estadia.ToString());
                    cliest.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo realizar la operacion, la estadia ya esta registrada");
                    return;
                }
                
                
                
            }
            else
            {
                resultado.Close();
                MessageBox.Show("Numero de reserva invalido");
                return;
            }
        }
    }
}

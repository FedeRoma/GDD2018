using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Login
{
    public partial class MainFuncionalidades : Form
    {
        private int cerrate =0;
        private SqlDataReader resultado;
        public MainFuncionalidades()
        {
            InitializeComponent();
        }

        private void MainFuncionalidades_Load(object sender, EventArgs e)
        {

            string consulta = "select distinct Fun.fun_descfrom EN_CASA_ANDABA.Funcionalidades Fun, EN_CASA_ANDABA.Roles Rol where Rol.rol_nombre='" + Login.HomeLogin.rol;
            resultado = Home.BD.comando(consulta);
            while (resultado.Read() == true)
            {
                comboBox1.Items.Add(resultado.GetSqlString(0));
            }
            resultado.Close();
            consulta = "select distinct Hot.hot_calle+Hot.hot_calle_nro from EN_CASA_ANDABA.Hoteles Hot where Hot.hot_id = " + Login.HomeLogin.hotel.ToString();
            resultado = Home.BD.comando(consulta);
            resultado.Read();
            listBox1.Items.Add(resultado.GetSqlString(0));
            resultado.Close();
        }
        private void HandlerFuncionalidad(string funcionalidad)
        {
            switch (funcionalidad)
            {
                case "ABM ROL":
                    this.Hide();
                    ABM_de_Rol.HomeRol rol = new ABM_de_Rol.HomeRol();
                    rol.Show();
                    break;
                case "ABM USUARIO":
                    this.Hide();
                    ABM_de_Usuario.HomeUsuario usuario = new ABM_de_Usuario.HomeUsuario();
                    usuario.Show();
                    break;
                case "ABM CLIENTE":
                    this.Hide();
                    ABM_de_Cliente.HomeCliente cliente = new ABM_de_Cliente.HomeCliente();
                    cliente.Show();
                    break;
                case "ABM HOTEL":
                    this.Hide();
                    ABM_de_Hotel.HomeHotel hotel = new FrbaHotel.ABM_de_Hotel.HomeHotel();
                    hotel.Show();
                    break;
                case "ABM HABITACION":
                    this.Hide();
                    ABM_de_Habitacion.HomeHabitacion habitacion = new ABM_de_Habitacion.HomeHabitacion();
                    habitacion.Show();
                    break;
                case "ABM REGIMEN":
                    this.Hide();
                    Regimen.HomeRegimen regimen = new Regimen.HomeRegimen();
                    regimen.Show();
                    break;
                case "GENERAR/MODIFICAR RESERVA":
                    this.Hide();
                    Generar_Modificar_Reserva.HomeReserva reserva = new Generar_Modificar_Reserva.HomeReserva();
                    reserva.Show();
                    break;
                case "BAJA RESERVA":
                    this.Hide();
                    Cancelar_Reserva.Cancelacion cance = new Cancelar_Reserva.Cancelacion();
                    cance.Show();
                    break;
                case "REGISTRAR ESTADIA":
                    this.Hide();
                    Registrar_Estadia.HomeEstadia estadia = new Registrar_Estadia.HomeEstadia();
                    estadia.Show();
                    break;
                case "REGISTRAR CONSUMIBLES":
                    this.Hide();
                    Registrar_Consumible.RegistrarConsumibles consu = new Registrar_Consumible.RegistrarConsumibles();
                    consu.Show();
                    break;
                case "LISTADO ESTADISTICO":
                    this.Hide();
                    Listado_Estadistico.ListadoEstadistico listado = new Listado_Estadistico.ListadoEstadistico();
                    listado.Show();
                    break;
                default:
                    MessageBox.Show("error inesperado");
                    Application.Exit();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBox1.SelectedIndex) != -1)
            {
                HandlerFuncionalidad(comboBox1.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Debe seleccionar una funcionalidad");
                comboBox1.Focus();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {   
            Home.login.Show();
            cerrate=1;
            this.Close();
        }

        private void MainFuncionalidades_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrate == 1)
            {

            }
            else
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cambioPass cambio = new cambioPass();
            cambio.Show();
        }
    }
}

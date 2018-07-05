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

namespace FrbaHotel.Login
{
    public partial class MenuFuncionalidades : Form
    {
        private SqlDataReader qry;
        public static Index index;
        public static CambiarContrasenia cambiarContrasenia;
        private bool cerrarFormulario = false;

        public MenuFuncionalidades()
        {
            InitializeComponent();
        }

        private void MenuFuncionalidades_Load(object sender, EventArgs e)
        {
            qry = Index.BD.consultaGetPuntero("select distinct hot_calle, hot_calle_nro from EN_CASA_ANDABA.Hoteles where hot_id = " + Index.hotel);
            qry.Read();
            hotelActivo.Items.Add(qry.GetString(0) + " " + qry.GetInt32(1).ToString());
            qry.Close();

            qry = Index.BD.consultaGetPuntero("select distinct F.fun_desc from EN_CASA_ANDABA.Funcionalidades F, EN_CASA_ANDABA.Roles R, EN_CASA_ANDABA.Roles_Usuarios RyU, EN_CASA_ANDABA.Funcionalidades_Roles FyR, EN_CASA_ANDABA.Hoteles_Usuarios HyU where R.rol_nombre = '" + Index.rol + "' and R.rol_id = RyU.ryu_rol_id and R.rol_id = FyR.fyr_rol_id and FyR.fyr_fun_id = F.fun_id and RyU.ryu_usu_id = " + Index.usuarioID.ToString() + " and HyU.hyu_usu_id = RyU.ryu_usu_id and HyU.hyu_hot_id = " + Index.hotel);
            while (qry.Read() == true)
            {
                funcionalidad.Items.Add(qry.GetSqlString(0));
            }
            qry.Close();
            funcionalidad.SelectedIndex = 0;
        }

        private void SeleccionarFuncionalidad(string funcionalidad)
        {
         switch (funcionalidad)
            {
                case "ABM Rol":
                    this.Hide();
                    AbmRol.MenuAbmRol IndexRol = new AbmRol.MenuAbmRol();
                    IndexRol.Show();
                    break;
                case "ABM Usuario":
                    //this.Hide();
                    //AbmRol.MenuAbmRol IndexRol = new AbmRol.MenuAbmRol();
                    //IndexRol.Show();
                    break;
                case "ABM Cliente":
                    this.Hide();
                    AbmCliente.MenuAbmCliente IndexCliente = new AbmCliente.MenuAbmCliente();
                    IndexCliente.Show();
                    break;
                case "ABM Hotel":
                    //this.Hide();
                    //AbmHotel.MenuAbmHotel IndexHotel = new AbmHotel.MenuAbmHotel();
                    //IndexHotel.Show();
                    break;
                case "ABM Habitación":
                    this.Hide();
                    AbmHabitacion.MenuAbmHabitacion IndexHabitacion = new AbmHabitacion.MenuAbmHabitacion();
                    IndexHabitacion.Show();
                    break;
                case "ABM Régimen":
                    //this.Hide();
                    //AbmRegimen.MenuAbmRegimen IndexRegimen = new AbmRegimen.MenuAbmRegimen();
                    //IndexRegimen.Show();
                    break;
                case "Generar Reserva":
                    break;
                case "Modificar Reserva":
                    break;
                case "Baja Reserva":
                    this.Hide();
                    CancelarReserva.CancelarReserva BajaReserva = new CancelarReserva.CancelarReserva();
                    BajaReserva.Show();
                    break;
                case "Registrar Estadía":
                    break;
                case "Registrar Consumibles":
                    break;
                case "Listado Estadístico":
                    this.Hide();
                    ListadoEstadistico.ListadosEstadisticos IndexListados = new ListadoEstadistico.ListadosEstadisticos();
                    IndexListados.Show();
                    break;
                default:
                    MessageBox.Show("#error!");
                    Application.Exit();
                    break;
            }
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(funcionalidad.SelectedIndex) != -1)
            {
                SeleccionarFuncionalidad(funcionalidad.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("#error: Debe seleccionar una funcionalidad para continuar");
                funcionalidad.Focus();
            }
        }

        private void cambiarContraseña_Click(object sender, EventArgs e)
        {
            if (Index.rol == "Guest")
            {
                MessageBox.Show("#error: Acción inválida para el invitado");
            }
            else
            {
                cambiarContrasenia = new CambiarContrasenia();
                cambiarContrasenia.Show();
                cerrarFormulario = true;
                this.Close();
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            index = new Index();
            index.Show();
            cerrarFormulario = true;
            this.Close();
        }

        private void MenuFuncionalidades_FormClosing(object sender, EventArgs e)
        {
            if (cerrarFormulario)
            {
                Application.Exit();
            }
        }

    }
}

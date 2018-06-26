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
    public partial class RolesUsuario : Form
    {
        private SqlDataReader resultado;
        private SqlDataReader resultadoH;
        private SqlDataReader resultadoR;
        public static Index index;
        private string consulta;

        public RolesUsuario()
        {
            InitializeComponent();
        }

        private void comboBoxHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            consulta = "exec EN_CASA_ANDABA.buscarHoteles '" + comboBoxHotel.SelectedItem + "' , " + Login.usuarioId.ToString() + ";";
            resultado = Index.BD.ejecutarQueryTraePuntero(consulta);
            comboBoxRol.Items.Clear();
            while (resultado.Read() == true)
            {
                comboBoxRol.Items.Add(resultado.GetDecimal(0));
            }
            resultado.Close();
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RolesUsuario_Load(object sender, EventArgs e)
        {
            resultadoH = Index.BD.ejecutarQueryTraePuntero("select H.hot_calle from EN_CASA_ANDABA.Hoteles_Usuarios HU, EN_CASA_ANDABA.Hoteles H where HU.hyu_hot_id = H.hot_id and HU.hyu_usu_id = " + Login.usuarioId.ToString() + " order by H.hot_id");
            while (resultadoH.Read() == true)
            {
                comboBoxHotel.Items.Add(resultadoH.GetString(0));
            }
            resultadoH.Close();

            resultadoR = Index.BD.ejecutarQueryTraePuntero("select R.rol_nombre from EN_CASA_ANDABA.Roles_Usuarios RU, EN_CASA_ANDABA.Roles R where RU.ryu_rol_id = R.rol_id and RU.ryu_usu_id = " + Login.usuarioId.ToString() + " and R.rol_estado = 1 order by R.rol_id");
            while (resultadoR.Read() == true)
            {
                comboBoxRol.Items.Add(resultadoR.GetString(0));
            }
            resultadoR.Close();
        }
     
        private void aceptar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBoxRol.SelectedIndex) != -1 && Convert.ToInt32(comboBoxHotel.SelectedIndex) != -1)
            {
                Login.rol = comboBoxRol.SelectedItem.ToString();
                Login.hotel = comboBoxHotel.SelectedItem.ToString();
                Login.funcionalidadesUsuarios = new Funcionalidades_Usuarios();
                Login.funcionalidadesUsuarios.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("#error: Debe completar todos los datos para continuar");
                comboBoxHotel.Focus();
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            comboBoxHotel.ResetText();
            comboBoxRol.ResetText();
            comboBoxHotel.Focus();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            index = new Index();
            index.Show();
        }

    }
}

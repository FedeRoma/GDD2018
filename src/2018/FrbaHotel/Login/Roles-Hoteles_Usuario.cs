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
        public static Index index;
        private bool cerrarFormulario = false; 

        public RolesUsuario()
        {
            InitializeComponent();
        }

        private void RolesUsuario_Load(object sender, EventArgs e)
        {
            resultado = Index.BD.consultaGetPuntero("select distinct R.rol_nombre from EN_CASA_ANDABA.Roles_Usuarios RU, EN_CASA_ANDABA.Roles R where RU.ryu_rol_id = R.rol_id and RU.ryu_usu_id = " + Login.usuarioId.ToString() + " and R.rol_estado = 1");
            while (resultado.Read() == true)
            {
                comboBoxRol.Items.Add(resultado.GetSqlString(0));
            }
            resultado.Close();
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            resultado = Index.BD.consultaGetPuntero("exec EN_CASA_ANDABA.buscarHoteles '" + comboBoxRol.SelectedItem + "' , " + Login.usuarioId.ToString());
            comboBoxHotel.Items.Clear();
            List<int> hoteles = new List<int>();
            while (resultado.Read() == true)
            {
                hoteles.Add(resultado.GetInt32(0));
            }
            resultado.Close();
            foreach (int id in hoteles)
            {
                string hotel = Index.BD.consultaGetDato("select hot_calle from EN_CASA_ANDABA.Hoteles where hot_id =" + id.ToString());
                comboBoxHotel.Items.Add(hotel);
            }
        }
  
        private void aceptar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBoxRol.SelectedIndex) != -1 && Convert.ToInt32(comboBoxHotel.SelectedIndex) != -1)
            {
                Login.rol = comboBoxRol.SelectedItem.ToString();
                Login.hotel = comboBoxHotel.SelectedItem.ToString();
                Login.funcionalidadesUsuarios = new MenuFuncionalidades();
                Login.funcionalidadesUsuarios.Show();
                cerrarFormulario = true;
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

        private void RolesUsuario_FormClosing(object sender, EventArgs e)
        {
            if (cerrarFormulario)
            {
                Application.Exit();
            }
        }



    }
}
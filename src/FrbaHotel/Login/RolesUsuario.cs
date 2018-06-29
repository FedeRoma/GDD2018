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
        public static Index index;
        public static MenuFuncionalidades funcionalidadesUsuarios;
        private SqlDataReader qry;
        private bool cerrarFormulario = false; 

        public RolesUsuario()
        {
            InitializeComponent();
        }

        private void RolesUsuario_Load(object sender, EventArgs e)
        {
            qry = Index.BD.consultaGetPuntero("select distinct R.rol_nombre from EN_CASA_ANDABA.Roles_Usuarios RU, EN_CASA_ANDABA.Roles R where RU.ryu_rol_id = R.rol_id and RU.ryu_usu_id = " + Index.usuarioID.ToString() + " and R.rol_estado = 1");
            while (qry.Read() == true)
            {
                comboBoxRol.Items.Add(qry.GetSqlString(0));
            }
            qry.Close();
            comboBoxRol.SelectedIndex = 0;

            DataTable hoteles = Index.BD.consultaGetTabla("select distinct hot_id ID, hot_calle NOMBRE from EN_CASA_ANDABA.Hoteles H, EN_CASA_ANDABA.Hoteles_Usuarios HU where H.hot_id = HU.hyu_hot_id and HU.hyu_usu_id = " + Index.usuarioID.ToString());
            dataGridViewHoteles.DataSource = hoteles;
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            qry = Index.BD.consultaGetPuntero("exec EN_CASA_ANDABA.buscarHoteles '" + comboBoxRol.SelectedItem + "' , " + Index.usuarioID.ToString());
            comboBoxHotel.Items.Clear();
            while (qry.Read() == true)
            {
                comboBoxHotel.Items.Add(qry.GetInt32(0));
            }
            qry.Close();
            comboBoxHotel.SelectedIndex = 0;
        }
  
        private void aceptar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBoxRol.SelectedIndex) != -1 && Convert.ToInt32(comboBoxHotel.SelectedIndex) != -1)
            {
                Index.rol = comboBoxRol.SelectedItem.ToString();
                Index.hotel = comboBoxHotel.SelectedItem.ToString();
                funcionalidadesUsuarios = new MenuFuncionalidades();
                funcionalidadesUsuarios.Show();
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
            index = new Index();
            index.Show();
            cerrarFormulario = true;
            this.Close();
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
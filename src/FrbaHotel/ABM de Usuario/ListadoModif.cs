using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class ListadoModif : Form
    {
        public static decimal direccion = 0;
        Direccion.ListadoDireccion lista;
        private int a = 0;
        string consulta;
        SqlDataReader resultado;
        SqlDataAdapter sAdapter;
        DataTable dTable;
        public ListadoModif()
        {
            InitializeComponent();
            textBoxUser.Focus();
            consulta = "select distinct doc_desc from EN_CASA_ANDABA.Documentos";
            resultado = Home.BD.comando(consulta);
            while (resultado.Read() == true)
            {
                comboBoxTipoDoc.Items.Add(resultado.GetSqlString(0));
            }
            resultado.Close();
            consulta = "select hot_calle+hot_calle_nro from EN_CASA_ANDABA.Hoteles WHERE hot_id=" + Login.HomeLogin.hotel;
            resultado = Home.BD.comando(consulta);
            while (resultado.Read() == true)
            {
                comboBoxHotel.Items.Add(resultado.GetSqlString(0));
            }
            resultado.Close();
            consulta = "select rol_nombre from EN_CASA_ANDABA.Roles";
            resultado = Home.BD.comando(consulta);
            while (resultado.Read() == true)
            {
                comboBoxRol.Items.Add(resultado.GetSqlString(0));
            }
            resultado.Close();
            dateTimePicker1.Value = Home.fecha;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListadoModif_Load(object sender, EventArgs e)
        {
            string query = "select User.usu_nombre Usuario,Rol.rol_nombre Rol,User.usu_nombre Nombre,User.usu_apellido Apellido,User.usu_telefono Tel,User.usu_mail Mail,User.usu_documento Nro_Doc,User.usu_estado Estado,doc.doc_desc Tipo_Doc,Hot.hot_calle+Hot.hot_calle_nro Hotel,User.usu_fecha_nac Fecha_Nac,from	EN_CASA_ANDABA.Usuarios User,EN_CASA_ANDABA.Roles Rol,EN_CASA_ANDABA.Hoteles Hot,EN_CASA_ANDABA.Documentos doc where User.usu_documento = doc.doc_id and Hot.hot_id=" + Login.HomeLogin.hotel;
            sAdapter = FrbaHotel.Home.BD.dameDataAdapter(query);
            dTable = FrbaHotel.Home.BD.dameDataTable(sAdapter);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dTable;
            dataGridView1.DataSource = bSource;
        }
        private string filtrarExactamentePor(string columna, string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                return columna + " = '" + valor + "' AND ";
            }
            return "";
        }

        private string filtrarAproximadamentePor(string columna, string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                return columna + " LIKE '%" + valor + "%' AND ";
            }
            return "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataView dvData = new DataView(dTable);
            string query = "";
            query = query + this.filtrarAproximadamentePor("Usuario", textBoxUser.Text);
            query = query + this.filtrarExactamentePor("Rol", comboBoxRol.SelectedText);
            query = query + this.filtrarAproximadamentePor("Nombre", textBoxNombre.Text);
            query = query + this.filtrarAproximadamentePor("Apellido", textBoxApellido.Text);
            query = query + this.filtrarExactamentePor("Tel", textBoxTel.Text);
            query = query + this.filtrarAproximadamentePor("Mail", textBoxMail.Text);
            if (a == 1)
            {
                query = query + this.filtrarExactamentePor("Direccion", textBoxDir.Text);
            }
            query = query + this.filtrarExactamentePor("Nro_Doc", textBoxNroDoc.Text);
            query = query + this.filtrarExactamentePor("Tipo_Doc", comboBoxTipoDoc.Text);
            query = query + this.filtrarExactamentePor("Hotel", comboBoxHotel.Text);
            if (checkBox1.Checked)
            {
                DateTime fecha;
                fecha = Convert.ToDateTime(dateTimePicker1.Value);
                query = query + this.filtrarExactamentePor("Fecha_Nac", fecha.Date.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            if (checkBox2.Checked)
            {
                query = query + "Estado = 1 and";
            }
            else
            {
                query = query + "Estado = 0 and";
            }

            if (query.Length > 0) { query = query.Remove(query.Length - 4); }
            dvData.RowFilter = query;
            dataGridView1.DataSource = dvData;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a = 1;
            lista = new Direccion.ListadoDireccion("usuarioModif");
            lista.Show();
        }

        private void textBoxDir_TextChanged(object sender, EventArgs e)
        {
        }

        private void ListadoModif_Shown(object sender, EventArgs e)
        {
            if (direccion != 0)
            {
                textBoxDir.Text = direccion.ToString();
            }
        }

        private void ListadoModif_Activated(object sender, EventArgs e)
        {
            if (direccion != 0)
            {
                textBoxDir.Text = direccion.ToString();
            }
            string query = "select User.usu_nombre Usuario,Rol.rol_nombre Rol,User.usu_nombre Nombre,User.usu_apellido Apellido,User.usu_telefono Tel,User.usu_mail Mail,User.usu_documento Nro_Doc,User.usu_estado Estado,doc.doc_desc Tipo_Doc,Hot.hot_calle+Hot.hot_calle_nro Hotel,User.usu_fecha_nac Fecha_Nac,from	EN_CASA_ANDABA.Usuarios User,EN_CASA_ANDABA.Roles Rol,EN_CASA_ANDABA.Hoteles Hot,EN_CASA_ANDABA.Documentos doc where User.usu_documento = doc.doc_id and Hot.hot_id=" + Login.HomeLogin.hotel;
            sAdapter = FrbaHotel.Home.BD.dameDataAdapter(query);
            dTable = FrbaHotel.Home.BD.dameDataTable(sAdapter);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dTable;
            dataGridView1.DataSource = bSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBoxDir.Text = string.Empty;
            textBoxUser.Text = string.Empty;
            comboBoxRol.ResetText();
            textBoxNombre.Text = string.Empty;
            textBoxApellido.Text = string.Empty;
            textBoxTel.Text = string.Empty;
            textBoxMail.Text = string.Empty;
            textBoxDir.Text = string.Empty;
            textBoxNroDoc.Text = string.Empty;
            comboBoxTipoDoc.ResetText();
            comboBoxHotel.ResetText();
            dateTimePicker1.ResetText();
            textBoxUser.Focus();
            this.button2_Click(null, null);
        }

        private void ListadoModif_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void textBoxNroDoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBoxTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBoxTel_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                decimal id=0;
                decimal idUXR = 0;
                string username = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                consulta = "select usu_id  from EN_CASA_ANDABA.Usuarios where usu_username = '"+username+"'";
                resultado = Home.BD.comando(consulta);
                if (resultado.Read() == true)
                {
                    id = resultado.GetDecimal(0);
                }
                resultado.Close();
                string hotel = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                string rol = dataGridView1.CurrentRow.Cells[2].Value.ToString();
               // consulta = "select UR.idUserXRol from EN_CASA_ANDABA.UserXRolXHotel UR, EN_CASA_ANDABA.Hoteles Hot, EN_CASA_ANDABA.Roles R  " + id + "and R.descripcion = '" + rol + "' and R.idRol = UR.rol and H.nombre = '"+hotel+"' and H.idHotel = UR.hotel"; // no hay USERXROLXHOTEL
                resultado = Home.BD.comando(consulta);
                if (resultado.Read() == true)
                {
                    idUXR = resultado.GetDecimal(0);
                }
                resultado.Close();
                
                string nombre = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string apellido = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                string tel = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                string mail = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                string direccion = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                string nroDoc = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                string tipoDoc = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                string fecha = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                string estado = dataGridView1.CurrentRow.Cells[16].Value.ToString();
                Modificacion modif = new Modificacion(id,idUXR,username,rol,nombre,apellido,tel,mail,direccion,nroDoc,tipoDoc,hotel,fecha,estado);
                modif.Show();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            a = 1;
            lista = new Direccion.ListadoDireccion("usuarioModif");
            lista.Show();
        }

        
     }
}
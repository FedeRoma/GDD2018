using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class Modificacion : Form
    {
        string ID;
        SqlDataReader resultado;
        public Modificacion(string id, string rol, string estado)
        {
            InitializeComponent();
            textBox1.Text = rol;
            ID = id;
            comboBox1.Items.Add("Activo");
            comboBox1.Items.Add("Inactivo");
            if (estado == "True")
            {
                comboBox1.Text = "Activo";
            }
            else
            {
                comboBox1.Text = "Inactivo";
            }
            string consulta = "select Fun.fun_desc from EN_CASA_ANDABA.Funccionalidades_Roles FR,EN_CASA_ANDABA.Funcionalidades Fun where Fun.fun_id=FR.fyr_fun_id and FR.fyr_rol_id = " + id;
            resultado = Home.BD.comando(consulta);
            comboBox3.Items.Add("Ninguna");
            comboBox2.Items.Add("Ninguna");
            while (resultado.Read())
            {
                comboBox3.Items.Add(resultado.GetString(0));
            }
            resultado.Close();
            consulta = "select distinct fun_desc from EN_CASA_ANDABA.Funcionalidades except select Fun.fun_desc from EN_CASA_ANDABA.Funcionalidades_ROles FR,EN_CASA_ANDABA.Funcionalidades Fun where Fun.fun_id=FR.fyr_fun_id and FR.fyr_rol_id =" + id;
            resultado = Home.BD.comando(consulta);
            while (resultado.Read())
            {
                comboBox2.Items.Add(resultado.GetString(0));
            }
            resultado.Close();
            textBox1.Focus();

        }

        private void Modificacion_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox1.ResetText();
            comboBox2.ResetText();
            comboBox3.ResetText();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("El nombre tiene que estar completo");
                return;
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("El estado tiene que estar completo");
                return;
            }
            string consulta;
            if (comboBox1.Text == "Activo")
            {
                consulta = "update EN_CASA_ANDABA.Roles set rol_nombre = '" + textBox1.Text + "', rol_estado=1 where rol_id= " + ID;
                resultado = Home.BD.comando(consulta);
                resultado.Read();
                resultado.Close();
            }
            else
            {
                consulta = "update EN_CASA_ANDABA.Roles set rol_nombre = '" + textBox1.Text + "', rol_estado=0 where rol_id= " + ID;
                resultado = Home.BD.comando(consulta);
                resultado.Read();
                resultado.Close();
            }
            decimal idF = 0;
            if (!string.IsNullOrEmpty(comboBox2.Text) && (comboBox2.Text!="Ninguna"))
            {
                //agregar func, insert
                consulta = "select fun_id from GESTION_DE_GATOS.Funcionalidades where fun_desc = '"+comboBox2.Text+"'";
                resultado = Home.BD.comando(consulta);
                if (resultado.Read())
                {
                    idF = resultado.GetDecimal(0);
                }
                resultado.Close();
                consulta = "EXEC EN_CASA_ANDABA.altaFuncionalidadRol " + ID + "," + idF;
                resultado = Home.BD.comando(consulta);
                decimal resu =0;
                if (resultado.Read())
                {
                    resu = resultado.GetDecimal(0);                    
                }
                if(resu!=0)
                {
                    MessageBox.Show("La funcionalidad fue agregada correctamente");
                }
                else
                {
                    MessageBox.Show("La funcionalidad no se pudo agregar correctamente");
                }
                resultado.Close();
            }
            if (!string.IsNullOrEmpty(comboBox3.Text) && (comboBox3.Text != "Ninguna"))
            {
                //delete
                consulta = "select fun_id from GESTION_DE_GATOS.Funcionalidades where fun_desc = '"+comboBox3.Text+"'";
                resultado = Home.BD.comando(consulta);
                if (resultado.Read())
                {
                    idF = resultado.GetDecimal(0);
                }
                resultado.Close();
                consulta = "delete from EN_CASA_ANDABA.Funcionalidades_Roles where fyr_fun_id = " + idF + " and fyr_rol_id = " + ID;
                resultado = Home.BD.comando(consulta);
                resultado.Read();
                resultado.Close();
                MessageBox.Show("La funcionalidad fue eliminada con exito");
            }
            MessageBox.Show("El rol ha sido modificado exitosamente");
            this.Close();


        }
    }
}

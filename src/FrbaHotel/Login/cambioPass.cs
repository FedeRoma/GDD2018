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
    public partial class cambioPass : Form
    {
        private SqlDataReader resultado;
        public cambioPass()
        {
            InitializeComponent();
            textBox1.Focus();
        }

        private void cambioPass_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Debe escribir la clave actual para continuar");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Debe escribir la clave nueva para continuar");
                return;
            }
            string claveVieja=string.Empty;
            string consulta = "select usu_password from EN_CASA_ANDABA.Usuarios where usu_id = " + Login.HomeLogin.idUsuario.ToString();
            resultado = Home.BD.comando(consulta);
            if (resultado.Read())
            {
                claveVieja = resultado.GetString(0);
            }
            resultado.Close();
            if (claveVieja == Login.HomeLogin.dameHash(textBox1.Text))
            {
                consulta = "update EN_CASA_ANDABA.Usuarios set usu_password = '" + Login.HomeLogin.dameHash(textBox2.Text) + "' where usu_id = " + Login.HomeLogin.idUsuario.ToString();
                resultado = Home.BD.comando(consulta);
                resultado.Read();
                MessageBox.Show("Clave cambiada correctamente");
                resultado.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("La clave anterior no es correcta. Vuelva a intentarlo");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}

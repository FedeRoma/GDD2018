﻿using System;
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
    public partial class Listado : Form
    {
        
        public static decimal direccion = 0;
        Direccion.ListadoDireccion lista;
        private int a = 0;
        string consulta;
        SqlDataReader resultado;
        SqlDataAdapter sAdapter;
        DataTable dTable;
        public Listado()
        {
            InitializeComponent();
            textBoxUser.Focus();
            consulta = "select distinct doc_desc from En_CASA_ANDABA.Documentos";
            resultado = Home.BD.comando(consulta);
            while (resultado.Read() == true)
            {
                comboBoxTipoDoc.Items.Add(resultado.GetSqlString(0));
            }
            resultado.Close();
            consulta = "select hot_calle+hot_calle_nro from GESTION_DE_GATOS.Hoteles";
            resultado = Home.BD.comando(consulta);
            while (resultado.Read() == true)
            {
                comboBoxHotel.Items.Add(resultado.GetSqlString(0));
            }
            resultado.Close();
            consulta = "select rol_nombre from GESTION_DE_GATOS.Roles";
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

        private void Listado_Load(object sender, EventArgs e)
        {
            string query = "select User.usu_nombre Usuario,Rol.rol_nombre Rol,User.usu_nombre Nombre,User.usu_apellido Apellido,User.usu_telefono Tel,User.usu_mail Mail,User.usu_documento Nro_Doc,User.usu_estado Estado,doc.doc_desc Tipo_Doc,Hot.hot_calle+Hot.hot_calle_nro Hotel,User.usu_fecha_nac Fecha_Nac,from	EN_CASA_ANDABA.Usuarios User,EN_CASA_ANDABA.Roles Rol,EN_CASA_ANDABA.Hoteles Hot,EN_CASA_ANDABA.Documentos doc where User.usu_documento = doc.doc_id and Hot.hot_id=";
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
            query = query + this.filtrarExactamentePor("Rol", comboBoxRol.Text);
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
            if(checkBox1.Checked){
            DateTime fecha;
            fecha =Convert.ToDateTime(dateTimePicker1.Value);
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
            a=1;
            lista = new Direccion.ListadoDireccion("usuarioListado");
            lista.Show();
        }

        private void textBoxDir_TextChanged(object sender, EventArgs e)
        {
        }

        private void Listado_Shown(object sender, EventArgs e)
        {
        }

        private void Listado_Activated(object sender, EventArgs e)
        {
            if (direccion != 0)
            {
                textBoxDir.Text = direccion.ToString();
            }
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
            dateTimePicker1.Value = Home.fecha;
            textBoxUser.Focus();
            this.button2_Click(null, null);
        }

        private void Listado_FormClosing(object sender, FormClosingEventArgs e)
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

    }
}

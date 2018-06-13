using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Facturar_Estadia
{
    public partial class Facturacion : Form
    {
        DataTable tablaDias;
        DataTable consumibles;
        string consulta;
        SqlDataReader resultado;
        BindingSource bSource2;
        public Facturacion(string idEstadia)
        {
            InitializeComponent();
            textBox1.Text = idEstadia;
            consulta = "select est_res_id from EN_CASA_ANDABA.Estadias where est_res_id = " + idEstadia;
            resultado = Home.BD.comando(consulta);
            resultado.Read();
            textBox2.Text = resultado.GetDecimal(0).ToString();
            resultado.Close();
            consulta = "select distinct med_desc from EN_CASA_ANDABA.MediosPago";
            resultado = Home.BD.comando(consulta);
            while (resultado.Read() == true)
            {
                comboBox1.Items.Add(resultado.GetSqlString(0));
            }
            resultado.Close();
            consulta = "select est_checkin,est_checkout,est_dias_sobrantes,est_cant_noches,est_precio from EN_CASA_ANDABA.Estadias where est_res_id = " + idEstadia;
            resultado = Home.BD.comando(consulta);
            resultado.Read();
            DateTime ingreso = resultado.GetDateTime(0);
            DateTime salida = resultado.GetDateTime(1);
            decimal diasSobran = resultado.GetDecimal(2);
            decimal cantNoches = resultado.GetDecimal(3);
            decimal precio = resultado.GetDecimal(4);
            textBox4.Text = ingreso.ToShortDateString();
            textBox5.Text = ingreso.AddDays(Convert.ToDouble(cantNoches+diasSobran)).ToShortDateString();
            textBox6.Text = salida.ToShortDateString();
            resultado.Close();
            tablaDias = new DataTable();
            tablaDias.Columns.Add("Fecha");
            tablaDias.Columns.Add("Precio");
            tablaDias.Columns.Add("Descripcion");
            decimal auxcantnoches = cantNoches;
            decimal auxdiassobran = diasSobran;
            DataRow row = tablaDias.NewRow();
            while (cantNoches >0)
            {
                row = tablaDias.NewRow();
                                     
                row["Fecha"] = ingreso;
                row["Precio"] = precio;
                row["Descripcion"] = "SE ALOJO";
                tablaDias.Rows.Add(row);
                ingreso = ingreso.AddDays(1);
                cantNoches--;
            }
            while (diasSobran > 0)
            {
                row = tablaDias.NewRow();
                
                row["Fecha"] = ingreso;
                row["Precio"] = precio;
                row["Descripcion"] = "NO SE ALOJO";
                tablaDias.Rows.Add(row);
                ingreso = ingreso.AddDays(1);
                diasSobran--;
            }
            bSource2 = new BindingSource();
            bSource2.DataSource = tablaDias;
            dataGridView1.DataSource = bSource2;
            textBox7.Text = (precio * (auxdiassobran + auxcantnoches)).ToString();

            string query = "select It.iyf_cantidad Cantidad, It.iyf_monto Monto from EN_CASA_ANDABA.Items_Facturas it,EN_CASA_ANDABA.Facturas Fact where It.iyf_fac_id = Fact.fac_id  and Fact.fac_est_res_id = "+idEstadia;
            SqlDataAdapter sAdapter = FrbaHotel.Home.BD.dameDataAdapter(query);
            consumibles = FrbaHotel.Home.BD.dameDataTable(sAdapter);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = consumibles;
            dataGridView2.DataSource = bSource;

            consulta = "select Con.con_precio from EN_CASA_ANDABA.Consumibles Ccon, where Con.con_id= " + idEstadia;
            resultado = Home.BD.comando(consulta);
            if (resultado.Read()==true)
            {
                resultado.Close();
                consulta = "select sum(Con.con_precio) from EN_CASA_ANDABA.Consumibles Ccon, GESTION_DE_GATOS.Consumibles C where Con.con_id = " + idEstadia;
                resultado = Home.BD.comando(consulta);
                resultado.Read();
                textBox9.Text = resultado.GetDecimal(0).ToString();
            }
            else
            {   
                textBox9.Text = 0.ToString();
            }
            resultado.Close();

            consulta = "select Res.reg_id from EN_CASA_ANDABA.Reservas Res, EN_CASA_ANDABA.Estadias Est where Est_res_id= Res.res_id and Est.est_id = " + idEstadia;
            resultado = Home.BD.comando(consulta);
            resultado.Read();
            decimal regimen = resultado.GetDecimal(0);
            resultado.Close();
            if (regimen == 3)
            {
                textBox8.Text = "-"+textBox9.Text;
                textBox3.Text = textBox7.Text;
            }
            else 
            { 
               textBox8.Text = 0.ToString();
               decimal resu = Convert.ToDecimal(textBox7.Text) + Convert.ToDecimal(textBox9.Text);
               textBox3.Text = (resu).ToString();
            }



        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Debe seleccionar una Forma de pago");
                return;
            }
            consulta = "select med_id from EN_CASA_ANDABA.MediosPago where med_desc = '" + comboBox1.Text +"'";
            resultado = Home.BD.comando(consulta);
            resultado.Read();
            decimal fp = resultado.GetDecimal(0);
            resultado.Close();
            consulta = "EXEC EN_CASA_ANDABA.modificacionFactura " + textBox1.Text +","+fp.ToString()+",'"+Home.fecha.Date+"'";
            resultado = Home.BD.comando(consulta);
            resultado.Read();
            decimal factura = resultado.GetDecimal(0);
            if (factura == 0)
            {
                resultado.Close();
                MessageBox.Show("error al insertar factura, ya esta generada");
                return;
            }
            resultado.Close();
            if (fp == 2)
            {
                Tarjeta tarj = new Tarjeta(factura.ToString());
                tarj.Show();
            }
            MessageBox.Show("Se ha generado la factura correctamente");
            this.Close();
        }
    }
}

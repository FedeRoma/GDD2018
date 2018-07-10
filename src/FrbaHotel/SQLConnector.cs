using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Windows.Forms;


namespace FrbaHotel
{
    public class SQLConnector
    {
        private SqlConnection connection;

        public SQLConnector()
        {
            try
            {
                connection = new SqlConnection("Data Source=.\\SQLSERVER2012;Initial Catalog=GD1C2018;user=gdHotel2018;password=gd2018");
                connection.Open();

            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo conectar a la DB");

            }
        }

        public SqlDataReader consultaGetPuntero(string consulta)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandTimeout = 999999999;

            sqlCommand.Connection = this.connection;
            sqlCommand.CommandText = consulta;

            SqlDataReader ejecutar = sqlCommand.ExecuteReader();
            return ejecutar;
        }

        public DataTable consultaGetTabla(string consulta)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandTimeout = 999999999;

            sqlCommand.Connection = this.connection;
            sqlCommand.CommandText = consulta;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta, this.connection);

            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        public int consultaGetInt(string consulta)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandTimeout = 999999999;

            sqlCommand.Connection = this.connection;
            sqlCommand.CommandText = consulta;

            int retorno = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlCommand.Dispose();
            sqlCommand = null;
            return retorno;
        }

        public string consultaGetString(string consulta)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandTimeout = 999999999;

            sqlCommand.Connection = this.connection;
            sqlCommand.CommandText = consulta;

            string retorno = Convert.ToString(sqlCommand.ExecuteScalar());
            sqlCommand.Dispose();
            sqlCommand = null;
            return retorno;
        }


    }
}

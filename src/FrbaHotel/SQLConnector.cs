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
            SqlCommand queryCommand = new SqlCommand();
            queryCommand.CommandTimeout = 999999999;

            queryCommand.Connection = this.connection;
            queryCommand.CommandText = consulta;

            queryCommand.CommandType = CommandType.StoredProcedure;
            return (int)queryCommand.ExecuteScalar();
        }

        public string consultaGetString(string consulta)
        {
            SqlCommand queryCommand = new SqlCommand();
            queryCommand.CommandTimeout = 999999999;

            queryCommand.Connection = this.connection;
            queryCommand.CommandText = consulta;

            string retorno = Convert.ToString(queryCommand.ExecuteScalar());
            queryCommand.Dispose();
            queryCommand = null;
            return retorno;
        }


    }
}
/*
 * 
 * 
 * 
 *         public string consultaGetDato(string consulta)
        {
            SqlCommand queryCommand = new SqlCommand();
            queryCommand.CommandTimeout = 999999999;

            queryCommand.Connection = this.connection;
            queryCommand.CommandText = consulta;

            string retorno = Convert.ToString(queryCommand.ExecuteScalar());
            queryCommand.Dispose();
            queryCommand = null;
            return retorno;
        }        
 * 
 * public int consultaGetCampo(string consulta)
        {
            SqlCommand queryCommand = new SqlCommand(consulta, connection);

            queryCommand.CommandType = CommandType.StoredProcedure;
            return (int)queryCommand.ExecuteScalar();
        }
 * public static DataSet ejecutarQueryTraeSetDatos(SqlCommand consulta)
        {
            DataSet dataSet = new DataSet();
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta);
                dataAdapter.Fill(dataSet);
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message);
            }
            return dataSet;
        }

        public static DataTable ejecutarQueryDevuelveTabla(SqlCommand consulta)
        {
            DataSet dataSet = ejecutarQueryTraeSetDatos(consulta);
            DataTable tabla = dataSet.Tables[0];
            return tabla;
        }
        public SqlCommand armaQueryStoreProcedure(string nombre)
        {
            SqlCommand queryCommand = new SqlCommand(nombre, connection);
            queryCommand.CommandType = CommandType.StoredProcedure;
            return queryCommand;
        }



        public void ejecutaQuery(string query)
        {
            SqlCommand queryCommand = new SqlCommand();
            queryCommand.CommandTimeout = 999999999;
            queryCommand.Connection = this.connection;
            queryCommand.CommandText = query;
            queryCommand.ExecuteNonQuery();
            queryCommand.Dispose();
            queryCommand = null;
        }





/*        public SqlDataAdapter dameDataAdapter(string consulta)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandTimeout = 999999999;
            sqlCommand.Connection = this.connection;
            sqlCommand.CommandText = consulta;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta, this.connection);
            return dataAdapter;
        }

        public DataTable dameDataTable(SqlDataAdapter dataAdapter)
        {
            DataTable dataTable = new DataTable();
            dataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(dataTable);
            return dataTable;
        }
        /*ejecutar dameDataAdapter y luego ejecutar dameDataTable es lo mismo que ejecutar
         * ejecutarQueryTraeTabla(string consulta)*/
/*       


  /*Funciones copadas para usar en vistas
      public static void comboBoxCargar(ComboBox comboBox, List<string> listaDatos)
      {
          comboBox.Items.Clear();
          foreach (string dato in listaDatos)
              comboBox.Items.Add(dato);
          if (comboBox.Items.Count > 0)
              comboBox.SelectedIndex = 0;
      }

      public static int consultaEjecutar(SqlCommand consulta)
      {
          int resultado = 0;
          
          try
          {
              resultado = consulta.ExecuteNonQuery();
          }
          catch (Exception excepcion)
          {
              /*mostrar error
          }
            
          return resultado;
      }

        
      public static DataSet consultaDevuelveSetDatos(SqlCommand consulta)
      {
          DataSet dataSet = new DataSet();
          try
          {
              SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta);
              dataAdapter.Fill(dataSet);
          }
          catch (Exception excepcion)
          {
              /*mostrar error
          }
          return dataSet;
      }

      public static DataTable consultaDevuelveTabla(SqlCommand consulta)
      {
          DataSet dataSet = consultaDevuelveSetDatos(consulta);
          DataTable tabla = dataSet.Tables[0];
          return tabla;
      }


      public static List<string> ObtenerListaDeConsulta(SqlCommand consulta)
      {
          DataTable tabla = consultaDevuelveTabla(consulta) /*LO MISMO QUE MI DAMEDATATABLE;
          List<string> columna = new List<string>();
          if (tabla.Rows.Count > 0)
              foreach (DataRow fila in tabla.Rows)
                  columna.Add(fila[0].ToString());
          return columna;
      }

*/

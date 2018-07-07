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

namespace FrbaHotel.AbmHotel
{
    public partial class AltaHotel : Form
    {
        private SqlDataReader qry;
        public static MenuAbmHotel AbmHot;
        string insert = "";
        

        public AltaHotel()
        {
            InitializeComponent();
            fechaCreacion.Value = DateTime.Today;
        }

        private bool checkCampos()
        {
            bool inconsistencias = false;
            string alerta = "";

            if (string.IsNullOrEmpty(nombre.Text))
            {
                alerta = alerta + "Debe ingresar un nombre válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(cantidadEstrellas.Text))
            {
                alerta = alerta + "Debe ingresar una cantidadEstrellas válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(recargaEstrellas.Text))
            {
                alerta = alerta + "Debe ingresar una Recarga Estrellas válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(ciudad.Text))
            {
                alerta = alerta + "Debe ingresar una Ciudad válida\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(eMail.Text))
            {
                alerta = alerta + "Debe ingresar un eMail válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(calleNumero.Text))
            {
                alerta = alerta + "Debe ingresar un numero de calle válida\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(calle.Text) || string.IsNullOrEmpty(calleNumero.Text))
            {
                alerta = alerta + "Debe ingresar una dirección válida\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(telefono.Text))
            {
                alerta = alerta + "Debe ingresar un teléfono válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(pais.Text) || string.IsNullOrEmpty(pais.Text))
            {
                alerta = alerta + "Debe ingresar un pais válidos\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(fechaCreacion.Text))
            {
                alerta = alerta + "Debe ingresar un nombre válido\n";
                inconsistencias = true;
            }

            DateTime fechaNac, hoy;
            fechaNac = Convert.ToDateTime(fechaCreacion.Value);
            hoy = DateTime.Today;

            if (DateTime.Compare(fechaNac, hoy) >= 0)
            {
                alerta = alerta + "Debe ingresar una fecha de nacimiento válida\n";
                inconsistencias = true;
            }

            if (inconsistencias)
            {
                MessageBox.Show(alerta);
            }
            return inconsistencias;
        }//Fin CheckSUM



        private string insertString(string campo)
        {
            if (string.IsNullOrEmpty(campo))
            {
                insert = insert + "null,";
            }
            else
            {
                insert = insert + "'" + campo + "',";
            }
            return insert;
        }

        private string insertNro(string campo)
        {
            if (string.IsNullOrEmpty(campo))
            {
                insert = insert + "null,";
            }
            else
            {
                insert = insert + "" + campo + ",";
            }
            return insert;
        }
        
        private void guardar_Click(object sender, EventArgs e)
        {
            if (!checkCampos())
            {
                insert = "exec EN_CASA_ANDABA.altaHotel ";
                /*	@nombre varchar(50), 
                 *  @cantEstrellas int, 
                 *  @calle varchar(50), 
                 *  @numero int, 
                 *  @ciudad varchar(50), 
	                @pais varchar(50), 
                 *  @email nvarchar(50), 
                 *  @telefono varchar(50), 
                 *  @fecha datetime,
	                @recargaEstrellas int as*/
                insert = insertNro(nombre.Text);
                insert = insertString(cantidadEstrellas.Text);
                insert = insertString(calle.Text);
                insert = insertString(calleNumero.Text);
                insert = insertString(ciudad.Text);
                insert = insertString(pais.Text);
                insert = insertString(eMail.Text);
                insert = insertString(telefono.Text);
                DateTime fecha;
                fecha = Convert.ToDateTime(fechaCreacion.Value);
                insert = insertString(fecha.Date.ToString("yyyyMMdd HH:mm:ss"));
                insert = insertString(recargaEstrellas.Text);
                insert = insert.Remove(insert.Length - 1);

                bool insertOk = false;

                qry = Index.BD.consultaGetPuntero(insert);
                if (qry.Read())
                {
                    insertOk = qry.GetBoolean(0);
                }
                qry.Close();

                if (insertOk)
                {
                    MessageBox.Show("Hotel dado de alta");
                }
                else
                {
                    MessageBox.Show("#error: no se ha podido realizar la operación");
                }
                limpiar.PerformClick();
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Text = string.Empty;
            cantidadEstrellas.Text = string.Empty;
            recargaEstrellas.Text = string.Empty;
            eMail.Text = string.Empty;
            calle.Text = string.Empty;
            calleNumero.Text = string.Empty;
            ciudad.Text = string.Empty;
            pais.Text = string.Empty;
            telefono.Text = string.Empty;
            nombre.Focus();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmHot = new MenuAbmHotel();
            AbmHot.Show();
        }

    }
}

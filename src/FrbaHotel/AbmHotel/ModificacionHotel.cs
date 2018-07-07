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
    public partial class ModificacionHotel : Form
    {
        private SqlDataReader qry;
        public static MenuAbmHotel AbmHot;
        string insert = "";
        private DataTable tablaRegimenes;
        private DataTable tablaRegimenesAsig;
        private string regimenes = "";
        private int cantRegimenes = 0;
        private string nombre1;
        private string eMail1;
        private string telefono1;
        private string cantidadEstrellas1;
        private string recargaEstrellas1;
        private string fecha_creacion;
        private string calle1;
        private string calleNro;
        private string ciudad1;
        private string pais1;



  /*      public ModificacionHotel()
        {
            InitializeComponent();
            rolID = idRol;
            nombre.Text = nombreRol;
            if (estadoRol == "True")
            {
                estado.Checked = true;
            }
            nombre.Focus();

            qry = Index.BD.consultaGetPuntero("select F.fun_desc from EN_CASA_ANDABA.Funcionalidades_Roles FR, EN_CASA_ANDABA.Funcionalidades F where F.fun_id = FR.fyr_fun_id and FR.fyr_rol_id = " + idRol);

            bajaFuncionalidad.Items.Add("Ninguna");
            while (qry.Read())
            {
                bajaFuncionalidad.Items.Add(qry.GetString(0));
            }
            qry.Close();
            bajaFuncionalidad.SelectedIndex = 0;

            qry = Index.BD.consultaGetPuntero("select fun_desc from EN_CASA_ANDABA.Funcionalidades except select F.fun_desc from EN_CASA_ANDABA.Funcionalidades_Roles FR, EN_CASA_ANDABA.Funcionalidades F where F.fun_id = FR.fyr_fun_id and FR.fyr_rol_id = " + idRol);

            altaFuncionalidad.Items.Add("Ninguna");
            while (qry.Read())
            {
                altaFuncionalidad.Items.Add(qry.GetString(0));
            }
            qry.Close();
            altaFuncionalidad.SelectedIndex = 0;
            nombre.Focus();
        }*/

        public ModificacionHotel(string nombre1, string eMail1, string telefono1, string cantidadEstrellas1, string recargaEstrellas1, string fecha_creacion, string calle1, string calleNro, string ciudad1)
        {
            // TODO: Complete member initialization
            this.nombre1 = nombre1;
            this.eMail1 = eMail1;
            this.telefono1 = telefono1;
            this.cantidadEstrellas1 = cantidadEstrellas1;
            this.recargaEstrellas1 = recargaEstrellas1;
            this.fecha_creacion = fecha_creacion;
            this.calle1 = calle1;
            this.calleNro = calleNro;
            this.ciudad1 = ciudad1;
        }

        public ModificacionHotel(string nombre1, string eMail1, string telefono1, string cantidadEstrellas1, string recargaEstrellas1, string fecha_creacion, string calle1, string calleNro, string ciudad1, string pais1)
        {
            // TODO: Complete member initialization
            this.nombre1 = nombre1;
            this.eMail1 = eMail1;
            this.telefono1 = telefono1;
            this.cantidadEstrellas1 = cantidadEstrellas1;
            this.recargaEstrellas1 = recargaEstrellas1;
            this.fecha_creacion = fecha_creacion;
            this.calle1 = calle1;
            this.calleNro = calleNro;
            this.ciudad1 = ciudad1;
            this.pais1 = pais1;
        }

        private void cantidadEstrellas_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void recargaEstrellas_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void calleNro_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
                //limpiar.PerformClick();
            }
        }

/*        private void limpiar_Click(object sender, EventArgs e)
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
*/
        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmHot = new MenuAbmHotel();
            AbmHot.Show();
        }




    }
}

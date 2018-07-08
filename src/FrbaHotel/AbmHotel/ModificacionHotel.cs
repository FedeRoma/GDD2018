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
        public static ListadoHoteles ListadoHoteles;
        int hotelID = 0;
        string update = "";

        public ModificacionHotel(string nombreHot, string eMailHot, string telefonoHot, string cantidadEstrellasHot, 
                                    string recargaEstrellasHot, string fechaCreacionHot, string calleHot, 
                                    string calleNroHot, string ciudadHot, string paisHot, string estadoHot)
        {
            InitializeComponent();

            nombre.Text = nombreHot;
            cantidadEstrellas.Text = cantidadEstrellasHot;
            recargaEstrellas.Text = recargaEstrellasHot;
            eMail.Text = eMailHot;
            calle.Text = calleHot;
            calleNumero.Text = calleNroHot;
            ciudad.Text = ciudadHot;
            pais.Text = paisHot;
            telefono.Text = telefonoHot;
            
            if (fechaCreacionHot == "")
            {
                fechaCreacion.Value = new DateTime(1900, 1, 1);
            }
            else 
            {
                fechaCreacion.Value = Convert.ToDateTime(fechaCreacionHot);
            }
          
            if (estadoHot == "True")
            {
                estado.Checked = true;
            }

            qry = Index.BD.consultaGetPuntero("select hot_id from EN_CASA_ANDABA.Hoteles where hot_calle = '" + calleHot + "' and hot_calle_nro = " + calleNroHot);
            if (qry.Read())
            {
                hotelID = qry.GetInt32(0); 
            }
            qry.Close();

            qry = Index.BD.consultaGetPuntero("select R.reg_desc from EN_CASA_ANDABA.Regimenes_Hoteles RH, EN_CASA_ANDABA.Regimenes R where R.reg_id = RH.ryh_reg_id and RH.ryh_hot_id = " + hotelID);

            bajaRegimen.Items.Add("Ninguna");
            while (qry.Read())
            {
                bajaRegimen.Items.Add(qry.GetString(0));
            }
            qry.Close();
            bajaRegimen.SelectedIndex = 0;

            qry = Index.BD.consultaGetPuntero("select R.reg_desc from EN_CASA_ANDABA.Regimenes_Hoteles RH, EN_CASA_ANDABA.Regimenes R except select R.reg_desc from EN_CASA_ANDABA.Regimenes_Hoteles RH, EN_CASA_ANDABA.Regimenes R where R.reg_id = RH.ryh_reg_id and RH.ryh_hot_id = " + hotelID);

            altaRegimen.Items.Add("Ninguna");
            while (qry.Read())
            {
                altaRegimen.Items.Add(qry.GetString(0));
            }
            qry.Close();
            altaRegimen.SelectedIndex = 0;

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
                alerta = alerta + "Debe ingresar una cantidad de estrellas válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(recargaEstrellas.Text))
            {
                alerta = alerta + "Debe ingresar una recarga estrellas válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(eMail.Text))
            {
                alerta = alerta + "Debe ingresar un eMail válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(calle.Text) || string.IsNullOrEmpty(calleNumero.Text))
            {
                alerta = alerta + "Debe ingresar una dirección válida\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(ciudad.Text))
            {
                alerta = alerta + "Debe ingresar una ciudad válida\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(pais.Text) || string.IsNullOrEmpty(pais.Text))
            {
                alerta = alerta + "Debe ingresar un pais válido\n";
                inconsistencias = true;
            }
            if (string.IsNullOrEmpty(telefono.Text))
            {
                alerta = alerta + "Debe ingresar un teléfono válido\n";
                inconsistencias = true;
            }

            if (string.IsNullOrEmpty(fechaCreacion.Text))
            {
                alerta = alerta + "Debe ingresar una fecha de alta válida\n";
                inconsistencias = true;
            }

            DateTime fechaCrea, hoy;
            fechaCrea = Convert.ToDateTime(fechaCreacion.Value);
            hoy = DateTime.Today;

            if (DateTime.Compare(fechaCrea, hoy) >= 0)
            {
                alerta = alerta + "Debe ingresar una fecha de alta válida\n";
                inconsistencias = true;
            }

            if (inconsistencias)
            {
                MessageBox.Show(alerta);
            }
            return inconsistencias;
        }

        private string updateString(string campo)
        {
            if (string.IsNullOrEmpty(campo))
            {
                update = update + "null,";
            }
            else
            {
                update = update + "'" + campo + "',";
            }
            return update;
        }

        private string updateNro(string campo)
        {
            if (string.IsNullOrEmpty(campo))
            {
                update = update + "null,";
            }
            else
            {
                update = update + "" + campo + ",";
            }
            return update;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (!checkCampos())
            {
                update = "exec EN_CASA_ANDABA.modificacionHotel ";
                update = updateNro(hotelID.ToString());
                update = updateString(nombre.Text);
                update = updateNro(cantidadEstrellas.Text);
                update = updateString(calle.Text);
                update = updateNro(calleNumero.Text);
                update = updateString(ciudad.Text);
                update = updateString(pais.Text);
                update = updateString(eMail.Text);
                update = updateString(telefono.Text);

                DateTime fecha;
                fecha = Convert.ToDateTime(fechaCreacion.Value);
                update = updateString(fecha.Date.ToString("yyyyMMdd HH:mm:ss"));

                if (estado.Text == "True")
                {
                    update = updateNro("1");
                }
                else
                {
                    update = updateNro("0");
                }

                update = updateNro(recargaEstrellas.Text);

                update = update.Remove(update.Length - 1);

                bool insertOk = false;

                qry = Index.BD.consultaGetPuntero(update);
                if (qry.Read())
                {
                    insertOk = qry.GetBoolean(0);
                }
                qry.Close();

                if (insertOk)
                {
                    MessageBox.Show("Hotel modificado con éxito");
                    atras_Click(null, null);
                }
                else
                {
                    MessageBox.Show("#error: no se ha podido realizar la operación");
                }
            }
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListadoHoteles = new ListadoHoteles();
            ListadoHoteles.Show();
        }

    }
}

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

namespace FrbaHotel.AbmRol
{
    public partial class ModificacionRol : Form
    {
        private SqlDataReader qry;
        public static ListadoRoles ListadoRoles;
        string rolID;

        public ModificacionRol(string idRol, string nombreRol, string estadoRol)
        {
            InitializeComponent();

            rolID = idRol;
            nombre.Text = nombreRol;
            if (estadoRol == "True")
            {
                estado.Checked = true;
            }

            qry = Index.BD.consultaGetPuntero("select F.fun_desc from EN_CASA_ANDABA.Funcionalidades_Roles FR, EN_CASA_ANDABA.Funcionalidades F where F.fun_id = FR.fyr_fun_id and FR.fyr_rol_id = " + idRol); 

            bajaFuncionalidad.Items.Add("Ninguna");         
            while (qry.Read())
            {
                if (qry.GetString(0) != "ABM Rol") // la funcionalidad ABM Rol es exclusiva del SysAdmin
                {
                    bajaFuncionalidad.Items.Add(qry.GetString(0));
                }              
            }
            qry.Close();
            bajaFuncionalidad.SelectedIndex = 0;

            qry = Index.BD.consultaGetPuntero("select fun_desc from EN_CASA_ANDABA.Funcionalidades except select F.fun_desc from EN_CASA_ANDABA.Funcionalidades_Roles FR, EN_CASA_ANDABA.Funcionalidades F where F.fun_id = FR.fyr_fun_id and FR.fyr_rol_id = " + idRol);

            altaFuncionalidad.Items.Add("Ninguna");
            while (qry.Read())
            {
                if (qry.GetString(0) != "ABM Rol") // la funcionalidad ABM Rol es exclusiva del SysAdmin
                {
                    altaFuncionalidad.Items.Add(qry.GetString(0));
                }
            }
            qry.Close();
            altaFuncionalidad.SelectedIndex = 0;
            nombre.Focus();
        }

        private bool checkCampos()
        {
            bool inconsistencias = false;
            string alerta = "";

            if (string.IsNullOrEmpty(nombre.Text))
            {
                alerta = alerta + "Debe ingresar un nombre válido";
                inconsistencias = true;
            }

            if (inconsistencias)
            {
                MessageBox.Show(alerta);
            }
            return inconsistencias;
        }
        
        private void guardar_Click(object sender, EventArgs e)
        {
            if (!checkCampos())
            {
                string nuevoEstado;
                if (estado.Checked)
                {
                    nuevoEstado = "1";
                }
                else
                {
                    nuevoEstado = "0";
                }
                
                qry = Index.BD.consultaGetPuntero("update EN_CASA_ANDABA.Roles set rol_nombre = '" + nombre.Text + "', rol_estado = " + nuevoEstado + " where rol_id = " + rolID);
                qry.Close();

                int funcionalidadID = 0;
                if (!string.IsNullOrEmpty(altaFuncionalidad.Text) && (altaFuncionalidad.Text != "Ninguna"))
                {
                    qry = Index.BD.consultaGetPuntero("select fun_id from EN_CASA_ANDABA.Funcionalidades where fun_desc = '" + altaFuncionalidad.Text + "'");
                    if (qry.Read())
                    {
                        funcionalidadID = qry.GetInt32(0);
                    }
                    qry.Close();

                    qry = Index.BD.consultaGetPuntero("exec EN_CASA_ANDABA.altaFuncionalidadRol " + rolID.ToString() + "," + funcionalidadID);
                    qry.Close();
                }

                if (!string.IsNullOrEmpty(bajaFuncionalidad.Text) && (bajaFuncionalidad.Text != "Ninguna"))
                {
                    qry = Index.BD.consultaGetPuntero("select fun_id from EN_CASA_ANDABA.Funcionalidades where fun_desc = '" + bajaFuncionalidad.Text + "'");
                    if (qry.Read())
                    {
                        funcionalidadID = qry.GetInt32(0);
                    }
                    qry.Close();

                    qry = Index.BD.consultaGetPuntero("delete from EN_CASA_ANDABA.Funcionalidades_Roles where fyr_fun_id = " + funcionalidadID + " and fyr_rol_id = " + rolID);
                    qry.Close();
                }
                
                MessageBox.Show("Rol modificado con éxito");
                atras_Click(null, null);
            }
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListadoRoles = new ListadoRoles();
            ListadoRoles.Show();
        }

    }
}

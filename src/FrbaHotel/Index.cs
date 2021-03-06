﻿using FrbaHotel.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class Index : Form
    {
        public static SQLConnector BD = new SQLConnector();
        private SqlDataReader qry;
        public static Login.Login login;
        public static RolesUsuario rolesUsuario;
        public static int usuarioID = 0;
        public static bool estadoID = true;
        public static string rol = "";
        public static string hotel = "";
       
        public Index()
        {
            InitializeComponent();

            string minFechaReservas = DateTime.Today.ToShortDateString();

            int reservasVencidasCanceladas = Index.BD.consultaGetInt("exec EN_CASA_ANDABA.bajaReservasVencidas '" + DateTime.Today.ToString() + "'");

            if (reservasVencidasCanceladas == 1)
            {
                estadoReservasVencidas.Text = "NO HAY RESERVAS ACTIVAS ANTERIORES AL";
                minFechaRes.Text = minFechaReservas;
            }
        }

        private void iniciarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            login = new Login.Login();
            login.Show();
        }

        private void invitado_Click(object sender, EventArgs e)
        {
            qry = Index.BD.consultaGetPuntero("select usu_id,usu_estado FROM EN_CASA_ANDABA.Usuarios where usu_username = 'Guest'");
            qry.Read();
            usuarioID = qry.GetInt32(0);
            estadoID = qry.GetBoolean(1);
            qry.Close();
            if (estadoID != false)
            {
                qry = Index.BD.consultaGetPuntero("select distinct R.rol_nombre from EN_CASA_ANDABA.Roles_Usuarios RU, EN_CASA_ANDABA.Roles R where RU.ryu_rol_id = R.rol_id and RU.ryu_usu_id = " + usuarioID.ToString() + " and R.rol_estado = 1");
                if (qry.Read())
                {
                    rol = qry.GetString(0);
                    qry.Close();
                    this.Hide();
                    rolesUsuario = new RolesUsuario();
                    rolesUsuario.Show();
                }
            }
            else
            {
                qry.Close();
                MessageBox.Show("#error: Rol de Guest inhabilitado");
            }
        }

    }
}
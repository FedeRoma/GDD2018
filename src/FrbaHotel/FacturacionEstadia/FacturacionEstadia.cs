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

namespace FrbaHotel.FacturacionEstadia
{
    public partial class FacturacionEstadia : Form
    {
        DataTable tablaDetalleEstadias;
        DataTable tablaDetalleConsumibles;
        private SqlDataReader qry;
        DateTime chkIn, chkOut;
        int diasSobrantes, cantNoches, precio;
        int subConsumibles, subEstadia;

        public FacturacionEstadia(string estadiaID)
        {
            InitializeComponent();

            estadia.Text = estadiaID;

            qry = Index.BD.consultaGetPuntero("select R.res_id from EN_CASA_ANDABA.Estadias E, EN_CASA_ANDABA.Reservas R where E.est_res_id = R.res_id and R.res_id = "+ estadiaID);
            if (qry.Read())
            {
                reserva.Text = qry.GetInt32(0).ToString();
            }
            qry.Close();

            qry = Index.BD.consultaGetPuntero("select distinct med_desc from EN_CASA_ANDABA.MediosPago");
            while (qry.Read())
            {
                formasDePago.Items.Add(qry.GetString(0));
            }
            qry.Close();
                       
            qry = Index.BD.consultaGetPuntero("select est_checkin, est_checkout, est_dias_sobrantes, est_cant_noches, est_precio from EN_CASA_ANDABA.Estadias where est_res_id = " + estadiaID);
            if (qry.Read())
            {
                chkIn = qry.GetDateTime(0);
                chkOut = qry.GetDateTime(1);
                diasSobrantes = qry.GetInt32(2);
                cantNoches = qry.GetInt32(3);
                precio = qry.GetInt32(4);
                fechaIngreso.Text = chkIn.ToShortDateString();
                fechaEgreso.Text = chkIn.AddDays(Convert.ToDouble(cantNoches + diasSobrantes)).ToShortDateString();
                checkOut.Text = chkOut.ToShortDateString();
            }
            qry.Close();

            tablaDetalleEstadias = new DataTable();
            tablaDetalleEstadias.Columns.Add("FECHA");
            tablaDetalleEstadias.Columns.Add("PRECIO");
            tablaDetalleEstadias.Columns.Add("DESCRIPCION");

            DataRow fila = tablaDetalleEstadias.NewRow();
            int i = cantNoches;
            while (i > 0)
            {
                fila = tablaDetalleEstadias.NewRow();
                fila["FECHA"] = chkIn;
                fila["PRECIO"] = precio;
                fila["DESCRIPCION"] = "Ocupada";
                tablaDetalleEstadias.Rows.Add(fila);
                chkIn = chkIn.AddDays(1);
                i--;
            }
            int j = diasSobrantes;
            while (j > 0)
            {
                fila = tablaDetalleEstadias.NewRow();
                fila["FECHA"] = chkIn;
                fila["PRECIO"] = precio;
                fila["DESCRIPCION"] = "Libre";
                tablaDetalleEstadias.Rows.Add(fila);
                j--;
            }

            BindingSource bindingSourceDetalleEstadia = new BindingSource();
            bindingSourceDetalleEstadia.DataSource = tablaDetalleEstadias;
            listaDetalleEstadia.DataSource = bindingSourceDetalleEstadia;

            subEstadia = (precio * (diasSobrantes + cantNoches));
            subtotalEstadia.Text = subEstadia.ToString();

            tablaDetalleConsumibles = Index.BD.consultaGetTabla("select IT.iyf_cantidad CANTIDAD, IT.iyf_monto MONTO from EN_CASA_ANDABA.Items_Facturas IT, EN_CASA_ANDABA.Facturas F where IT.iyf_fac_id = F.fac_id and F.fac_est_res_id = " + estadiaID);
            BindingSource bindingSourceConsumibles = new BindingSource();
            bindingSourceConsumibles.DataSource = tablaDetalleConsumibles;
            listaConsumibles.DataSource = bindingSourceConsumibles;

            subConsumibles = Index.BD.consultaGetInt("select EN_CASA_ANDABA.deudaConsumibles(" + estadiaID + ")");
            subtotalConsumibles.Text = subConsumibles.ToString();

            int regimen = 0;
            qry = Index.BD.consultaGetPuntero("select R.res_id from EN_CASA_ANDABA.Estadias E, EN_CASA_ANDABA.Reservas R where E.est_res_id = R.res_id and R.res_id = " + estadiaID);
            if (qry.Read())
            {
                regimen = qry.GetInt32(0);
            }
            qry.Close();

            if (regimen == 3)
            {
                bonificacion.Text = "- (" + subtotalConsumibles.Text + ")";
                totalFactura.Text = subtotalEstadia.Text;
            }
            else
            {
                bonificacion.Text = "0";
                int total = subEstadia + subConsumibles;
                totalFactura.Text = (total).ToString();
            }
        }
        
        private bool checkCampos()
        {
            bool inconsistencias = false;
            string alerta = "";

            if (string.IsNullOrEmpty(formasDePago.Text))
            {
                alerta = alerta + "Debe seleccionar una forma de pago\n";
                inconsistencias = true;
            }

            qry = Index.BD.consultaGetPuntero("select fac_id from EN_CASA_ANDABA.Facturas where fac_est_res_id = "+ estadia.Text);
            if (qry.Read())
            {
                alerta = alerta + "La estadía " + estadia.Text + " ya fue facturada\nFactura Nro.: " + qry.GetInt32(0).ToString() + "\n";
                inconsistencias = true;
            }
            qry.Close();
            
            if (inconsistencias)
            {
                MessageBox.Show(alerta);
            }
            return inconsistencias;
        }

        private void generarFactura_Click(object sender, EventArgs e)
        {
            if (!checkCampos())
            {
                int medioPagoID = Index.BD.consultaGetInt("select med_id from EN_CASA_ANDABA.MediosPago where med_desc = '" + formasDePago.Text + "'");

                int resultado = Index.BD.consultaGetInt("exec EN_CASA_ANDABA.altaFactura " + estadia.Text + ", " + medioPagoID + ", '" + DateTime.Today.ToString("yyyyMMdd HH:mm:ss") + "'");
                if (resultado == 0)
                {
                    MessageBox.Show("#error!");
                    return;
                }
                MessageBox.Show("La factura se ha generado correctamente");
                this.Close();
            }
        }

    }
}

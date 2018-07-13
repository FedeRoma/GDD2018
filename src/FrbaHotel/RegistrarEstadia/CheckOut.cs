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

namespace FrbaHotel.RegistrarEstadia
{
    public partial class CheckOut : Form
    {
        private SqlDataReader qry;
        DataTable tablaEstadias;
        public static MenuRegistrarEstadia MenuEstadia;
        public static FacturacionEstadia.FacturacionEstadia Facturacion;
        string chkOut = "";
        string estadiaID = "";

        public CheckOut()
        {
            InitializeComponent();
        }

        private void CheckOut_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn botonSelec = new DataGridViewButtonColumn();
            botonSelec.Name = "selec";
            listaEstadias.Columns.Add(botonSelec);

            tablaEstadias = Index.BD.consultaGetTabla("select distinct CE.cye_cye_id ESTADIA, CE.cye_hab_id HABITACION, H.hab_numero NUMERO, H.hab_piso PISO from EN_CASA_ANDABA.Estadias E, EN_CASA_ANDABA.Clientes_Estadias CE, EN_CASA_ANDABA.Habitaciones H where E.est_checkout is null and E.est_checkin <= '" + DateTime.Today.ToString("yyyyMMdd HH:mm:ss") + "' and CE.cye_cye_id = E.est_res_id and CE.cye_hab_id = H.hab_id and H.hab_hot_id = " + Index.hotel);
            BindingSource bindingSourcelistaEstadias = new BindingSource();
            bindingSourcelistaEstadias.DataSource = tablaEstadias;
            listaEstadias.DataSource = bindingSourcelistaEstadias;
        }

        private void listaEstadias_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.listaEstadias.Columns[e.ColumnIndex].Name == "selec" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonSelec = this.listaEstadias.Rows[e.RowIndex].Cells["selec"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\selec.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.listaEstadias.Rows[e.RowIndex].Height = icono.Height + 5;
                this.listaEstadias.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }
        }

        private void estadia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void habitacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void piso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private string esExactamente(string col, string clave)
        {
            if (!string.IsNullOrEmpty(clave))
            {
                return col + " = '" + clave + "' and ";
            }
            return "";
        }

        private string updateString(string campo)
        {
            if (string.IsNullOrEmpty(campo))
            {
                chkOut = chkOut + "null,";
            }
            else
            {
                chkOut = chkOut + "'" + campo + "',";
            }
            return chkOut;
        }
        private string updateNro(string campo)
        {
            if (string.IsNullOrEmpty(campo))
            {
                chkOut = chkOut + "null,";
            }
            else
            {
                chkOut = chkOut + "" + campo + ",";
            }
            return chkOut;
        }

        private void listaEstadias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listaEstadias.Columns[e.ColumnIndex].Name == "selec")
            {
                estadiaID = listaEstadias.CurrentRow.Cells[1].Value.ToString();
                chkOut = "exec EN_CASA_ANDABA.altaCheckoutEstadia ";
                chkOut = updateNro(listaEstadias.CurrentRow.Cells[1].Value.ToString());
                chkOut = updateString(DateTime.Today.ToString("yyyyMMdd HH:mm:ss"));
                chkOut = updateNro(Index.usuarioID.ToString());

                chkOut = chkOut.Remove(chkOut.Length - 1);

                bool insertOk = false;

                qry = Index.BD.consultaGetPuntero(chkOut);
                if (qry.Read())
                {
                    insertOk = qry.GetBoolean(0);
                }
                qry.Close();

                if (insertOk)
                {
                    this.Close();
                    MessageBox.Show("CheckOut realizado correctamente");
                    Facturacion = new FacturacionEstadia.FacturacionEstadia(estadiaID);
                    Facturacion.Show();
                }
                else
                {
                    MessageBox.Show("#error: no se ha podido realizar la operación");
                }
                this.Close();
                MenuEstadia = new MenuRegistrarEstadia();
                MenuEstadia.Show();
            }
        }
        
        private void buscar_Click(object sender, EventArgs e)
        {
            DataView vistaEstadias = new DataView(tablaEstadias);
            string filtro = "";
            filtro = filtro + this.esExactamente("[ESTADIA]", estadia.Text);
            filtro = filtro + this.esExactamente("[HABITACION]", habitacion.Text);
            filtro = filtro + this.esExactamente("NUMERO", numero.Text);
            filtro = filtro + this.esExactamente("PISO", piso.Text);

            if (filtro.Length > 0)
            {
                filtro = filtro.Remove(filtro.Length - 4);
            }

            vistaEstadias.RowFilter = filtro;
            listaEstadias.DataSource = vistaEstadias;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            estadia.Clear();
            habitacion.Clear();
            numero.Clear();
            piso.Clear();
            estadia.Focus();
            this.buscar_Click(null, null);
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuEstadia = new MenuRegistrarEstadia();
            MenuEstadia.Show();
        }

    }
}

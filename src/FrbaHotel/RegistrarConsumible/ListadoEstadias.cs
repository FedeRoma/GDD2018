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

namespace FrbaHotel.RegistrarConsumible
{
    public partial class ListadoEstadias : Form
    {
        public static Login.MenuFuncionalidades AbmMenu;
        public static RegistrarConsumible RegConsumible;
        DataTable tablaEstadias;

        public ListadoEstadias()
        {
            InitializeComponent();
        }

        private void RegistrarConsumibles_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn botonSelec = new DataGridViewButtonColumn();
            botonSelec.Name = "selec";
            listaEstadias.Columns.Add(botonSelec);


            tablaEstadias = Index.BD.consultaGetTabla("select distinct CE.cye_cye_id IdEstadia, CE. cye_hab_id IdHabitacion, H.hab_numero NUMERO, H.hab_piso PISO, R.res_reg_id Regimen from EN_CASA_ANDABA.Estadias E, EN_CASA_ANDABA.Clientes_Estadias CE, EN_CASA_ANDABA.Habitaciones H,EN_CASA_ANDABA.Reservas R  where CE. cye_est_res_id = E. est_res_id and CE. cye_hab_id=H.hab_id and (cye_cye_id)is not NULL and CE.cye_hab_hot_id=H.hab_hot_id and est_res_id = R.res_id and H.hab_hot_id =" + Index.hotel);

            BindingSource bindingSourceListaEstadias = new BindingSource();
            bindingSourceListaEstadias.DataSource = tablaEstadias;
            listaEstadias.DataSource = bindingSourceListaEstadias;
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

        private string filtrarExactamentePor(string columna, string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                return columna + " = '" + valor + "' AND ";
            }
            return "";
        }

        private void listaEstadias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listaEstadias.Columns[e.ColumnIndex].Name == "selec")
            {
                string estadiaID = listaEstadias.CurrentRow.Cells[1].Value.ToString();
                string habitacionID = listaEstadias.CurrentRow.Cells[2].Value.ToString();
                string numero = listaEstadias.CurrentRow.Cells[3].Value.ToString();
                string piso = listaEstadias.CurrentRow.Cells[4].Value.ToString();
                string regimen = listaEstadias.CurrentRow.Cells[5].Value.ToString();

                RegConsumible = new RegistrarConsumible(estadiaID, habitacionID, numero, piso, regimen);
                RegConsumible.Show();
                this.Hide();
            }

        }

        private void buscar_Click(object sender, EventArgs e)
        {
            DataView vistaEstadias = new DataView(tablaEstadias);
            string filtro = "";
            filtro = filtro + this.filtrarExactamentePor("IdEstadia", estadia.Text);
            filtro = filtro + this.filtrarExactamentePor("IdHabitacion", habitacion.Text);
            filtro = filtro + this.filtrarExactamentePor("NUMERO", numero.Text);
            filtro = filtro + this.filtrarExactamentePor("PISO", piso.Text);

            if (filtro.Length > 0)
            {
                filtro = filtro.Remove(filtro.Length - 4);
            }

            vistaEstadias.RowFilter = filtro;
            listaEstadias.DataSource = vistaEstadias;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            estadia.ResetText();
            habitacion.Clear();
            numero.Clear();
            piso.Clear();
            estadia.Focus();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmMenu = new FrbaHotel.Login.MenuFuncionalidades();
            AbmMenu.Show();
        }
    }

}
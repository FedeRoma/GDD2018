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
    public partial class ListadoHoteles : Form
    {
        private SqlDataReader qry;
        public static MenuAbmHotel AbmHot;
        public static ModificacionHotel ModifHot;
        DataTable tablaHoteles;


        public ListadoHoteles()
        {
            InitializeComponent();
        }

        private void ListadoHoteles_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn botonModif = new DataGridViewButtonColumn();
            botonModif.Name = "modif";
            listaHoteles.Columns.Add(botonModif);

            tablaHoteles = Index.BD.consultaGetTabla("select hot_nombre Nombre,hot_mail Mail,hot_telefono Tel,hot_estrellas Estrellas,hot_recarga_estrellas RecargaEstrella,hot_fecha_cre FechaCreacion, hot_calle Calle, hot_calle_nro Numero_Calle, hot_ciudad Ciudad,hot_pais Pais from EN_CASA_ANDABA.Hoteles");
            BindingSource bindingSourcelistaHoteles = new BindingSource();
            bindingSourcelistaHoteles.DataSource = tablaHoteles;
            listaHoteles.DataSource = bindingSourcelistaHoteles;
        }

        private string esExactamente(string col, string clave)
        {
            if (!string.IsNullOrEmpty(clave))
            {
                return col + " = '" + clave + "' and ";
            }
            return "";
        }
        private string esAproximadamente(string col, string clave)
        {
            if (!string.IsNullOrEmpty(clave))
            {
                return col + " like '%" + clave + "%' and ";
            }
            return "";
        }
        private void listaHoteles_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.listaHoteles.Columns[e.ColumnIndex].Name == "modif" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonModif = this.listaHoteles.Rows[e.RowIndex].Cells["modif"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\pencil.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.listaHoteles.Rows[e.RowIndex].Height = icono.Height + 5;
                this.listaHoteles.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }
        }
        private void listaHoteles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listaHoteles.Columns[e.ColumnIndex].Name == "modif")
            {
                string nombre = listaHoteles.CurrentRow.Cells[1].Value.ToString();
                string eMail = listaHoteles.CurrentRow.Cells[2].Value.ToString();
                string telefono = listaHoteles.CurrentRow.Cells[3].Value.ToString();
                string cantidadEstrellas = listaHoteles.CurrentRow.Cells[4].Value.ToString();
                string recargaEstrellas = listaHoteles.CurrentRow.Cells[5].Value.ToString();
                string fecha_creacion = listaHoteles.CurrentRow.Cells[6].Value.ToString();
                string calle = listaHoteles.CurrentRow.Cells[7].Value.ToString();
                string calleNro = listaHoteles.CurrentRow.Cells[8].Value.ToString();
                string ciudad = listaHoteles.CurrentRow.Cells[9].Value.ToString();
                string pais = listaHoteles.CurrentRow.Cells[10].Value.ToString();
                ModifHot = new ModificacionHotel(nombre, eMail,telefono,cantidadEstrellas ,recargaEstrellas,
                                                fecha_creacion,calle, calleNro,ciudad,pais);
                ModifHot.Show();
                this.Hide();
            }
        }
        private void buscar_Click(object sender, EventArgs e)
        {
            DataView vistaHoteles = new DataView(tablaHoteles);
            string filtro = "";
            filtro = filtro + this.esExactamente("[Nombre]", nombre.Text);
            filtro = filtro + this.esExactamente("[Estrellas]", cantidadEstrellas.Text);
            filtro = filtro + this.esExactamente("[Ciudad]", ciudad.Text);
            filtro = filtro + this.esExactamente("[Pais]", pais.Text);


            if (filtro.Length > 0)
            {
                filtro = filtro.Remove(filtro.Length - 4);
            }

            vistaHoteles.RowFilter = filtro;
            listaHoteles.DataSource = vistaHoteles;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Text = string.Empty;
            cantidadEstrellas.Text = string.Empty;
            ciudad.Text = string.Empty;
            pais.Text = string.Empty;
            nombre.Focus();

        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmHot = new MenuAbmHotel();
            AbmHot.Show();
        }

    }
}

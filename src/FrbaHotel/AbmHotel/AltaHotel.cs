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
        private DataTable tablaRegimenes;
        private DataTable tablaRegimenesAsig;
        private string regimenes = "";
        private int cantRegimenes = 0;
        int nuevoHotelID = 0;

        public AltaHotel()
        {
            InitializeComponent();
         
            fechaCreacion.Value = DateTime.Today;
        }

        private void AltaHotel_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn botonAsignar = new DataGridViewButtonColumn();
            botonAsignar.Name = "asignar";
            listaRegimenes.Columns.Add(botonAsignar);

            tablaRegimenes = Index.BD.consultaGetTabla("select distinct reg_id ID,reg_desc DESCRIPCION from EN_CASA_ANDABA.Regimenes");
            BindingSource bindingSourceListaRegimenes = new BindingSource();
            bindingSourceListaRegimenes.DataSource = tablaRegimenes;
            listaRegimenes.DataSource = bindingSourceListaRegimenes;

            tablaRegimenesAsig = new DataTable();
            tablaRegimenesAsig.Columns.Add("ID");
            tablaRegimenesAsig.Columns.Add("DESCRIPCION");
            BindingSource bindingSourceListaRegimenesAsig = new BindingSource();
            bindingSourceListaRegimenesAsig.DataSource = tablaRegimenesAsig;
            listaRegimenesAsig.DataSource = bindingSourceListaRegimenesAsig;
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

        private void listaRegimenes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.listaRegimenes.Columns[e.ColumnIndex].Name == "asignar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell botonAsignar = this.listaRegimenes.Rows[e.RowIndex].Cells["asignar"] as DataGridViewButtonCell;
                Icon icono = new Icon(Environment.CurrentDirectory + @"\\plus.ico");
                e.Graphics.DrawIcon(icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.listaRegimenes.Rows[e.RowIndex].Height = icono.Height + 5;
                this.listaRegimenes.Columns[e.ColumnIndex].Width = icono.Width + 5;

                e.Handled = true;
            }
        }

        private void listaRegimenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listaRegimenes.Columns[e.ColumnIndex].Name == "asignar")
            {
                string regimenID = listaRegimenes.CurrentRow.Cells[1].Value.ToString();
                string regimenDesc = listaRegimenes.CurrentRow.Cells[2].Value.ToString();
                listaRegimenes.Rows.RemoveAt(listaRegimenes.CurrentRow.Index);

                DataRow row = tablaRegimenesAsig.NewRow();
                row["ID"] = regimenID;
                row["DESCRIPCION"] = regimenDesc;
                tablaRegimenesAsig.Rows.Add(row);
                bindingSourceListaRegimenesAsig.DataSource = tablaRegimenesAsig;
                bindingSourceListaRegimenesAsig.ResetBindings(true);

                if (cantRegimenes == 0)
                {
                    regimenes = regimenes + regimenID.ToString();
                }
                else
                {
                    regimenes = regimenes + "," + regimenID.ToString();
                }
                cantRegimenes++;

                listaRegimenesAsig.DataSource = bindingSourceListaRegimenesAsig;
            }
        }


        private bool checkCampos()
        {
            bool inconsistencias = false;
            string alerta = "";

            if (regimenes == "")
            {
                alerta = alerta + "Se debe asignar por lo menos un regimen\n";
                inconsistencias = true;
            }

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

            if (DateTime.Compare(fechaCrea, hoy) > 0)
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
                insert = insertNro(recargaEstrellas.Text);
                insert = insert.Remove(insert.Length - 1);

                qry = Index.BD.consultaGetPuntero(insert);

                if (qry.Read())
                {
                    nuevoHotelID = qry.GetInt32(0);
                }
                qry.Close();

                if (nuevoHotelID == 0)
                {
                   MessageBox.Show("#error: no se ha podido realizar la operación");
                }
                else 
                {
                    int altaHotUsu = Index.BD.consultaGetInt("insert EN_CASA_ANDABA.Hoteles_Usuarios (hyu_usu_id, hyu_hot_id) values(" + Index.usuarioID.ToString() + ", " + nuevoHotelID.ToString() + ")");
                    if (altaHotUsu == 0)
                    {
                        MessageBox.Show("Hotel dado de alta");
                    }

                    string[] regimenesArr = null;
                    regimenesArr = regimenes.Split(',');

                    for (int i = 0; i <= regimenesArr.Length - 1; i++)
                    {
                        qry = Index.BD.consultaGetPuntero("exec EN_CASA_ANDABA.altaRegimenesHotel " + regimenesArr[i].ToString() + "," + nuevoHotelID.ToString());
                        if (!qry.Read())
                        {
                            MessageBox.Show("#error: no se ha podido asignar el régimen elegido al hotel");
                            return;
                        }
                        qry.Close();
                    }
                }
            }
            limpiar.PerformClick();
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
            listaRegimenes.Columns.Clear();
            AltaHotel_Load(null, null);
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmHot = new MenuAbmHotel();
            AbmHot.Show();
        }

    }
}

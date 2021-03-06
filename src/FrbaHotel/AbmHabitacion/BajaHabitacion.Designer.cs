﻿namespace FrbaHotel.AbmHabitacion
{
    partial class BajaHabitacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BajaHabitacion));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hotelActivo = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.piso = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numero = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tipoHabitacion = new System.Windows.Forms.ComboBox();
            this.atras = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSourceListaHabitaciones = new System.Windows.Forms.BindingSource(this.components);
            this.listaHabitaciones = new System.Windows.Forms.DataGridView();
            this.vista = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceListaHabitaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vista);
            this.groupBox1.Controls.Add(this.hotelActivo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.piso);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numero);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tipoHabitacion);
            this.groupBox1.Location = new System.Drawing.Point(89, 66);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(708, 141);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTROS";
            // 
            // hotelActivo
            // 
            this.hotelActivo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.hotelActivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hotelActivo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotelActivo.ForeColor = System.Drawing.Color.Crimson;
            this.hotelActivo.FormattingEnabled = true;
            this.hotelActivo.ItemHeight = 23;
            this.hotelActivo.Location = new System.Drawing.Point(11, 40);
            this.hotelActivo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hotelActivo.Name = "hotelActivo";
            this.hotelActivo.Size = new System.Drawing.Size(350, 25);
            this.hotelActivo.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(536, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "Piso";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // piso
            // 
            this.piso.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.piso.ForeColor = System.Drawing.Color.DimGray;
            this.piso.Location = new System.Drawing.Point(540, 38);
            this.piso.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.piso.Name = "piso";
            this.piso.Size = new System.Drawing.Size(159, 26);
            this.piso.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(369, 16);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 16);
            this.label8.TabIndex = 29;
            this.label8.Text = "Nro.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numero
            // 
            this.numero.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numero.ForeColor = System.Drawing.Color.DimGray;
            this.numero.Location = new System.Drawing.Point(372, 38);
            this.numero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numero.Name = "numero";
            this.numero.Size = new System.Drawing.Size(159, 26);
            this.numero.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(8, 75);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 16);
            this.label9.TabIndex = 32;
            this.label9.Text = "Vista";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(365, 75);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 16);
            this.label10.TabIndex = 33;
            this.label10.Text = "Tipo";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Hotel";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tipoHabitacion
            // 
            this.tipoHabitacion.DisplayMember = "tip_nombre";
            this.tipoHabitacion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoHabitacion.ForeColor = System.Drawing.Color.DimGray;
            this.tipoHabitacion.FormattingEnabled = true;
            this.tipoHabitacion.Location = new System.Drawing.Point(369, 96);
            this.tipoHabitacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tipoHabitacion.Name = "tipoHabitacion";
            this.tipoHabitacion.Size = new System.Drawing.Size(330, 26);
            this.tipoHabitacion.TabIndex = 4;
            this.tipoHabitacion.ValueMember = "tip_id";
            // 
            // atras
            // 
            this.atras.BackColor = System.Drawing.Color.DimGray;
            this.atras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.atras.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atras.ForeColor = System.Drawing.Color.White;
            this.atras.Location = new System.Drawing.Point(15, 482);
            this.atras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.atras.Name = "atras";
            this.atras.Size = new System.Drawing.Size(126, 55);
            this.atras.TabIndex = 7;
            this.atras.Text = "atrás";
            this.atras.UseVisualStyleBackColor = false;
            this.atras.Click += new System.EventHandler(this.atras_Click);
            // 
            // limpiar
            // 
            this.limpiar.BackColor = System.Drawing.Color.White;
            this.limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.limpiar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limpiar.ForeColor = System.Drawing.Color.DimGray;
            this.limpiar.Location = new System.Drawing.Point(149, 482);
            this.limpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(126, 55);
            this.limpiar.TabIndex = 6;
            this.limpiar.Text = "limpiar datos";
            this.limpiar.UseVisualStyleBackColor = false;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // buscar
            // 
            this.buscar.BackColor = System.Drawing.Color.Crimson;
            this.buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar.ForeColor = System.Drawing.Color.White;
            this.buscar.Location = new System.Drawing.Point(739, 482);
            this.buscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(126, 55);
            this.buscar.TabIndex = 5;
            this.buscar.Text = "buscar";
            this.buscar.UseVisualStyleBackColor = false;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(260, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 51);
            this.label1.TabIndex = 63;
            this.label1.Text = "BAJA HABITACION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listaHabitaciones
            // 
            this.listaHabitaciones.AllowUserToAddRows = false;
            this.listaHabitaciones.AllowUserToDeleteRows = false;
            this.listaHabitaciones.AllowUserToOrderColumns = true;
            this.listaHabitaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaHabitaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.listaHabitaciones.BackgroundColor = System.Drawing.Color.White;
            this.listaHabitaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listaHabitaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaHabitaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listaHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaHabitaciones.DefaultCellStyle = dataGridViewCellStyle2;
            this.listaHabitaciones.Location = new System.Drawing.Point(89, 215);
            this.listaHabitaciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listaHabitaciones.Name = "listaHabitaciones";
            this.listaHabitaciones.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.listaHabitaciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.listaHabitaciones.RowHeadersVisible = false;
            this.listaHabitaciones.RowHeadersWidth = 20;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DimGray;
            this.listaHabitaciones.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.listaHabitaciones.Size = new System.Drawing.Size(708, 260);
            this.listaHabitaciones.TabIndex = 65;
            this.listaHabitaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaHabitaciones_CellClick);
            this.listaHabitaciones.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.listaHabitaciones_CellPainting);
            // 
            // vista
            // 
            this.vista.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vista.ForeColor = System.Drawing.Color.DimGray;
            this.vista.FormattingEnabled = true;
            this.vista.Location = new System.Drawing.Point(8, 96);
            this.vista.Margin = new System.Windows.Forms.Padding(4);
            this.vista.Name = "vista";
            this.vista.Size = new System.Drawing.Size(349, 26);
            this.vista.TabIndex = 75;
            // 
            // BajaHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(880, 552);
            this.Controls.Add(this.listaHabitaciones);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.atras);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "BajaHabitacion";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Hotel 2018";
            this.Load += new System.EventHandler(this.BajaHabitacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceListaHabitaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaHabitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox piso;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox numero;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tipoHabitacion;
        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox hotelActivo;
        private System.Windows.Forms.BindingSource bindingSourceListaHabitaciones;
        private System.Windows.Forms.DataGridView listaHabitaciones;
        private System.Windows.Forms.ComboBox vista;

    }
}
namespace FrbaHotel.FacturacionEstadia
{
    partial class FacturacionEstadia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacturacionEstadia));
            this.formasDePago = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.generarFactura = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.bindingSourceDetalleEstadia = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceConsumibles = new System.Windows.Forms.BindingSource(this.components);
            this.listaDetalleEstadia = new System.Windows.Forms.DataGridView();
            this.listaConsumibles = new System.Windows.Forms.DataGridView();
            this.estadia = new System.Windows.Forms.TextBox();
            this.reserva = new System.Windows.Forms.TextBox();
            this.fechaIngreso = new System.Windows.Forms.TextBox();
            this.fechaEgreso = new System.Windows.Forms.TextBox();
            this.checkOut = new System.Windows.Forms.TextBox();
            this.subtotalConsumibles = new System.Windows.Forms.TextBox();
            this.subtotalEstadia = new System.Windows.Forms.TextBox();
            this.bonificacion = new System.Windows.Forms.TextBox();
            this.totalFactura = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetalleEstadia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceConsumibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaDetalleEstadia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaConsumibles)).BeginInit();
            this.SuspendLayout();
            // 
            // formasDePago
            // 
            this.formasDePago.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formasDePago.ForeColor = System.Drawing.Color.DimGray;
            this.formasDePago.FormattingEnabled = true;
            this.formasDePago.Location = new System.Drawing.Point(71, 85);
            this.formasDePago.Name = "formasDePago";
            this.formasDePago.Size = new System.Drawing.Size(280, 24);
            this.formasDePago.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(68, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 74;
            this.label2.Text = "Estadía";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(220, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 14);
            this.label3.TabIndex = 76;
            this.label3.Text = "Reserva";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(354, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 14);
            this.label4.TabIndex = 78;
            this.label4.Text = "Fecha de Ingreso";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(501, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 14);
            this.label5.TabIndex = 80;
            this.label5.Text = "Fecha de Egreso";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(354, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 14);
            this.label6.TabIndex = 82;
            this.label6.Text = "Check Out";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(68, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 14);
            this.label7.TabIndex = 83;
            this.label7.Text = "Forma de Pago";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(68, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 14);
            this.label8.TabIndex = 84;
            this.label8.Text = "Detalle de la Estadía";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(354, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 14);
            this.label9.TabIndex = 87;
            this.label9.Text = "Consumibles";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // generarFactura
            // 
            this.generarFactura.BackColor = System.Drawing.Color.Crimson;
            this.generarFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generarFactura.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generarFactura.ForeColor = System.Drawing.Color.White;
            this.generarFactura.Location = new System.Drawing.Point(528, 386);
            this.generarFactura.Name = "generarFactura";
            this.generarFactura.Size = new System.Drawing.Size(164, 44);
            this.generarFactura.TabIndex = 2;
            this.generarFactura.Text = "generar factura";
            this.generarFactura.UseVisualStyleBackColor = false;
            this.generarFactura.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(236, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 94;
            this.label1.Text = "Subtotal Estadía:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(174, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(177, 16);
            this.label10.TabIndex = 95;
            this.label10.Text = "Bonificación por Régimen:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(201, 324);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 16);
            this.label11.TabIndex = 96;
            this.label11.Text = "Subtotal Consumibles:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(290, 379);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 18);
            this.label12.TabIndex = 98;
            this.label12.Text = "TOTAL:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listaDetalleEstadia
            // 
            this.listaDetalleEstadia.AllowUserToAddRows = false;
            this.listaDetalleEstadia.AllowUserToDeleteRows = false;
            this.listaDetalleEstadia.AllowUserToOrderColumns = true;
            this.listaDetalleEstadia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaDetalleEstadia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.listaDetalleEstadia.BackgroundColor = System.Drawing.Color.White;
            this.listaDetalleEstadia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listaDetalleEstadia.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaDetalleEstadia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listaDetalleEstadia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaDetalleEstadia.DefaultCellStyle = dataGridViewCellStyle2;
            this.listaDetalleEstadia.Location = new System.Drawing.Point(71, 129);
            this.listaDetalleEstadia.Name = "listaDetalleEstadia";
            this.listaDetalleEstadia.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.listaDetalleEstadia.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.listaDetalleEstadia.RowHeadersVisible = false;
            this.listaDetalleEstadia.RowHeadersWidth = 20;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DimGray;
            this.listaDetalleEstadia.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.listaDetalleEstadia.Size = new System.Drawing.Size(280, 158);
            this.listaDetalleEstadia.TabIndex = 99;
            // 
            // listaConsumibles
            // 
            this.listaConsumibles.AllowUserToAddRows = false;
            this.listaConsumibles.AllowUserToDeleteRows = false;
            this.listaConsumibles.AllowUserToOrderColumns = true;
            this.listaConsumibles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaConsumibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.listaConsumibles.BackgroundColor = System.Drawing.Color.White;
            this.listaConsumibles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listaConsumibles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaConsumibles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.listaConsumibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaConsumibles.DefaultCellStyle = dataGridViewCellStyle6;
            this.listaConsumibles.Location = new System.Drawing.Point(357, 129);
            this.listaConsumibles.Name = "listaConsumibles";
            this.listaConsumibles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.listaConsumibles.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.listaConsumibles.RowHeadersVisible = false;
            this.listaConsumibles.RowHeadersWidth = 20;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.DimGray;
            this.listaConsumibles.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.listaConsumibles.Size = new System.Drawing.Size(280, 158);
            this.listaConsumibles.TabIndex = 100;
            // 
            // estadia
            // 
            this.estadia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.estadia.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estadia.ForeColor = System.Drawing.Color.Crimson;
            this.estadia.Location = new System.Drawing.Point(71, 43);
            this.estadia.Name = "estadia";
            this.estadia.ReadOnly = true;
            this.estadia.Size = new System.Drawing.Size(128, 22);
            this.estadia.TabIndex = 101;
            // 
            // reserva
            // 
            this.reserva.BackColor = System.Drawing.Color.WhiteSmoke;
            this.reserva.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reserva.ForeColor = System.Drawing.Color.DimGray;
            this.reserva.Location = new System.Drawing.Point(223, 43);
            this.reserva.Name = "reserva";
            this.reserva.ReadOnly = true;
            this.reserva.Size = new System.Drawing.Size(128, 22);
            this.reserva.TabIndex = 102;
            // 
            // fechaIngreso
            // 
            this.fechaIngreso.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fechaIngreso.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaIngreso.ForeColor = System.Drawing.Color.DimGray;
            this.fechaIngreso.Location = new System.Drawing.Point(357, 43);
            this.fechaIngreso.Name = "fechaIngreso";
            this.fechaIngreso.ReadOnly = true;
            this.fechaIngreso.Size = new System.Drawing.Size(133, 22);
            this.fechaIngreso.TabIndex = 103;
            this.fechaIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // fechaEgreso
            // 
            this.fechaEgreso.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fechaEgreso.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaEgreso.ForeColor = System.Drawing.Color.DimGray;
            this.fechaEgreso.Location = new System.Drawing.Point(504, 43);
            this.fechaEgreso.Name = "fechaEgreso";
            this.fechaEgreso.ReadOnly = true;
            this.fechaEgreso.Size = new System.Drawing.Size(133, 22);
            this.fechaEgreso.TabIndex = 104;
            this.fechaEgreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // checkOut
            // 
            this.checkOut.BackColor = System.Drawing.Color.WhiteSmoke;
            this.checkOut.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkOut.ForeColor = System.Drawing.Color.DimGray;
            this.checkOut.Location = new System.Drawing.Point(357, 85);
            this.checkOut.Name = "checkOut";
            this.checkOut.ReadOnly = true;
            this.checkOut.Size = new System.Drawing.Size(280, 22);
            this.checkOut.TabIndex = 105;
            this.checkOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // subtotalConsumibles
            // 
            this.subtotalConsumibles.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subtotalConsumibles.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtotalConsumibles.ForeColor = System.Drawing.Color.DimGray;
            this.subtotalConsumibles.Location = new System.Drawing.Point(357, 321);
            this.subtotalConsumibles.Name = "subtotalConsumibles";
            this.subtotalConsumibles.ReadOnly = true;
            this.subtotalConsumibles.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.subtotalConsumibles.Size = new System.Drawing.Size(110, 22);
            this.subtotalConsumibles.TabIndex = 108;
            // 
            // subtotalEstadia
            // 
            this.subtotalEstadia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subtotalEstadia.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtotalEstadia.ForeColor = System.Drawing.Color.Gray;
            this.subtotalEstadia.Location = new System.Drawing.Point(357, 293);
            this.subtotalEstadia.Name = "subtotalEstadia";
            this.subtotalEstadia.ReadOnly = true;
            this.subtotalEstadia.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.subtotalEstadia.Size = new System.Drawing.Size(110, 22);
            this.subtotalEstadia.TabIndex = 109;
            // 
            // bonificacion
            // 
            this.bonificacion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bonificacion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bonificacion.ForeColor = System.Drawing.Color.DimGray;
            this.bonificacion.Location = new System.Drawing.Point(357, 349);
            this.bonificacion.Name = "bonificacion";
            this.bonificacion.ReadOnly = true;
            this.bonificacion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bonificacion.Size = new System.Drawing.Size(110, 22);
            this.bonificacion.TabIndex = 110;
            // 
            // totalFactura
            // 
            this.totalFactura.BackColor = System.Drawing.Color.WhiteSmoke;
            this.totalFactura.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalFactura.ForeColor = System.Drawing.Color.Crimson;
            this.totalFactura.Location = new System.Drawing.Point(357, 377);
            this.totalFactura.Name = "totalFactura";
            this.totalFactura.ReadOnly = true;
            this.totalFactura.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.totalFactura.Size = new System.Drawing.Size(110, 22);
            this.totalFactura.TabIndex = 111;
            // 
            // FacturacionEstadia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.totalFactura);
            this.Controls.Add(this.bonificacion);
            this.Controls.Add(this.subtotalEstadia);
            this.Controls.Add(this.subtotalConsumibles);
            this.Controls.Add(this.checkOut);
            this.Controls.Add(this.fechaEgreso);
            this.Controls.Add(this.fechaIngreso);
            this.Controls.Add(this.reserva);
            this.Controls.Add(this.estadia);
            this.Controls.Add(this.listaConsumibles);
            this.Controls.Add(this.listaDetalleEstadia);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.generarFactura);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.formasDePago);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FacturacionEstadia";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Hotel 2018";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetalleEstadia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceConsumibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaDetalleEstadia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaConsumibles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox formasDePago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button generarFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.BindingSource bindingSourceDetalleEstadia;
        private System.Windows.Forms.BindingSource bindingSourceConsumibles;
        private System.Windows.Forms.DataGridView listaDetalleEstadia;
        private System.Windows.Forms.DataGridView listaConsumibles;
        private System.Windows.Forms.TextBox estadia;
        private System.Windows.Forms.TextBox reserva;
        private System.Windows.Forms.TextBox fechaIngreso;
        private System.Windows.Forms.TextBox fechaEgreso;
        private System.Windows.Forms.TextBox checkOut;
        private System.Windows.Forms.TextBox subtotalConsumibles;
        private System.Windows.Forms.TextBox subtotalEstadia;
        private System.Windows.Forms.TextBox bonificacion;
        private System.Windows.Forms.TextBox totalFactura;
    }
}
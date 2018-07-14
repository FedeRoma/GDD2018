namespace FrbaHotel.GenerarModificacionReserva
{
    partial class GenerarReserva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerarReserva));
            this.nuevoCliente = new System.Windows.Forms.Button();
            this.nroDocumento = new System.Windows.Forms.TextBox();
            this.tipoDocumento = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.hotelActivo = new System.Windows.Forms.TextBox();
            this.total = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cantidadPersonas = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listaHabitacionesAsig = new System.Windows.Forms.DataGridView();
            this.listaHabitaciones = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buscarHabitaciones = new System.Windows.Forms.Button();
            this.atras = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.hasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.desde = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tipoHabitacion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.regimen = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bindingSourceListaHabitaciones = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceListaHabitacionesAsig = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaHabitacionesAsig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaHabitaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceListaHabitaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceListaHabitacionesAsig)).BeginInit();
            this.SuspendLayout();
            // 
            // nuevoCliente
            // 
            this.nuevoCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nuevoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nuevoCliente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuevoCliente.ForeColor = System.Drawing.Color.Crimson;
            this.nuevoCliente.Location = new System.Drawing.Point(336, 153);
            this.nuevoCliente.Name = "nuevoCliente";
            this.nuevoCliente.Size = new System.Drawing.Size(108, 27);
            this.nuevoCliente.TabIndex = 145;
            this.nuevoCliente.Text = "nuevo cliente";
            this.nuevoCliente.UseVisualStyleBackColor = false;
            this.nuevoCliente.Click += new System.EventHandler(this.nuevoCliente_Click);
            // 
            // nroDocumento
            // 
            this.nroDocumento.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nroDocumento.ForeColor = System.Drawing.Color.DimGray;
            this.nroDocumento.Location = new System.Drawing.Point(450, 155);
            this.nroDocumento.Name = "nroDocumento";
            this.nroDocumento.Size = new System.Drawing.Size(192, 22);
            this.nroDocumento.TabIndex = 167;
            this.nroDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeroDocumento_Keypress);
            // 
            // tipoDocumento
            // 
            this.tipoDocumento.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoDocumento.ForeColor = System.Drawing.Color.DimGray;
            this.tipoDocumento.FormattingEnabled = true;
            this.tipoDocumento.Location = new System.Drawing.Point(450, 123);
            this.tipoDocumento.Name = "tipoDocumento";
            this.tipoDocumento.Size = new System.Drawing.Size(192, 24);
            this.tipoDocumento.TabIndex = 166;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(447, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 14);
            this.label5.TabIndex = 165;
            this.label5.Text = "Cliente (Tipo y Nro de Doc)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hotelActivo
            // 
            this.hotelActivo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.hotelActivo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotelActivo.ForeColor = System.Drawing.Color.Crimson;
            this.hotelActivo.Location = new System.Drawing.Point(68, 34);
            this.hotelActivo.Name = "hotelActivo";
            this.hotelActivo.ReadOnly = true;
            this.hotelActivo.Size = new System.Drawing.Size(262, 22);
            this.hotelActivo.TabIndex = 164;
            // 
            // total
            // 
            this.total.BackColor = System.Drawing.Color.WhiteSmoke;
            this.total.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.ForeColor = System.Drawing.Color.DimGray;
            this.total.Location = new System.Drawing.Point(514, 352);
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Size = new System.Drawing.Size(128, 22);
            this.total.TabIndex = 163;
            this.total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(447, 354);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 18);
            this.label12.TabIndex = 162;
            this.label12.Text = "TOTAL:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cantidadPersonas
            // 
            this.cantidadPersonas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cantidadPersonas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cantidadPersonas.ForeColor = System.Drawing.Color.DimGray;
            this.cantidadPersonas.Location = new System.Drawing.Point(336, 123);
            this.cantidadPersonas.Name = "cantidadPersonas";
            this.cantidadPersonas.ReadOnly = true;
            this.cantidadPersonas.Size = new System.Drawing.Size(108, 22);
            this.cantidadPersonas.TabIndex = 161;
            this.cantidadPersonas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(333, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 160;
            this.label4.Text = "Capacidad";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listaHabitacionesAsig);
            this.groupBox1.Controls.Add(this.listaHabitaciones);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(68, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 153);
            this.groupBox1.TabIndex = 159;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Habitaciones";
            // 
            // listaHabitacionesAsig
            // 
            this.listaHabitacionesAsig.AllowUserToAddRows = false;
            this.listaHabitacionesAsig.AllowUserToDeleteRows = false;
            this.listaHabitacionesAsig.AllowUserToOrderColumns = true;
            this.listaHabitacionesAsig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaHabitacionesAsig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.listaHabitacionesAsig.BackgroundColor = System.Drawing.Color.White;
            this.listaHabitacionesAsig.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listaHabitacionesAsig.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaHabitacionesAsig.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listaHabitacionesAsig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaHabitacionesAsig.DefaultCellStyle = dataGridViewCellStyle2;
            this.listaHabitacionesAsig.Location = new System.Drawing.Point(295, 33);
            this.listaHabitacionesAsig.Name = "listaHabitacionesAsig";
            this.listaHabitacionesAsig.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.listaHabitacionesAsig.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.listaHabitacionesAsig.RowHeadersVisible = false;
            this.listaHabitacionesAsig.RowHeadersWidth = 20;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DimGray;
            this.listaHabitacionesAsig.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.listaHabitacionesAsig.Size = new System.Drawing.Size(271, 105);
            this.listaHabitacionesAsig.TabIndex = 72;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaHabitaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.listaHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaHabitaciones.DefaultCellStyle = dataGridViewCellStyle6;
            this.listaHabitaciones.Location = new System.Drawing.Point(9, 33);
            this.listaHabitaciones.Name = "listaHabitaciones";
            this.listaHabitaciones.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.listaHabitaciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.listaHabitaciones.RowHeadersVisible = false;
            this.listaHabitaciones.RowHeadersWidth = 20;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.DimGray;
            this.listaHabitaciones.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.listaHabitaciones.Size = new System.Drawing.Size(253, 105);
            this.listaHabitaciones.TabIndex = 71;
            this.listaHabitaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaHabitaciones_CellClick);
            this.listaHabitaciones.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.listaHabitaciones_CellPainting);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(480, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 14);
            this.label6.TabIndex = 41;
            this.label6.Text = "Seleccionadas";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 14);
            this.label8.TabIndex = 39;
            this.label8.Text = "Disponibles";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buscarHabitaciones
            // 
            this.buscarHabitaciones.BackColor = System.Drawing.Color.DimGray;
            this.buscarHabitaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscarHabitaciones.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarHabitaciones.ForeColor = System.Drawing.Color.White;
            this.buscarHabitaciones.Location = new System.Drawing.Point(68, 153);
            this.buscarHabitaciones.Name = "buscarHabitaciones";
            this.buscarHabitaciones.Size = new System.Drawing.Size(171, 27);
            this.buscarHabitaciones.TabIndex = 151;
            this.buscarHabitaciones.Text = "buscar habitaciones";
            this.buscarHabitaciones.UseVisualStyleBackColor = false;
            this.buscarHabitaciones.Click += new System.EventHandler(this.buscarHabitaciones_Click);
            // 
            // atras
            // 
            this.atras.BackColor = System.Drawing.Color.DimGray;
            this.atras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.atras.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atras.ForeColor = System.Drawing.Color.White;
            this.atras.Location = new System.Drawing.Point(12, 386);
            this.atras.Name = "atras";
            this.atras.Size = new System.Drawing.Size(101, 44);
            this.atras.TabIndex = 153;
            this.atras.Text = "atrás";
            this.atras.UseVisualStyleBackColor = false;
            this.atras.Click += new System.EventHandler(this.atras_Click);
            // 
            // aceptar
            // 
            this.aceptar.BackColor = System.Drawing.Color.Crimson;
            this.aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aceptar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptar.ForeColor = System.Drawing.Color.White;
            this.aceptar.Location = new System.Drawing.Point(591, 386);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(101, 44);
            this.aceptar.TabIndex = 152;
            this.aceptar.Text = "aceptar";
            this.aceptar.UseVisualStyleBackColor = false;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // hasta
            // 
            this.hasta.CalendarTitleBackColor = System.Drawing.Color.Crimson;
            this.hasta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hasta.Location = new System.Drawing.Point(336, 76);
            this.hasta.Name = "hasta";
            this.hasta.Size = new System.Drawing.Size(304, 21);
            this.hasta.TabIndex = 150;
            this.hasta.ValueChanged += new System.EventHandler(this.hasta_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(333, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 158;
            this.label3.Text = "Hasta";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // desde
            // 
            this.desde.CalendarTitleBackColor = System.Drawing.Color.Crimson;
            this.desde.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desde.Location = new System.Drawing.Point(336, 35);
            this.desde.Name = "desde";
            this.desde.Size = new System.Drawing.Size(304, 21);
            this.desde.TabIndex = 149;
            this.desde.ValueChanged += new System.EventHandler(this.desde_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(333, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 14);
            this.label9.TabIndex = 157;
            this.label9.Text = "Desde";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(65, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 14);
            this.label2.TabIndex = 156;
            this.label2.Text = "Tipo de Habitación";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tipoHabitacion
            // 
            this.tipoHabitacion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoHabitacion.ForeColor = System.Drawing.Color.DimGray;
            this.tipoHabitacion.FormattingEnabled = true;
            this.tipoHabitacion.Location = new System.Drawing.Point(68, 123);
            this.tipoHabitacion.Name = "tipoHabitacion";
            this.tipoHabitacion.Size = new System.Drawing.Size(262, 24);
            this.tipoHabitacion.TabIndex = 148;
            this.tipoHabitacion.TextChanged += new System.EventHandler(this.tipoHabitacion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(65, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 155;
            this.label1.Text = "Regimen";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // regimen
            // 
            this.regimen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regimen.ForeColor = System.Drawing.Color.DimGray;
            this.regimen.FormattingEnabled = true;
            this.regimen.Location = new System.Drawing.Point(68, 79);
            this.regimen.Name = "regimen";
            this.regimen.Size = new System.Drawing.Size(262, 24);
            this.regimen.TabIndex = 147;
            this.regimen.SelectedIndexChanged += new System.EventHandler(this.regimen_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(65, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 154;
            this.label7.Text = "Hotel";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GenerarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.nroDocumento);
            this.Controls.Add(this.tipoDocumento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.hotelActivo);
            this.Controls.Add(this.total);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cantidadPersonas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buscarHabitaciones);
            this.Controls.Add(this.atras);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.hasta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.desde);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tipoHabitacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.regimen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nuevoCliente);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GenerarReserva";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Hotel 2018";
            this.Load += new System.EventHandler(this.GenerarReserva_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaHabitacionesAsig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaHabitaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceListaHabitaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceListaHabitacionesAsig)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nuevoCliente;
        private System.Windows.Forms.TextBox nroDocumento;
        private System.Windows.Forms.ComboBox tipoDocumento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox hotelActivo;
        private System.Windows.Forms.TextBox total;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox cantidadPersonas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView listaHabitacionesAsig;
        private System.Windows.Forms.DataGridView listaHabitaciones;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buscarHabitaciones;
        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.DateTimePicker hasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker desde;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tipoHabitacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox regimen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource bindingSourceListaHabitaciones;
        private System.Windows.Forms.BindingSource bindingSourceListaHabitacionesAsig;

    }
}
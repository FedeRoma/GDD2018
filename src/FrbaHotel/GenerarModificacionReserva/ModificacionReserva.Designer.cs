﻿namespace FrbaHotel.GenerarModificacionReserva
{
    partial class ModificacionReserva
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificacionReserva));
            this.label12 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listaHabitacionesAsig = new System.Windows.Forms.DataGridView();
            this.listaHabitaciones = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.seleccionarCliente = new System.Windows.Forms.Button();
            this.cliente = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.atras = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.cantPersonas = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.fechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tipoHabitacion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.regimen = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.hotel = new System.Windows.Forms.ComboBox();
            this.reserva = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaHabitacionesAsig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(445, 354);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 18);
            this.label12.TabIndex = 129;
            this.label12.Text = "TOTAL:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // total
            // 
            this.total.BackColor = System.Drawing.Color.WhiteSmoke;
            this.total.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.total.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.ForeColor = System.Drawing.Color.Crimson;
            this.total.FormattingEnabled = true;
            this.total.ItemHeight = 18;
            this.total.Location = new System.Drawing.Point(512, 354);
            this.total.Name = "total";
            this.total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.total.Size = new System.Drawing.Size(128, 18);
            this.total.TabIndex = 128;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.listaHabitacionesAsig);
            this.groupBox1.Controls.Add(this.listaHabitaciones);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(68, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 153);
            this.groupBox1.TabIndex = 127;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Habitaciones";
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
            // listaHabitacionesAsig
            // 
            this.listaHabitacionesAsig.AllowUserToAddRows = false;
            this.listaHabitacionesAsig.AllowUserToOrderColumns = true;
            this.listaHabitacionesAsig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.listaHabitacionesAsig.BackgroundColor = System.Drawing.Color.White;
            this.listaHabitacionesAsig.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listaHabitacionesAsig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaHabitacionesAsig.Location = new System.Drawing.Point(291, 33);
            this.listaHabitacionesAsig.Name = "listaHabitacionesAsig";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.listaHabitacionesAsig.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            this.listaHabitacionesAsig.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.listaHabitacionesAsig.Size = new System.Drawing.Size(275, 105);
            this.listaHabitacionesAsig.TabIndex = 6;
            // 
            // listaHabitaciones
            // 
            this.listaHabitaciones.AllowUserToAddRows = false;
            this.listaHabitaciones.AllowUserToOrderColumns = true;
            this.listaHabitaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.listaHabitaciones.BackgroundColor = System.Drawing.Color.White;
            this.listaHabitaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listaHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaHabitaciones.Location = new System.Drawing.Point(6, 33);
            this.listaHabitaciones.Name = "listaHabitaciones";
            this.listaHabitaciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listaHabitaciones.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.listaHabitaciones.Size = new System.Drawing.Size(275, 105);
            this.listaHabitaciones.TabIndex = 5;
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(68, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 27);
            this.button1.TabIndex = 114;
            this.button1.Text = "buscar habitaciones";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // seleccionarCliente
            // 
            this.seleccionarCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.seleccionarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seleccionarCliente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seleccionarCliente.ForeColor = System.Drawing.Color.DimGray;
            this.seleccionarCliente.Location = new System.Drawing.Point(562, 153);
            this.seleccionarCliente.Name = "seleccionarCliente";
            this.seleccionarCliente.Size = new System.Drawing.Size(78, 27);
            this.seleccionarCliente.TabIndex = 113;
            this.seleccionarCliente.Text = "cambiar";
            this.seleccionarCliente.UseVisualStyleBackColor = false;
            // 
            // cliente
            // 
            this.cliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cliente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cliente.ForeColor = System.Drawing.Color.DimGray;
            this.cliente.FormattingEnabled = true;
            this.cliente.ItemHeight = 18;
            this.cliente.Location = new System.Drawing.Point(488, 123);
            this.cliente.Name = "cliente";
            this.cliente.Size = new System.Drawing.Size(152, 20);
            this.cliente.TabIndex = 125;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(485, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 14);
            this.label5.TabIndex = 126;
            this.label5.Text = "Cliente";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.atras.TabIndex = 117;
            this.atras.Text = "atrás";
            this.atras.UseVisualStyleBackColor = false;
            // 
            // limpiar
            // 
            this.limpiar.BackColor = System.Drawing.Color.White;
            this.limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.limpiar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limpiar.ForeColor = System.Drawing.Color.DimGray;
            this.limpiar.Location = new System.Drawing.Point(119, 386);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(101, 44);
            this.limpiar.TabIndex = 116;
            this.limpiar.Text = "limpiar datos";
            this.limpiar.UseVisualStyleBackColor = false;
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
            this.aceptar.TabIndex = 115;
            this.aceptar.Text = "aceptar";
            this.aceptar.UseVisualStyleBackColor = false;
            // 
            // cantPersonas
            // 
            this.cantPersonas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cantPersonas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cantPersonas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cantPersonas.ForeColor = System.Drawing.Color.DimGray;
            this.cantPersonas.FormattingEnabled = true;
            this.cantPersonas.ItemHeight = 18;
            this.cantPersonas.Location = new System.Drawing.Point(336, 123);
            this.cantPersonas.Name = "cantPersonas";
            this.cantPersonas.Size = new System.Drawing.Size(125, 20);
            this.cantPersonas.TabIndex = 123;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(333, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 14);
            this.label4.TabIndex = 124;
            this.label4.Text = "Cantidad de Personas";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fechaHasta
            // 
            this.fechaHasta.CalendarTitleBackColor = System.Drawing.Color.Crimson;
            this.fechaHasta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaHasta.Location = new System.Drawing.Point(336, 76);
            this.fechaHasta.Name = "fechaHasta";
            this.fechaHasta.Size = new System.Drawing.Size(304, 21);
            this.fechaHasta.TabIndex = 111;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(333, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 122;
            this.label3.Text = "Hasta";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fechaDesde
            // 
            this.fechaDesde.CalendarTitleBackColor = System.Drawing.Color.Crimson;
            this.fechaDesde.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaDesde.Location = new System.Drawing.Point(336, 35);
            this.fechaDesde.Name = "fechaDesde";
            this.fechaDesde.Size = new System.Drawing.Size(304, 21);
            this.fechaDesde.TabIndex = 110;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(333, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 14);
            this.label9.TabIndex = 121;
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
            this.label2.TabIndex = 120;
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
            this.tipoHabitacion.TabIndex = 109;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(65, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 119;
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
            this.regimen.TabIndex = 108;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(65, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 118;
            this.label7.Text = "Hotel";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hotel
            // 
            this.hotel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotel.ForeColor = System.Drawing.Color.DimGray;
            this.hotel.FormattingEnabled = true;
            this.hotel.Location = new System.Drawing.Point(68, 35);
            this.hotel.Name = "hotel";
            this.hotel.Size = new System.Drawing.Size(262, 24);
            this.hotel.TabIndex = 107;
            // 
            // reserva
            // 
            this.reserva.BackColor = System.Drawing.Color.WhiteSmoke;
            this.reserva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reserva.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reserva.ForeColor = System.Drawing.Color.Crimson;
            this.reserva.FormattingEnabled = true;
            this.reserva.ItemHeight = 18;
            this.reserva.Location = new System.Drawing.Point(336, 163);
            this.reserva.Name = "reserva";
            this.reserva.Size = new System.Drawing.Size(125, 20);
            this.reserva.TabIndex = 130;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(333, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 14);
            this.label10.TabIndex = 131;
            this.label10.Text = "Código de Reserva";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ModificacionReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.reserva);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.total);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.seleccionarCliente);
            this.Controls.Add(this.cliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.atras);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.cantPersonas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fechaHasta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fechaDesde);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tipoHabitacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.regimen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.hotel);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ModificacionReserva";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Hotel 2018";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaHabitacionesAsig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaHabitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox total;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView listaHabitacionesAsig;
        private System.Windows.Forms.DataGridView listaHabitaciones;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button seleccionarCliente;
        private System.Windows.Forms.ListBox cliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.ListBox cantPersonas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker fechaHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker fechaDesde;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tipoHabitacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox regimen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox hotel;
        private System.Windows.Forms.ListBox reserva;
        private System.Windows.Forms.Label label10;
    }
}
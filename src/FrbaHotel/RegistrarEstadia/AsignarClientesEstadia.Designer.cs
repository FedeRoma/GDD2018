﻿namespace FrbaHotel.RegistrarEstadia
{
    partial class AsignarClientesEstadia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsignarClientesEstadia));
            this.label1 = new System.Windows.Forms.Label();
            this.atras = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.seleccionarCliente = new System.Windows.Forms.Button();
            this.nuevoCliente = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.listaClientes = new System.Windows.Forms.DataGridView();
            this.bindingSourcelistaClientes = new System.Windows.Forms.BindingSource(this.components);
            this.numeroReserva = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.titularEstadia = new System.Windows.Forms.TextBox();
            this.capacidadHabitacion = new System.Windows.Forms.TextBox();
            this.plazasRestantes = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.listaClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcelistaClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(113, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(478, 41);
            this.label1.TabIndex = 28;
            this.label1.Text = "ASIGNAR CLIENTES A ESTADIA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.atras.TabIndex = 5;
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
            this.limpiar.Location = new System.Drawing.Point(119, 386);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(101, 44);
            this.limpiar.TabIndex = 4;
            this.limpiar.Text = "limpiar datos";
            this.limpiar.UseVisualStyleBackColor = false;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
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
            this.aceptar.TabIndex = 3;
            this.aceptar.Text = "aceptar";
            this.aceptar.UseVisualStyleBackColor = false;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(97, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 47;
            this.label4.Text = "Titular";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(507, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 14);
            this.label2.TabIndex = 49;
            this.label2.Text = "Plazas Restantes";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(369, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 14);
            this.label3.TabIndex = 51;
            this.label3.Text = "Capacidad Habitación";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // seleccionarCliente
            // 
            this.seleccionarCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.seleccionarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seleccionarCliente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seleccionarCliente.ForeColor = System.Drawing.Color.DimGray;
            this.seleccionarCliente.Location = new System.Drawing.Point(530, 154);
            this.seleccionarCliente.Name = "seleccionarCliente";
            this.seleccionarCliente.Size = new System.Drawing.Size(78, 27);
            this.seleccionarCliente.TabIndex = 2;
            this.seleccionarCliente.Text = "existente";
            this.seleccionarCliente.UseVisualStyleBackColor = false;
            this.seleccionarCliente.Click += new System.EventHandler(this.seleccionarCliente_Click);
            // 
            // nuevoCliente
            // 
            this.nuevoCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nuevoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nuevoCliente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuevoCliente.ForeColor = System.Drawing.Color.Crimson;
            this.nuevoCliente.Location = new System.Drawing.Point(456, 154);
            this.nuevoCliente.Name = "nuevoCliente";
            this.nuevoCliente.Size = new System.Drawing.Size(68, 27);
            this.nuevoCliente.TabIndex = 1;
            this.nuevoCliente.Text = "nuevo";
            this.nuevoCliente.UseVisualStyleBackColor = false;
            this.nuevoCliente.Click += new System.EventHandler(this.nuevoCliente_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(96, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 14);
            this.label5.TabIndex = 54;
            this.label5.Text = "Clientes";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listaClientes
            // 
            this.listaClientes.AllowUserToAddRows = false;
            this.listaClientes.AllowUserToDeleteRows = false;
            this.listaClientes.AllowUserToOrderColumns = true;
            this.listaClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.listaClientes.BackgroundColor = System.Drawing.Color.White;
            this.listaClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listaClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaClientes.DefaultCellStyle = dataGridViewCellStyle2;
            this.listaClientes.Location = new System.Drawing.Point(99, 187);
            this.listaClientes.Name = "listaClientes";
            this.listaClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.listaClientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.listaClientes.RowHeadersVisible = false;
            this.listaClientes.RowHeadersWidth = 20;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DimGray;
            this.listaClientes.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.listaClientes.Size = new System.Drawing.Size(509, 188);
            this.listaClientes.TabIndex = 69;
            this.listaClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaClientes_CellClick);
            // 
            // numeroReserva
            // 
            this.numeroReserva.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numeroReserva.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroReserva.ForeColor = System.Drawing.Color.Crimson;
            this.numeroReserva.Location = new System.Drawing.Point(100, 84);
            this.numeroReserva.Name = "numeroReserva";
            this.numeroReserva.ReadOnly = true;
            this.numeroReserva.Size = new System.Drawing.Size(78, 22);
            this.numeroReserva.TabIndex = 102;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(97, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 14);
            this.label6.TabIndex = 103;
            this.label6.Text = "Reserva";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // titularEstadia
            // 
            this.titularEstadia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.titularEstadia.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titularEstadia.ForeColor = System.Drawing.Color.DimGray;
            this.titularEstadia.Location = new System.Drawing.Point(100, 126);
            this.titularEstadia.Name = "titularEstadia";
            this.titularEstadia.ReadOnly = true;
            this.titularEstadia.Size = new System.Drawing.Size(508, 22);
            this.titularEstadia.TabIndex = 104;
            // 
            // capacidadHabitacion
            // 
            this.capacidadHabitacion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.capacidadHabitacion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capacidadHabitacion.ForeColor = System.Drawing.Color.DimGray;
            this.capacidadHabitacion.Location = new System.Drawing.Point(418, 84);
            this.capacidadHabitacion.Name = "capacidadHabitacion";
            this.capacidadHabitacion.ReadOnly = true;
            this.capacidadHabitacion.Size = new System.Drawing.Size(73, 22);
            this.capacidadHabitacion.TabIndex = 105;
            // 
            // plazasRestantes
            // 
            this.plazasRestantes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.plazasRestantes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plazasRestantes.ForeColor = System.Drawing.Color.DimGray;
            this.plazasRestantes.Location = new System.Drawing.Point(535, 84);
            this.plazasRestantes.Name = "plazasRestantes";
            this.plazasRestantes.ReadOnly = true;
            this.plazasRestantes.Size = new System.Drawing.Size(73, 22);
            this.plazasRestantes.TabIndex = 106;
            // 
            // AsignarClientesEstadia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.plazasRestantes);
            this.Controls.Add(this.capacidadHabitacion);
            this.Controls.Add(this.titularEstadia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numeroReserva);
            this.Controls.Add(this.listaClientes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.seleccionarCliente);
            this.Controls.Add(this.nuevoCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.atras);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AsignarClientesEstadia";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Hotel 2018";
            this.Activated += new System.EventHandler(this.AsignarClientesEstadia_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.listaClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcelistaClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button seleccionarCliente;
        private System.Windows.Forms.Button nuevoCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView listaClientes;
        private System.Windows.Forms.BindingSource bindingSourcelistaClientes;
        private System.Windows.Forms.TextBox numeroReserva;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox titularEstadia;
        private System.Windows.Forms.TextBox capacidadHabitacion;
        private System.Windows.Forms.TextBox plazasRestantes;
    }
}
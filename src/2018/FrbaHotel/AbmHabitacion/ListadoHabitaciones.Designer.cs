﻿namespace FrbaHotel.AbmHabitacion
{
    partial class ListadoHabitaciones
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
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxPiso = new System.Windows.Forms.TextBox();
            this.textBoxNroHab = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cancelar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxHotel = new System.Windows.Forms.TextBox();
            this.textBoxUbicacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTipoHab = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(499, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 14);
            this.label12.TabIndex = 85;
            this.label12.Text = "PISO";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxPiso
            // 
            this.textBoxPiso.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPiso.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxPiso.Location = new System.Drawing.Point(502, 67);
            this.textBoxPiso.Name = "textBoxPiso";
            this.textBoxPiso.Size = new System.Drawing.Size(135, 22);
            this.textBoxPiso.TabIndex = 3;
            // 
            // textBoxNroHab
            // 
            this.textBoxNroHab.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNroHab.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxNroHab.Location = new System.Drawing.Point(357, 67);
            this.textBoxNroHab.Name = "textBoxNroHab";
            this.textBoxNroHab.Size = new System.Drawing.Size(135, 22);
            this.textBoxNroHab.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(354, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 14);
            this.label3.TabIndex = 84;
            this.label3.Text = "NUMERO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(71, 212);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(566, 168);
            this.dataGridView1.TabIndex = 10;
            // 
            // cancelar
            // 
            this.cancelar.BackColor = System.Drawing.Color.DimGray;
            this.cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelar.ForeColor = System.Drawing.Color.White;
            this.cancelar.Location = new System.Drawing.Point(12, 386);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(101, 44);
            this.cancelar.TabIndex = 9;
            this.cancelar.Text = "cancelar";
            this.cancelar.UseVisualStyleBackColor = false;
            // 
            // limpiar
            // 
            this.limpiar.BackColor = System.Drawing.Color.White;
            this.limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.limpiar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limpiar.ForeColor = System.Drawing.Color.Crimson;
            this.limpiar.Location = new System.Drawing.Point(119, 386);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(101, 44);
            this.limpiar.TabIndex = 8;
            this.limpiar.Text = "limpiar datos";
            this.limpiar.UseVisualStyleBackColor = false;
            // 
            // buscar
            // 
            this.buscar.BackColor = System.Drawing.Color.Crimson;
            this.buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar.ForeColor = System.Drawing.Color.White;
            this.buscar.Location = new System.Drawing.Point(536, 162);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(101, 44);
            this.buscar.TabIndex = 7;
            this.buscar.Text = "buscar";
            this.buscar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(161, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 41);
            this.label1.TabIndex = 83;
            this.label1.Text = "LISTADO HABITACIONES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescripcion.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxDescripcion.Location = new System.Drawing.Point(71, 173);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(459, 22);
            this.textBoxDescripcion.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(68, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 14);
            this.label7.TabIndex = 82;
            this.label7.Text = "DESCRIPCION";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxHotel
            // 
            this.textBoxHotel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHotel.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxHotel.Location = new System.Drawing.Point(71, 67);
            this.textBoxHotel.Name = "textBoxHotel";
            this.textBoxHotel.Size = new System.Drawing.Size(280, 22);
            this.textBoxHotel.TabIndex = 1;
            // 
            // textBoxUbicacion
            // 
            this.textBoxUbicacion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUbicacion.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxUbicacion.Location = new System.Drawing.Point(71, 121);
            this.textBoxUbicacion.Name = "textBoxUbicacion";
            this.textBoxUbicacion.Size = new System.Drawing.Size(280, 22);
            this.textBoxUbicacion.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(354, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 14);
            this.label5.TabIndex = 81;
            this.label5.Text = "TIPO";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(68, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 14);
            this.label4.TabIndex = 80;
            this.label4.Text = "UBICACION";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(68, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 79;
            this.label2.Text = "HOTEL";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxTipoHab
            // 
            this.comboBoxTipoHab.DisplayMember = "tip_nombre";
            this.comboBoxTipoHab.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipoHab.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxTipoHab.FormattingEnabled = true;
            this.comboBoxTipoHab.Location = new System.Drawing.Point(357, 119);
            this.comboBoxTipoHab.Name = "comboBoxTipoHab";
            this.comboBoxTipoHab.Size = new System.Drawing.Size(280, 24);
            this.comboBoxTipoHab.TabIndex = 5;
            this.comboBoxTipoHab.ValueMember = "tip_id";
            // 
            // ListadoHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxPiso);
            this.Controls.Add(this.textBoxNroHab);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDescripcion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxHotel);
            this.Controls.Add(this.textBoxUbicacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxTipoHab);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ListadoHabitaciones";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Hotel 2018";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxPiso;
        private System.Windows.Forms.TextBox textBoxNroHab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxHotel;
        private System.Windows.Forms.TextBox textBoxUbicacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTipoHab;
    }
}
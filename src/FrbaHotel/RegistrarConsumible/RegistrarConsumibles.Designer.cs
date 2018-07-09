namespace FrbaHotel.RegistrarConsumible
{
    partial class RegistrarConsumibles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarConsumibles));
            this.textBoxIdEstadia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIdHabitacion = new System.Windows.Forms.TextBox();
            this.textBoxNumero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPiso = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.listaEstadias = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.listaEstadias)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxIdEstadia
            // 
            this.textBoxIdEstadia.Location = new System.Drawing.Point(187, 97);
            this.textBoxIdEstadia.Name = "textBoxIdEstadia";
            this.textBoxIdEstadia.Size = new System.Drawing.Size(100, 23);
            this.textBoxIdEstadia.TabIndex = 0;
            this.textBoxIdEstadia.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID ESTADIA";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID HABITACION";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxIdHabitacion
            // 
            this.textBoxIdHabitacion.Location = new System.Drawing.Point(460, 97);
            this.textBoxIdHabitacion.Name = "textBoxIdHabitacion";
            this.textBoxIdHabitacion.Size = new System.Drawing.Size(100, 23);
            this.textBoxIdHabitacion.TabIndex = 3;
            // 
            // textBoxNumero
            // 
            this.textBoxNumero.Location = new System.Drawing.Point(187, 145);
            this.textBoxNumero.Name = "textBoxNumero";
            this.textBoxNumero.Size = new System.Drawing.Size(100, 23);
            this.textBoxNumero.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "NUMERO";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(414, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "PISO";
            // 
            // textBoxPiso
            // 
            this.textBoxPiso.Location = new System.Drawing.Point(460, 145);
            this.textBoxPiso.Name = "textBoxPiso";
            this.textBoxPiso.Size = new System.Drawing.Size(100, 23);
            this.textBoxPiso.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(87, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 123);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(403, 360);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 9;
            this.buttonLimpiar.Text = "LIMPIAR";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(501, 360);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 10;
            this.buttonBuscar.Text = "BUSCAR";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(87, 360);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(94, 23);
            this.buttonCancelar.TabIndex = 12;
            this.buttonCancelar.Text = "CANCELAR";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.button3_Click);
            // 
            // listaEstadias
            // 
            this.listaEstadias.AllowUserToAddRows = false;
            this.listaEstadias.AllowUserToOrderColumns = true;
            this.listaEstadias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.listaEstadias.BackgroundColor = System.Drawing.Color.White;
            this.listaEstadias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listaEstadias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaEstadias.Location = new System.Drawing.Point(87, 194);
            this.listaEstadias.Name = "listaEstadias";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.listaEstadias.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            this.listaEstadias.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.listaEstadias.Size = new System.Drawing.Size(489, 149);
            this.listaEstadias.TabIndex = 13;
            this.listaEstadias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaEstadias_CellContentClick);
            // 
            // RegistrarConsumibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.listaEstadias);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.textBoxPiso);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNumero);
            this.Controls.Add(this.textBoxIdHabitacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIdEstadia);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RegistrarConsumibles";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Hotel 2018";
            this.Load += new System.EventHandler(this.RegistrarConsumibles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listaEstadias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIdEstadia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIdHabitacion;
        private System.Windows.Forms.TextBox textBoxNumero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPiso;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.DataGridView listaEstadias;
    }
}
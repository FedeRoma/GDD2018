namespace FrbaHotel.ListadoEstadistico
{
    partial class ListadoEstadistico
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
            this.label1 = new System.Windows.Forms.Label();
            this.limpiarDatos = new System.Windows.Forms.Button();
            this.trimestre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.año = new System.Windows.Forms.ComboBox();
            this.top5 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.aceptar = new System.Windows.Forms.Button();
            this.salir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(700, 51);
            this.label1.TabIndex = 7;
            this.label1.Text = "LISTADOS ESTADISTICOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // limpiarDatos
            // 
            this.limpiarDatos.BackColor = System.Drawing.Color.Gray;
            this.limpiarDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.limpiarDatos.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limpiarDatos.ForeColor = System.Drawing.Color.White;
            this.limpiarDatos.Location = new System.Drawing.Point(133, 388);
            this.limpiarDatos.Name = "limpiarDatos";
            this.limpiarDatos.Size = new System.Drawing.Size(132, 38);
            this.limpiarDatos.TabIndex = 15;
            this.limpiarDatos.Text = "Limpiar Datos";
            this.limpiarDatos.UseVisualStyleBackColor = false;
            // 
            // trimestre
            // 
            this.trimestre.BackColor = System.Drawing.Color.White;
            this.trimestre.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trimestre.ForeColor = System.Drawing.Color.DimGray;
            this.trimestre.FormattingEnabled = true;
            this.trimestre.Location = new System.Drawing.Point(420, 73);
            this.trimestre.MaxDropDownItems = 5;
            this.trimestre.Name = "trimestre";
            this.trimestre.Size = new System.Drawing.Size(189, 29);
            this.trimestre.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(317, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "TRIMESTRE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(67, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "TOP 5";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(78, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "AÑO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // año
            // 
            this.año.BackColor = System.Drawing.Color.White;
            this.año.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.año.ForeColor = System.Drawing.Color.DimGray;
            this.año.FormattingEnabled = true;
            this.año.Location = new System.Drawing.Point(126, 73);
            this.año.MaxDropDownItems = 5;
            this.año.Name = "año";
            this.año.Size = new System.Drawing.Size(132, 29);
            this.año.TabIndex = 9;
            // 
            // top5
            // 
            this.top5.BackColor = System.Drawing.Color.White;
            this.top5.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.top5.ForeColor = System.Drawing.Color.DimGray;
            this.top5.FormattingEnabled = true;
            this.top5.Location = new System.Drawing.Point(126, 118);
            this.top5.MaxDropDownItems = 5;
            this.top5.Name = "top5";
            this.top5.Size = new System.Drawing.Size(362, 29);
            this.top5.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 162);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(676, 217);
            this.dataGridView1.TabIndex = 13;
            // 
            // aceptar
            // 
            this.aceptar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aceptar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptar.ForeColor = System.Drawing.Color.White;
            this.aceptar.Location = new System.Drawing.Point(494, 112);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(115, 38);
            this.aceptar.TabIndex = 16;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = false;
            // 
            // salir
            // 
            this.salir.BackColor = System.Drawing.Color.Crimson;
            this.salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salir.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salir.ForeColor = System.Drawing.Color.White;
            this.salir.Location = new System.Drawing.Point(12, 388);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(115, 38);
            this.salir.TabIndex = 17;
            this.salir.Text = "SALIR";
            this.salir.UseVisualStyleBackColor = false;
            // 
            // ListadoEstadistico
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(700, 438);
            this.Controls.Add(this.salir);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.limpiarDatos);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.trimestre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.año);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.top5);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListadoEstadistico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA HOTEL 2018";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBUSCAR;
        private System.Windows.Forms.Button buttonSALIR;
        private System.Windows.Forms.Button limpiarDatos;
        private System.Windows.Forms.ComboBox trimestre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox año;
        private System.Windows.Forms.ComboBox top5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Button salir;
    }
}
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
            this.headerListadosEstadisticos = new System.Windows.Forms.Label();
            this.buttonListadosEstadisticosLimpiarDatos = new System.Windows.Forms.Button();
            this.trimestre = new System.Windows.Forms.ComboBox();
            this.labelListadosEstadisticosTrimestre = new System.Windows.Forms.Label();
            this.labelListadosEstadisticosTop5 = new System.Windows.Forms.Label();
            this.labelListadosEstadisticosAño = new System.Windows.Forms.Label();
            this.año = new System.Windows.Forms.ComboBox();
            this.top5 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonListadosEstadisticosAceptar = new System.Windows.Forms.Button();
            this.buttonListadosEstadisticosSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // headerListadosEstadisticos
            // 
            this.headerListadosEstadisticos.BackColor = System.Drawing.Color.Transparent;
            this.headerListadosEstadisticos.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerListadosEstadisticos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.headerListadosEstadisticos.Font = new System.Drawing.Font("Franklin Gothic Medium", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerListadosEstadisticos.ForeColor = System.Drawing.Color.DimGray;
            this.headerListadosEstadisticos.Location = new System.Drawing.Point(0, 0);
            this.headerListadosEstadisticos.Name = "headerListadosEstadisticos";
            this.headerListadosEstadisticos.Size = new System.Drawing.Size(700, 51);
            this.headerListadosEstadisticos.TabIndex = 7;
            this.headerListadosEstadisticos.Text = "LISTADOS ESTADISTICOS";
            this.headerListadosEstadisticos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonListadosEstadisticosLimpiarDatos
            // 
            this.buttonListadosEstadisticosLimpiarDatos.BackColor = System.Drawing.Color.Gray;
            this.buttonListadosEstadisticosLimpiarDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonListadosEstadisticosLimpiarDatos.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonListadosEstadisticosLimpiarDatos.ForeColor = System.Drawing.Color.White;
            this.buttonListadosEstadisticosLimpiarDatos.Location = new System.Drawing.Point(133, 388);
            this.buttonListadosEstadisticosLimpiarDatos.Name = "buttonListadosEstadisticosLimpiarDatos";
            this.buttonListadosEstadisticosLimpiarDatos.Size = new System.Drawing.Size(132, 38);
            this.buttonListadosEstadisticosLimpiarDatos.TabIndex = 15;
            this.buttonListadosEstadisticosLimpiarDatos.Text = "Limpiar Datos";
            this.buttonListadosEstadisticosLimpiarDatos.UseVisualStyleBackColor = false;
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
            // labelListadosEstadisticosTrimestre
            // 
            this.labelListadosEstadisticosTrimestre.AutoSize = true;
            this.labelListadosEstadisticosTrimestre.BackColor = System.Drawing.Color.Transparent;
            this.labelListadosEstadisticosTrimestre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelListadosEstadisticosTrimestre.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListadosEstadisticosTrimestre.ForeColor = System.Drawing.Color.DimGray;
            this.labelListadosEstadisticosTrimestre.Location = new System.Drawing.Point(317, 79);
            this.labelListadosEstadisticosTrimestre.Name = "labelListadosEstadisticosTrimestre";
            this.labelListadosEstadisticosTrimestre.Size = new System.Drawing.Size(97, 18);
            this.labelListadosEstadisticosTrimestre.TabIndex = 10;
            this.labelListadosEstadisticosTrimestre.Text = "TRIMESTRE";
            this.labelListadosEstadisticosTrimestre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelListadosEstadisticosTop5
            // 
            this.labelListadosEstadisticosTop5.AutoSize = true;
            this.labelListadosEstadisticosTop5.BackColor = System.Drawing.Color.Transparent;
            this.labelListadosEstadisticosTop5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelListadosEstadisticosTop5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListadosEstadisticosTop5.ForeColor = System.Drawing.Color.DimGray;
            this.labelListadosEstadisticosTop5.Location = new System.Drawing.Point(67, 122);
            this.labelListadosEstadisticosTop5.Name = "labelListadosEstadisticosTop5";
            this.labelListadosEstadisticosTop5.Size = new System.Drawing.Size(53, 18);
            this.labelListadosEstadisticosTop5.TabIndex = 5;
            this.labelListadosEstadisticosTop5.Text = "TOP 5";
            this.labelListadosEstadisticosTop5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelListadosEstadisticosAño
            // 
            this.labelListadosEstadisticosAño.AutoSize = true;
            this.labelListadosEstadisticosAño.BackColor = System.Drawing.Color.Transparent;
            this.labelListadosEstadisticosAño.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelListadosEstadisticosAño.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListadosEstadisticosAño.ForeColor = System.Drawing.Color.DimGray;
            this.labelListadosEstadisticosAño.Location = new System.Drawing.Point(78, 79);
            this.labelListadosEstadisticosAño.Name = "labelListadosEstadisticosAño";
            this.labelListadosEstadisticosAño.Size = new System.Drawing.Size(42, 18);
            this.labelListadosEstadisticosAño.TabIndex = 8;
            this.labelListadosEstadisticosAño.Text = "AÑO";
            this.labelListadosEstadisticosAño.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // buttonListadosEstadisticosAceptar
            // 
            this.buttonListadosEstadisticosAceptar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.buttonListadosEstadisticosAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonListadosEstadisticosAceptar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonListadosEstadisticosAceptar.ForeColor = System.Drawing.Color.White;
            this.buttonListadosEstadisticosAceptar.Location = new System.Drawing.Point(494, 112);
            this.buttonListadosEstadisticosAceptar.Name = "buttonListadosEstadisticosAceptar";
            this.buttonListadosEstadisticosAceptar.Size = new System.Drawing.Size(115, 38);
            this.buttonListadosEstadisticosAceptar.TabIndex = 16;
            this.buttonListadosEstadisticosAceptar.Text = "Aceptar";
            this.buttonListadosEstadisticosAceptar.UseVisualStyleBackColor = false;
            // 
            // buttonListadosEstadisticosSalir
            // 
            this.buttonListadosEstadisticosSalir.BackColor = System.Drawing.Color.Crimson;
            this.buttonListadosEstadisticosSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonListadosEstadisticosSalir.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonListadosEstadisticosSalir.ForeColor = System.Drawing.Color.White;
            this.buttonListadosEstadisticosSalir.Location = new System.Drawing.Point(12, 388);
            this.buttonListadosEstadisticosSalir.Name = "buttonListadosEstadisticosSalir";
            this.buttonListadosEstadisticosSalir.Size = new System.Drawing.Size(115, 38);
            this.buttonListadosEstadisticosSalir.TabIndex = 17;
            this.buttonListadosEstadisticosSalir.Text = "SALIR";
            this.buttonListadosEstadisticosSalir.UseVisualStyleBackColor = false;
            // 
            // ListadoEstadistico
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(700, 438);
            this.Controls.Add(this.buttonListadosEstadisticosSalir);
            this.Controls.Add(this.buttonListadosEstadisticosAceptar);
            this.Controls.Add(this.buttonListadosEstadisticosLimpiarDatos);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.trimestre);
            this.Controls.Add(this.labelListadosEstadisticosTrimestre);
            this.Controls.Add(this.año);
            this.Controls.Add(this.labelListadosEstadisticosAño);
            this.Controls.Add(this.headerListadosEstadisticos);
            this.Controls.Add(this.labelListadosEstadisticosTop5);
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

        private System.Windows.Forms.Label headerListadosEstadisticos;
        private System.Windows.Forms.Button buttonBUSCAR;
        private System.Windows.Forms.Button buttonSALIR;
        private System.Windows.Forms.Button buttonListadosEstadisticosLimpiarDatos;
        private System.Windows.Forms.ComboBox trimestre;
        private System.Windows.Forms.Label labelListadosEstadisticosTrimestre;
        private System.Windows.Forms.Label labelListadosEstadisticosTop5;
        private System.Windows.Forms.Label labelListadosEstadisticosAño;
        private System.Windows.Forms.ComboBox año;
        private System.Windows.Forms.ComboBox top5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonListadosEstadisticosAceptar;
        private System.Windows.Forms.Button buttonListadosEstadisticosSalir;
    }
}
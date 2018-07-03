namespace FrbaHotel.Login
{
    partial class MenuFuncionalidades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuFuncionalidades));
            this.label2 = new System.Windows.Forms.Label();
            this.cancelar = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.cambiarContraseña = new System.Windows.Forms.Button();
            this.funcionalidad = new System.Windows.Forms.ComboBox();
            this.hotelActivo = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(211, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Funcionalidad";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cancelar.TabIndex = 4;
            this.cancelar.Text = "cancelar";
            this.cancelar.UseVisualStyleBackColor = false;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
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
            this.aceptar.TabIndex = 2;
            this.aceptar.Text = "aceptar";
            this.aceptar.UseVisualStyleBackColor = false;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // cambiarContraseña
            // 
            this.cambiarContraseña.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cambiarContraseña.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cambiarContraseña.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cambiarContraseña.ForeColor = System.Drawing.Color.Crimson;
            this.cambiarContraseña.Location = new System.Drawing.Point(119, 386);
            this.cambiarContraseña.Name = "cambiarContraseña";
            this.cambiarContraseña.Size = new System.Drawing.Size(106, 44);
            this.cambiarContraseña.TabIndex = 3;
            this.cambiarContraseña.Text = "cambiar contraseña";
            this.cambiarContraseña.UseVisualStyleBackColor = false;
            this.cambiarContraseña.Click += new System.EventHandler(this.cambiarContraseña_Click);
            // 
            // funcionalidad
            // 
            this.funcionalidad.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionalidad.ForeColor = System.Drawing.Color.DimGray;
            this.funcionalidad.FormattingEnabled = true;
            this.funcionalidad.Location = new System.Drawing.Point(214, 220);
            this.funcionalidad.Name = "funcionalidad";
            this.funcionalidad.Size = new System.Drawing.Size(280, 24);
            this.funcionalidad.TabIndex = 1;
            // 
            // hotelActivo
            // 
            this.hotelActivo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.hotelActivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hotelActivo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotelActivo.ForeColor = System.Drawing.Color.Crimson;
            this.hotelActivo.FormattingEnabled = true;
            this.hotelActivo.ItemHeight = 18;
            this.hotelActivo.Location = new System.Drawing.Point(214, 167);
            this.hotelActivo.Name = "hotelActivo";
            this.hotelActivo.Size = new System.Drawing.Size(280, 20);
            this.hotelActivo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(211, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Hotel";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MenuFuncionalidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hotelActivo);
            this.Controls.Add(this.funcionalidad);
            this.Controls.Add(this.cambiarContraseña);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MenuFuncionalidades";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Hotel 2018";
            this.Load += new System.EventHandler(this.MenuFuncionalidades_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Button cambiarContraseña;
        private System.Windows.Forms.ComboBox funcionalidad;
        private System.Windows.Forms.ListBox hotelActivo;
        private System.Windows.Forms.Label label1;
    }
}
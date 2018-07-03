namespace FrbaHotel.Login
{
    partial class CambiarContrasenia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarContrasenia));
            this.label1 = new System.Windows.Forms.Label();
            this.usuarioActivo = new System.Windows.Forms.ListBox();
            this.atras = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.contraseniaNueva = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.contraseniaActual = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(157, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nombre de Usuario";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // usuarioActivo
            // 
            this.usuarioActivo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.usuarioActivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usuarioActivo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioActivo.ForeColor = System.Drawing.Color.Crimson;
            this.usuarioActivo.FormattingEnabled = true;
            this.usuarioActivo.ItemHeight = 18;
            this.usuarioActivo.Location = new System.Drawing.Point(160, 142);
            this.usuarioActivo.Name = "usuarioActivo";
            this.usuarioActivo.Size = new System.Drawing.Size(280, 20);
            this.usuarioActivo.TabIndex = 5;
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
            this.atras.TabIndex = 4;
            this.atras.Text = "atrás";
            this.atras.UseVisualStyleBackColor = false;
            this.atras.Click += new System.EventHandler(this.atras_Click);
            // 
            // aceptar
            // 
            this.aceptar.BackColor = System.Drawing.Color.Crimson;
            this.aceptar.CausesValidation = false;
            this.aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aceptar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptar.ForeColor = System.Drawing.Color.White;
            this.aceptar.Location = new System.Drawing.Point(446, 235);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(101, 44);
            this.aceptar.TabIndex = 3;
            this.aceptar.Text = "aceptar";
            this.aceptar.UseVisualStyleBackColor = false;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // contraseniaNueva
            // 
            this.contraseniaNueva.BackColor = System.Drawing.Color.White;
            this.contraseniaNueva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contraseniaNueva.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contraseniaNueva.ForeColor = System.Drawing.Color.DimGray;
            this.contraseniaNueva.Location = new System.Drawing.Point(160, 246);
            this.contraseniaNueva.Name = "contraseniaNueva";
            this.contraseniaNueva.PasswordChar = '*';
            this.contraseniaNueva.Size = new System.Drawing.Size(280, 22);
            this.contraseniaNueva.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(157, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 14);
            this.label5.TabIndex = 26;
            this.label5.Text = "Nueva Contraseña";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contraseniaActual
            // 
            this.contraseniaActual.BackColor = System.Drawing.Color.White;
            this.contraseniaActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contraseniaActual.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contraseniaActual.ForeColor = System.Drawing.Color.DimGray;
            this.contraseniaActual.Location = new System.Drawing.Point(160, 192);
            this.contraseniaActual.Name = "contraseniaActual";
            this.contraseniaActual.PasswordChar = '*';
            this.contraseniaActual.Size = new System.Drawing.Size(280, 22);
            this.contraseniaActual.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(157, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "Contraseña Actual";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CambiarContrasenia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.atras);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.contraseniaNueva);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.contraseniaActual);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usuarioActivo);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CambiarContrasenia";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Hotel 2018";
            this.Load += new System.EventHandler(this.CambiarContrasenia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox usuarioActivo;
        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.TextBox contraseniaNueva;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox contraseniaActual;
        private System.Windows.Forms.Label label3;
    }
}
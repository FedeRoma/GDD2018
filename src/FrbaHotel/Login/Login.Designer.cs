﻿namespace FrbaHotel.Login
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.contrasenia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nombreUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cancelar = new System.Windows.Forms.Button();
            this.ingresar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // contrasenia
            // 
            this.contrasenia.BackColor = System.Drawing.Color.White;
            this.contrasenia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contrasenia.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contrasenia.ForeColor = System.Drawing.Color.DimGray;
            this.contrasenia.Location = new System.Drawing.Point(214, 246);
            this.contrasenia.Name = "contrasenia";
            this.contrasenia.PasswordChar = '*';
            this.contrasenia.Size = new System.Drawing.Size(280, 22);
            this.contrasenia.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(211, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 14);
            this.label5.TabIndex = 11;
            this.label5.Text = "Contraseña";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nombreUsuario
            // 
            this.nombreUsuario.BackColor = System.Drawing.Color.White;
            this.nombreUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nombreUsuario.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.nombreUsuario.Location = new System.Drawing.Point(214, 192);
            this.nombreUsuario.Name = "nombreUsuario";
            this.nombreUsuario.Size = new System.Drawing.Size(280, 22);
            this.nombreUsuario.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(211, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nombre de Usuario";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cancelar.Click += new System.EventHandler(this.atras_Click);
            // 
            // ingresar
            // 
            this.ingresar.BackColor = System.Drawing.Color.Crimson;
            this.ingresar.CausesValidation = false;
            this.ingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ingresar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ingresar.ForeColor = System.Drawing.Color.White;
            this.ingresar.Location = new System.Drawing.Point(500, 235);
            this.ingresar.Name = "ingresar";
            this.ingresar.Size = new System.Drawing.Size(101, 44);
            this.ingresar.TabIndex = 3;
            this.ingresar.Text = "ingresar";
            this.ingresar.UseVisualStyleBackColor = false;
            this.ingresar.Click += new System.EventHandler(this.ingresar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(194, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(317, 61);
            this.label2.TabIndex = 13;
            this.label2.Text = "Iniciar Sesión";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.ingresar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contrasenia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nombreUsuario);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Hotel 2018";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox contrasenia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nombreUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button ingresar;
        private System.Windows.Forms.Label label2;

    }
}
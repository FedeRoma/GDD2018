﻿namespace FrbaHotel
{
    partial class Index
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
            this.label2 = new System.Windows.Forms.Label();
            this.iniciarSesion = new System.Windows.Forms.Button();
            this.invitado = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(163, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 81);
            this.label1.TabIndex = 2;
            this.label1.Text = "BIENVENIDO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(204, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 43);
            this.label2.TabIndex = 3;
            this.label2.Text = "FRBA Hotel 2018";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iniciarSesion
            // 
            this.iniciarSesion.BackColor = System.Drawing.Color.Crimson;
            this.iniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iniciarSesion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iniciarSesion.ForeColor = System.Drawing.Color.White;
            this.iniciarSesion.Location = new System.Drawing.Point(292, 337);
            this.iniciarSesion.Name = "iniciarSesion";
            this.iniciarSesion.Size = new System.Drawing.Size(121, 44);
            this.iniciarSesion.TabIndex = 20;
            this.iniciarSesion.Text = "Iniciar Sesión";
            this.iniciarSesion.UseVisualStyleBackColor = false;
            this.iniciarSesion.Click += new System.EventHandler(this.iniciarSesion_Click);
            // 
            // invitado
            // 
            this.invitado.BackColor = System.Drawing.Color.DimGray;
            this.invitado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.invitado.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invitado.ForeColor = System.Drawing.Color.White;
            this.invitado.Location = new System.Drawing.Point(257, 267);
            this.invitado.Name = "invitado";
            this.invitado.Size = new System.Drawing.Size(191, 44);
            this.invitado.TabIndex = 22;
            this.invitado.Text = "Continuar como Invitado";
            this.invitado.UseVisualStyleBackColor = false;
            this.invitado.Click += new System.EventHandler(this.invitado_Click);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.invitado);
            this.Controls.Add(this.iniciarSesion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Index";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Hotel 2018";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button iniciarSesion;
        private System.Windows.Forms.Button invitado;
    }
}
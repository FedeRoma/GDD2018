namespace FrbaHotel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.iniciarSesion = new System.Windows.Forms.Button();
            this.invitado = new System.Windows.Forms.Button();
            this.estadoReservasVencidas = new System.Windows.Forms.TextBox();
            this.minFechaRes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(45, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(614, 61);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sistema de Gestión Hotelera";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(79, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(546, 75);
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
            this.iniciarSesion.Location = new System.Drawing.Point(170, 271);
            this.iniciarSesion.Name = "iniciarSesion";
            this.iniciarSesion.Size = new System.Drawing.Size(364, 44);
            this.iniciarSesion.TabIndex = 1;
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
            this.invitado.Location = new System.Drawing.Point(170, 321);
            this.invitado.Name = "invitado";
            this.invitado.Size = new System.Drawing.Size(364, 44);
            this.invitado.TabIndex = 2;
            this.invitado.Text = "Continuar como Invitado";
            this.invitado.UseVisualStyleBackColor = false;
            this.invitado.Click += new System.EventHandler(this.invitado_Click);
            // 
            // estadoReservasVencidas
            // 
            this.estadoReservasVencidas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.estadoReservasVencidas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.estadoReservasVencidas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estadoReservasVencidas.ForeColor = System.Drawing.Color.Gray;
            this.estadoReservasVencidas.Location = new System.Drawing.Point(221, 208);
            this.estadoReservasVencidas.Name = "estadoReservasVencidas";
            this.estadoReservasVencidas.ReadOnly = true;
            this.estadoReservasVencidas.Size = new System.Drawing.Size(262, 13);
            this.estadoReservasVencidas.TabIndex = 165;
            this.estadoReservasVencidas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // minFechaRes
            // 
            this.minFechaRes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.minFechaRes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.minFechaRes.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minFechaRes.ForeColor = System.Drawing.Color.DarkGray;
            this.minFechaRes.Location = new System.Drawing.Point(221, 236);
            this.minFechaRes.Name = "minFechaRes";
            this.minFechaRes.ReadOnly = true;
            this.minFechaRes.Size = new System.Drawing.Size(262, 19);
            this.minFechaRes.TabIndex = 166;
            this.minFechaRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.minFechaRes);
            this.Controls.Add(this.estadoReservasVencidas);
            this.Controls.Add(this.invitado);
            this.Controls.Add(this.iniciarSesion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Index";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
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
        private System.Windows.Forms.TextBox estadoReservasVencidas;
        private System.Windows.Forms.TextBox minFechaRes;
    }
}
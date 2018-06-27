namespace FrbaHotel.Login
{
    partial class RolesUsuario
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
            this.comboBoxRol = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxHotel = new System.Windows.Forms.ComboBox();
            this.cancelar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(151, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "POR FAVOR SELECCIONE:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(211, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "ROL";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxRol
            // 
            this.comboBoxRol.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRol.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxRol.FormattingEnabled = true;
            this.comboBoxRol.Location = new System.Drawing.Point(214, 240);
            this.comboBoxRol.Name = "comboBoxRol";
            this.comboBoxRol.Size = new System.Drawing.Size(280, 24);
            this.comboBoxRol.TabIndex = 2;
            this.comboBoxRol.SelectedIndexChanged += new System.EventHandler(this.comboBoxRol_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(211, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "HOTEL";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxHotel
            // 
            this.comboBoxHotel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxHotel.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxHotel.FormattingEnabled = true;
            this.comboBoxHotel.Location = new System.Drawing.Point(214, 196);
            this.comboBoxHotel.Name = "comboBoxHotel";
            this.comboBoxHotel.Size = new System.Drawing.Size(280, 24);
            this.comboBoxHotel.TabIndex = 1;
            this.comboBoxHotel.SelectedIndexChanged += new System.EventHandler(this.comboBoxHotel_SelectedIndexChanged);
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
            this.cancelar.TabIndex = 5;
            this.cancelar.Text = "cancelar";
            this.cancelar.UseVisualStyleBackColor = false;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
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
            // RolesUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxHotel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxRol);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RolesUsuario";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Hotel 2018";
            this.Load += new System.EventHandler(this.RolesUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxRol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxHotel;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button aceptar;
    }
}
namespace FrbaHotel.AbmCliente
{
    partial class MenuAbmCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuAbmCliente));
            this.label1 = new System.Windows.Forms.Label();
            this.listadoClientes = new System.Windows.Forms.Button();
            this.altaCliente = new System.Windows.Forms.Button();
            this.bajaCliente = new System.Windows.Forms.Button();
            this.modificacionCliente = new System.Windows.Forms.Button();
            this.atras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(159, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "ADMINISTRAR CLIENTES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listadoClientes
            // 
            this.listadoClientes.BackColor = System.Drawing.Color.Crimson;
            this.listadoClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listadoClientes.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listadoClientes.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.listadoClientes.Location = new System.Drawing.Point(193, 80);
            this.listadoClientes.Name = "listadoClientes";
            this.listadoClientes.Size = new System.Drawing.Size(318, 69);
            this.listadoClientes.TabIndex = 1;
            this.listadoClientes.Text = "LISTADO";
            this.listadoClientes.UseVisualStyleBackColor = false;
            this.listadoClientes.Click += new System.EventHandler(this.listadoClientes_Click);
            // 
            // altaCliente
            // 
            this.altaCliente.BackColor = System.Drawing.Color.Crimson;
            this.altaCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.altaCliente.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altaCliente.ForeColor = System.Drawing.Color.White;
            this.altaCliente.Location = new System.Drawing.Point(193, 155);
            this.altaCliente.Name = "altaCliente";
            this.altaCliente.Size = new System.Drawing.Size(156, 131);
            this.altaCliente.TabIndex = 2;
            this.altaCliente.Text = "ALTA";
            this.altaCliente.UseVisualStyleBackColor = false;
            this.altaCliente.Click += new System.EventHandler(this.altaCliente_Click);
            // 
            // bajaCliente
            // 
            this.bajaCliente.BackColor = System.Drawing.Color.Crimson;
            this.bajaCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bajaCliente.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bajaCliente.ForeColor = System.Drawing.Color.White;
            this.bajaCliente.Location = new System.Drawing.Point(355, 155);
            this.bajaCliente.Name = "bajaCliente";
            this.bajaCliente.Size = new System.Drawing.Size(156, 131);
            this.bajaCliente.TabIndex = 3;
            this.bajaCliente.Text = "BAJA";
            this.bajaCliente.UseVisualStyleBackColor = false;
            this.bajaCliente.Click += new System.EventHandler(this.bajaCliente_Click);
            // 
            // modificacionCliente
            // 
            this.modificacionCliente.BackColor = System.Drawing.Color.Crimson;
            this.modificacionCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modificacionCliente.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificacionCliente.ForeColor = System.Drawing.Color.White;
            this.modificacionCliente.Location = new System.Drawing.Point(193, 293);
            this.modificacionCliente.Name = "modificacionCliente";
            this.modificacionCliente.Size = new System.Drawing.Size(318, 69);
            this.modificacionCliente.TabIndex = 4;
            this.modificacionCliente.Text = "MODIFICACION";
            this.modificacionCliente.UseVisualStyleBackColor = false;
            this.modificacionCliente.Click += new System.EventHandler(this.modificacionCliente_Click);
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
            this.atras.TabIndex = 5;
            this.atras.Text = "atrás";
            this.atras.UseVisualStyleBackColor = false;
            this.atras.Click += new System.EventHandler(this.atras_Click);
            // 
            // MenuAbmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.atras);
            this.Controls.Add(this.modificacionCliente);
            this.Controls.Add(this.bajaCliente);
            this.Controls.Add(this.altaCliente);
            this.Controls.Add(this.listadoClientes);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MenuAbmCliente";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Hotel 2018";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button listadoClientes;
        private System.Windows.Forms.Button altaCliente;
        private System.Windows.Forms.Button bajaCliente;
        private System.Windows.Forms.Button modificacionCliente;
        private System.Windows.Forms.Button atras;
    }
}
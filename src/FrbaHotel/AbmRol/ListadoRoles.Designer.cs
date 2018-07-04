namespace FrbaHotel.AbmRol
{
    partial class ListadoRoles
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoRoles));
            this.label1 = new System.Windows.Forms.Label();
            this.listaFuncionalidades = new System.Windows.Forms.DataGridView();
            this.atras = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listaRoles = new System.Windows.Forms.DataGridView();
            this.bindingSourceListaRoles = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceListaFuncionalidades = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.listaFuncionalidades)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceListaRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceListaFuncionalidades)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(223, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 41);
            this.label1.TabIndex = 39;
            this.label1.Text = "LISTADO ROLES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listaFuncionalidades
            // 
            this.listaFuncionalidades.AllowUserToOrderColumns = true;
            this.listaFuncionalidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.listaFuncionalidades.BackgroundColor = System.Drawing.Color.White;
            this.listaFuncionalidades.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listaFuncionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaFuncionalidades.Location = new System.Drawing.Point(6, 19);
            this.listaFuncionalidades.Name = "listaFuncionalidades";
            this.listaFuncionalidades.Size = new System.Drawing.Size(554, 138);
            this.listaFuncionalidades.TabIndex = 40;
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
            this.atras.TabIndex = 43;
            this.atras.Text = "atrás";
            this.atras.UseVisualStyleBackColor = false;
            this.atras.Click += new System.EventHandler(this.atras_Click);
            // 
            // limpiar
            // 
            this.limpiar.BackColor = System.Drawing.Color.White;
            this.limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.limpiar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limpiar.ForeColor = System.Drawing.Color.DimGray;
            this.limpiar.Location = new System.Drawing.Point(119, 386);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(101, 44);
            this.limpiar.TabIndex = 42;
            this.limpiar.Text = "limpiar datos";
            this.limpiar.UseVisualStyleBackColor = false;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listaFuncionalidades);
            this.groupBox1.Location = new System.Drawing.Point(69, 217);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 163);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funcionalidades";
            // 
            // listaRoles
            // 
            this.listaRoles.AllowUserToOrderColumns = true;
            this.listaRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.listaRoles.BackgroundColor = System.Drawing.Color.White;
            this.listaRoles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listaRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaRoles.GridColor = System.Drawing.Color.Gainsboro;
            this.listaRoles.Location = new System.Drawing.Point(69, 53);
            this.listaRoles.Name = "listaRoles";
            this.listaRoles.Size = new System.Drawing.Size(566, 158);
            this.listaRoles.TabIndex = 45;
            this.listaRoles.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.listaRoles_CellPainting);
            // 
            // ListadoRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.listaRoles);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.atras);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ListadoRoles";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Hotel 2018";
            this.Load += new System.EventHandler(this.ListadoRoles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listaFuncionalidades)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listaRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceListaRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceListaFuncionalidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView listaFuncionalidades;
        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView listaRoles;
        private System.Windows.Forms.BindingSource bindingSourceListaRoles;
        private System.Windows.Forms.BindingSource bindingSourceListaFuncionalidades;
    }
}
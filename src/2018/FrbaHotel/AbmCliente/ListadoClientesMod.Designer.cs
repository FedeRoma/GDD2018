namespace FrbaHotel.AbmCliente
{
    partial class ListadoClientesMod
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clidocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clidocidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clinombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliapellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.climailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clinacionalidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clifechanacDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clihabilitadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clicalleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clicallenroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clipisoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clideptoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clidirlocalidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clidirpaisDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clitelefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gD1C2018DataSet = new FrbaHotel.GD1C2018DataSet();
            this.cancelar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNroDoc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTipoDoc = new System.Windows.Forms.ComboBox();
            this.clientesTableAdapter = new FrbaHotel.GD1C2018DataSetTableAdapters.ClientesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2018DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clidocumentoDataGridViewTextBoxColumn,
            this.clidocidDataGridViewTextBoxColumn,
            this.clinombreDataGridViewTextBoxColumn,
            this.cliapellidoDataGridViewTextBoxColumn,
            this.climailDataGridViewTextBoxColumn,
            this.clinacionalidadDataGridViewTextBoxColumn,
            this.clifechanacDataGridViewTextBoxColumn,
            this.clihabilitadoDataGridViewCheckBoxColumn,
            this.clicalleDataGridViewTextBoxColumn,
            this.clicallenroDataGridViewTextBoxColumn,
            this.clipisoDataGridViewTextBoxColumn,
            this.clideptoDataGridViewTextBoxColumn,
            this.clidirlocalidadDataGridViewTextBoxColumn,
            this.clidirpaisDataGridViewTextBoxColumn,
            this.clitelefonoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.clientesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(71, 212);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(566, 168);
            this.dataGridView1.TabIndex = 9;
            // 
            // clidocumentoDataGridViewTextBoxColumn
            // 
            this.clidocumentoDataGridViewTextBoxColumn.DataPropertyName = "cli_documento";
            this.clidocumentoDataGridViewTextBoxColumn.HeaderText = "cli_documento";
            this.clidocumentoDataGridViewTextBoxColumn.Name = "clidocumentoDataGridViewTextBoxColumn";
            // 
            // clidocidDataGridViewTextBoxColumn
            // 
            this.clidocidDataGridViewTextBoxColumn.DataPropertyName = "cli_doc_id";
            this.clidocidDataGridViewTextBoxColumn.HeaderText = "cli_doc_id";
            this.clidocidDataGridViewTextBoxColumn.Name = "clidocidDataGridViewTextBoxColumn";
            // 
            // clinombreDataGridViewTextBoxColumn
            // 
            this.clinombreDataGridViewTextBoxColumn.DataPropertyName = "cli_nombre";
            this.clinombreDataGridViewTextBoxColumn.HeaderText = "cli_nombre";
            this.clinombreDataGridViewTextBoxColumn.Name = "clinombreDataGridViewTextBoxColumn";
            // 
            // cliapellidoDataGridViewTextBoxColumn
            // 
            this.cliapellidoDataGridViewTextBoxColumn.DataPropertyName = "cli_apellido";
            this.cliapellidoDataGridViewTextBoxColumn.HeaderText = "cli_apellido";
            this.cliapellidoDataGridViewTextBoxColumn.Name = "cliapellidoDataGridViewTextBoxColumn";
            // 
            // climailDataGridViewTextBoxColumn
            // 
            this.climailDataGridViewTextBoxColumn.DataPropertyName = "cli_mail";
            this.climailDataGridViewTextBoxColumn.HeaderText = "cli_mail";
            this.climailDataGridViewTextBoxColumn.Name = "climailDataGridViewTextBoxColumn";
            // 
            // clinacionalidadDataGridViewTextBoxColumn
            // 
            this.clinacionalidadDataGridViewTextBoxColumn.DataPropertyName = "cli_nacionalidad";
            this.clinacionalidadDataGridViewTextBoxColumn.HeaderText = "cli_nacionalidad";
            this.clinacionalidadDataGridViewTextBoxColumn.Name = "clinacionalidadDataGridViewTextBoxColumn";
            // 
            // clifechanacDataGridViewTextBoxColumn
            // 
            this.clifechanacDataGridViewTextBoxColumn.DataPropertyName = "cli_fecha_nac";
            this.clifechanacDataGridViewTextBoxColumn.HeaderText = "cli_fecha_nac";
            this.clifechanacDataGridViewTextBoxColumn.Name = "clifechanacDataGridViewTextBoxColumn";
            // 
            // clihabilitadoDataGridViewCheckBoxColumn
            // 
            this.clihabilitadoDataGridViewCheckBoxColumn.DataPropertyName = "cli_habilitado";
            this.clihabilitadoDataGridViewCheckBoxColumn.HeaderText = "cli_habilitado";
            this.clihabilitadoDataGridViewCheckBoxColumn.Name = "clihabilitadoDataGridViewCheckBoxColumn";
            // 
            // clicalleDataGridViewTextBoxColumn
            // 
            this.clicalleDataGridViewTextBoxColumn.DataPropertyName = "cli_calle";
            this.clicalleDataGridViewTextBoxColumn.HeaderText = "cli_calle";
            this.clicalleDataGridViewTextBoxColumn.Name = "clicalleDataGridViewTextBoxColumn";
            // 
            // clicallenroDataGridViewTextBoxColumn
            // 
            this.clicallenroDataGridViewTextBoxColumn.DataPropertyName = "cli_calle_nro";
            this.clicallenroDataGridViewTextBoxColumn.HeaderText = "cli_calle_nro";
            this.clicallenroDataGridViewTextBoxColumn.Name = "clicallenroDataGridViewTextBoxColumn";
            // 
            // clipisoDataGridViewTextBoxColumn
            // 
            this.clipisoDataGridViewTextBoxColumn.DataPropertyName = "cli_piso";
            this.clipisoDataGridViewTextBoxColumn.HeaderText = "cli_piso";
            this.clipisoDataGridViewTextBoxColumn.Name = "clipisoDataGridViewTextBoxColumn";
            // 
            // clideptoDataGridViewTextBoxColumn
            // 
            this.clideptoDataGridViewTextBoxColumn.DataPropertyName = "cli_depto";
            this.clideptoDataGridViewTextBoxColumn.HeaderText = "cli_depto";
            this.clideptoDataGridViewTextBoxColumn.Name = "clideptoDataGridViewTextBoxColumn";
            // 
            // clidirlocalidadDataGridViewTextBoxColumn
            // 
            this.clidirlocalidadDataGridViewTextBoxColumn.DataPropertyName = "cli_dir_localidad";
            this.clidirlocalidadDataGridViewTextBoxColumn.HeaderText = "cli_dir_localidad";
            this.clidirlocalidadDataGridViewTextBoxColumn.Name = "clidirlocalidadDataGridViewTextBoxColumn";
            // 
            // clidirpaisDataGridViewTextBoxColumn
            // 
            this.clidirpaisDataGridViewTextBoxColumn.DataPropertyName = "cli_dir_pais";
            this.clidirpaisDataGridViewTextBoxColumn.HeaderText = "cli_dir_pais";
            this.clidirpaisDataGridViewTextBoxColumn.Name = "clidirpaisDataGridViewTextBoxColumn";
            // 
            // clitelefonoDataGridViewTextBoxColumn
            // 
            this.clitelefonoDataGridViewTextBoxColumn.DataPropertyName = "cli_telefono";
            this.clitelefonoDataGridViewTextBoxColumn.HeaderText = "cli_telefono";
            this.clitelefonoDataGridViewTextBoxColumn.Name = "clitelefonoDataGridViewTextBoxColumn";
            // 
            // clientesBindingSource
            // 
            this.clientesBindingSource.DataMember = "Clientes";
            this.clientesBindingSource.DataSource = this.gD1C2018DataSet;
            // 
            // gD1C2018DataSet
            // 
            this.gD1C2018DataSet.DataSetName = "GD1C2018DataSet";
            this.gD1C2018DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.cancelar.TabIndex = 8;
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
            this.limpiar.TabIndex = 7;
            this.limpiar.Text = "limpiar datos";
            this.limpiar.UseVisualStyleBackColor = false;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // buscar
            // 
            this.buscar.BackColor = System.Drawing.Color.Crimson;
            this.buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar.ForeColor = System.Drawing.Color.White;
            this.buscar.Location = new System.Drawing.Point(451, 156);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(101, 44);
            this.buscar.TabIndex = 6;
            this.buscar.Text = "buscar";
            this.buscar.UseVisualStyleBackColor = false;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(202, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 41);
            this.label1.TabIndex = 53;
            this.label1.Text = "LISTADO CLIENTES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxEmail.Location = new System.Drawing.Point(71, 173);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(280, 22);
            this.textBoxEmail.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(68, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 14);
            this.label7.TabIndex = 52;
            this.label7.Text = "eMAIL";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxApellido.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxApellido.Location = new System.Drawing.Point(357, 121);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(280, 22);
            this.textBoxApellido.TabIndex = 4;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNombre.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxNombre.Location = new System.Drawing.Point(71, 121);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(280, 22);
            this.textBoxNombre.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(354, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 14);
            this.label5.TabIndex = 51;
            this.label5.Text = "APELLIDO";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(68, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 14);
            this.label4.TabIndex = 50;
            this.label4.Text = "NOMBRE";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxNroDoc
            // 
            this.textBoxNroDoc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNroDoc.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxNroDoc.Location = new System.Drawing.Point(357, 67);
            this.textBoxNroDoc.Name = "textBoxNroDoc";
            this.textBoxNroDoc.Size = new System.Drawing.Size(280, 22);
            this.textBoxNroDoc.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(354, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 14);
            this.label3.TabIndex = 49;
            this.label3.Text = "NRO DE DOCUMENTO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(68, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 14);
            this.label2.TabIndex = 48;
            this.label2.Text = "TIPO DE DOCUMENTO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxTipoDoc
            // 
            this.comboBoxTipoDoc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipoDoc.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxTipoDoc.FormattingEnabled = true;
            this.comboBoxTipoDoc.Location = new System.Drawing.Point(71, 67);
            this.comboBoxTipoDoc.Name = "comboBoxTipoDoc";
            this.comboBoxTipoDoc.Size = new System.Drawing.Size(280, 24);
            this.comboBoxTipoDoc.TabIndex = 1;
            // 
            // clientesTableAdapter
            // 
            this.clientesTableAdapter.ClearBeforeFill = true;
            // 
            // ListadoClientesMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxApellido);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNroDoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxTipoDoc);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ListadoClientesMod";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Hotel 2018";
            this.Load += new System.EventHandler(this.ListadoClientesMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2018DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNroDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTipoDoc;
        private GD1C2018DataSet gD1C2018DataSet;
        private System.Windows.Forms.BindingSource clientesBindingSource;
        private GD1C2018DataSetTableAdapters.ClientesTableAdapter clientesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn clidocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clidocidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clinombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliapellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn climailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clinacionalidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clifechanacDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clihabilitadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clicalleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clicallenroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clipisoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clideptoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clidirlocalidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clidirpaisDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clitelefonoDataGridViewTextBoxColumn;
    }
}
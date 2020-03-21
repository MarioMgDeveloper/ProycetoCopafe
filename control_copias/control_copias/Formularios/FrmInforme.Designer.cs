namespace control_copias.Formularios
{
    partial class FrmInforme
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbxFotocopiadoras = new System.Windows.Forms.ComboBox();
            this.cbxUsuarios = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxRegistro = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkActFin = new System.Windows.Forms.CheckBox();
            this.chkActInicio = new System.Windows.Forms.CheckBox();
            this.FechaFin = new System.Windows.Forms.DateTimePicker();
            this.FechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExportar = new FontAwesome.Sharp.IconButton();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.grdResultados = new System.Windows.Forms.DataGridView();
            this.btnContador = new FontAwesome.Sharp.IconButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 61;
            this.label2.Text = "Fotocopiadora:";
            // 
            // cbxFotocopiadoras
            // 
            this.cbxFotocopiadoras.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxFotocopiadoras.FormattingEnabled = true;
            this.cbxFotocopiadoras.Location = new System.Drawing.Point(141, 9);
            this.cbxFotocopiadoras.Name = "cbxFotocopiadoras";
            this.cbxFotocopiadoras.Size = new System.Drawing.Size(297, 21);
            this.cbxFotocopiadoras.TabIndex = 62;
            this.cbxFotocopiadoras.SelectedIndexChanged += new System.EventHandler(this.cbxFotocopiadoras_SelectedIndexChanged);
            // 
            // cbxUsuarios
            // 
            this.cbxUsuarios.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxUsuarios.FormattingEnabled = true;
            this.cbxUsuarios.Location = new System.Drawing.Point(141, 36);
            this.cbxUsuarios.Name = "cbxUsuarios";
            this.cbxUsuarios.Size = new System.Drawing.Size(297, 21);
            this.cbxUsuarios.TabIndex = 64;
            this.cbxUsuarios.SelectedIndexChanged += new System.EventHandler(this.cbxUsuarios_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 63;
            this.label1.Text = "Usuarios:";
            // 
            // cbxRegistro
            // 
            this.cbxRegistro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxRegistro.FormattingEnabled = true;
            this.cbxRegistro.Location = new System.Drawing.Point(141, 63);
            this.cbxRegistro.Name = "cbxRegistro";
            this.cbxRegistro.Size = new System.Drawing.Size(297, 21);
            this.cbxRegistro.TabIndex = 66;
            this.cbxRegistro.SelectedIndexChanged += new System.EventHandler(this.cbxRegistro_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 65;
            this.label3.Text = "Tipo registro:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.chkActFin);
            this.groupBox1.Controls.Add(this.chkActInicio);
            this.groupBox1.Controls.Add(this.FechaFin);
            this.groupBox1.Controls.Add(this.FechaInicio);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(601, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 82);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rango de fechas";
            // 
            // chkActFin
            // 
            this.chkActFin.AutoSize = true;
            this.chkActFin.Location = new System.Drawing.Point(382, 54);
            this.chkActFin.Name = "chkActFin";
            this.chkActFin.Size = new System.Drawing.Size(15, 14);
            this.chkActFin.TabIndex = 73;
            this.chkActFin.UseVisualStyleBackColor = true;
            this.chkActFin.CheckedChanged += new System.EventHandler(this.chkActFin_CheckedChanged);
            // 
            // chkActInicio
            // 
            this.chkActInicio.AutoSize = true;
            this.chkActInicio.Location = new System.Drawing.Point(382, 19);
            this.chkActInicio.Name = "chkActInicio";
            this.chkActInicio.Size = new System.Drawing.Size(15, 14);
            this.chkActInicio.TabIndex = 72;
            this.chkActInicio.UseVisualStyleBackColor = true;
            this.chkActInicio.CheckedChanged += new System.EventHandler(this.chkActInicio_CheckedChanged);
            // 
            // FechaFin
            // 
            this.FechaFin.Enabled = false;
            this.FechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaFin.Location = new System.Drawing.Point(134, 49);
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.Size = new System.Drawing.Size(228, 22);
            this.FechaFin.TabIndex = 71;
            this.FechaFin.ValueChanged += new System.EventHandler(this.FechaFin_ValueChanged);
            // 
            // FechaInicio
            // 
            this.FechaInicio.Enabled = false;
            this.FechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaInicio.Location = new System.Drawing.Point(134, 16);
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.Size = new System.Drawing.Size(228, 22);
            this.FechaInicio.TabIndex = 70;
            this.FechaInicio.ValueChanged += new System.EventHandler(this.FechaInicio_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(18, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 69;
            this.label5.Text = "Fecha fin:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(18, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 68;
            this.label4.Text = "Fecha inicio:";
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnExportar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.btnExportar.IconColor = System.Drawing.Color.Green;
            this.btnExportar.IconSize = 50;
            this.btnExportar.Location = new System.Drawing.Point(445, 121);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Rotation = 0D;
            this.btnExportar.Size = new System.Drawing.Size(147, 52);
            this.btnExportar.TabIndex = 69;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnBuscar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscar.IconColor = System.Drawing.Color.RoyalBlue;
            this.btnBuscar.IconSize = 50;
            this.btnBuscar.Location = new System.Drawing.Point(293, 121);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Rotation = 0D;
            this.btnBuscar.Size = new System.Drawing.Size(135, 52);
            this.btnBuscar.TabIndex = 68;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnLimpiar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiar.IconColor = System.Drawing.Color.OrangeRed;
            this.btnLimpiar.IconSize = 50;
            this.btnLimpiar.Location = new System.Drawing.Point(601, 120);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Rotation = 0D;
            this.btnLimpiar.Size = new System.Drawing.Size(135, 52);
            this.btnLimpiar.TabIndex = 70;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // grdResultados
            // 
            this.grdResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.grdResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResultados.Location = new System.Drawing.Point(16, 207);
            this.grdResultados.Name = "grdResultados";
            this.grdResultados.ReadOnly = true;
            this.grdResultados.Size = new System.Drawing.Size(1007, 353);
            this.grdResultados.TabIndex = 71;
            // 
            // btnContador
            // 
            this.btnContador.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnContador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContador.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnContador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContador.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnContador.IconColor = System.Drawing.Color.Black;
            this.btnContador.IconSize = 16;
            this.btnContador.Location = new System.Drawing.Point(445, 9);
            this.btnContador.Name = "btnContador";
            this.btnContador.Rotation = 0D;
            this.btnContador.Size = new System.Drawing.Size(147, 75);
            this.btnContador.TabIndex = 72;
            this.btnContador.UseVisualStyleBackColor = true;
            // 
            // FrmInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1035, 572);
            this.Controls.Add(this.btnContador);
            this.Controls.Add(this.grdResultados);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbxRegistro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxUsuarios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxFotocopiadoras);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInforme";
            this.Text = "FrmInforme";
            this.Load += new System.EventHandler(this.FrmInforme_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxFotocopiadoras;
        private System.Windows.Forms.ComboBox cbxUsuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxRegistro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkActFin;
        private System.Windows.Forms.CheckBox chkActInicio;
        private System.Windows.Forms.DateTimePicker FechaFin;
        private System.Windows.Forms.DateTimePicker FechaInicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btnExportar;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private System.Windows.Forms.DataGridView grdResultados;
        private FontAwesome.Sharp.IconButton btnContador;
    }
}
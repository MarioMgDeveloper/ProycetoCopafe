namespace control_copias.Formularios
{
    partial class FrmFotocopiadoras
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
            this.PanelClave = new System.Windows.Forms.Panel();
            this.BtnOkClave = new FontAwesome.Sharp.IconButton();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelControles = new System.Windows.Forms.Panel();
            this.grdFotocopiadoras = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContador = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelClave.SuspendLayout();
            this.PanelControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFotocopiadoras)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelClave
            // 
            this.PanelClave.Controls.Add(this.BtnOkClave);
            this.PanelClave.Controls.Add(this.txtClave);
            this.PanelClave.Controls.Add(this.label1);
            this.PanelClave.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelClave.Location = new System.Drawing.Point(0, 0);
            this.PanelClave.Name = "PanelClave";
            this.PanelClave.Size = new System.Drawing.Size(1000, 40);
            this.PanelClave.TabIndex = 0;
            // 
            // BtnOkClave
            // 
            this.BtnOkClave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnOkClave.BackColor = System.Drawing.Color.Transparent;
            this.BtnOkClave.FlatAppearance.BorderSize = 0;
            this.BtnOkClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOkClave.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnOkClave.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleRight;
            this.BtnOkClave.IconColor = System.Drawing.Color.RoyalBlue;
            this.BtnOkClave.IconSize = 25;
            this.BtnOkClave.Location = new System.Drawing.Point(672, 11);
            this.BtnOkClave.Name = "BtnOkClave";
            this.BtnOkClave.Rotation = 0D;
            this.BtnOkClave.Size = new System.Drawing.Size(40, 23);
            this.BtnOkClave.TabIndex = 2;
            this.BtnOkClave.UseVisualStyleBackColor = false;
            this.BtnOkClave.Click += new System.EventHandler(this.BtnOkClave_Click);
            // 
            // txtClave
            // 
            this.txtClave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtClave.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(412, 11);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(254, 23);
            this.txtClave.TabIndex = 1;
            this.txtClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClave_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(290, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clave:";
            // 
            // PanelControles
            // 
            this.PanelControles.Controls.Add(this.grdFotocopiadoras);
            this.PanelControles.Controls.Add(this.btnCancelar);
            this.PanelControles.Controls.Add(this.btnGuardar);
            this.PanelControles.Controls.Add(this.txtDescripcion);
            this.PanelControles.Controls.Add(this.label4);
            this.PanelControles.Controls.Add(this.txtContador);
            this.PanelControles.Controls.Add(this.label3);
            this.PanelControles.Controls.Add(this.txtNombre);
            this.PanelControles.Controls.Add(this.label2);
            this.PanelControles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControles.Location = new System.Drawing.Point(0, 40);
            this.PanelControles.Name = "PanelControles";
            this.PanelControles.Size = new System.Drawing.Size(1000, 560);
            this.PanelControles.TabIndex = 1;
            this.PanelControles.Visible = false;
            // 
            // grdFotocopiadoras
            // 
            this.grdFotocopiadoras.AllowUserToAddRows = false;
            this.grdFotocopiadoras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.grdFotocopiadoras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdFotocopiadoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFotocopiadoras.Location = new System.Drawing.Point(56, 205);
            this.grdFotocopiadoras.Name = "grdFotocopiadoras";
            this.grdFotocopiadoras.ReadOnly = true;
            this.grdFotocopiadoras.Size = new System.Drawing.Size(888, 343);
            this.grdFotocopiadoras.TabIndex = 9;
            this.grdFotocopiadoras.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFotocopiadoras_CellDoubleClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCancelar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnCancelar.IconColor = System.Drawing.Color.Red;
            this.btnCancelar.IconSize = 50;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(563, 145);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Rotation = 0D;
            this.btnCancelar.Size = new System.Drawing.Size(149, 54);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnGuardar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnGuardar.IconColor = System.Drawing.Color.ForestGreen;
            this.btnGuardar.IconSize = 50;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(378, 145);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Rotation = 0D;
            this.btnGuardar.Size = new System.Drawing.Size(149, 54);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(354, 77);
            this.txtDescripcion.MaxLength = 150;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(377, 62);
            this.txtDescripcion.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(206, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Descripción:";
            // 
            // txtContador
            // 
            this.txtContador.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContador.Location = new System.Drawing.Point(354, 45);
            this.txtContador.Name = "txtContador";
            this.txtContador.Size = new System.Drawing.Size(377, 26);
            this.txtContador.TabIndex = 4;
            this.txtContador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContador_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(206, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Contador:";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(354, 13);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(377, 26);
            this.txtNombre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(206, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // FrmFotocopiadoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.PanelControles);
            this.Controls.Add(this.PanelClave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmFotocopiadoras";
            this.Text = "FrmFotocopiadoras";
            this.Load += new System.EventHandler(this.FrmFotocopiadoras_Load);
            this.PanelClave.ResumeLayout(false);
            this.PanelClave.PerformLayout();
            this.PanelControles.ResumeLayout(false);
            this.PanelControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFotocopiadoras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelClave;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton BtnOkClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Panel PanelControles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView grdFotocopiadoras;
    }
}
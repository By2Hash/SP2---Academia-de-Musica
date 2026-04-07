namespace pryPereiroAcademiaDeMusicaSP2
{
    partial class frmTema
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
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.cmbCantantes = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblTema = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblLink = new System.Windows.Forms.Label();
            this.lblCantante = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(189, 46);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(121, 26);
            this.txtID.TabIndex = 0;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(189, 111);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(342, 26);
            this.txtNombre.TabIndex = 1;
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(189, 186);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(342, 26);
            this.txtLink.TabIndex = 2;
            // 
            // cmbCantantes
            // 
            this.cmbCantantes.FormattingEnabled = true;
            this.cmbCantantes.Location = new System.Drawing.Point(189, 255);
            this.cmbCantantes.Name = "cmbCantantes";
            this.cmbCantantes.Size = new System.Drawing.Size(121, 28);
            this.cmbCantantes.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(586, 47);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(144, 58);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(586, 147);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(144, 58);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblTema
            // 
            this.lblTema.AutoSize = true;
            this.lblTema.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTema.Location = new System.Drawing.Point(37, 47);
            this.lblTema.Name = "lblTema";
            this.lblTema.Size = new System.Drawing.Size(87, 25);
            this.lblTema.TabIndex = 6;
            this.lblTema.Text = "ID Tema";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(37, 117);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(81, 25);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "Nombre";
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLink.Location = new System.Drawing.Point(37, 185);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(48, 25);
            this.lblLink.TabIndex = 8;
            this.lblLink.Text = "Link";
            // 
            // lblCantante
            // 
            this.lblCantante.AutoSize = true;
            this.lblCantante.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantante.Location = new System.Drawing.Point(37, 255);
            this.lblCantante.Name = "lblCantante";
            this.lblCantante.Size = new System.Drawing.Size(102, 25);
            this.lblCantante.TabIndex = 9;
            this.lblCantante.Text = "Cantantes";
            // 
            // frmTema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 313);
            this.Controls.Add(this.lblCantante);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTema);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbCantantes);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtID);
            this.Name = "frmTema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tema";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.ComboBox cmbCantantes;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblTema;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblLink;
        private System.Windows.Forms.Label lblCantante;
    }
}
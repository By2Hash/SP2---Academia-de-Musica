namespace pryPereiroAcademiaDeMusicaSP2
{
    partial class frmVideo
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
            this.btnVerVideo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblCantante = new System.Windows.Forms.Label();
            this.lblTema = new System.Windows.Forms.Label();
            this.lblLink = new System.Windows.Forms.Label();
            this.cmbCantante = new System.Windows.Forms.ComboBox();
            this.cmbTemas = new System.Windows.Forms.ComboBox();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.grpBrowser = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // btnVerVideo
            // 
            this.btnVerVideo.Location = new System.Drawing.Point(651, 30);
            this.btnVerVideo.Name = "btnVerVideo";
            this.btnVerVideo.Size = new System.Drawing.Size(124, 52);
            this.btnVerVideo.TabIndex = 0;
            this.btnVerVideo.Text = "&Ver Video";
            this.btnVerVideo.UseVisualStyleBackColor = true;
            this.btnVerVideo.Click += new System.EventHandler(this.btnVerVideo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(651, 111);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(124, 52);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblCantante
            // 
            this.lblCantante.AutoSize = true;
            this.lblCantante.Location = new System.Drawing.Point(15, 35);
            this.lblCantante.Name = "lblCantante";
            this.lblCantante.Size = new System.Drawing.Size(75, 20);
            this.lblCantante.TabIndex = 2;
            this.lblCantante.Text = "Cantante";
            // 
            // lblTema
            // 
            this.lblTema.AutoSize = true;
            this.lblTema.Location = new System.Drawing.Point(15, 84);
            this.lblTema.Name = "lblTema";
            this.lblTema.Size = new System.Drawing.Size(49, 20);
            this.lblTema.TabIndex = 3;
            this.lblTema.Text = "Tema";
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Location = new System.Drawing.Point(15, 137);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(38, 20);
            this.lblLink.TabIndex = 4;
            this.lblLink.Text = "Link";
            // 
            // cmbCantante
            // 
            this.cmbCantante.FormattingEnabled = true;
            this.cmbCantante.Location = new System.Drawing.Point(132, 35);
            this.cmbCantante.Name = "cmbCantante";
            this.cmbCantante.Size = new System.Drawing.Size(197, 28);
            this.cmbCantante.TabIndex = 5;
            this.cmbCantante.SelectedIndexChanged += new System.EventHandler(this.cmbCantante_SelectedIndexChanged);
            // 
            // cmbTemas
            // 
            this.cmbTemas.FormattingEnabled = true;
            this.cmbTemas.Location = new System.Drawing.Point(132, 83);
            this.cmbTemas.Name = "cmbTemas";
            this.cmbTemas.Size = new System.Drawing.Size(352, 28);
            this.cmbTemas.TabIndex = 6;
            this.cmbTemas.SelectedIndexChanged += new System.EventHandler(this.cmbTemas_SelectedIndexChanged);
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(132, 137);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(479, 26);
            this.txtLink.TabIndex = 7;
            // 
            // grpBrowser
            // 
            this.grpBrowser.Location = new System.Drawing.Point(19, 192);
            this.grpBrowser.Name = "grpBrowser";
            this.grpBrowser.Size = new System.Drawing.Size(769, 303);
            this.grpBrowser.TabIndex = 8;
            this.grpBrowser.TabStop = false;
            // 
            // frmVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 507);
            this.Controls.Add(this.grpBrowser);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.cmbTemas);
            this.Controls.Add(this.cmbCantante);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.lblTema);
            this.Controls.Add(this.lblCantante);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnVerVideo);
            this.Name = "frmVideo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver Video";
            this.Load += new System.EventHandler(this.frmVideo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVerVideo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblCantante;
        private System.Windows.Forms.Label lblTema;
        private System.Windows.Forms.Label lblLink;
        private System.Windows.Forms.ComboBox cmbCantante;
        private System.Windows.Forms.ComboBox cmbTemas;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.GroupBox grpBrowser;
    }
}
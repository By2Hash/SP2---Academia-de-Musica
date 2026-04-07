namespace pryPereiroAcademiaDeMusicaSP2
{
    partial class frmMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnsMenu = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoCantanteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoTemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verVideoTemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsMenu
            // 
            this.mnsMenu.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.mnsMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnsMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.mnsMenu.Location = new System.Drawing.Point(0, 0);
            this.mnsMenu.Name = "mnsMenu";
            this.mnsMenu.Size = new System.Drawing.Size(833, 33);
            this.mnsMenu.TabIndex = 0;
            this.mnsMenu.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoCantanteToolStripMenuItem,
            this.nuevoTemaToolStripMenuItem,
            this.verVideoTemaToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(103, 29);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // nuevoCantanteToolStripMenuItem
            // 
            this.nuevoCantanteToolStripMenuItem.Name = "nuevoCantanteToolStripMenuItem";
            this.nuevoCantanteToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.nuevoCantanteToolStripMenuItem.Text = "Nuevo Cantante";
            this.nuevoCantanteToolStripMenuItem.Click += new System.EventHandler(this.nuevoCantanteToolStripMenuItem_Click);
            // 
            // nuevoTemaToolStripMenuItem
            // 
            this.nuevoTemaToolStripMenuItem.Name = "nuevoTemaToolStripMenuItem";
            this.nuevoTemaToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.nuevoTemaToolStripMenuItem.Text = "Nuevo Tema";
            this.nuevoTemaToolStripMenuItem.Click += new System.EventHandler(this.nuevoTemaToolStripMenuItem_Click);
            // 
            // verVideoTemaToolStripMenuItem
            // 
            this.verVideoTemaToolStripMenuItem.Name = "verVideoTemaToolStripMenuItem";
            this.verVideoTemaToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.verVideoTemaToolStripMenuItem.Text = "Ver Video-Tema";
            this.verVideoTemaToolStripMenuItem.Click += new System.EventHandler(this.verVideoTemaToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 450);
            this.ControlBox = false;
            this.Controls.Add(this.mnsMenu);
            this.MainMenuStrip = this.mnsMenu;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Academia de Música";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.mnsMenu.ResumeLayout(false);
            this.mnsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMenu;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoCantanteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoTemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verVideoTemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}


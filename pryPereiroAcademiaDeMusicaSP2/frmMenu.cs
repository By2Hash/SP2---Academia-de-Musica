using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryPereiroAcademiaDeMusicaSP2
{
    public partial class frmMenu : Form
    {
        CConexion conexion = new CConexion();
       

        public frmMenu()
        {
            InitializeComponent();
            if (!conexion.Conectar("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
             Application.StartupPath + "\\Academia.mdb"))
            {
                MessageBox.Show(conexion.ObtenerError());
                
            }
            else
            {
                MessageBox.Show("Conexión exitosa con la base de datos");
            }
        }
        

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conexion.Desconectar();
            Close();
        }

        private void nuevoCantanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCantante frm = new frmCantante();
            frm.ShowDialog();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void nuevoTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTema frm = new frmTema();
            frm.ShowDialog();
        }

        private void verVideoTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVideo frm = new frmVideo();
            frm.ShowDialog();
        }
    }
}

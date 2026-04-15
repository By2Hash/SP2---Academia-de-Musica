using Gecko;
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
    
    public partial class frmVideo : Form
    {
        private CConexion conexion;
        private CCantantes cantante;
        private CTema tema;
        private GeckoWebBrowser geckoWebBrowser;
        public frmVideo()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // cerrar la conexión con la base de datos
            conexion.Desconectar();
            // controlar el estado del webBrowser
            if (!(geckoWebBrowser is null)) // si no es nulo
            {
                // detener la navegación
                geckoWebBrowser.Stop();
                // liberar los recursos del objeto
                geckoWebBrowser.Dispose();
            }
            Close();
        }

        private void frmVideo_Load(object sender, EventArgs e)
        {

            conexion = new CConexion(); // crear la conexión
            if (!conexion.Conectar("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
            Application.StartupPath + "\\Academia.mdb"))
            {
                MessageBox.Show(conexion.ObtenerError());
                Close();
            }
            else
            {
                // crear el objeto tema
                tema = new CTema(conexion.CNN, conexion.DS);
                // crear el objeto cantante y cargar el combo con sus datos
                cantante = new CCantantes(conexion.CNN, conexion.DS);
                cmbCantante.DisplayMember = "Nombre";
                cmbCantante.ValueMember = "IdCantante";
                cmbCantante.DataSource = cantante.dtCantantes;
            }

        }

        private void cmbCantante_SelectedIndexChanged(object sender, EventArgs e)
        {
            long IdCantante = long.Parse(cmbCantante.SelectedValue.ToString());
            cmbTemas.DisplayMember = "Nombre";
            cmbTemas.ValueMember = "IdTema";
            cmbTemas.DataSource = tema.ObtenerTemasDeCantantes(IdCantante);

        }

        private void cmbTemas_SelectedIndexChanged(object sender, EventArgs e)
        {
            long IdCantante = long.Parse(cmbCantante.SelectedValue.ToString());
            long IdTema = long.Parse(cmbTemas.SelectedValue.ToString());
            txtLink.Text = tema.ObtenerLinkTemasCantantes(IdTema, IdCantante);

        }

        private void btnVerVideo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLink.Text))
                return;

            string firefoxPath = System.IO.Path.Combine(Application.StartupPath, "Firefox");
            string xulFile = System.IO.Path.Combine(firefoxPath, "xul.dll");

            if (!System.IO.Directory.Exists(firefoxPath) || !System.IO.File.Exists(xulFile))
            {
                MessageBox.Show("No se encontró 'xul.dll' en:\n" + firefoxPath +
                    "\n\nColoca la carpeta completa del runtime de Gecko (Firefox/XULRunner) ahí, que contenga xul.dll.");
                return;
            }

            try
            {
                Xpcom.Initialize(firefoxPath);
            }
            catch (System.DllNotFoundException dllEx)
            {
                MessageBox.Show("DLL no encontrada: " + dllEx.Message + "\nVerifica que 'xul.dll' y sus dependencias existan y corresponda la arquitectura.");
                return;
            }
            catch (System.BadImageFormatException badEx)
            {
                MessageBox.Show("Incompatibilidad de arquitectura (x86/x64): " + badEx.Message + "\nCompila la app para la misma arquitectura que el runtime de Firefox.");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inicializando Gecko: " + ex.Message);
                return;
            }

            // crear el control webBrowser
            geckoWebBrowser?.Dispose();
            geckoWebBrowser = new GeckoWebBrowser { Dock = DockStyle.Fill };
            grpBrowser.Controls.Clear();
            grpBrowser.Controls.Add(geckoWebBrowser);
            geckoWebBrowser.Navigate(txtLink.Text);
        }
    }
}

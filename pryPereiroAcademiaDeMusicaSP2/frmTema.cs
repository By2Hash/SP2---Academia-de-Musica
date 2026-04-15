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
    public partial class frmTema : Form
    {
        private CConexion conexion;
        private CCantantes cantante;
        private CTema tema;
        public frmTema()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            conexion.Desconectar();
            Close();
        }

        private void frmTema_Load(object sender, EventArgs e)
        {
            conexion = new CConexion();
            if (!conexion.Conectar("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
            Application.StartupPath + "\\Academia.mdb"))
            {
                MessageBox.Show(conexion.ObtenerError());
                Close();
            }
            else
            {
                // crear el objeto Cantante y cargar el combo con sus datos
                cantante = new CCantantes(conexion.CNN, conexion.DS);
                cmbCantantes.DisplayMember = "Nombre";
                cmbCantantes.ValueMember = "IdCantante";
                cmbCantantes.DataSource = cantante.dtCantantes;
                // crear el objeto Tema y leer la tabla de Temas
                tema = new CTema(conexion.CNN, conexion.DS);
            }

        }

        private bool ValidarDatos()
        {
            bool resultado = false;
            long Id = 0;
            if (txtID.Text != "" && txtNombre.Text != "" &&
            txtLink.Text != "" && cmbCantantes.SelectedIndex != -1)
            {
                if (long.TryParse(txtID.Text, out Id))
                {
                    if (Id > 0)
                    {
                        resultado = true;
                    }
                }
            }
            return resultado;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            long IdTema = 0;
            string Nombre = "";
            string Link = "";
            long IdCantante = 0;

            if (ValidarDatos())
            {
                try
                {
                    long.TryParse(txtID.Text, out IdTema);
                    Nombre = txtNombre.Text;
                    long.TryParse(cmbCantantes.SelectedValue.ToString(), out IdCantante);
                    Link = txtLink.Text;

                    if (tema.BuscarTema(IdTema, IdCantante) == false)
                    {
                        if (tema.NuevoTema(IdTema, IdCantante, Nombre, Link))
                        {
                            txtID.Text = "";
                            txtNombre.Text = "";
                            txtLink.Text = "";
                        }
                        else
                        {
                            // Mostrar el error real devuelto por CTema para depurar por qué falló el guardado
                            MessageBox.Show("Error grabando el tema: " + tema.ObtenerError());
                        }
                    }
                    else
                    {
                        MessageBox.Show("El tema ya existe para ese cantante");
                    }
                }
                catch (Exception ex)
                {
                    // Capturar excepciones inesperadas y mostrarlas para depuración
                    MessageBox.Show("Excepción al intentar guardar: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.");
            }
        }
    }
}

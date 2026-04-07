using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace pryPereiroAcademiaDeMusicaSP2
{
    internal class CTema
    {
        public DataTable dtTemas;
        private OleDbDataAdapter da;
        private string ERROR = "";

        public CTema(OleDbConnection cnn, DataSet ds)
        {
            ERROR = "";
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.TableDirect;
                cmd.CommandText = "Temas";

                da = new OleDbDataAdapter(cmd);
                da.Fill(ds, "Temas");
                dtTemas = ds.Tables["Temas"];
                DataColumn[] dc = new DataColumn[2];
                dc[0] = ds.Tables["Temas"].Columns["IdTema"];
                dc[1] = ds.Tables["Temas"].Columns["IdCantante"];
                ds.Tables["Temas"].PrimaryKey = dc;

                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
            }
            catch (Exception ex)
            {
                ERROR = ex.Message;
            }
        }

        public bool NuevoTema(long IdTema, long IdCantente, string Nombre, string Link)
        {
            ERROR = "";
            bool resultado = false;
            try
            {
                DataRow nuevo = dtTemas.NewRow();
                nuevo["IdTema"] = IdTema;
                nuevo["IdCantante"] = IdCantente;
                nuevo["Nombre"] = Nombre;
                nuevo["Link"] = Link;
                dtTemas.Rows.Add(nuevo);
                da.Update(dtTemas);
                resultado = true;
            }
            catch (Exception ex)
            {
                ERROR = ex.Message;
            }
            return resultado;
        }

        public bool BuscarTema(long IdTema, long IdCantante)
        {
            ERROR = "";
            bool resultado = false;
            try
            {
                object[] valor = new object[2];
                valor[0] = IdTema;
                valor[1] = IdCantante;

                DataRow dr = dtTemas.Rows.Find(valor);
                if (!(dr is null))
                {
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                ERROR = ex.Message;
            }
            return resultado;
        }


        public DataTable ObtenerTemasDeCantantes(long IdCantantes)
        {
            ERROR = "";
            DataTable dtTemasCantantes = null;
            try
            {
                dtTemasCantantes = dtTemas.Clone();
                foreach (DataRow dr in dtTemas.Rows)
                {
                    if (IdCantantes == long.Parse(dr["IdCantantes"].ToString()))
                    {
                        dtTemasCantantes.ImportRow(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                ERROR = ex.Message;
            }
            return dtTemasCantantes;
        }

        public string ObtenerLinkTemasCantantes(long IdTema, long IdCantante)
        {
            ERROR = "";
            string link = "";
            try
            {
                object[] valor = new object[2];
                valor[0] = IdTema;
                valor[1] = IdCantante;
                DataRow dr = dtTemas.Rows.Find(valor);
                if (!(dr is null))
                {
                    link = dr["Link"].ToString();
                }
            }
            catch (Exception ex)
            {
                ERROR = ex.Message;

            }
            return link;
        }

        public string ObtenerError()
        {
            return ERROR;
        }
    }
}
    


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace pryPereiroAcademiaDeMusicaSP2
{
    internal class CCantantes
    {
        public DataTable dtCantantes;
        private OleDbDataAdapter da;
        private string ERROR = "";

        public CCantantes(OleDbConnection cnn, DataSet ds)
        {
            ERROR = "";

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.TableDirect;
                cmd.CommandText = "Cantantes";
                da = new OleDbDataAdapter(cmd);
                da.Fill(ds, "Cantantes");
                dtCantantes = ds.Tables["Cantantes"];
                DataColumn[] dc = new DataColumn[1];
                dc[0] = ds.Tables["Cantantes"].Columns["IdCantante"];
                ds.Tables["Cantantes"].PrimaryKey = dc;
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
            }
            catch (Exception ex)
            {
                ERROR = ex.Message;

            }
        }


        public bool NuevoCantante(long Id, string Nombre)
        {
            ERROR = "";
            bool resultado = false;

            try
            {
                DataRow nuevo = dtCantantes.NewRow();
                nuevo["IdCantante"] = Id;
                nuevo["Nombre"] = Nombre;
                dtCantantes.Rows.Add(nuevo);
                da.Update(dtCantantes);
                resultado = true;
            }
            catch (Exception ex)
            {
                ERROR = ex.Message;
            }
            return resultado;
        }

        public bool BuscarCantante(long Id)
        {
            ERROR = "";
            bool resultado = false;
            try
            {
                object[] valor = new object[1];
                valor[0] = Id;
                DataRow dr = dtCantantes.Rows.Find(valor);
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

        public string ObtenerError()
        {
            return ERROR;
        }
    }
}

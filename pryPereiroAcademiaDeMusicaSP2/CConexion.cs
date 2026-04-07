using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace pryPereiroAcademiaDeMusicaSP2
{
    internal class CConexion
    {
        public OleDbConnection CNN;
        public DataSet DS;

        private string ERROR = "";
        public CConexion()
        {
            CNN = null;
            DS = null;
            ERROR = "";
        }
    

        public bool Conectar(string Cadena)
        {
            bool resultado = false;
            CNN = new OleDbConnection();
            CNN.ConnectionString = Cadena;
            try
            {
                CNN.Open();
                DS = new DataSet();
                resultado = true;
            }
            catch (Exception ex)
            {
                ERROR = ex.Message;
            }
            return resultado;
        }

        public bool Desconectar()
        {
            bool resultado = false;
            try
            {
                if (CNN.State == ConnectionState.Open)
                {
                    CNN.Close();
                    resultado = true;
                }
            }
            catch (System.Exception ex)
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

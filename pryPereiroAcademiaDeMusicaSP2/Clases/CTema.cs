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

        // Nombres de columna resueltos dinámicamente
        private string colIdTema = null;
        private string colIdCantante = null;
        private string colNombre = null;
        private string colLink = null;

        public CTema(OleDbConnection cnn, DataSet ds)
        {
            ERROR = "";
            try
            {
                // Usar SELECT * para que OleDbCommandBuilder pueda generar comandos
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Temas", cnn);
                cmd.CommandType = CommandType.Text;

                da = new OleDbDataAdapter(cmd);
                da.Fill(ds, "Temas");
                dtTemas = ds.Tables["Temas"];

                // Intentar resolver nombres de columnas de forma tolerante
                colIdTema = ResolveColumnNameTolerant(dtTemas, new[] { "IdTema", "IDTema", "Id_Tema", "IdTemas", "IdTemaId", "TemaId" });
                colIdCantante = ResolveColumnNameTolerant(dtTemas, new[] { "IdCantante", "IdCantantes", "IDCantante", "Id_Cantante", "CantanteId", "Id_Cantantes" });
                colNombre = ResolveColumnNameTolerant(dtTemas, new[] { "Nombre", "nombre", "Titulo", "NombreTema", "TituloTema" });
                colLink = ResolveColumnNameTolerant(dtTemas, new[] { "Link", "URL", "Enlace", "LinkTema", "VideoLink" });

                // Si no se encontró IdCantante intentar heurística: buscar cualquier columna numérica distinta de IdTema
                if (colIdCantante == null)
                {
                    colIdCantante = FindNumericColumnFallback(dtTemas, exclude: colIdTema);
                }

                // Si no se encontró colNombre o colLink, tratar de asignar por posición lógica
                if (colNombre == null || colLink == null)
                {
                    TryAssignByCommonPositions(dtTemas);
                }

                // Si encontramos ambas columnas de clave, establecer PrimaryKey para usar Rows.Find
                if (colIdTema != null && colIdCantante != null)
                {
                    DataColumn[] dc = new DataColumn[2];
                    dc[0] = dtTemas.Columns[colIdTema];
                    dc[1] = dtTemas.Columns[colIdCantante];
                    dtTemas.PrimaryKey = dc;
                }

                // Si alguna columna crítica falta, guardar mensaje descriptivo
                if (colIdTema == null || colIdCantante == null || colNombre == null || colLink == null)
                {
                    var cols = string.Join(", ", dtTemas.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
                    ERROR = "Columnas detectadas en tabla Temas: " + cols + ". " +
                            "Columnas mapeadas -> IdTema: " + (colIdTema ?? "NO") +
                            ", IdCantante: " + (colIdCantante ?? "NO") +
                            ", Nombre: " + (colNombre ?? "NO") +
                            ", Link: " + (colLink ?? "NO") + ". ";
                    // Mostrar diálogo para que el desarrollador vea la lista de columnas reales
                    MessageBox.Show(ERROR, "CTema - columnas Temas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
            }
            catch (Exception ex)
            {
                ERROR = ex.Message;
            }
        }

        // Normaliza un nombre (quita no alfanuméricos y pasa a minúsculas)
        private static string NormalizeName(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            var chars = s.Where(char.IsLetterOrDigit).ToArray();
            return new string(chars).ToLowerInvariant();
        }

        // Busca la primera columna que coincida de forma tolerante con los candidatos
        private string ResolveColumnNameTolerant(DataTable table, string[] candidates)
        {
            if (table == null) return null;
            var normalizedCandidates = candidates.Select(NormalizeName).ToArray();

            // Primera pasada: coincidencia exacta normalizada
            foreach (DataColumn col in table.Columns)
            {
                var colNorm = NormalizeName(col.ColumnName);
                for (int i = 0; i < normalizedCandidates.Length; i++)
                {
                    if (colNorm == normalizedCandidates[i])
                        return col.ColumnName;
                }
            }

            // Segunda pasada: contiene / contained (por si la columna tiene prefijos/sufijos)
            foreach (DataColumn col in table.Columns)
            {
                var colNorm = NormalizeName(col.ColumnName);
                foreach (var cand in normalizedCandidates)
                {
                    if (colNorm.Contains(cand) || cand.Contains(colNorm))
                        return col.ColumnName;
                }
            }

            return null;
        }

        // Heurística: buscar columna numérica (int/long/decimal) que no sea la excluida
        private string FindNumericColumnFallback(DataTable table, string exclude)
        {
            foreach (DataColumn col in table.Columns)
            {
                if (string.Equals(col.ColumnName, exclude, StringComparison.OrdinalIgnoreCase)) continue;
                var t = col.DataType;
                if (t == typeof(int) || t == typeof(long) || t == typeof(short) || t == typeof(decimal))
                {
                    return col.ColumnName;
                }
            }
            return null;
        }

        // Intentar asignar Nombre/Link por posiciones comunes si no fueron detectadas
        private void TryAssignByCommonPositions(DataTable table)
        {
            // casos comunes: [IdTema, Nombre, Link, IdCantante] o [IdTema, IdCantante, Nombre, Link]
            if (table.Columns.Count >= 3)
            {
                var col0 = table.Columns[0].ColumnName;
                var col1 = table.Columns[1].ColumnName;
                var col2 = table.Columns[2].ColumnName;
                var col3 = table.Columns.Count >= 4 ? table.Columns[3].ColumnName : null;

                if (colNombre == null)
                {
                    // si columna 1 o 2 parece textual, asignarla a Nombre
                    if (table.Columns[1].DataType == typeof(string)) colNombre = col1;
                    else if (table.Columns[2].DataType == typeof(string)) colNombre = col2;
                }

                if (colLink == null)
                {
                    // asignar a la siguiente columna string disponible que no sea Nombre
                    if (col3 != null && table.Columns[3].DataType == typeof(string) && col3 != colNombre) colLink = col3;
                    else if (table.Columns[2].DataType == typeof(string) && table.Columns[2].ColumnName != colNombre) colLink = col2;
                }
            }
        }

        public bool NuevoTema(long IdTema, long IdCantente, string Nombre, string Link)
        {
            ERROR = "";
            bool resultado = false;
            try
            {
                if (dtTemas == null) throw new Exception("Tabla 'Temas' no cargada.");
                DataRow nuevo = dtTemas.NewRow();

                // Verificar nuevamente antes de asignar
                if (colIdTema == null) throw new Exception("Columna de IdTema no encontrada en la tabla 'Temas'. " + ERROR);
                if (colIdCantante == null) throw new Exception("Columna de IdCantante no encontrada en la tabla 'Temas'. " + ERROR);
                if (colNombre == null) throw new Exception("Columna de Nombre no encontrada en la tabla 'Temas'. " + ERROR);
                if (colLink == null) throw new Exception("Columna de Link no encontrada en la tabla 'Temas'. " + ERROR);

                nuevo[colIdTema] = IdTema;
                nuevo[colIdCantante] = IdCantente;
                nuevo[colNombre] = Nombre;
                nuevo[colLink] = Link;

                dtTemas.Rows.Add(nuevo);
                da.Update(dtTemas);
                resultado = true;
            }
            catch (Exception ex)
            {
                // Guardar mensaje detallado para mostrar en el formulario
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
                if (dtTemas == null) throw new Exception("Tabla 'Temas' no cargada.");

                if (dtTemas.PrimaryKey != null && dtTemas.PrimaryKey.Length >= 2)
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
                else
                {
                    if (colIdTema == null || colIdCantante == null) throw new Exception("No se pueden buscar los campos Id en la tabla 'Temas'. " + ERROR);
                    foreach (DataRow dr in dtTemas.Rows)
                    {
                        long idT = long.Parse(dr[colIdTema].ToString());
                        long idC = long.Parse(dr[colIdCantante].ToString());
                        if (idT == IdTema && idC == IdCantante)
                        {
                            resultado = true;
                            break;
                        }
                    }
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
                if (dtTemas == null) throw new Exception("Tabla 'Temas' no cargada.");
                dtTemasCantantes = dtTemas.Clone();

                if (colIdCantante == null) throw new Exception("Columna de IdCantante no encontrada en la tabla 'Temas'. " + ERROR);

                foreach (DataRow dr in dtTemas.Rows)
                {
                    if (IdCantantes == long.Parse(dr[colIdCantante].ToString()))
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
                if (dtTemas == null) throw new Exception("Tabla 'Temas' no cargada.");
                if (colIdTema == null || colIdCantante == null) throw new Exception("Columnas Id no encontradas en la tabla 'Temas'. " + ERROR);

                object[] valor = new object[2];
                valor[0] = IdTema;
                valor[1] = IdCantante;
                DataRow dr = dtTemas.Rows.Find(valor);
                if (dr is null)
                {
                    foreach (DataRow r in dtTemas.Rows)
                    {
                        if (long.Parse(r[colIdTema].ToString()) == IdTema &&
                            long.Parse(r[colIdCantante].ToString()) == IdCantante)
                        {
                            dr = r;
                            break;
                        }
                    }
                }

                if (!(dr is null))
                {
                    if (colLink == null) throw new Exception("Columna Link no encontrada en la tabla 'Temas'. " + ERROR);
                    link = dr[colLink].ToString();
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


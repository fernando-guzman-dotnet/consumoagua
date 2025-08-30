using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPA.Clases
{
    public class TipoUsuario
    {
        private static readonly Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public static List<TipoUsuario> GetTipoUsuarios()
        {
            DataTable tabla = new DataTable();
            List<TipoUsuario> lista = new List<TipoUsuario>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getTipoUsuarios", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            TipoUsuario tipoUsuario = fila;
                            lista.Add(tipoUsuario);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetTipoUsuarios - " + ex.Message, "Clase TipoUsuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static implicit operator TipoUsuario(DataRow fila)
        {
            TipoUsuario tipoUsuario = new TipoUsuario
            {
                Id = int.Parse(fila["Id"].ToString()),
                Descripcion = fila["Descripcion"].ToString()
            };

            return tipoUsuario;
        }
    }
}


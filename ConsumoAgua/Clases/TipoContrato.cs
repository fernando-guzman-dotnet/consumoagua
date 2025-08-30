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
    public class TipoContrato
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public static List<TipoContrato> GetTiposContrato()
        {
            DataTable tabla = new DataTable();
            List<TipoContrato> lista = new List<TipoContrato>();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("getTiposContrato", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            TipoContrato tipoContrato = fila;
                            lista.Add(tipoContrato);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getTiposContrato - " + ex.Message, "Clase ContratoDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return lista;
        }

        public static implicit operator TipoContrato(DataRow fila)
        {
            TipoContrato tipoContrato = new TipoContrato
            {
                Id = int.Parse(fila["IdTipoContrato"].ToString()),
                Descripcion = fila["Descripcion"].ToString()
            };

            return tipoContrato;
        }
    }
}


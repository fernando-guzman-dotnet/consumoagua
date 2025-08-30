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
    public class Puesto
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public static List<Puesto> GetPuestos()
        {
            DataTable tabla = new DataTable();
            List<Puesto> lista = new List<Puesto>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getPuestos", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Puesto puesto = fila;
                            lista.Add(puesto);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetPuestos - " + ex.Message, "Clase GetPuestos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static implicit operator Puesto(DataRow fila)
        {
            Puesto puesto = new Puesto
            {
                Id = int.Parse(fila["Id"].ToString()),
                Descripcion = fila["Descripcion"].ToString()
            };

            return puesto;
        }
    }
}


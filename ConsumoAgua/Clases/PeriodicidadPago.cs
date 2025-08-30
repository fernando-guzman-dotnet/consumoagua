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
    public class PeriodicidadPago
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public static List<PeriodicidadPago> GetPeriodicidadesPago()
        {
            DataTable tabla = new DataTable();
            List<PeriodicidadPago> lista = new List<PeriodicidadPago>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getPeriodicidadesPago", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            PeriodicidadPago periodicidadPago = fila;
                            lista.Add(periodicidadPago);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetPeriodicidadesPago - " + ex.Message, "Clase PeriodicidadesPago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static implicit operator PeriodicidadPago(DataRow fila)
        {
            PeriodicidadPago periodicidadPago = new PeriodicidadPago();

            periodicidadPago.Id = int.Parse(fila["Id"].ToString());
            periodicidadPago.Descripcion = fila["Descripcion"].ToString();

            return periodicidadPago;
        }
    }
}


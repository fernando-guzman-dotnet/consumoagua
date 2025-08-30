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
    public class ContratoObservacion
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int NoContrato { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }

        public int IdEmpleado => Empleado?.Id ?? 0;
        public string NombreEmpleado => Empleado?.NombreCompleto ?? string.Empty;

        public Empleado Empleado { get; set; }


        public bool Agregar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addContratoObservacion", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NoContrato", this.NoContrato);
                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Comentario", this.Comentario);
                    cmd.Parameters.AddWithValue("@IdEmpleado", this.IdEmpleado);

                    Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase nombreClase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregado;
        }

        public static List<ContratoObservacion> GetContratoObservaciones(int noContrato)
        {
            DataTable tabla = new DataTable();
            List<ContratoObservacion> lista = new List<ContratoObservacion>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getContratoObservaciones", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@NoContrato", noContrato);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            ContratoObservacion contratoObservacion = fila;
                            lista.Add(contratoObservacion);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetContratoObservaciones - " + ex.Message, "Clase ContratoObservacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static implicit operator ContratoObservacion(DataRow fila)
        {
            ContratoObservacion contratoObservacion = new ContratoObservacion
            {
                Id = int.Parse(fila["Id"].ToString()),
                NoContrato = int.Parse(fila["NoContrato"].ToString()),
                Fecha = DateTime.Parse(fila["Fecha"].ToString()),
                Comentario = fila["Comentario"].ToString(),
                Empleado = new Empleado
                {
                    Id = int.Parse(fila["IdEmpleado"].ToString()),
                    Nombre = fila["EmpleadoNombre"].ToString(),
                    ApellidoPaterno = fila["EmpleadoApellidoPaterno"].ToString(),
                    ApellidoMaterno = fila["EmpleadoApellidoMaterno"].ToString()
                }
            };

            return contratoObservacion;
        }
    }
}


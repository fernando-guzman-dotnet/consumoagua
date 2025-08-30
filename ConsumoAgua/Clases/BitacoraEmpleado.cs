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
    public class BitacoraEmpleado
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Descripicon { get; set; }
        public string Modulo { get; set; }
        public DateTime Fecha { get; set; }

        public int Agregar(int idEmpleado, string Descripcion, string Modulo, DateTime Fecha)
        {
            int aux = 0;
            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addLogEmpleado", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdEmp", idEmpleado);
                    cmd.Parameters.AddWithValue("@Desc", Descripcion);
                    cmd.Parameters.AddWithValue("@Modulo", Modulo);
                    cmd.Parameters.AddWithValue("@Fecha", Fecha);

                    aux = int.Parse(cmd.ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EmpleadoLogInsert - " + ex.Message, "Clase Empleados_Log", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return aux;
        }

        public static List<BitacoraEmpleado> Select(int idEmpleado)
        {
            DataTable tabla = new DataTable();
            List<BitacoraEmpleado> registrosBitacoraEmpleado = new List<BitacoraEmpleado>();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("getBitacoraEmpleadoByIdEmpleado", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@IdEmpleado", SqlDbType.Int).Value = idEmpleado;
                    dat.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            BitacoraEmpleado bitaco = new BitacoraEmpleado();
                            bitaco = fila;
                            registrosBitacoraEmpleado.Add(bitaco);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EmpleadoLog_Select - " + ex.Message, "Clase Empleados_Log", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return registrosBitacoraEmpleado;
        }

        public static implicit operator BitacoraEmpleado(DataRow fila)
        {
            BitacoraEmpleado bitacoraEmpleados = new BitacoraEmpleado
            {
                Id = Convert.ToInt32(fila["Id"].ToString()),
                IdEmpleado = Convert.ToInt32(fila["IdEmpleado"].ToString()),
                Nombre = (fila["Nombre"].ToString()),
                Usuario = fila["Usuario"].ToString(),
                Descripicon = fila["Descripcion"].ToString(),
                Modulo = fila["Modulo"].ToString(),
                Fecha = Convert.ToDateTime(fila["fecha"].ToString())
            };

            return bitacoraEmpleados;
        }
    }
}


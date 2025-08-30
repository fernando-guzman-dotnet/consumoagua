using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPA.Clases
{
    public class EmpleadoPermisosModulo
    {
        private static Conexion _conexion = new Conexion();

        [Browsable(false)]
        public int Id { get; set; }

        [Browsable(false)]
        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public bool Visible { get; set; }
        public bool Habilitado { get; set; }

        [Browsable(false)]
        public int IdEmpleado { get; set; }


        public bool Guardar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addEmpleadoPermiso", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Codigo", Codigo);
                    cmd.Parameters.AddWithValue("@Visible", Visible);
                    cmd.Parameters.AddWithValue("@Habilitado", Habilitado);
                    cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);

                    Id = int.Parse(cmd.ExecuteScalar().ToString());

                    agregado = Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Guardar - " + ex.Message, "Clase EmpleadoPermisosModulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregado;
        }



        public static List<EmpleadoPermisosModulo> GetEmpleadoPermisos(int idEmpleado)
        {
            DataTable tabla = new DataTable();
            List<EmpleadoPermisosModulo> lista = new List<EmpleadoPermisosModulo>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getEmpleadoPermisos", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            EmpleadoPermisosModulo empleadoPermisosModulo = fila;
                            lista.Add(empleadoPermisosModulo);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("getEmpleadoPermisos - " + ex.Message, "Clase EmpleadoPermisosModulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static bool EliminarPermisosPrevios(int idEmpleado)
        {
            bool eliminadas = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("deleteEmpleadoPermisos", _conexion.Actual))
                {
                    cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    eliminadas = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EliminarPermisosPrevios - " + ex.Message, "Clase EmpleadoPermisosModulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminadas;
        }

        public static implicit operator EmpleadoPermisosModulo(DataRow fila)
        {
            EmpleadoPermisosModulo empleadoPermisosModulo = new EmpleadoPermisosModulo
            {
                Id = int.Parse(fila["Id"].ToString()),
                Codigo = fila["Codigo"].ToString(),
                Visible = bool.Parse(fila["Visible"].ToString()),
                Habilitado = bool.Parse(fila["Habilitado"].ToString()),
                IdEmpleado = int.Parse(fila["IdEmpleado"].ToString())
            };

            return empleadoPermisosModulo;
        }
    }
}


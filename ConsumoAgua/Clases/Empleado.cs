using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPA.Clases
{
    public class Empleado
    {
        private static Conexion _conexion = new Conexion();

        public static Empleado Actual { get; set; }

        public int Id { get; set; }

        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; } 
        public string ApellidoMaterno { get; set; }

        public string NombreCompleto
        {
            get
            {
                var nombre = string.IsNullOrWhiteSpace(Nombre) ? string.Empty : Nombre;
                var apellidoPaterno = string.IsNullOrWhiteSpace(ApellidoPaterno) ? string.Empty : ' ' + ApellidoPaterno;
                var apellidoMaterno = string.IsNullOrWhiteSpace(ApellidoMaterno) ? string.Empty : ' ' + ApellidoMaterno;

                return $"{nombre}{apellidoPaterno}{apellidoMaterno}";
            }
        } 

        public string Usuario { get; set; }
        public string Contrasena { get; set; }

        public string NombrePuesto => Puesto.Descripcion;
        public string NombreCaja => Caja == null ? "N/A" : Caja.Descripcion;

        public int IdPuesto => Puesto.Id;
        public int IdCaja => Caja.Id;

        public int NoCuadrilla { get; set; }

        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string RFC { get; set; }


        [Browsable(false)]
        public Puesto Puesto { get; set; } = new Puesto();

        [Browsable(false)]
        public Caja Caja { get; set; } = new Caja();

        [Browsable(false)]
        public List<EmpleadoPermisosModulo> PermisosModulos { get; set; } = new List<EmpleadoPermisosModulo>();


        public bool Agregar()
        {
            bool agregado = false;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("addEmpleado", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", string.IsNullOrWhiteSpace(ApellidoPaterno) ? SqlString.Null : ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", string.IsNullOrWhiteSpace(ApellidoMaterno) ? SqlString.Null : ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Usuario", Usuario);
                    cmd.Parameters.AddWithValue("@Contrasena", Contrasena);
                    cmd.Parameters.AddWithValue("@Domicilio", string.IsNullOrWhiteSpace(Domicilio) ? SqlString.Null : Domicilio);
                    cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(Telefono) ? SqlString.Null : Telefono);
                    cmd.Parameters.AddWithValue("@RFC", string.IsNullOrWhiteSpace(RFC) ? SqlString.Null : RFC);
                    cmd.Parameters.AddWithValue("@IdPuesto", IdPuesto);
                    cmd.Parameters.AddWithValue("@IdCaja", IdCaja == 0 ? SqlInt32.Null : IdCaja);
                    cmd.Parameters.AddWithValue("@NoCuadrilla", NoCuadrilla == 0 ? SqlInt32.Null : NoCuadrilla);

                    this.Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = this.Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("addEmpleado - " + ex.Message, "Clase Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregado;
        }


        public static Empleado GetEmpleadoByCredenciales(string usuario, string contrasena)
        {
            Empleado empleado = null;

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getEmpleadoByCredenciales", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@Usuario", usuario);
                    adapter.SelectCommand.Parameters.AddWithValue("@Contrasena", contrasena);

                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                        empleado = dt.Rows[0];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetEmpleadoByCredenciales - " + ex.Message, "Clase Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return empleado;
        }

        public bool Eliminar()
        {
            bool eliminado = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("deleteEmpleado", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idEmpleado", Id);

                    eliminado = cmd.ExecuteNonQuery() > 0;

                    // TODO: Agregar a bitacora del empleado actual, fuera de aqui
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("deleteEmpleado - " + ex.Message, "Clase Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminado;
        }


        public static List<Empleado> GetEmpleados()
        {
            DataTable tabla = new DataTable();
            List<Empleado> lista = new List<Empleado>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getEmpleados", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Empleado empleado = fila;
                            lista.Add(empleado);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetEmpleados - " + ex.Message, "Clase Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static List<Empleado> GetCajeros() => GetEmpleados().Where(e => e.Puesto.Descripcion.Contains("CAJERO")).ToList();
        public static List<Empleado> GetNotificadores() => GetEmpleados().Where(e => e.Puesto.Descripcion.Contains("NOTIFICADOR")).ToList();
        public static List<Empleado> GetLecturistas() => GetEmpleados().Where(e => e.Puesto.Descripcion.Contains("LECTURISTA")).ToList();
        public static List<Empleado> GetSupervisores() => GetEmpleados().Where(e => e.Puesto.Descripcion.Contains("SUPERVISOR")).ToList();
        public static List<Empleado> GetJefesCuadrilla() => GetEmpleados().Where(e => e.Puesto.Descripcion.Contains("JEFE DE CUADRILLA")).ToList();

        public bool Actualizar()
        {
            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("updateEmpleado", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", string.IsNullOrWhiteSpace(ApellidoPaterno) ? SqlString.Null : ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", string.IsNullOrWhiteSpace(ApellidoMaterno) ? SqlString.Null : ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Usuario", Usuario);
                    cmd.Parameters.AddWithValue("@Contrasena", Contrasena);
                    cmd.Parameters.AddWithValue("@Domicilio", string.IsNullOrWhiteSpace(Domicilio) ? SqlString.Null : Domicilio);
                    cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(Telefono) ? SqlString.Null : Telefono);
                    cmd.Parameters.AddWithValue("@RFC", string.IsNullOrWhiteSpace(RFC) ? SqlString.Null : RFC);
                    cmd.Parameters.AddWithValue("@IdPuesto", IdPuesto);
                    cmd.Parameters.AddWithValue("@IdCaja", IdCaja == 0 ? SqlInt32.Null : IdCaja);
                    cmd.Parameters.AddWithValue("@NoCuadrilla", NoCuadrilla == 0 ? SqlInt32.Null : NoCuadrilla);
                    cmd.Parameters.AddWithValue("@IdEmpleado", this.Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("updateEmpleado - " + ex.Message, "Clase Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public static implicit operator Empleado(DataRow fila)
        {
            Empleado empleado = new Empleado
            {
                Id = int.Parse(fila["Id"].ToString()),
                Nombre = fila["Nombre"].ToString(),
                ApellidoPaterno = fila["ApellidoPaterno"].ToString(),
                ApellidoMaterno = fila["ApellidoMaterno"].ToString(),
                Usuario = fila["Usuario"].ToString(),
                Contrasena = fila["Contrasena"].ToString(),
                Puesto = new Puesto
                {
                    Id = int.Parse(fila["IdPuesto"].ToString()),
                    Descripcion = fila["PuestoDescripcion"].ToString()
                },
                Caja = string.IsNullOrWhiteSpace(fila["IdCaja"].ToString()) ? null : new Caja
                {
                    Id = int.Parse(fila["IdCaja"].ToString()),
                    Descripcion = fila["CajaDescripcion"].ToString()
                },
                NoCuadrilla = string.IsNullOrWhiteSpace(fila["NoCuadrilla"].ToString()) ? 0 : int.Parse(fila["NoCuadrilla"].ToString()),
                Domicilio = fila["Domicilio"].ToString(),
                Telefono = fila["Telefono"].ToString(),
                RFC = fila["RFC"].ToString()
            };

            return empleado;
        }
    }
}


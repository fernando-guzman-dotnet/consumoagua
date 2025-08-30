using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;

namespace SAPA.Clases
{
    public class OrdenTrabajo
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }

        public int NoContrato { get; set; }

        public DateTime Fecha { get; set; }

        public int IdTipoOrdenTrabajo => TipoOrdenTrabajo.Id;
        public string TipoOrden => TipoOrdenTrabajo.Tipo;

        public int IdEmpleado => Empleado.Id;
        public string NombreEmpleado => Empleado.NombreCompleto;

        public int IdEmpleadoSupervisor => Supervisor.Id;
        public string NombreEmpleadoSupervisor => Supervisor.NombreCompleto;
        public int NoCuadrilla => Supervisor.NoCuadrilla;

        public int IdEmpleadoJefeCuadrilla => JefeCuadrilla.Id;
        public string NombreEmpleadoJefeCuadrilla => string.IsNullOrWhiteSpace(JefeCuadrilla.NombreCompleto) ? "N/A" : JefeCuadrilla.NombreCompleto;

        public string Observaciones { get; set; }

        public int IdEstatus { get; set; }
        public string OrdenEstatus { get; set; }

        public string Pagada => IdPago > 0 ? "PAGADA" : "NO PAGADA";
        public int IdPago { get; set; }

        [Browsable(false)]
        public TipoOrdenTrabajo TipoOrdenTrabajo { get; set; }

        [Browsable(false)]
        public Empleado Empleado { get; set; }

        [Browsable(false)]
        public Empleado Supervisor { get; set; }

        [Browsable(false)]
        public Empleado JefeCuadrilla { get; set; }

        public enum Estatus
        {
            Cancelada = 1,
            Pendiente,
            Completada,
            EnProceso,
        }

        public bool Guardar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addOrdenTrabajo", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NoContrato", NoContrato);
                    cmd.Parameters.AddWithValue("@Fecha", Fecha);
                    cmd.Parameters.AddWithValue("@IdTipoOrden", IdTipoOrdenTrabajo);
                    cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                    cmd.Parameters.AddWithValue("@IdEmpleadoSupervisor", IdEmpleadoSupervisor);
                    cmd.Parameters.AddWithValue("@IdEmpleadoJefeCuadrilla", IdEmpleadoJefeCuadrilla);
                    cmd.Parameters.AddWithValue("@Observaciones", Observaciones);
                    cmd.Parameters.AddWithValue("@IdEstatus", IdEstatus);

                    Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase OrdenTrabajo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregado;
        }

        public bool Actualizar()
        {
            bool actualizado = false;
            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("updateOrdenTrabajo", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NoContrato", NoContrato);
                    cmd.Parameters.AddWithValue("@Fecha", Fecha);
                    cmd.Parameters.AddWithValue("@IdTipoOrden", IdTipoOrdenTrabajo);
                    cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                    cmd.Parameters.AddWithValue("@IdEmpleadoSupervisor", IdEmpleadoSupervisor);
                    cmd.Parameters.AddWithValue("@IdEmpleadoJefeCuadrilla", IdEmpleadoJefeCuadrilla);
                    cmd.Parameters.AddWithValue("@Observaciones", Observaciones);
                    cmd.Parameters.AddWithValue("@IdEstatus", IdEstatus);
                    cmd.Parameters.AddWithValue("@Id", Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Actualizar - " + ex.Message, "Clase OrdenTrabajo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public static List<OrdenTrabajo> GetOrdenesTrabajo()
        {
            List<OrdenTrabajo> lista = new List<OrdenTrabajo>();

            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getOrdenesTrabajo", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            OrdenTrabajo ordenTrabajo = new OrdenTrabajo();
                            ordenTrabajo = fila;
                            lista.Add(ordenTrabajo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetOrdenesTrabajo - " + ex.Message, "Clase OrdenTrabajo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return lista;
        }


        public static List<OrdenTrabajo> GetOrdenesTrabajoByNoContrato(int noContrato)
        {

            List<OrdenTrabajo> lista = new List<OrdenTrabajo>();

            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getOrdenesTrabajoByParams", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@NoContrato", noContrato);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            OrdenTrabajo ordenTrabajo = fila;
                            lista.Add(ordenTrabajo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetOrdenesTrabajo - " + ex.Message, "Clase OrdenTrabajo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return lista;
        }

        public static DataTable GetOrdenConceptos(int idOrden)
        {
            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("getOrdenConceptos", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.Add("@idOrden", SqlDbType.Int).Value = idOrden;
                    adapter.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetOrdenConceptos - " + ex.Message, "Clase OrdenTrabajo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return tabla;
        }


        public bool EliminarConceptos()
        {
            bool eliminados = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("deleteOrdenConceptos", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idOrden", this.Id);
                    eliminados = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EliminarConceptos - " + ex.Message, "Clase OrdenTrabajo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminados;
        }

        internal bool AgregarConcepto(int idConcepto, decimal cantidad)
        {
            bool agregado = false;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("addOrdenConcepto", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idOrden", this.Id);
                    cmd.Parameters.AddWithValue("@idConcepto", idConcepto);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);

                    agregado = int.Parse(cmd.ExecuteScalar().ToString()) > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AgregarConcepto - " + ex.Message, "Clase OrdenTrabajo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return agregado;
        }


        public static implicit operator OrdenTrabajo(DataRow fila)
        {
            OrdenTrabajo ordenTrabajo = new OrdenTrabajo
            {
                Id = int.Parse(fila["Id"].ToString()),
                NoContrato = int.Parse(fila["NoContrato"].ToString()),
                Fecha = DateTime.Parse(fila["Fecha"].ToString()),
                TipoOrdenTrabajo = new TipoOrdenTrabajo
                {
                    Id = int.Parse(fila["IdTipoOrden"].ToString()),
                    Tipo = fila["TipoOrden"].ToString()
                },
                Empleado = new Empleado
                {
                    Id = int.Parse(fila["IdEmpleado"].ToString()),
                    Nombre = fila["EmpleadoNombre"].ToString(),
                    ApellidoPaterno = fila["EmpleadoApellidoPaterno"].ToString(),
                    ApellidoMaterno = fila["EmpleadoApellidoMaterno"].ToString()
                },
                Supervisor = new Empleado
                {
                    Id = int.Parse(fila["IdEmpleadoSupervisor"].ToString()),
                    Nombre = fila["SupervisorNombre"].ToString(),
                    ApellidoPaterno = fila["SupervisorApellidoPaterno"].ToString(),
                    ApellidoMaterno = fila["SupervisorApellidoMaterno"].ToString(),
                    NoCuadrilla =  string.IsNullOrEmpty(fila["NoCuadrilla"].ToString()) ? 0 : int.Parse(fila["NoCuadrilla"].ToString())
                },
                JefeCuadrilla = new Empleado()
                {
                    Id = int.Parse(fila["IdEmpleadoJefeCuadrilla"].ToString()),
                    Nombre = fila["JefeCuadrillaNombre"].ToString(),
                    ApellidoPaterno = fila["JefeCuadrillaApellidoPaterno"].ToString(),
                    ApellidoMaterno = fila["JefeCuadrillaApellidoMaterno"].ToString(),
                    NoCuadrilla = string.IsNullOrEmpty(fila["JefeCuadrillaNoCuadrilla"].ToString()) ? 0 : int.Parse(fila["NoCuadrilla"].ToString())
                },
                Observaciones = fila["Observaciones"].ToString(),
                IdEstatus = int.Parse(fila["IdEstatus"].ToString()),
                OrdenEstatus = fila["Estatus"].ToString().ToUpper(),
            };

            if (!string.IsNullOrWhiteSpace(fila["IdPago"].ToString()))
                ordenTrabajo.IdPago = int.Parse(fila["IdPago"].ToString());

            return ordenTrabajo;
        }



    }
}


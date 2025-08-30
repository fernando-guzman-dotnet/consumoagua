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
    public class Convenio
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }

        public int NoContrato { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public DateTime AdeudoPeriodoInicio { get; set; }
        public DateTime AdeudoPeriodoFin { get; set; }

        public int NumeroPagos { get; set; }

        public int IdPeriodicidadPago => PeriodicidadPago.Id;
        public int IdEmpleado => Empleado.Id;

        public string DescripcionPeriodicidad => PeriodicidadPago == null ? string.Empty : PeriodicidadPago.Descripcion;
        public string NombreEmpleado => Empleado == null ? string.Empty : Empleado.NombreCompleto;

        public PeriodicidadPago PeriodicidadPago { get; set; }
        public Empleado Empleado { get; set; }

        public decimal Total { get; set; }


        public enum Periodicidades
        {
            Ninguna = 0,
            Diaria,
            Semanal,
            Quincenal,
            Mensual,
            Anual
        }

        public bool Agregar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addConvenio", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NoContrato", NoContrato);

                    cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio.Date);
                    cmd.Parameters.AddWithValue("@FechaFin", FechaFin.Date);

                    cmd.Parameters.AddWithValue("@AdeudoPeriodoInicio", AdeudoPeriodoInicio.Date);
                    cmd.Parameters.AddWithValue("@AdeudoPeriodoFin", AdeudoPeriodoFin.Date);

                    cmd.Parameters.AddWithValue("@NumeroPagos", NumeroPagos);

                    cmd.Parameters.AddWithValue("@IdPeriodicidadPago", IdPeriodicidadPago);
                    cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);

                    cmd.Parameters.AddWithValue("@Total", Total);

                    Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase Convenio", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("updateConvenio", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio.Date);
                    cmd.Parameters.AddWithValue("@FechaFin", FechaFin.Date);

                    cmd.Parameters.AddWithValue("@NumeroPagos", NumeroPagos);

                    cmd.Parameters.AddWithValue("@IdPeriodicidadPago", IdPeriodicidadPago);
                    cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);

                    cmd.Parameters.AddWithValue("@Total", Total);

                    cmd.Parameters.AddWithValue("@IdConvenio", this.Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Actualizar - " + ex.Message, "Clase Convenio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }


        public bool Cancelar()
        {
            bool eliminado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("deleteConvenio", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdConvenio", this.Id);

                    eliminado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cancelar - " + ex.Message, "Clase Convenio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminado;
        }


        public static List<Convenio> GetConveniosByNoContrato(int noContrato)
        {
            DataTable tabla = new DataTable();
            List<Convenio> lista = new List<Convenio>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getConveniosByNoContrato", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@NoContrato", noContrato);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Convenio convenio = fila;
                            lista.Add(convenio);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetConveniosByNoContrato - " + ex.Message, "Clase Convenio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }



        public static List<Convenio> GetConvenios()
        {
            DataTable tabla = new DataTable();
            List<Convenio> lista = new List<Convenio>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getConvenios", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Convenio convenio = fila;
                            lista.Add(convenio);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetConvenios - " + ex.Message, "Clase Convenio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }



        public static implicit operator Convenio(DataRow fila)
        {
            Convenio convenio = new Convenio
            {
                Id = int.Parse(fila["Id"].ToString()),
                NoContrato = int.Parse(fila["NoContrato"].ToString()),
                FechaInicio = DateTime.Parse(fila["FechaInicio"].ToString()),
                FechaFin = DateTime.Parse(fila["FechaFin"].ToString()),
                AdeudoPeriodoInicio = DateTime.Parse(fila["AdeudoPeriodoInicio"].ToString()),
                AdeudoPeriodoFin = DateTime.Parse(fila["AdeudoPeriodoFin"].ToString()),
                NumeroPagos = int.Parse(fila["NumeroPagos"].ToString()),
                PeriodicidadPago = new PeriodicidadPago
                {
                    Id = int.Parse(fila["IdPeriodicidadPago"].ToString()),
                    Descripcion = fila["DescripcionPeriodicidadPago"].ToString()
                },
                Empleado = new Empleado
                {
                    Id = int.Parse(fila["IdEmpleado"].ToString()),
                    ApellidoPaterno = fila["EmpleadoApellidoPaterno"].ToString(),
                    ApellidoMaterno = fila["EmpleadoApellidoMaterno"].ToString(),
                    Nombre = fila["EmpleadoNombre"].ToString(),
                },
                Total = decimal.Parse(fila["Total"].ToString())
            };

            return convenio;
        }

    }
}


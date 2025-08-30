using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Windows.Forms;

namespace SAPA.Clases
{
    public static class Reporte
    {
        private static Conexion _conexion = new Conexion();

        public static DataTable CorteCajaByFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getCorteCajaByFechas", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    adapter.SelectCommand.Parameters.AddWithValue("@FechaFin", fechaFin);
                    adapter.Fill(tabla);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("CorteCajaByFechas - " + ex.Message, "Clase Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return tabla;
        }


        public static DataTable CorteCajaExcelByFechas(DateTime fechaInicio, DateTime fechaFin, int idCaja = 0)
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getCorteCajaDetalladoExcelByFechas", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    adapter.SelectCommand.Parameters.AddWithValue("@FechaFin", fechaFin);
                    adapter.SelectCommand.Parameters.AddWithValue("IdCaja", idCaja);
                    adapter.Fill(tabla);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("CorteCajaByFechas - " + ex.Message, "Clase Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return tabla;
        }



        public static DataTable CorteCajaConceptosByFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getCorteCajaConceptosByFechas", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    adapter.SelectCommand.Parameters.AddWithValue("@FechaFin", fechaFin);
                    adapter.Fill(tabla);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("CorteCajaByFechas - " + ex.Message, "Clase Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return tabla;
        }

        public static DataTable SituacionActualContratos()
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getSituacionActualContratos", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("SituacionActualContratos - " + ex.Message, "Clase Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return tabla;
        }

        public static DataTable GetContratosRevisiones()
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getRptContratosRevisiones", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("getContratosRevisiones - " + ex.Message, "Clase Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return tabla;
        }

        public static DataSet GetRptRevision(int idRevision)
        {
            DataSet dataSet = new DataSet();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getRptRevision", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@IdRevision", idRevision);

                    adapter.Fill(dataSet);

                    // La primera tabla dentro del DataSet contiene los nombres de las tablas con el que se identificará cada una
                    // Asignamos el nombre a cada tabla, y luego eliminamos la primera

                    for (int columnIdx = 0; columnIdx < dataSet.Tables[0].Columns.Count; ++columnIdx)
                    {
                        int tableIdx = columnIdx + 1;

                        if (tableIdx >= dataSet.Tables.Count)
                        {
                            break;
                        }

                        dataSet.Tables[tableIdx].TableName = dataSet.Tables[0].Rows[0][columnIdx].ToString().Trim();
                    }

                    dataSet.Tables.RemoveAt(0);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetRptRevision - " + ex.Message, "Clase Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return dataSet;
        }



        public static DataTable GetPagosUltimaSemana()
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getPagosUltimaSemana", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("getPagosUltimaSemana - " + ex.Message, "Clase Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return tabla;
        }



        public static DataTable GetAñosDisponiblesTarifas()
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getAñosDisponiblesTarifas", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetAñosDisponiblesTarifas - " + ex.Message, "Clase Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return tabla;
        }


        public static DataTable GetCuotasTarifas(int año)
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getRptCuotasTarifas", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@año", año);
                    adapter.Fill(tabla);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetCuotasTarifas - " + ex.Message, "Clase Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return tabla;
        }


        public static DataTable GetDeudores()
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getDeudores", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetDeudores - " + ex.Message, "Clase Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return tabla;
        }



        public static bool LimpiarDeudores()
        {
            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("deleteDeudores", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LimpiarDeudores - " + ex.Message, "Clase Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public static void CargarBulkDeudores(DataTable tabla, SqlRowsCopiedEventHandler subEvent = null)
        {
            if (tabla == null || tabla.Rows.Count == 0) return;

            try
            {
                _conexion.Actual.Open();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(_conexion.Actual))
                {
                    bulkCopy.BulkCopyTimeout = 6600;
                    bulkCopy.DestinationTableName = "Deudores";
                    bulkCopy.WriteToServer(tabla.CreateDataReader());

                    bulkCopy.NotifyAfter = tabla.Rows.Count;

                    if (subEvent != null)
                        bulkCopy.SqlRowsCopied += subEvent;

                    bulkCopy.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
        }

    }
}


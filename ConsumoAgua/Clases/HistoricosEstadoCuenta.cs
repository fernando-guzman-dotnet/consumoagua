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
    class HistoricosEstadoCuenta
    {
        private static Conexion _conexion = new Conexion();


        public static DataTable DatosSuplementarios(int noContrato)
        {
            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("DatosSuplementarios", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.Add("@idContrato", SqlDbType.Int).Value = noContrato;
                    adapter.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DatosSuplementarios - " + ex.Message, "Clase Historicos_EstadoC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return tabla;
        }

        public static DataTable UltimosPagosVarios_Select(int noContrato, DateTime FechaIni, DateTime FechaFin)
        {
            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("UltimosPagosVarios_Select", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    adapter.SelectCommand.Parameters.Add("@idContrato", SqlDbType.Int).Value = noContrato;
                    adapter.SelectCommand.Parameters.Add("@FechaIni", SqlDbType.DateTime).Value = FechaIni;
                    adapter.SelectCommand.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = FechaFin;

                    adapter.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("UltimosPagosVarios_Select - " + ex.Message, "Clase Historicos_EstadoC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return tabla;
        }

        public DataTable ContratosMediciones_Select(int noContrato, DateTime FechaIni, DateTime FechaFin)
        {
            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("ContratosMediciones_Select", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.Add("@NoContrato", SqlDbType.Int).Value = noContrato;
                    adapter.SelectCommand.Parameters.Add("@FechaIni", SqlDbType.DateTime).Value = FechaIni;
                    adapter.SelectCommand.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = FechaFin;
                    adapter.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ContratosMediciones_Select - " + ex.Message, "Clase Historicos_EstadoC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return tabla;
        }
    }
}


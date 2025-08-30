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
    public class Observaciones
    {
        private static Conexion _conexion = new Conexion();


        public int Id { get; set; }
        public int NoContrato { get; set; }
        public string Comentario { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime Fecha { get; set; }

        public bool Agregar()
        {
            bool agregado = false;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("addContratoObservaciones", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@noContrato", SqlDbType.Int).Value = NoContrato;
                    cmd.Parameters.Add("@Observacion", SqlDbType.NVarChar).Value = Comentario;
                    cmd.Parameters.Add("@IdEmpleado", SqlDbType.Int).Value = IdEmpleado;
                    cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = DateTime.Now;
                    agregado = Convert.ToInt32(cmd.ExecuteScalar().ToString()) > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase Observaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return agregado;
        }

        public int ObservacionesUpdate()
        {
            int aux = 0;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("updateContratoObservaciones", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@noContrato", SqlDbType.Int).Value = NoContrato;
                    cmd.Parameters.Add("@Observacion", SqlDbType.NVarChar).Value = Comentario;
                    cmd.Parameters.Add("@IdEmpleado", SqlDbType.Int).Value = IdEmpleado;
                    cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                    aux = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ObservacionesUpdate - " + ex.Message, "Clase Observaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return aux;
        }

        public static DataTable GetObservacionesByNoContrato(int noContrato)
        {
            DataTable tbl = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("getContratoObservacionesByNoContrato", _conexion.Actual))
                {
                    adapter.SelectCommand.Parameters.Add("@noContrato", SqlDbType.Int).Value = noContrato;
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tbl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ObservacionesSelectBynoContrato - " + ex, "Clase Observaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return tbl;
        }
    }
}


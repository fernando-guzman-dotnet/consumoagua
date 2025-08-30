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
    public class BitacoraOrdenTrabajo
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdOrden { get; set; }
        public int IdEstatus { get; set; }
        public string Estatus { get; set; }
        public string Observaciones { get; set; }
        public int IdEmpleado { get; set; }

        public bool Agregar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addLogOrdenTrabajo", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha", Fecha);
                    cmd.Parameters.AddWithValue("@IdOrden", IdOrden);
                    cmd.Parameters.AddWithValue("@IdEstatus", IdEstatus);
                    cmd.Parameters.AddWithValue("@Observaciones", Observaciones);
                    cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
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

        public static DataTable GetByIdOrden(int IdOrden)
        {
            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getBitacoraOrdenByIdOrden", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@IdOrden", IdOrden);
                    adapter.Fill(tabla);

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

            return tabla;
        }
    }
}


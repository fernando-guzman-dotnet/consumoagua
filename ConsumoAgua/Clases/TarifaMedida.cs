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
    public class TarifaMedida
    {
        private static Conexion _conexion = new Conexion();
        public int Id { get; set; }
        public int IdTarifa { get; set; }
        public string Descripcion { get; set; }
        public decimal LimiteMenor { get; set; }
        public decimal LimiteMayor { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Excedente { get; set; }
        public int Año { get; set; }



        public bool Guardar()
        {
            bool agregada = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addCuotaMedida", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idTarifa", this.Id);
                    cmd.Parameters.AddWithValue("@descripcion", this.Descripcion);
                    cmd.Parameters.AddWithValue("@limiteMenor", this.LimiteMenor);
                    cmd.Parameters.AddWithValue("@limiteMayor", this.LimiteMayor);
                    cmd.Parameters.AddWithValue("@cantidad", this.Cantidad);
                    cmd.Parameters.AddWithValue("@Excedente", this.Excedente);
                    cmd.Parameters.AddWithValue("@Año", this.Año);

                    agregada = int.Parse(cmd.ExecuteScalar().ToString()) > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GuardarCuotaMedida - " + ex.Message, "Clase Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregada;
        }



        public bool EliminarCuotasMedidas(int año)
        {
            bool eliminada = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("deleteCuotaMedida", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTarifa", this.IdTarifa);
                    cmd.Parameters.AddWithValue("@Año", año);
                    eliminada = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EliminarCuotasMedidas - " + ex.Message, "Clase Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminada;
        }

        public static DataTable GetTarifasMedidas(int idTarifa)
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getCuotasByIDTarifa", _conexion.Actual))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@idTarifa", idTarifa);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getCuotasByIDTarifa - " + ex.Message, "Clase Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return tabla;
        }



        public static List<TarifaMedida> GetTarifasServicioMedidoByIdTarifa(int idTarifa)
        {
            List<TarifaMedida> lista = new List<TarifaMedida>();

            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getTarifasServicioMedidoByIdTarifa", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@IdTarifa", idTarifa);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            TarifaMedida tarifa = fila;
                            lista.Add(tarifa);
                        }
                    }
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
            return lista;
        }


        public List<TarifaMedida> GetTarifasMedidasByIdTarifa(int idTarifa)
        {
            List<TarifaMedida> lista = new List<TarifaMedida>();

            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getTarifasMedidasByIdTarifa", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@IdTarifa", idTarifa);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            lista.Add(fila);
                        }
                    }
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
            return lista;
        }

        public static implicit operator TarifaMedida(DataRow fila)
        {
            TarifaMedida tarifa = new TarifaMedida
            {
                Id = Convert.ToInt32(fila["Id"].ToString()),
                IdTarifa = Convert.ToInt32(fila["IdTarifa"].ToString()),
                Descripcion = fila["Descripcion"].ToString(),
                LimiteMenor = Convert.ToDecimal(fila["LimiteMenor"].ToString()),
                LimiteMayor = Convert.ToDecimal(fila["LimiteMayor"].ToString()),
                Cantidad = Convert.ToDecimal(fila["Cantidad"].ToString()),
                Excedente = Convert.ToDecimal(fila["Excedente"].ToString()),
                Año = Convert.ToInt32(fila["Año"].ToString()),
            };

            return tarifa;
        }
    }
}



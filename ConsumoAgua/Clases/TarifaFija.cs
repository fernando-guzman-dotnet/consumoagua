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
    public class TarifaFija
    {

        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int IdTarifa { get; set; }
        public decimal CantidadMensual { get; set; }
        public decimal CantidadAnual { get; set; }
        public decimal IVA { get; set; }
        public int Año { get; set; }

        public bool GuardarCuotasFijas()
        {
            bool agregada = false;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("addCuotaFija", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@idTarifa", SqlDbType.Int).Value = this.IdTarifa;
                    cmd.Parameters.Add("@cantidadMensual", SqlDbType.Decimal).Value = this.CantidadMensual;
                    cmd.Parameters.Add("@cantidadAnual", SqlDbType.Decimal).Value = this.CantidadAnual;
                    cmd.Parameters.AddWithValue("@año", this.Año);

                    agregada = int.Parse(cmd.ExecuteScalar().ToString()) > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("addCuotaFija - " + ex.Message, "Clase Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregada;
        }

        public bool ActualizarCuotasFijas()
        {
            bool actualizada = false;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("updateCuotaFija", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cantidadMensual", this.CantidadMensual);
                    cmd.Parameters.AddWithValue("@cantidadAnual", this.CantidadAnual);
                    cmd.Parameters.AddWithValue("@Id", this.Id);

                    actualizada = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("updateCuotaFija - " + ex.Message, "Clase Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizada;
        }

        public bool EliminarCuotasFijas()
        {
            bool eliminada = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("deleteCuotaFija", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTarifa", this.IdTarifa);
                    cmd.Parameters.AddWithValue("@año", this.Año);

                    eliminada = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("updateCuotaFija - " + ex.Message, "Clase Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return eliminada;
        }



        public static List<TarifaFija> GetTarifasFijasByIdTarifa(int idTarifa)
        {
            List<TarifaFija> lista = new List<TarifaFija>();

            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getTarifasFijasByIdTarifa", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@IdTarifa", idTarifa);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            TarifaFija tarifaFija = fila;
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

        public static implicit operator TarifaFija(DataRow fila)
        {
            TarifaFija tarifaFija = new TarifaFija
            {
                Id = int.Parse(fila["Id"].ToString()),
                IdTarifa = int.Parse(fila["IdTarifa"].ToString()),
                CantidadMensual = decimal.Parse(fila["cantidadMensual"].ToString()),
                CantidadAnual = decimal.Parse(fila["cantidadAnual"].ToString()),
                Año = int.Parse(fila["Año"].ToString())
            };

            return tarifaFija;
        }

    }
}


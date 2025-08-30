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
    public class ContratoDescuento
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }

        public int NoContrato { get; set; }

        public int IdDescuento => Descuento.Id;

        public Descuento Descuento { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }


        public static List<ContratoDescuento> GetTodosByNoContrato(int noContrato)
        {
            DataTable tabla = new DataTable();
            List<ContratoDescuento> lista = new List<ContratoDescuento>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getContratosDescuentosByNoContrato", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.Add("@NoContrato", SqlDbType.Int).Value = noContrato;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            ContratoDescuento contratoDescuento = new ContratoDescuento();
                            contratoDescuento = fila;
                            lista.Add(contratoDescuento);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetByNoContrato - " + ex.Message, "Clase ContratoDescuento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return lista;
        }



        public static List<ContratoDescuento> GetTodosByUsuario(int idUsuario)
        {
            DataTable tabla = new DataTable();
            List<ContratoDescuento> lista = new List<ContratoDescuento>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getContratosDescuentosByIdUsuario", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            ContratoDescuento contratoDescuento = new ContratoDescuento();
                            contratoDescuento = fila;
                            lista.Add(contratoDescuento);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetByNoContrato - " + ex.Message, "Clase ContratoDescuento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return lista;
        }


        public bool AplicarMasivamente(int idColonia = 0, int idCalle = 0)
        {

            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addDescuentoMasivo", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdDescuento", IdDescuento);
                    cmd.Parameters.AddWithValue("@FechaAplicado", DateTime.Now);
                    cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                    cmd.Parameters.AddWithValue("@IdColonia", idColonia);
                    cmd.Parameters.AddWithValue("@IdCalle", idCalle);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AplicarMasivamente - " + ex.Message, "Clase ContratoDescuento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public bool Agregar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addContratoDescuento", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NoContrato", NoContrato);
                    cmd.Parameters.AddWithValue("@IdDescuento", IdDescuento);
                    cmd.Parameters.AddWithValue("@FechaAplicado", DateTime.Now);
                    cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", FechaFin);

                    Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase nombreClase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregado;
        }
        

        public static implicit operator ContratoDescuento(DataRow fila)
        {
            ContratoDescuento contratoDescuento = new ContratoDescuento
            {
                Id = int.Parse(fila["Id"].ToString()),
                NoContrato = int.Parse(fila["NoContrato"].ToString()),
                Descuento = new Descuento
                {
                    Id = int.Parse(fila["DescuentoId"].ToString()),
                    TipoDescuento = new TipoDescuento
                    {
                        Id = int.Parse(fila["IdTipoDescuento"].ToString()),
                        Descripcion = fila["NombreTipoDescuento"].ToString()
                    },
                    PorcentajeAgua = decimal.Parse(fila["PorcentajeAgua"].ToString()),
                    PorcentajeAlcantarillado = decimal.Parse(fila["PorcentajeAlcantarillado"].ToString()),
                    PorcentajeSaneamiento = decimal.Parse(fila["PorcentajeSaneamiento"].ToString()),
                    PorcentajeRecargos = decimal.Parse(fila["PorcentajeRecargos"].ToString()),
                    PorcentajeMultas = decimal.Parse(fila["PorcentajeMultas"].ToString()),
                    PorcentajeGastosEjecucion = decimal.Parse(fila["PorcentajeGastosEjecucion"].ToString()),
                    PorcentajeIVA = decimal.Parse(fila["PorcentajeIVA"].ToString()),
                    FechaCreado = DateTime.Parse(fila["DescuentoFechaCreado"].ToString()),
                },
                FechaInicio = DateTime.Parse(fila["FechaInicio"].ToString()),
                FechaFin = DateTime.Parse(fila["FechaFin"].ToString())
            };

            return contratoDescuento;
        }
    }
}


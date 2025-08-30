using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPA.Clases
{
    public class Descuento
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }

        public int IdTipoDescuento => TipoDescuento.Id;
        public string NombreTipoDescuento => TipoDescuento.Descripcion;

        public decimal PorcentajeAgua { get; set; }
        public decimal PorcentajeAlcantarillado { get; set; }
        public decimal PorcentajeSaneamiento { get; set; }
        public decimal PorcentajeRecargos { get; set; }
        public decimal PorcentajeMultas { get; set; }
        public decimal PorcentajeGastosEjecucion { get; set; }
        public decimal PorcentajeIVA { get; set; }

        public DateTime FechaCreado { get; set; }

        [Browsable(false)]
        public TipoDescuento TipoDescuento { get; set; }

        public static List<Descuento> GetDescuentos()
        {
            DataTable tabla = new DataTable();
            List<Descuento> lista = new List<Descuento>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getDescuentos", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Descuento descuento = fila;
                            lista.Add(descuento);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetDescuentos - " + ex.Message, "Clase Descuento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public bool Agregar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addDescuento", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdTipoDescuento", IdTipoDescuento);
                    cmd.Parameters.AddWithValue("@PorcentajeAgua", PorcentajeAgua);
                    cmd.Parameters.AddWithValue("@PorcentajeAlcantarillado", PorcentajeAlcantarillado);
                    cmd.Parameters.AddWithValue("@PorcentajeSaneamiento", PorcentajeSaneamiento);
                    cmd.Parameters.AddWithValue("@PorcentajeRecargos", PorcentajeRecargos);
                    cmd.Parameters.AddWithValue("@PorcentajeMultas", PorcentajeMultas);
                    cmd.Parameters.AddWithValue("@PorcentajeGastosEjecucion", PorcentajeGastosEjecucion);
                    cmd.Parameters.AddWithValue("@PorcentajeIVA", PorcentajeIVA);
                    cmd.Parameters.AddWithValue("@FechaCreado", DateTime.Now);

                    Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase Descuento", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("updateDescuento", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdTipoDescuento", IdTipoDescuento);
                    cmd.Parameters.AddWithValue("@PorcentajeAgua", PorcentajeAgua);
                    cmd.Parameters.AddWithValue("@PorcentajeAlcantarillado", PorcentajeAlcantarillado);
                    cmd.Parameters.AddWithValue("@PorcentajeSaneamiento", PorcentajeSaneamiento);
                    cmd.Parameters.AddWithValue("@PorcentajeRecargos", PorcentajeRecargos);
                    cmd.Parameters.AddWithValue("@PorcentajeMultas", PorcentajeMultas);
                    cmd.Parameters.AddWithValue("@PorcentajeGastosEjecucion", PorcentajeGastosEjecucion);
                    cmd.Parameters.AddWithValue("@PorcentajeIVA", PorcentajeIVA);

                    cmd.Parameters.AddWithValue("@Id", Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Actualizar - " + ex.Message, "Clase Descuento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public bool Eliminar()
        {
            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("deleteDescuento", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Actualizar - " + ex.Message, "Clase Descuento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public static implicit operator Descuento(DataRow fila)
        {
            Descuento descuento = new Descuento
            {
                Id = int.Parse(fila["Id"].ToString()),
                TipoDescuento = new TipoDescuento
                {
                    Id = int.Parse(fila["IdTipoDescuento"].ToString()),
                    Descripcion = fila["Descripcion"].ToString()
                },
                PorcentajeAgua = decimal.Parse(fila["PorcentajeAgua"].ToString()),
                PorcentajeAlcantarillado = decimal.Parse(fila["PorcentajeAlcantarillado"].ToString()),
                PorcentajeSaneamiento = decimal.Parse(fila["PorcentajeSaneamiento"].ToString()),
                PorcentajeRecargos = decimal.Parse(fila["PorcentajeRecargos"].ToString()),
                PorcentajeMultas = decimal.Parse(fila["PorcentajeMultas"].ToString()),
                PorcentajeGastosEjecucion = decimal.Parse(fila["PorcentajeGastosEjecucion"].ToString()),
                PorcentajeIVA = decimal.Parse(fila["PorcentajeIVA"].ToString()),
                FechaCreado = DateTime.Parse(fila["FechaCreado"].ToString())
            };

            return descuento;
        }
    }
}


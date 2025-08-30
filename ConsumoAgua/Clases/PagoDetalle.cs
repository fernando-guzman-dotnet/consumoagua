using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Windows.Forms;

namespace SAPA.Clases
{
    public class PagoDetalle
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int IdPago { get; set; }

        public decimal Agua { get; set; }
        public decimal Alcantarillado { get; set; }
        public decimal Saneamiento { get; set; }
        public decimal Recargos { get; set; }
        public decimal Multas { get; set; }
        public decimal GastosEjecucion { get; set; }
        public decimal Redondeo { get; set; }
        public decimal IVA { get; set; }
        public decimal DescuentoTotal => DescuentoValores.Total;
        public decimal AdeudoTotal { get; set; }

        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFin { get; set; }

        public List<ConceptoAdicional> ConceptosAdicionales { get; set; } = new List<ConceptoAdicional>();
        public List<ContratoDescuento> DescuentosAplicados { get; set; } = new List<ContratoDescuento>();
        public DescuentoTemporal DescuentoTemporal { get; set; } = new DescuentoTemporal();
        public DescuentoValores DescuentoValores { get; set; } = new DescuentoValores();

        public bool Agregar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addPagoDetalles", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdPago", IdPago);
                    cmd.Parameters.AddWithValue("@Agua", Agua);
                    cmd.Parameters.AddWithValue("@Alcantarillado", Alcantarillado);
                    cmd.Parameters.AddWithValue("@Saneamiento", Saneamiento);
                    cmd.Parameters.AddWithValue("@Recargos", Recargos);
                    cmd.Parameters.AddWithValue("@Multas", Multas);
                    cmd.Parameters.AddWithValue("@GastosEjecucion", GastosEjecucion);
                    cmd.Parameters.AddWithValue("@Redondeo", Redondeo);
                    cmd.Parameters.AddWithValue("@IVA", IVA);
                    cmd.Parameters.AddWithValue("@AdeudoTotal", AdeudoTotal);
                    cmd.Parameters.AddWithValue("@PeriodoInicio", (PeriodoInicio == default(DateTime)) ? SqlDateTime.Null : PeriodoInicio);
                    cmd.Parameters.AddWithValue("@PeriodoFin", (PeriodoFin == default(DateTime)) ? SqlDateTime.Null : PeriodoFin);

                    Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase PagoDetalle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregado;
        }


        public bool AgregarDescuento(ContratoDescuento contratoDescuento)
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addPagoContratoDescuento", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdPago", IdPago);
                    cmd.Parameters.AddWithValue("@IdContratoDescuento", contratoDescuento.Id);
                    cmd.Parameters.AddWithValue("@PorcentajeAgua", contratoDescuento.Descuento.PorcentajeAgua);
                    cmd.Parameters.AddWithValue("@PorcentajeAlcantarillado", contratoDescuento.Descuento.PorcentajeAlcantarillado);
                    cmd.Parameters.AddWithValue("@PorcentajeSaneamiento", contratoDescuento.Descuento.PorcentajeSaneamiento);
                    cmd.Parameters.AddWithValue("@PorcentajeRecargos", contratoDescuento.Descuento.PorcentajeRecargos);
                    cmd.Parameters.AddWithValue("@PorcentajeMultas", contratoDescuento.Descuento.PorcentajeMultas);
                    cmd.Parameters.AddWithValue("@PorcentajeGastosEjecucion", contratoDescuento.Descuento.PorcentajeGastosEjecucion);
                    cmd.Parameters.AddWithValue("@PorcentajeIVA", contratoDescuento.Descuento.PorcentajeIVA);

                    contratoDescuento.Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = contratoDescuento.Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase PagoDetalle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregado;
        }


        public bool AgregarDescuentoValores()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addPagoDescuentoValores", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdPago", IdPago);
                    cmd.Parameters.AddWithValue("@Agua", DescuentoValores.Agua);
                    cmd.Parameters.AddWithValue("@Alcantarillado", DescuentoValores.Alcantarillado);
                    cmd.Parameters.AddWithValue("@Saneamiento", DescuentoValores.Saneamiento);
                    cmd.Parameters.AddWithValue("@Recargos", DescuentoValores.Recargos);
                    cmd.Parameters.AddWithValue("@Multas", DescuentoValores.Multas);
                    cmd.Parameters.AddWithValue("@GastosEjecucion", DescuentoValores.GastosEjecucion);
                    cmd.Parameters.AddWithValue("@IVA", DescuentoValores.IVA);
                    cmd.Parameters.AddWithValue("@Total", DescuentoValores.Total);

                    DescuentoValores.Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = DescuentoValores.Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase PagoDetalle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregado;
        }


        public bool AgregarConceptoAdicional(ConceptoAdicional conceptoAdicional)
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addPagoConceptoAdicional", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdPago", IdPago);
                    cmd.Parameters.AddWithValue("@IdConcepto", conceptoAdicional.IdConcepto);
                    cmd.Parameters.AddWithValue("@Importe", conceptoAdicional.Importe);

                    conceptoAdicional.Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = conceptoAdicional.Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase PagoDetalle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregado;
        }

        public static DescuentoValores GetDescuentoValores(int idPago)
        {
            DataTable tabla = new DataTable();
            DescuentoValores obj = new DescuentoValores();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getPagoDescuentoValoresByIdPago", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@IdPago", idPago);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        obj = tabla.Rows[0];
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetPagoDescuentoValores - " + ex.Message, "Clase DescuentoValores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return obj;
        }

        public static List<ContratoDescuento> GetDescuentosAplicadosByIdPago(int idPago)
        {
            DataTable tabla = new DataTable();
            List<ContratoDescuento> lista = new List<ContratoDescuento>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getDescuentosAplicadosByIdPago", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@IdPago", idPago);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            ContratoDescuento contratoDescuento = fila;
                            lista.Add(contratoDescuento);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }


        public static List<ConceptoAdicional> GetConceptosAdicionalesByIdPago(int idPago)
        {
            DataTable tabla = new DataTable();
            List<ConceptoAdicional> lista = new List<ConceptoAdicional>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getConceptosAdicionalesByIdPago", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@idPago", idPago);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            ConceptoAdicional conceptoAdicional = fila;
                            lista.Add(conceptoAdicional);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetConceptosAdicionalesByIdPago - " + ex.Message, "Clase PagoDetalle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }
    }
}


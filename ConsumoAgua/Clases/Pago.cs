using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Security.Cryptography;
using System.Windows.Forms;
using Clases;

namespace SAPA.Clases
{
    public class Pago
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int Folio { get; set; }
        public string FolioInterno { get; set; }
        public int NoContrato { get; set; }
        public DateTime Fecha { get; set; }

        [Browsable(false)]
        public int IdFormaPago => FormaPago.Id;
        public string DescripcionFormaPago => (FormaPago == null) ? string.Empty : FormaPago.Descripcion;

        [Browsable(false)]
        public int IdEmpleado => Empleado.Id;
        public string NombreEmpleado => (Empleado == null) ? string.Empty : Empleado.NombreCompleto;

        [Browsable(false)]
        public int IdBanco => Banco.Id;
        public string NombreBanco => (Banco == null) ? "N/A" : Banco.Nombre;

        [Browsable(false)]
        public int IdCaja => Caja.Id;
        public string NombreCaja => (Caja == null) ? string.Empty : Caja.Descripcion;

        public string Referencia { get; set; }

        public string PeriodoPagado => (Detalles == null || (Detalles.PeriodoInicio == default(DateTime) && Detalles.PeriodoFin == default(DateTime)))
                ? string.Empty
                : $"{Detalles.PeriodoInicio.ToString("MMM yy", new CultureInfo("es-MX"))} - {Detalles.PeriodoFin.ToString("MMM yy", new CultureInfo("es-MX"))}";

        public decimal TotalPagado => Detalles?.AdeudoTotal ?? 0m;


        [Browsable(false)]
        public FormaPago FormaPago { get; set; }
        [Browsable(false)]
        public Empleado Empleado { get; set; }
        [Browsable(false)]
        public Banco Banco { get; set; }
        [Browsable(false)]
        public Caja Caja { get; set; }
        [Browsable(false)]
        public PagoDetalle Detalles { get; set; }

        public enum Forma
        {
            Efectivo = 1,
            Transferencia,
            TarjetaDebito,
            TarjetaCredito,
            Cheque
        }

        public bool Agregar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addPago", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FolioInterno", string.IsNullOrEmpty(FolioInterno) ? SqlString.Null : FolioInterno);
                    cmd.Parameters.AddWithValue("@NoContrato", NoContrato);
                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@IdFormaPago", IdFormaPago);
                    cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado == 0 ? SqlInt32.Null : IdEmpleado);
                    cmd.Parameters.AddWithValue("@IdCaja", IdCaja == 0 ? SqlInt32.Null : IdCaja);
                    cmd.Parameters.AddWithValue("@IdBanco", IdBanco == 0 ? SqlInt32.Null : IdBanco);
                    cmd.Parameters.AddWithValue("@Referencia", string.IsNullOrWhiteSpace(Referencia) ? SqlString.Null : Referencia);

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Id = Convert.ToInt32(dataReader[0].ToString());
                            Folio = Convert.ToInt32(dataReader[1].ToString());
                        }

                        dataReader.Close();
                    }

                    agregado = Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase Pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregado;
        }


        public bool Cancelar()
        {
            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("deletePago", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPago", Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cancelar - " + ex.Message, "Clase Pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }


        public static List<Pago> GetPagosByNoContrato(int noContrato)
        {
            DataTable tabla = new DataTable();
            List<Pago> lista = new List<Pago>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getPagosByNoContrato", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@NoContrato", noContrato);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Pago pago = fila;
                            lista.Add(pago);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetPagosByNoContrato - " + ex.Message, "Clase Pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }


        public static List<Pago> GetPagosCanceladosByNoContrato(int noContrato)
        {
            DataTable tabla = new DataTable();
            List<Pago> lista = new List<Pago>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getPagosCanceladosByNoContrato", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@NoContrato", noContrato);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Pago pago = fila;
                            lista.Add(pago);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetPagosCanceladosByNoContrato - " + ex.Message, "Clase Pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static int GetUltimoFolio()
        {
            int ultimoId = 0;

            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getUltimoFolioPago", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        ultimoId = int.Parse(tabla.Rows[0]["Folio"].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetPagosByNoContrato - " + ex.Message, "Clase Pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return ultimoId;
        }

        public static implicit operator Pago(DataRow fila)
        {
            Pago pago = new Pago
            {
                Id = int.Parse(fila["Id"].ToString()),
                Folio = int.Parse(fila["Folio"].ToString()),
                FolioInterno = fila["FolioInterno"].ToString(),
                NoContrato = int.Parse(fila["NoContrato"].ToString()),
                Fecha = DateTime.Parse(fila["Fecha"].ToString()),
                FormaPago = new FormaPago
                {
                    Id = int.Parse(fila["IdFormaPago"].ToString()),
                    Descripcion = fila["DescripcionFormaPago"].ToString()
                },
                Empleado = new Empleado
                {
                    Id = int.Parse(fila["IdEmpleado"].ToString()),
                    Nombre = fila["EmpleadoNombre"].ToString(),
                    ApellidoPaterno = fila["EmpleadoApellidoPaterno"].ToString(),
                    ApellidoMaterno = fila["EmpleadoApellidoMaterno"].ToString()
                },
                Banco = string.IsNullOrWhiteSpace(fila["IdBanco"].ToString()) ? new Banco {Nombre = "N/A"} : new Banco
                {
                    Id = int.Parse(fila["IdBanco"].ToString()),
                    Nombre = fila["BancoNombre"].ToString()
                },
                Caja = new Caja
                {
                    Id = int.Parse(fila["IdCaja"].ToString()),
                    Descripcion = fila["DescripcionCaja"].ToString()
                },
                Referencia = fila["Referencia"].ToString(),
                Detalles = new PagoDetalle
                {
                    Id = int.Parse(fila["IdPagoDetalle"].ToString()),
                    IdPago = int.Parse(fila["Id"].ToString()),
                    Agua = decimal.Parse(fila["Agua"].ToString()),
                    Alcantarillado = decimal.Parse(fila["Alcantarillado"].ToString()),
                    Saneamiento = decimal.Parse(fila["Saneamiento"].ToString()),
                    Recargos = decimal.Parse(fila["Recargos"].ToString()),
                    Multas = decimal.Parse(fila["Multas"].ToString()),
                    GastosEjecucion = decimal.Parse(fila["GastosEjecucion"].ToString()),
                    Redondeo = decimal.Parse(fila["Redondeo"].ToString()),
                    IVA = decimal.Parse(fila["IVA"].ToString()),
                    AdeudoTotal = decimal.Parse(fila["AdeudoTotal"].ToString()),
                    PeriodoInicio = string.IsNullOrWhiteSpace(fila["PeriodoInicio"].ToString()) ? default(DateTime) : DateTime.Parse(fila["PeriodoInicio"].ToString()),
                    PeriodoFin = string.IsNullOrWhiteSpace(fila["PeriodoFin"].ToString()) ? default(DateTime) : DateTime.Parse(fila["PeriodoFin"].ToString()),
                }
            };

            pago.Detalles.DescuentosAplicados = PagoDetalle.GetDescuentosAplicadosByIdPago(pago.Id);
            pago.Detalles.DescuentoValores = PagoDetalle.GetDescuentoValores(pago.Id);
            pago.Detalles.ConceptosAdicionales = PagoDetalle.GetConceptosAdicionalesByIdPago(pago.Id);

            return pago;
        }
    }
}



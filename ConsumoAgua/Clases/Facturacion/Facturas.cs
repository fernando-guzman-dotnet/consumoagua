using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SAPA.Clases.Facturacion
{
    public class Facturas
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        //public int IdVenta { get; set; }
        public String FolioUUID { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal Total { get; set; }
        public Decimal IVA { get; set; }
        public Decimal Ret_IVA { get; set; }
        public Decimal Ret_ISR { get; set; }
        public Decimal IEPS { get; set; }
        public String Referencia { get; set; }
        public String MetodoPago { get; set; }
        public String FormaPago { get; set; }
        public String Uso_CFDI { get; set; }
        public String Comentarios { get; set; }
        public int Folio_Factura { get; set; }
        public String Tipo_Comprobante { get; set; }

        public int IdEmisor { get; set; }
        public Boolean cancelada { get; set; }


        public static implicit operator Facturas(DataRow fila) 
        {
            Facturas obj = new Facturas();

            obj.Id = Convert.ToInt32(fila["Id"].ToString());
            obj.FolioUUID = fila["Folio_UUID"].ToString();
            obj.IdCliente = Convert.ToInt32(fila["IdCliente"].ToString());
            obj.Fecha = Convert.ToDateTime(fila["Fecha"].ToString());
            obj.SubTotal = Convert.ToDecimal(fila["Subtotal"].ToString());
            obj.Total = Convert.ToDecimal(fila["Total"].ToString());
            obj.IVA = Convert.ToDecimal(fila["IVA"].ToString());
            obj.Ret_IVA = Convert.ToDecimal(fila["Ret_IVA"].ToString());
            obj.Ret_ISR = Convert.ToDecimal(fila["Ret_ISR"].ToString());
            obj.IEPS = Convert.ToDecimal(fila["IEPS"].ToString());
            obj.Referencia = fila["Referencia"].ToString();
            obj.MetodoPago = fila["Metodo_Pago"].ToString();
            obj.FormaPago = fila["Forma_Pago"].ToString();
            obj.Uso_CFDI = fila["Uso_CFDI"].ToString();
            obj.Comentarios = fila["Comentarios"].ToString();
            obj.Folio_Factura = Convert.ToInt32(fila["Folio_Factura"].ToString());
            obj.Tipo_Comprobante = fila["Tipo_Comprobante"].ToString();

            return obj;
        }

        public static DataTable SelectFacturas(DateTime fecha_inicio, DateTime fecha_fin,int idsucursal, string nombre) 
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("SelectFacturas", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = idsucursal;
                    dat.SelectCommand.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = fecha_inicio;
                    dat.SelectCommand.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = fecha_fin;
                    dat.SelectCommand.Parameters.Add("@Cliente", SqlDbType.NVarChar).Value = nombre;
                    dat.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                {
                    _conexion.Actual.Close();
                }
            }
            return tabla;
        }

        public static DataTable FacturasSelect()  
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("FacturasSelect", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //dat.SelectCommand.Parameters.Add("@UUID", SqlDbType.NVarChar).Value = this.FolioUUID;
                    dat.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                {
                    _conexion.Actual.Close();
                }
            }
            return tabla;
        }

        public int FacturasIdInsert()  
        {
            int res = 0;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("FacturasIdInsert", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdFactura", SqlDbType.Int).Value = Folio_Factura;

                    res = int.Parse(cmd.ExecuteScalar().ToString());
                    //res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                {
                    _conexion.Actual.Close();
                }
            }
            return res;
        }

        public int FacturasIdDelete()  
        {
            int res = 0;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("FacturasIdDelete", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdFactura", SqlDbType.Int).Value = Folio_Factura;
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                {
                    _conexion.Actual.Close();
                }
            }
            return res;
        }

        public DataTable FacturasIdSelectMaxID()  
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("FacturasIdSelectMaxID", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //dat.SelectCommand.Parameters.Add("@UUID", SqlDbType.NVarChar).Value = this.FolioUUID;
                    dat.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                {
                    _conexion.Actual.Close();
                }
            }
            return tabla;
        }

        public DataTable SelectFacturasPorFolioUUID()  
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("SelectFacturasPorFolioUUID", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@UUID", SqlDbType.NVarChar).Value = FolioUUID;
                    dat.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                {
                    _conexion.Actual.Close();
                }
            }
            return tabla;
        }

        public DataTable SelectAmbienteFacturacion()  
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("SelectAmbienteFacturacion", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;

                    dat.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                {
                    _conexion.Actual.Close();
                }
            }
            return tabla;
        }

        public int Guardar()  
        {
            int res = 0;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("FacturasInsert", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FolioUUID", SqlDbType.NVarChar).Value = FolioUUID;
                    cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = IdCliente;
                    cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha;
                    cmd.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = SubTotal;
                    cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = Total;
                    cmd.Parameters.Add("@Metodo_Pago", SqlDbType.NVarChar).Value = MetodoPago;
                    cmd.Parameters.Add("@Forma_Pago", SqlDbType.NVarChar).Value = FormaPago;
                    cmd.Parameters.Add("@Referencia", SqlDbType.NVarChar).Value = Referencia;
                    cmd.Parameters.Add("@IEPS", SqlDbType.Decimal).Value = IEPS;
                    cmd.Parameters.Add("@IVA", SqlDbType.Decimal).Value = IVA;
                    cmd.Parameters.Add("@Ret_ISR", SqlDbType.Decimal).Value = Ret_ISR;
                    cmd.Parameters.Add("@Ret_IVA", SqlDbType.Decimal).Value = Ret_IVA;
                    cmd.Parameters.Add("@UsoCFDI", SqlDbType.NVarChar).Value = Uso_CFDI;
                    cmd.Parameters.Add("@Comentarios", SqlDbType.NVarChar).Value = Comentarios;
                    cmd.Parameters.Add("@Folio_Factura", SqlDbType.Int).Value = Folio_Factura;
                    cmd.Parameters.Add("@TipoComprobante", SqlDbType.NVarChar).Value = Tipo_Comprobante;

                    res = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    //res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                {
                    _conexion.Actual.Close();
                }
            }
            return res;
        }

        public int Eliminar()  
        {
            int res = 0;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("FacturasDelete", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                {
                    _conexion.Actual.Close();
                }
            }
            return res;
        }

        public DataTable FacturasSelectMaxFolioFactura()  
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("[FacturasSelectMaxFolioFactura]", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;

                    dat.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                {
                    _conexion.Actual.Close();
                }
            }
            return tabla;
        }

        public DataTable FacturasSelectMaxID()  
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("[FacturasSelectMaxID]", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //dat.SelectCommand.Parameters.Add("@Consulta", SqlDbType.Int).Value = Consulta;
                    dat.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                {
                    _conexion.Actual.Close();
                }
            }
            return tabla;
        }

        public DataTable FacturasSelectById()  
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("FacturasSelectById", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                    dat.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                {
                    _conexion.Actual.Close();
                }
            }
            return tabla;
        }
    }
}


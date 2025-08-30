using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SAPA.Clases.Facturacion
{
    public class Facturas_Detalles
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public String Codigo { get; set; }
        public String Descripcion { get; set; }
        public Decimal Cantidad { get; set; }
        public Decimal Precio_Unitario { get; set; }
        public Decimal Importe { get; set; }
        public Decimal Imp_traslado_iva { get; set; }
        public Decimal Imp_traslados_ieps { get; set; }
        public Decimal Imp_retencion_isr { get; set; }
        public Decimal Imp_retencion_iva { get; set; }
        public String Clave_Prod_Serv { get; set; }
        public String Clave_Unidad { get; set; }
        public String Unidad { get; set; }

        public int Guardar()  
        {
            int res = 0;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("GuardarFacturasDetalles", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdFactura", SqlDbType.Int).Value = IdFactura;
                    cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = IdProducto;
                    cmd.Parameters.Add("@Codigo", SqlDbType.NVarChar).Value = Codigo;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = Descripcion;
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = Cantidad;
                    cmd.Parameters.Add("@Precio_Unitario", SqlDbType.Decimal).Value = Precio_Unitario;
                    cmd.Parameters.Add("@Importe", SqlDbType.Decimal).Value = Importe;
                    cmd.Parameters.Add("@Imp_Traslado_IVA", SqlDbType.Decimal).Value = Imp_traslado_iva;
                    cmd.Parameters.Add("@Imp_Traslado_IEPS", SqlDbType.Decimal).Value = Imp_traslados_ieps;
                    cmd.Parameters.Add("@Imp_Retencion_IVA", SqlDbType.Decimal).Value = Imp_retencion_iva;
                    cmd.Parameters.Add("@Imp_Retencion_ISR", SqlDbType.Decimal).Value = Imp_retencion_isr;
                    cmd.Parameters.Add("@Clave_Prod_Serv", SqlDbType.NVarChar).Value = Clave_Prod_Serv;
                    cmd.Parameters.Add("@Clave_Unidad", SqlDbType.NVarChar).Value = Clave_Unidad;
                    cmd.Parameters.Add("@Unidad", SqlDbType.NVarChar).Value = Unidad;
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

        public DataTable SelectFacturaDetallesIDFactura()  
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("SelectFacturaDetallesIDFactura", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@IdFactura", SqlDbType.Int).Value = IdFactura;
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


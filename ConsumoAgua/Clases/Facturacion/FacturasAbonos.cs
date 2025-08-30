using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SAPA.Clases.Facturacion
{
    public class FacturasAbonos
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int IdFactura { get; set; }
        public int IdFactura_Abonada { get; set; }
        public Decimal Cantidad { get; set; }
        public String Forma_Pago { get; set; }
        public DateTime Fecha { get; set; }
        public Decimal Tipo_Cambio { get; set; }
        public String Moneda { get; set; }

        public int Guardar(int IdUsuario)  
        {
            int res = 0;
            try
            {
               _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("FacturasAbonosInsert", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdFactura", SqlDbType.Int).Value = IdFactura;
                    cmd.Parameters.Add("@IdFactura_Abonada", SqlDbType.Int).Value = IdFactura_Abonada;
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = Cantidad;
                    cmd.Parameters.Add("@Forma_Pago", SqlDbType.NVarChar).Value = Forma_Pago;
                    cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha;
                    cmd.Parameters.Add("@Moneda", SqlDbType.NVarChar).Value = Moneda;
                    cmd.Parameters.Add("@Tipo_Cambio", SqlDbType.Decimal).Value = Tipo_Cambio;

                    //u = new Usuarios_Log();
                    //u.IdUsuario = IdUsuario;
                    //u.Descripcion = "Insert Abonos: Id " + (int.Parse(AbonosSelect_MaxID().Rows[0]["ID"].ToString()) + 1) +
                    //                ", IdFactura - " + this.IdFactura +
                    //                ", IdFactura_Abonada - " + this.IdFactura_Abonada +
                    //                ", Cantidad - " + this.Cantidad +
                    //                ", Forma_Pago - " + this.Forma_Pago +
                    //                ", Fecha - " + this.Fecha +
                    //                ", Moneda - " + this.Moneda +
                    //                ", Tipo_Cambio - " + this.Tipo_Cambio;
                    //u.Guardar();

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

        public int Eliminar(int IdUsuario)  
        {
            int res = 0;
            try
            {
               _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("FacturasAbonosDeleteByIdFactura", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdFactura", SqlDbType.Int).Value = IdFactura;

                    //u = new Usuarios_Log();
                    //u.IdUsuario = IdUsuario;
                    //u.Descripcion = "Delete Abonos: IdFactura " + this.IdFactura;
                    //u.Guardar();

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

        public DataTable AbonosSelectMaxID()  
        {
            DataTable tabla = new DataTable();
            try
            {
               _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("FacturasAbonosSelectMaxID", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.Fill(tabla);
                }
            }
            catch
            {

            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return tabla;
        }

        public DataTable AbonosSelect_MaxID()  
        {
            DataTable tabla = new DataTable();
            try
            {
               _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("FacturasAbonosSelectMaxID", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.Fill(tabla);
                }
            }
            catch
            {

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

        public DataTable AbonosSelectByIdFactura()  
        {
            DataTable tabla = new DataTable();
            try
            {
               _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("FacturasAbonosSelectByIdFactura", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@IdFactura", SqlDbType.Int).Value = IdFactura;
                    dat.Fill(tabla);
                }
            }
            catch
            {

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


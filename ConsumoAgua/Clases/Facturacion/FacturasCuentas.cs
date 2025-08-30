using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SAPA.Clases.Facturacion
{
    public class FacturasCuentas
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int IdFactura { get; set; }
        public Decimal Abonado { get; set; }
        public Decimal Restante { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaPago { get; set; }
        public String TipoPago { get; set; }

        public int Guardar(int IdUsuario)  
        {
            int res = 0;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("FacturasCuentasInsert", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdFactura", SqlDbType.Int).Value = IdFactura;
                    cmd.Parameters.Add("@Abonado", SqlDbType.Decimal).Value = Abonado;
                    cmd.Parameters.Add("@Restante", SqlDbType.Decimal).Value = Restante;
                    cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha;
                    cmd.Parameters.Add("@FechaPago", SqlDbType.DateTime).Value = FechaPago;
                    cmd.Parameters.Add("@TipoPago", SqlDbType.NVarChar).Value = TipoPago;

                    //u = new Usuarios_Log();
                    //u.IdUsuario = IdUsuario;
                    //u.Descripcion = "Insert FacturasCuentas: Id " + (int.Parse(FacturasCuentasSelect_MaxID().Rows[0]["ID"].ToString()) + 1) +
                    //                ", IdFactura - " + this.IdFactura +
                    //                ", Abonado - " + this.Abonado +
                    //                ", Restante - " + this.Restante +
                    //                ", Fecha - " + this.Fecha +
                    //                ", FechaPago - " + this.FechaPago +
                    //                ", TipoPago - " + this.TipoPago;
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

        public int Actualizar(int IdUsuario)  
        {
            int res = 0;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("FacturasCuentasUpdateSaldo", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdFactura", SqlDbType.Int).Value = IdFactura;
                    cmd.Parameters.Add("@Abono", SqlDbType.Decimal).Value = Abonado;

                    //u = new Usuarios_Log();
                    //u.IdUsuario = IdUsuario;
                    //u.Descripcion = "Update FacturasCuentas: IdFactura " + this.IdFactura +
                    //                ", Abono - " + this.Abonado;
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

        public int FacturasCuentasUpdateSaldoCancelacion(int IdUsuario)  
        {
            int res = 0;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("FacturasCuentasUpdateSaldoCancelacion", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdFactura", SqlDbType.Int).Value = IdFactura;
                    cmd.Parameters.Add("@Abono", SqlDbType.Decimal).Value = Abonado;

                    //u = new Usuarios_Log();
                    //u.IdUsuario = IdUsuario;
                    //u.Descripcion = "Update FacturasCuentas Cancelacion: IdFactura " + this.IdFactura +
                    //                ", Abono - " + this.Abonado;
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

        public DataTable FacturasCuentasSelectMaxID()  
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("FacturasCuentasSelectMaxID", _conexion.Actual))
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

        public DataTable FacturasCuentasSelect_MaxID()  
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("FacturasCuentasSelectMaxID", _conexion.Actual))
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

        public DataTable FacturasCuentasSelectAbonoByIDFactura()  
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("FacturasCuentasSelectAbonoByIDFactura", _conexion.Actual))
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


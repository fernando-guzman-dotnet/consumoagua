using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SAPA.Clases.Facturacion
{
    public class FacturasPagosDetalles
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int IdComplemento { get; set; }
        public String Folio { get; set; }
        public Decimal ImpSaldoInsoluto { get; set; }
        public Decimal ImpSaldoAnt { get; set; }
        public Decimal ImpPagado { get; set; }
        public String Parcialidad { get; set; }
        public String MetodoPago { get; set; }
        public String Moneda { get; set; }
        public String IdDocumento { get; set; }

        public int Guardar(int IdUsuario)  
        {
            int res = 0;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("Complemento_PA_Detalles_Insert", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdComplemento", SqlDbType.Int).Value = IdComplemento;
                    cmd.Parameters.Add("@Folio", SqlDbType.NVarChar).Value = Folio;
                    cmd.Parameters.Add("@Imp_Saldo_Insoluto", SqlDbType.Decimal).Value = ImpSaldoInsoluto;
                    cmd.Parameters.Add("@Imp_Saldo_Anterior", SqlDbType.Decimal).Value = ImpSaldoAnt;
                    cmd.Parameters.Add("@Imp_Pagado", SqlDbType.Decimal).Value = ImpPagado;
                    cmd.Parameters.Add("@Parcialidad", SqlDbType.NVarChar).Value = Parcialidad;
                    cmd.Parameters.Add("@MetodoPago", SqlDbType.NVarChar).Value = MetodoPago;
                    cmd.Parameters.Add("@Moneda", SqlDbType.NVarChar).Value = Moneda;
                    cmd.Parameters.Add("@IdDocumento", SqlDbType.NVarChar).Value = IdDocumento;

                    //u = new Usuarios_Log();
                    //u.IdUsuario = IdUsuario;
                    //u.Descripcion = "Insert Complemento_PA: Id " + (int.Parse(Complemento_PA_Detalles_Select_MaxID().Rows[0]["ID"].ToString()) + 1) +
                    //                ", Folio - " + this.Folio +
                    //                ", IdComplemento - " + this.IdComplemento +
                    //                ", Imp_Saldo_Insoluto - " + this.ImpSaldoInsoluto +
                    //                ", Imp_Saldo_Anterior - " + this.ImpSaldoAnt +
                    //                ", ImpPagado - " + this.ImpPagado +
                    //                ", Parcialidad - " + this.Parcialidad +
                    //                ", MetodoPago - " + this.MetodoPago +
                    //                ", Moneda - " + this.Moneda +
                    //                ", IdDocumento - " + this.IdDocumento
                    //                ;
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

        public DataTable Complemento_PA_Detalles_SelectByIdComplemento()  
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("Complemento_PA_Detalles_SelectByIdComplemento", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@IdComplemento", SqlDbType.Int).Value = IdComplemento;
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

        public DataTable Complemento_PA_Detalles_SelectMaxID()  
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("Complemento_PA_Detalles_SelectMaxID", _conexion.Actual))
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

        public DataTable Complemento_PA_Detalles_Select_MaxID()  
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("Complemento_PA_Detalles_SelectMaxID", _conexion.Actual))
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
    }
}


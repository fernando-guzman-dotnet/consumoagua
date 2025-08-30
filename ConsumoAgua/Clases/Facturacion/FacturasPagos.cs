using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SAPA.Clases.Facturacion
{
    public class FacturasPagos
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int IdFactura { get; set; }
        public Decimal Monto { get; set; }
        public String MonedaP { get; set; }
        public String FormaPagoP { get; set; }
        public DateTime FechaPago { get; set; }

        public String cuenta_ordenante { get; set; }
        public String cuenta_Ordenante_RFC { get; set; }
        public String cuenta_beneficiaria { get; set; }
        public String cuenta_beneficiaria_RFC { get; set; }
        public String no_operacion { get; set; }
        public String Banco { get; set; }

        public int Guardar(int IdUsuario)  
        {
            int res = 0;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("Complemento_PA_Insert", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdFactura", SqlDbType.Int).Value = IdFactura;
                    cmd.Parameters.Add("@Monto", SqlDbType.Decimal).Value = Monto;
                    cmd.Parameters.Add("@Moneda", SqlDbType.NVarChar).Value = MonedaP;
                    cmd.Parameters.Add("@FormaPago", SqlDbType.NVarChar).Value = FormaPagoP;
                    cmd.Parameters.Add("@FechaPago", SqlDbType.DateTime).Value = FechaPago;
                    cmd.Parameters.Add("@Cta_Ordenante", SqlDbType.NVarChar).Value = cuenta_ordenante;
                    cmd.Parameters.Add("@Cta_Ordenante_RFC", SqlDbType.NVarChar).Value = cuenta_Ordenante_RFC;
                    cmd.Parameters.Add("@Cta_Beneficiaria", SqlDbType.NVarChar).Value = cuenta_beneficiaria;
                    cmd.Parameters.Add("@Cta_Beneficiaria_RFC", SqlDbType.NVarChar).Value = cuenta_beneficiaria_RFC;
                    cmd.Parameters.Add("@Numero_Operacion", SqlDbType.NVarChar).Value = no_operacion;
                    cmd.Parameters.Add("@Banco", SqlDbType.NVarChar).Value = Banco;

                    //u = new Usuarios_Log();
                    //u.IdUsuario = IdUsuario;
                    //u.Descripcion = "Insert Complemento_PA: Id " + (int.Parse(Complemento_PA_Select_MaxID().Rows[0]["ID"].ToString()) + 1) +
                    //                ", IdFactura - " + this.IdFactura +
                    //                ", Monto - " + this.Monto +
                    //                ", Moneda - " + this.MonedaP +
                    //                ", FormaPago - " + this.FormaPagoP +
                    //                ", FechaPago - " + this.FechaPago
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

        public DataTable Complemento_PA_SelectByIdFactura()  
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("Complemento_PA_SelectByIdFactura", _conexion.Actual))
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

        public DataTable Complemento_PA_SelectMaxID()  
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("Complemento_PA_SelectMaxID", _conexion.Actual))
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

        public DataTable Complemento_PA_Select_MaxID()  
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("Complemento_PA_SelectMaxID", _conexion.Actual))
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
                    //_conexion.Actual.Close();
                }

            }
            return tabla;
        }
    }
}


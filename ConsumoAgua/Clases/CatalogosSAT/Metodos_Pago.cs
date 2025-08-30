using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SAPA.Clases.CatalogosSAT
{
    public class Metodos_Pago
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }
        public String Clave_SAT { get; set; }

        public static implicit operator Metodos_Pago(DataRow fila)
        {
            Metodos_Pago obj = new Metodos_Pago();

            obj.Id = Convert.ToInt32(fila["Id"].ToString());
            obj.Descripcion = fila["Descripcion"].ToString();
            obj.Clave_SAT = fila["Clave_SAT"].ToString();

            return obj;
        }

        public static List<Metodos_Pago> MetodosPagoSATSelect_()
        {
            DataTable tabla = new DataTable();
            List<Metodos_Pago> listobj = new List<Metodos_Pago>();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("MetodosPagoSATSelect", Conexion.ActualTokens))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in tabla.Rows)
                        {
                            Metodos_Pago obj = new Metodos_Pago();
                            obj = item;
                            listobj.Add(obj);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (Conexion.ActualTokens.State != System.Data.ConnectionState.Closed)
                {
                    Conexion.ActualTokens.Close();
                }
            }
            return listobj;
        }

        public static DataTable MetodosPagoSATSelect()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("MetodosPagoSATSelect", Conexion.ActualTokens))
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
                if (Conexion.ActualTokens.State != System.Data.ConnectionState.Closed)
                {
                    Conexion.ActualTokens.Close();
                }
            }
            return tabla;
        }

        public DataTable MetodosPagoSATSelectByClaveSAT()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("MetodosPagoSATSelectByClaveSAT", Conexion.ActualTokens))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@Clave_SAT", SqlDbType.NVarChar).Value = this.Clave_SAT;
                    dat.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (Conexion.ActualTokens.State != System.Data.ConnectionState.Closed)
                {
                    Conexion.ActualTokens.Close();
                }
            }
            return tabla;
        }

        public DataTable MetodosPagoSATSelectByID()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("MetodosPagoSATSelectByID", Conexion.ActualTokens))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = this.Id;
                    dat.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (Conexion.ActualTokens.State != System.Data.ConnectionState.Closed)
                {
                    Conexion.ActualTokens.Close();
                }
            }
            return tabla;
        }

        //public DataTable SelectMetodosPago_SAT()
        //{
        //    DataTable tabla = new DataTable();
        //    try
        //    {
        //        using (SqlDataAdapter dat = new SqlDataAdapter("SelectMetodosPago_SAT", Conexion.Actual))
        //        {
        //            dat.SelectCommand.CommandType = CommandType.StoredProcedure;
        //            dat.Fill(tabla);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        if (Conexion.Actual.State != System.Data.ConnectionState.Closed)
        //        {
        //            Conexion.Actual.Close();
        //        }
        //    }
        //    return tabla;
        //}



        ////select para mostrar datos de los abonos
        //public DataTable SelectMetodosPago_SAT_PorClave()
        //{
        //    DataTable tabla = new DataTable();
        //    try
        //    {
        //        using (SqlDataAdapter dat = new SqlDataAdapter("SelectMetodosPago_SAT_PorClave", Conexion.Actual))
        //        {
        //            dat.SelectCommand.CommandType = CommandType.StoredProcedure;
        //            dat.SelectCommand.Parameters.Add("@Clave_SAT", SqlDbType.NVarChar).Value = this.Clave_SAT;
        //            dat.Fill(tabla);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        if (Conexion.Actual.State != System.Data.ConnectionState.Closed)
        //        {
        //            Conexion.Actual.Close();
        //        }
        //    }
        //    return tabla;
        //}

        ////select para mostrar datos de los abonos
        //public DataTable SelectMetodosPago_SAT_PorID()
        //{
        //    DataTable tabla = new DataTable();
        //    try
        //    {
        //        using (SqlDataAdapter dat = new SqlDataAdapter("SelectMetodosPago_SAT_PorID", Conexion.Actual))
        //        {
        //            dat.SelectCommand.CommandType = CommandType.StoredProcedure;
        //            dat.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = this.Id;
        //            dat.Fill(tabla);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        if (Conexion.Actual.State != System.Data.ConnectionState.Closed)
        //        {
        //            Conexion.Actual.Close();
        //        }
        //    }
        //    return tabla;
        //}


    }
}


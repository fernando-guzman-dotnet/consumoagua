using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SAPA.Clases.CatalogosSAT
{
    public class Formas_Pago
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }
        public String Clave_SAT { get; set; }

        public static implicit operator Formas_Pago(DataRow fila)
        {
            Formas_Pago obj = new Formas_Pago();

            obj.Id = Convert.ToInt32(fila["Id"].ToString());
            obj.Descripcion = fila["Descripcion"].ToString();
            obj.Clave_SAT = fila["Clave_SAT"].ToString();

            return obj;
        }

        public static List<Formas_Pago> FormasPagoSATSelect_()
        {
            DataTable tabla = new DataTable();
            List<Formas_Pago> listobj = new List<Formas_Pago>();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("FormasPagoSATSelect", Conexion.ActualTokens))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in tabla.Rows)
                        {
                            Formas_Pago obj = new Formas_Pago();
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

        public static DataTable FormasPagoSATSelect()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("FormasPagoSATSelect", Conexion.ActualTokens))
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

        public DataTable FormasPagoSATSelectByClaveSAT()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("FormasPagoSATSelectByClaveSAT", Conexion.ActualTokens))
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

        public DataTable FormasPagoSATSelectByID()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("FormasPagoSATSelectByID", Conexion.ActualTokens))
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

        //public DataTable SelectFormasPagoSAT()
        //{
        //    DataTable tabla = new DataTable();
        //    try
        //    {
        //        using (SqlDataAdapter dat = new SqlDataAdapter("SelectFormasPagoSAT", Conexion.Actual))
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
        //public DataTable SelectFormasPagoSATPorClave()
        //{
        //    DataTable tabla = new DataTable();
        //    try
        //    {
        //        using (SqlDataAdapter dat = new SqlDataAdapter("SelectFormasPagoSATPorClave", Conexion.Actual))
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
        //public DataTable SelectFormasPagoSATPorID()
        //{
        //    DataTable tabla = new DataTable();
        //    try
        //    {
        //        using (SqlDataAdapter dat = new SqlDataAdapter("SelectFormasPagoSATPorID", Conexion.Actual))
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


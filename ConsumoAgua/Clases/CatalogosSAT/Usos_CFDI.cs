using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SAPA.Clases.CatalogosSAT
{
    public class Usos_CFDI
    {
        public int Id { get; set; }
        public String descripcion { get; set; }
        public String Clave_SAT { get; set; }

        public static implicit operator Usos_CFDI(DataRow fila)
        {
            Usos_CFDI obj = new Usos_CFDI();

            obj.Id = Convert.ToInt32(fila["Id"].ToString());
            obj.descripcion = fila["Descripcion"].ToString();
            obj.Clave_SAT = fila["Clave_SAT"].ToString();

            return obj;
        }

        public static List<Usos_CFDI> UsosCFDISelect_()
        {
            DataTable tabla = new DataTable();
            List<Usos_CFDI> listobj = new List<Usos_CFDI>();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("UsosCFDISelect", Conexion.ActualTokens))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.Fill(tabla);

                    DataView dv = tabla.DefaultView;
                    dv.Sort = "descripcion";
                    tabla = dv.ToTable();

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in tabla.Rows)
                        {
                            Usos_CFDI obj = new Usos_CFDI();
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
                if (Conexion.ActualTokens.State != ConnectionState.Closed)
                {
                    Conexion.ActualTokens.Close();
                }
            }
            return listobj;
        }

        public static DataTable UsosCFDISelect()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("UsosCFDISelect", Conexion.ActualTokens))
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
                if (Conexion.ActualTokens.State != ConnectionState.Closed)
                {
                    Conexion.ActualTokens.Close();
                }
            }
            return tabla;
        }

        public DataTable UsosCFDISelectByClaveSAT()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("UsosCFDISelectByClaveSAT", Conexion.ActualTokens))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@Clave_SAT", SqlDbType.NVarChar).Value = Clave_SAT;
                    dat.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (Conexion.ActualTokens.State != ConnectionState.Closed)
                {
                    Conexion.ActualTokens.Close();
                }
            }
            return tabla;
        }

        public DataTable UsosCFDISelectByID()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("UsosCFDISelectByID", Conexion.ActualTokens))
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
                if (Conexion.ActualTokens.State != ConnectionState.Closed)
                {
                    Conexion.ActualTokens.Close();
                }
            }
            return tabla;
        }

        //public DataTable SelectUsosCFDI()
        //{
        //    DataTable tabla = new DataTable();
        //    try
        //    {
        //        using (SqlDataAdapter dat = new SqlDataAdapter("SelectUsosCFDI", Conexion.Actual))
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
        //public DataTable SelectUsosCFDIPorClaveSAT()
        //{
        //    DataTable tabla = new DataTable();
        //    try
        //    {
        //        using (SqlDataAdapter dat = new SqlDataAdapter("SelectUsosCFDIPorClaveSAT", Conexion.Actual))
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
        //public DataTable SelectUsosCFDIPorID()
        //{
        //    DataTable tabla = new DataTable();
        //    try
        //    {
        //        using (SqlDataAdapter dat = new SqlDataAdapter("SelectUsosCFDIPorID", Conexion.Actual))
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


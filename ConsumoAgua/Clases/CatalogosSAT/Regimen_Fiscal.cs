using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SAPA.Clases.CatalogosSAT
{
    public class Regimen_Fiscal
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }
        public String Clave_SAT { get; set; }
        public string Descripcion_con_clave { get; set; }
        public Boolean PeronsaMoral { get; set; }
        public String Tipo { get; set; }

        public static implicit operator Regimen_Fiscal(DataRow fila)
        {
            Regimen_Fiscal obj = new Regimen_Fiscal();

            obj.Id = Convert.ToInt32(fila["Id"].ToString());
            obj.Descripcion = fila["Descripcion"].ToString();
            obj.Clave_SAT = fila["Clave_SAT"].ToString();
            obj.Descripcion_con_clave = "(" + obj.Clave_SAT + ") - " + obj.Descripcion + " (" + fila["Tipo"].ToString() + ")";
            obj.PeronsaMoral = Convert.ToBoolean(fila["PersonaMoral"].ToString());

            return obj;
        }

        public static List<Regimen_Fiscal> RegimeFiscalSelect_()
        {
            DataTable tabla = new DataTable();
            List<Regimen_Fiscal> listobj = new List<Regimen_Fiscal>();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("RegimenFiscalSelect", Conexion.ActualTokens))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in tabla.Rows)
                        {
                            Regimen_Fiscal obj = new Regimen_Fiscal();
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

        public static DataTable RegimeFiscalSelect()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("RegimenFiscalSelect", Conexion.ActualTokens))
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

        public DataTable RegimenFiscalSelectByClaveSAT()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("RegimenFiscalSelectByClaveSAT", Conexion.ActualTokens))
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

        public DataTable RegimenFiscalSelectByID()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("RegimenFiscalSelectByID", Conexion.ActualTokens))
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

        //public DataTable SelectRegimenesFiscales()
        //{
        //    DataTable tabla = new DataTable();
        //    try
        //    {
        //        using (SqlDataAdapter dat = new SqlDataAdapter("SelectRegimenesFiscales", Conexion.Actual))
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
        //public DataTable SelectRegimenesFiscalesPorClave()
        //{
        //    DataTable tabla = new DataTable();
        //    try
        //    {
        //        using (SqlDataAdapter dat = new SqlDataAdapter("SelectRegimenesFiscalesPorClave", Conexion.Actual))
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
        //public DataTable SelectRegimenesFiscalesPorID()
        //{
        //    DataTable tabla = new DataTable();
        //    try
        //    {
        //        using (SqlDataAdapter dat = new SqlDataAdapter("SelectRegimenesFiscalesPorID", Conexion.Actual))
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


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPA.Clases.CatalogosSAT
{
    public class CodigosPostales
    {
        public int Id { get; set; }
        public String CP { get; set; }
        public String Estado { get; set; }
        public String Municipio { get; set; }
        public String Localidad { get; set; }

        public static DataTable CodigosPostalesSelect()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("CodigosPostalesSelect", Conexion.ActualTokens))
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

        public static List<CodigosPostales> CodigosPostalesSelect_()
        {
            DataTable tabla = new DataTable();
            List<CodigosPostales> listobj = new List<CodigosPostales>();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("CodigosPostalesSelect", Conexion.ActualTokens))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in tabla.Rows)
                        {
                            CodigosPostales obj = new CodigosPostales();
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

        //public DataTable BancosSelectByIdUsuario(int idusuario)
        //{
        //    DataTable tabla = new DataTable();
        //    try
        //    {
        //        using (SqlDataAdapter dat = new SqlDataAdapter("BancosSelectByIdUsuario", Conexion.Actual))
        //        {
        //            dat.SelectCommand.CommandType = CommandType.StoredProcedure;
        //            dat.SelectCommand.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idusuario;
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

        public static implicit operator CodigosPostales(DataRow fila)
        {
            CodigosPostales obj = new CodigosPostales();

            obj.Id = Convert.ToInt32(fila["Id"].ToString());
            obj.CP = fila["CP"].ToString();
            obj.Estado = fila["Estado"].ToString();
            obj.Municipio = fila["Municipio"].ToString();
            obj.Localidad = fila["Localidad"].ToString();

            return obj;
        }
    }
}


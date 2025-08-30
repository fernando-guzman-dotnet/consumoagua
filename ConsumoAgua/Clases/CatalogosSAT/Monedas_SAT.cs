using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SAPA.Clases.CatalogosSAT
{
    public class Monedas_SAT
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public String Clave_SAT { get; set; }
        public String Descripcion { get; set; }

        public static implicit operator Monedas_SAT(DataRow fila)
        {
            Monedas_SAT obj = new Monedas_SAT();

            obj.Id = Convert.ToInt32(fila["Id"].ToString());
            obj.Descripcion = fila["Descripcion"].ToString();
            obj.Clave_SAT = fila["Clave_SAT"].ToString();

            return obj;
        }

        public static DataTable MonedasSATSelect()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("MonedasSATSelect", Conexion.ActualTokens))
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

        public static DataTable SelectMonedasSAT()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("MonedasSATSelect", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.Fill(tabla);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == -2)
                    MessageBox.Show("El tiempo de espera para conectarse al servidor se ha agotado, revise su conexión a internet o contacte a su proveedor del sistema.",
                        "Problemas de conexión al servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ex.Number == -1)
                    MessageBox.Show("No ha sido posible conectarse al servidor, intente acceder más tarde o contacte a su proveedor del sistema.",
                        "Sin conexión al servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al acceder a los datos del servidor.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);//ex.Message);
            }
            finally
            {
                if (_conexion.Actual.State != System.Data.ConnectionState.Closed)
                {
                    _conexion.Actual.Close();
                }
            }
            return tabla;
        }


        #region procs clave y Id
        public DataTable MonedasSATSelectByClave()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("MonedasSATSelectByClave", Conexion.ActualTokens))
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

        public DataTable MonedasSATSelectByID()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("MonedasSATSelectByID", Conexion.ActualTokens))
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
        #endregion


        public static List<Monedas_SAT> SelectMonedasSAT_()
        {
            DataTable tabla = new DataTable();
            List<Monedas_SAT> listobj = new List<Monedas_SAT>();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("[MonedasSATSelect]", Conexion.ActualTokens))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in tabla.Rows)
                        {
                            Monedas_SAT obj = new Monedas_SAT();
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
    }
}


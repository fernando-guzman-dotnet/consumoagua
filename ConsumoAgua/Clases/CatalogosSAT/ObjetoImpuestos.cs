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
    public class ObjetoImpuestos
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }
        public String Clave_SAT { get; set; }

        public static DataTable ObjetoImpuestosSelect()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("ObjetoImpuestosSelect", Conexion.ActualTokens))
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

        public static List<ObjetoImpuestos> ObjetoImpuestosSelect_()
        {
            DataTable tabla = new DataTable();
            List<ObjetoImpuestos> listobj = new List<ObjetoImpuestos>();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("ObjetoImpuestosSelect", Conexion.ActualTokens))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in tabla.Rows)
                        {
                            ObjetoImpuestos obj = new ObjetoImpuestos();
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

        public static implicit operator ObjetoImpuestos(DataRow fila)
        {
            ObjetoImpuestos obj = new ObjetoImpuestos();

            obj.Id = Convert.ToInt32(fila["Id"].ToString());
            obj.Descripcion = fila["Descripcion"].ToString();
            obj.Clave_SAT = fila["Clave_SAT"].ToString();

            return obj;
        }
    }
}


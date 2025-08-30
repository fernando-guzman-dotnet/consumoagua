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
    public class Motivo_Cancelacion
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }
        public String Clave_SAT { get; set; }

        public static DataTable MotivosCancelacionesSelect()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("MotivosCancelacionesSelect", Conexion.ActualTokens))
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
                if (Conexion.ActualTokens.State != System.Data.ConnectionState.Closed)
                {
                    Conexion.ActualTokens.Close();
                }
            }
            return tabla;
        }

        public static List<Motivo_Cancelacion> MotivosCancelacionesSelect_()
        {
            DataTable tabla = new DataTable();
            List<Motivo_Cancelacion> listobj = new List<Motivo_Cancelacion>();
            try
            {
                using (SqlDataAdapter dat = new SqlDataAdapter("MotivosCancelacionesSelect", Conexion.ActualTokens))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in tabla.Rows)
                        {
                            Motivo_Cancelacion obj = new Motivo_Cancelacion();
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

        public static implicit operator Motivo_Cancelacion(DataRow fila)
        {
            Motivo_Cancelacion obj = new Motivo_Cancelacion();

            obj.Id = Convert.ToInt32(fila["Id"].ToString());
            obj.Descripcion = fila["Descripcion"].ToString();
            obj.Clave_SAT = fila["Clave_SAT"].ToString();

            return obj;
        }
    }
}


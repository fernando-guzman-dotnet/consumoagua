using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAPA.Clases;

namespace Clases
{

    public class FormaPago
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public string Descripcion { get; set; }


        public static List<FormaPago> GetFormasPago()
        {
            DataTable tabla = new DataTable();
            List<FormaPago> lista = new List<FormaPago>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getFormasPago", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            FormaPago formaPago = new FormaPago();
                            formaPago = fila;
                            lista.Add(formaPago);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetFormasPago - " + ex.Message, "Clase FormaPago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        } 

        public static implicit operator FormaPago(DataRow fila)
        {
            FormaPago formaPago = new FormaPago
            {
                Id = int.Parse(fila["Id"].ToString()),
                Descripcion = fila["Descripcion"].ToString(),
            };

            return formaPago;
        }
    }
}


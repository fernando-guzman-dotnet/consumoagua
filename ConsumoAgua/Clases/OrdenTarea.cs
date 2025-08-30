using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPA.Clases
{

    public class OrdenTarea
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int IdOrdenTrabajo { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        public bool Agregar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addOrdenTarea", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdOrdenTrabajo", IdOrdenTrabajo);
                    cmd.Parameters.AddWithValue("@Fecha", Fecha);
                    cmd.Parameters.AddWithValue("@Descripcion", Descripcion);

                    Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase OrdenTarea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregado;
        }


        public static List<OrdenTarea> GetOrdenTareas(int idOrdenTrabajo)
        {
            DataTable tabla = new DataTable();
            List<OrdenTarea> lista = new List<OrdenTarea>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getOrdenTareas", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@IdOrdenTrabajo", idOrdenTrabajo);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            OrdenTarea ordenTarea = fila;
                            lista.Add(ordenTarea);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetOrdenTareas - " + ex.Message, "Clase OrdenTarea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }


        public static implicit operator OrdenTarea(DataRow fila)
        {
            OrdenTarea ordenTarea = new OrdenTarea
            {
                Id = int.Parse(fila["Id"].ToString()),
                IdOrdenTrabajo = int.Parse(fila["IdOrdenTrabajo"].ToString()),
                Fecha = DateTime.Parse(fila["Fecha"].ToString()),
                Descripcion = fila["Descripcion"].ToString()
            };

            return ordenTarea;
        }
    }
}


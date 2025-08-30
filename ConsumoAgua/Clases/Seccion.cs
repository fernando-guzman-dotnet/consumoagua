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

    public class Seccion
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public bool Guardar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addSeccion", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", Descripcion);

                    this.Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("addSeccion - " + ex.Message, "Clase SeccionDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregado;
        }

        public bool Eliminar()
        {
            bool eliminada = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("deleteSeccion", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idSeccion", this.Id);
                    eliminada = cmd.ExecuteNonQuery() > 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("deleteSeccion - " + ex.Message, "Clase SeccionDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminada;
        }

        public static List<Seccion> GetSecciones()
        {
            DataTable tabla = new DataTable();
            List<Seccion> lista = new List<Seccion>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getSecciones", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Seccion seccion = new Seccion();
                            seccion = fila;
                            lista.Add(seccion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getSecciones - " + ex.Message, "Clase SeccionDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public bool Actualizar()
        {
            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("updateSeccion", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", this.Descripcion);
                    cmd.Parameters.AddWithValue("@idSeccion", this.Id);
                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("updateSeccion - " + ex.Message, "Clase SeccionDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public static implicit operator Seccion(DataRow fila)
        {
            Seccion seccion = new Seccion
            {
                Id = int.Parse(fila["IdSeccion"].ToString()),
                Descripcion = fila["Descripcion"].ToString()
            };

            return seccion;
        }

    }
}



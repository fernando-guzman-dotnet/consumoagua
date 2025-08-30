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
    public class Localidad
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public string Nombre { get; set; }

        public bool Agregar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addLocalidad", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);

                    agregado = Convert.ToInt32(cmd.ExecuteScalar().ToString()) > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase Localidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregado;
        }


        public bool Actualizar()
        {
            bool actualizar = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("updateLocalidad", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 150).Value = this.Nombre;
                    cmd.Parameters.Add("@IdLocalidad", SqlDbType.Int).Value = this.Id;

                    actualizar = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Actualizar - " + ex.Message, "Clase Localidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizar;
        }

        public static List<Localidad> GetLocalidades()
        {
            DataTable tabla = new DataTable();
            List<Localidad> lista = new List<Localidad>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getLocalidades", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Localidad localidad = new Localidad();
                            localidad = fila;
                            lista.Add(localidad);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetLocalidades - " + ex.Message, "Clase Localidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static List<Localidad> GetLocalidadesAsociadas(int idMunicipio)
        {
            DataTable tabla = new DataTable();
            List<Localidad> lista = new List<Localidad>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("[getLocalidadesAsignadasMunicipio]", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@idMunicipio", idMunicipio);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Localidad localidad = new Localidad();
                            localidad = fila;
                            lista.Add(localidad);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetLocalidades - " + ex.Message, "Clase Localidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static bool EliminarLocalidadesPrevias(int idMunicipio)
        {
            bool eliminadas = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("[deleteLocalidadesPrevias]", _conexion.Actual))
                {
                    cmd.Parameters.AddWithValue("@idMunicipio", idMunicipio);
                    cmd.CommandType = CommandType.StoredProcedure;
                    eliminadas = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EliminarLocalidadesPrevias - " + ex.Message, "Clase Localidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminadas;
        }

        public bool AsociarMunicipio(int idMunicipio)
        {
            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("[asociarMunicipioLocalidad]", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idMunicipio", idMunicipio);
                    cmd.Parameters.AddWithValue("@idLocalidad", this.Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AsociarMunicipio - " + ex.Message, "Clase Localidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }


        public static implicit operator Localidad(DataRow fila)
        {
            Localidad localidad = new Localidad()
            {
                Id = int.Parse(fila["Id"].ToString()),
                Nombre = fila["Nombre"].ToString()
            };

            return localidad;
        }

    }
}


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPA.Clases
{
    public class Municipio
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

                using (SqlCommand cmd = new SqlCommand("addMunicipio", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);

                    agregado = Convert.ToInt32(cmd.ExecuteScalar().ToString()) > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase Municipio", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("updateMunicipio", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 150).Value = this.Nombre;
                    cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int).Value = this.Id;

                    actualizar = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Actualizar - " + ex.Message, "Clase Municipio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizar;
        }

        public static List<Municipio> GetMunicipios()
        {
            DataTable tabla = new DataTable();
            List<Municipio> lista = new List<Municipio>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getMunicipios", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Municipio municipio = new Municipio();
                            municipio = fila;
                            lista.Add(municipio);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetMunicipios - " + ex.Message, "Clase Municipio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static List<Municipio> GetMunicipiosAsociados(int idEstado)
        {
            DataTable tabla = new DataTable();
            List<Municipio> lista = new List<Municipio>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("[getMunicipiosAsignadosEstado]", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@idEstado", idEstado);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Municipio municipio = new Municipio();
                            municipio = fila;
                            lista.Add(municipio);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetMunicipiosAsociados - " + ex.Message, "Clase Municipio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }


        public static bool EliminarMunicipiosPrevios(int idEstado)
        {
            bool eliminadas = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("deleteMunicipiosPrevios", _conexion.Actual))
                {
                    cmd.Parameters.AddWithValue("@idEstado", idEstado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    eliminadas = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EliminarMunicipiosPrevios - " + ex.Message, "Clase Municipio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminadas;
        }

        public bool AsociarEstado(int estadoId)
        {
            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("[asociarMunicipiosEstado]", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idEstado", estadoId);
                    cmd.Parameters.AddWithValue("@idMunicipio", this.Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AsociarEstado - " + ex.Message, "Clase Municipio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public static implicit operator Municipio(DataRow fila)
        {
            Municipio municipio = new Municipio()
            {
                Id = int.Parse(fila["Id"].ToString()),
                Nombre = fila["Nombre"].ToString()
            };

            return municipio;
        }
    }
}


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
    public class Colonia
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }

        public bool Agregar()
        {
            bool agregado = false;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("addColonia", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                    cmd.Parameters.AddWithValue("@Codigo", this.Codigo);
                    this.Id = int.Parse(cmd.ExecuteScalar().ToString());

                    agregado = this.Id > 0;

                    // TODO: Llena un Bitacora.EmpleadoLogInsert FUERA de aquí (Colonia "nombre" (ID) <accion hecha>) (lleva de parametro el empleado actual)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("addColonia - " + ex.Message, "Clase Colonia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregado;
        }

        public static List<Colonia> GetColonias()
        {
            List<Colonia> lista = new List<Colonia>();
            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("getColonias", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Colonia colonia = new Colonia();
                            colonia = fila;

                            lista.Add(colonia);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getColonias - " + ex.Message, "Clase Colonia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }


        public static List<Calle> GetCallesAsociadas(int idColonia)
        {
            List<Calle> lista = new List<Calle>();

            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("getCallesAsociadas", _conexion.Actual))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@idColonia", idColonia);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Calle calle = new Calle();
                            calle = ToCalle(fila);
                            lista.Add(calle);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetCallesAsociadas - " + ex.Message, "Clase SectorDAO", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        private static Calle ToCalle(DataRow fila)
        {
            Calle calle = new Calle()
            {
                Id = int.Parse(fila["Id"].ToString()),
                Codigo = int.Parse(fila["Codigo"].ToString()),
                Descripcion = fila["Descripcion"].ToString(),
                CodigoPostal = fila["CodigoPostal"].ToString()
            };

            return calle;
        }


        public bool Actualizar()
        {
            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("updateColonia", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                    cmd.Parameters.AddWithValue("@Codigo", this.Codigo);
                    cmd.Parameters.Add("@idColonia", SqlDbType.Int).Value = this.Id;
                    actualizado = cmd.ExecuteNonQuery() > 0;

                    // TODO: Llena un Bitacora.EmpleadoLogInsert FUERA de aquí (Colonia "nombre" (ID) <accion hecha>) (lleva de parametro el empleado actual)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("updateColonia - " + ex.Message, "Clase Colonia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;

        }

        public bool Eliminar()
        {
            bool eliminado = false;
            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("deleteColonia", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idColonia", SqlDbType.Int).Value = this.Id;
                    eliminado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("deleteColonia - " + ex.Message, "Clase Colonia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminado;
        }

        public bool TieneCalleAsignada(int idCalle = 0)
        {
            
            bool resultados = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("getColoniasAsignadasCalle", _conexion.Actual))
                {
                    DataTable tabla = new DataTable();

                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.Add("@idColonia", SqlDbType.Int).Value = this.Id;
                    adapter.SelectCommand.Parameters.Add("@idCalle", SqlDbType.Int).Value = idCalle;
                    adapter.Fill(tabla);

                    resultados = tabla.Rows.Count > 0;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TieneCalleAsignada - " + ex.Message, "Clase Colonia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return resultados;
        }


        public static implicit operator Colonia(DataRow fila)
        {
            Colonia colonia = new Colonia
            {
                Id = int.Parse(fila["IdColonia"].ToString()),
                Codigo = int.Parse(fila["Codigo"].ToString()),
                Descripcion = fila["Descripcion"].ToString(),
            };

            return colonia;
        }


        public bool EliminarCallesPrevias(int idColonia)
        {
            bool eliminadas = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("deleteCallesPrevias", _conexion.Actual))
                {
                    cmd.Parameters.AddWithValue("@idColonia", idColonia);
                    cmd.CommandType = CommandType.StoredProcedure;
                    eliminadas = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EliminarCallesPrevias - " + ex.Message, "Clase Calle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminadas;
        }

        public static bool AsociarCalle(int IdColonia, Calle calle)
        {
            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("asociarCalleColonia", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idColonia", IdColonia);
                    cmd.Parameters.AddWithValue("@idCalle", calle.Id);
                    cmd.Parameters.AddWithValue("@codigoPostal", calle.CodigoPostal ?? SqlString.Null);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AsociarCalle - " + ex.Message, "Clase Calle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public static List<Colonia> GetColoniasAsociadas(int idLocalidad)
        {
            List<Colonia> lista = new List<Colonia>();
            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("[getColoniasAsignadasLocalidad]", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@idLocalidad", idLocalidad);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Colonia colonia = new Colonia();
                            colonia = fila;

                            lista.Add(colonia);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetColoniasAsociadas - " + ex.Message, "Clase Colonia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static bool EliminarColoniasPrevias(int idLocalidad)
        {
            bool eliminadas = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("[deleteColoniasPreviasLocalidad]", _conexion.Actual))
                {
                    cmd.Parameters.AddWithValue("@idLocalidad", idLocalidad);
                    cmd.CommandType = CommandType.StoredProcedure;
                    eliminadas = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EliminarColoniasPrevias - " + ex.Message, "Clase Colonia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminadas;
        }

        public bool AsociarLocalidad(int idLocalidad)
        {
            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("[asociarColoniasLocalidades]", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idLocalidad", idLocalidad);
                    cmd.Parameters.AddWithValue("@idColonia", this.Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AsociarLocalidad - " + ex.Message, "Clase Colonia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }
    }
}


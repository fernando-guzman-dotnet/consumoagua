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
    public class Sector
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public static List<Sector> GetSectores()
        {
            List<Sector> lista = new List<Sector>();
            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("getSectores", _conexion.Actual);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.Fill(tabla);

                if (tabla.Rows.Count > 0)
                {
                    foreach (DataRow fila in tabla.Rows)
                    {
                        Sector sector = new Sector();
                        sector = fila;
                        lista.Add(sector);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getSectores - " + ex.Message, "Clase SectorDAO", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public bool Guardar()
        {
            bool agregado = false;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("addSector", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", this.Descripcion);
                    agregado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("addSector - " + ex.Message, "Clase SectorDAO", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return agregado;
        }

        public  bool Eliminar()
        {
            bool eliminado = false;
            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("deleteSector", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idSector", SqlDbType.Int).Value = this.Id;
                    eliminado = cmd.ExecuteNonQuery() > 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sector_Delete - " + ex.Message, "Clase SectorDAO", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminado;
        }

        public static List<Colonia> GetColoniasDisponibles(int idSector)
        {
            List<Colonia> lista = new List<Colonia>();
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getColoniasDisponiblesSector", _conexion.Actual))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@idSector", idSector);
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
                MessageBox.Show("getColoniasDisponibles - " + ex.Message, "Clase SectorDAO", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static List<Colonia> GetColoniasAsociadas(int idSector)
        {
            List<Colonia> lista = new List<Colonia>();
            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("getColoniasAsociadasSector", _conexion.Actual))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@idSector", idSector);
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
                MessageBox.Show("getColoniasAsociadas - " + ex.Message, "Clase SectorDAO", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static bool EliminarColoniasPrevias(int idSector)
        {
            bool eliminadas = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("deleteColoniasPrevias", _conexion.Actual))
                {
                    cmd.Parameters.AddWithValue("@idSector", idSector);
                    cmd.CommandType = CommandType.StoredProcedure;
                    eliminadas = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TieneContrato - " + ex.Message, "Clase Sector", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminadas;
        }

        public static bool AsociarColonia(int idSector, Colonia colonia)
        {
            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("asociarColoniaASector", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idSector", idSector);
                    cmd.Parameters.AddWithValue("@idColonia", colonia.Id);
                    cmd.Parameters.Add("@codigoPostal", SqlDbType.Int).Value = DBNull.Value;

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TieneContrato - " + ex.Message, "Clase Sector", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public bool Actualizar()
        {
            bool actualizado = false;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("updateSector", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idSector", SqlDbType.Int).Value = Id;
                    cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                    actualizado = cmd.ExecuteNonQuery() > 0;

                    // TODO: Agregar a la bitacora del empleado

                    /*if (aux > 0)
                    {
                        Bitacora.EmpleadoLogInsert(currentEmpleado.Id,
                            "Sector actualizado de forma correcta con la descripción " + sector.descripcion +
                            "y el Id " + idSector,
                            "Sectores", DateTime.Now);
                    }*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TieneContrato - " + ex.Message, "Clase Sector", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public bool TieneContrato()
        {
            bool existe = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("getContratosByIdSector", _conexion.Actual))
                {
                    cmd.Parameters.Add("@idSector", SqlDbType.Int).Value = this.Id;
                    cmd.CommandType = CommandType.StoredProcedure;

                    existe = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TieneContrato - " + ex.Message, "Clase Sector", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return existe;
        }


        public static int GetSectorByIdColonia(int idColonia)
        {
            int idSector = 0;

            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getSectorByIdColonia", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.Add("IdColonia", SqlDbType.Int).Value = idColonia;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        idSector = int.Parse(tabla.Rows[0]["IdSector"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getSectorByIdColonia - " + ex.Message, "Clase SeccionDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return idSector;
        }

        public static implicit operator Sector(DataRow fila)
        {
            Sector sector = new Sector
            {
                Id = int.Parse(fila["IdSector"].ToString()),
                Descripcion = fila["Descripcion"].ToString(),
            };

            return sector;
        }
    }
}


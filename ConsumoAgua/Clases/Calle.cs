using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Clases
{
    public class Calle
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }

        public string CodigoPostal { get; set; }

        public bool Agregar()
        {
            bool agregado = false;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("addCalle", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = Descripcion;

                    this.Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = this.Id > 0;

                    // TODO: Llena un Bitacora.EmpleadoLogInsert FUERA de aquí (Calle "nombre" (ID) <accion hecha>) (lleva de parametro el empleado actual)
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("CalleAgregar - " + ex.Message, "Clase Calle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregado;
        }

        public static List<Calle> GetCalles()
        {
            DataTable tabla = new DataTable();
            List<Calle> lista = new List<Calle>();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("getCalles", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Calle calle = new Calle();

                            calle = fila;
                            lista.Add(calle);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetCalles - " + ex.Message, "Clase Calle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static List<Calle> GetCallesByIdColonia(int idColonia)
        {
            DataTable tabla = new DataTable();
            List<Calle> lista = new List<Calle>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getCallesByIdColonia", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@idColonia", idColonia);

                    adapter.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Calle calle = fila;
                            lista.Add(calle);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetCallesByIdColonia - " + ex.Message, "Clase UsuarioDAO", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static int ObtenerUltimoID()
        {
            int ultimoId = 0;
            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("getCalleUltimoID", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        ultimoId = int.Parse(result.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CalleObtenerUltimoId - " + ex.Message, "Clase Calle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return ultimoId;
        }

        public bool Actualizar()
        {
            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("updateCalle", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdCalle", SqlDbType.Int).Value = this.Id;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = Descripcion;

                    actualizado = cmd.ExecuteNonQuery() > 0;

                    // TODO: Llena un Bitacora.EmpleadoLogInsert FUERA de aquí (Calle "nombre" (ID) <accion hecha>) (lleva de parametro el empleado actual)
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Actualizar - " + ex.Message, "Clase Calle", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            bool eliminada = false;
            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("deleteCalle", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdCalle", SqlDbType.Int).Value = this.Id;

                    eliminada = cmd.ExecuteNonQuery() > 0;
                }

                // TODO: Llena un Bitacora.EmpleadoLogInsert FUERA de aquí (Calle "nombre" (ID) <accion hecha>) (lleva de parametro el empleado actual)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eliminar - " + ex.Message, "Clase Calle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return eliminada;
        }


        public static implicit operator Calle(DataRow fila)
        {
            Calle calle = new Calle()
            {
                Id = int.Parse(fila["Id"].ToString()),
                Codigo = int.Parse(fila["Codigo"].ToString()),
                Descripcion = fila["Calle"].ToString(),
            };

            return calle;
        }
    }
}


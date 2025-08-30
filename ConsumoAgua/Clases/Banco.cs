using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;

namespace SAPA.Clases
{
    public class Banco
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }

        public bool Agregar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addBanco", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);

                    agregado = Convert.ToInt32(cmd.ExecuteScalar().ToString()) > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Guardar - " + ex.Message, "Clase Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("updateBanco", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 150).Value = this.Nombre;
                    cmd.Parameters.Add("@IdBanco", SqlDbType.Int).Value = this.Id;

                    actualizar = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Actualizar - " + ex.Message, "Clase Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizar;
        }


        public bool Eliminar()
        {
            bool eliminado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("deleteBanco", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdBanco", Id);

                    eliminado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eliminar - " + ex.Message, "Clase Banco", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminado;
        }

        public static bool EsUsado(int idBanco)
        {
            bool usado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("checkBancoEsUsado", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdBanco", idBanco);

                    usado = Convert.ToBoolean(cmd.ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Guardar - " + ex.Message, "Clase Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return usado;
        }

        public static List<Banco> GetBancos()
        {
            DataTable tabla = new DataTable();
            List<Banco> lista = new List<Banco>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getBancos", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Banco banco = new Banco();
                            banco = fila;
                            lista.Add(banco);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetBancos - " + ex.Message, "Clase Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static implicit operator Banco(DataRow fila)
        {
            Banco banco = new Banco()
            {
                Id = int.Parse(fila["Id"].ToString()),
                Nombre = fila["Nombre"].ToString(),
                Domicilio = fila["Domicilio"].ToString(),
                Telefono = fila["Telefono"].ToString()
            };

            return banco;
        }
    }
}


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
    public class Medidor
    {
        private static Conexion _conexion = new Conexion();


        public int Id { get; set; }
        public int NoMedidor { get; set; }
        public string Marca { get; set; }
        public DateTime Fecha { get; set; }

        public bool Estatus { get; set; }


        public bool Guardar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("addMedidor", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NoMedidor", SqlDbType.Int).Value = NoMedidor;
                    cmd.Parameters.Add("@Marca", SqlDbType.NVarChar).Value = Marca;
                    cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = DateTime.Now;
                    agregado = Convert.ToInt32(cmd.ExecuteScalar().ToString()) > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("addMedidor - " + ex.Message, "Clase Medidores", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("updateMedidor", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdMedidor", SqlDbType.Int).Value = Id;
                    cmd.Parameters.Add("@NoMedidor", SqlDbType.Int).Value = NoMedidor;
                    cmd.Parameters.Add("@Marca", SqlDbType.NVarChar).Value = Marca;
                    cmd.Parameters.Add("@Estatus", SqlDbType.Bit).Value = Estatus;
                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ListaMedidoresUpdate - " + ex.Message, "Clase Medidores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public static bool Existe(int noMedidor)
        {
            bool existe = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("getMedidorByNoMedidor", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NoMedidor", SqlDbType.Int).Value = noMedidor;
                    existe = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ListaMedidoresUpdate - " + ex.Message, "Clase Medidores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return existe;
        }

        public static List<Medidor> GetDisponibles()
        {
            DataTable tabla = new DataTable();
            List<Medidor> lista = new List<Medidor>();

            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("getMedidoresDisponibles", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Medidor medidor = new Medidor();
                            medidor = fila;
                            lista.Add(medidor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetDisponibles - " + ex.Message, "Clase Medidores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static List<Medidor> GetOcupados()
        {
            DataTable tabla = new DataTable();
            List<Medidor> lista = new List<Medidor>();

            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("getMedidoresOcupados", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Medidor medidor = new Medidor();
                            medidor = fila;
                            lista.Add(medidor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getMedidoresOcupados - " + ex.Message, "Clase Medidores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static List<Medidor> GetTodos()
        {
            DataTable tabla = new DataTable();
            List<Medidor> lista = new List<Medidor>();

            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("getMedidores", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure; dat.SelectCommand.CommandTimeout = 300;
                    dat.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Medidor medidor = new Medidor();
                            medidor = fila;
                            lista.Add(medidor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetTodos - " + ex.Message, "Clase Medidores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return lista;
        }


        public bool Eliminar()
        {
            bool eliminado = false;
            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("deleteMedidor", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

                    eliminado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eliminar - " + ex.Message, "Clase Medidores", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return eliminado;
        }

        public static implicit operator Medidor(DataRow fila)
        {
            Medidor medidor = new Medidor
            {
                Id = Convert.ToInt32(fila["Id"].ToString()),
                NoMedidor = Convert.ToInt32(fila["NoMedidor"].ToString()),
                Marca = fila["Marca"].ToString(),
                Estatus = bool.Parse(fila["Estatus"].ToString()),
                Fecha = Convert.ToDateTime(fila["Fecha"].ToString())
            };

            return medidor;
        }
    }
}



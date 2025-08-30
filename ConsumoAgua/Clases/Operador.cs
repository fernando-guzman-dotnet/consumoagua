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
    public class Operador
    {
        private static Conexion _conexion = new Conexion();


        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Domicilio { get; set; }
        public int IdSector { get; set; }
        public string Sector { get; set; }
        public string AuthToken { get; set; }

        public bool Guardar()
        {
            bool agregado = false;
            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addOperador", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", Usuario);
                    cmd.Parameters.AddWithValue("@Contrasena", Contrasena);
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", Apellido);
                    cmd.Parameters.AddWithValue("@Domicilio", Domicilio);
                    cmd.Parameters.AddWithValue("@authToken", AuthToken);
                    cmd.Parameters.AddWithValue("@IdSector", IdSector);
                    agregado = Convert.ToInt32(cmd.ExecuteScalar().ToString()) > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("addOperador - " + ex.Message, "Clase OperadorDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            bool eliminado = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("deleteOperador", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);
                    eliminado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("deleteOperador - " + ex.Message, "Clase OperadorDAO", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminado;
        }

        public static List<Operador> GetOperadores()
        {
            DataTable tabla = new DataTable();
            List<Operador> lista = new List<Operador>();

            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("getOperadores", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Operador operador = new Operador();
                            operador = fila;
                            lista.Add(operador);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getOperadores - " + ex.Message, "Clase OperadorDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("updateOperador", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Usuario", Usuario);
                    cmd.Parameters.AddWithValue("@Contrasena", Contrasena);
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", Apellido);
                    cmd.Parameters.AddWithValue("@Domicilio", Domicilio);
                    cmd.Parameters.AddWithValue("@authToken", AuthToken);
                    cmd.Parameters.AddWithValue("@IdSector", IdSector);
                    cmd.Parameters.AddWithValue("@Id", Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("updateOperador - " + ex.Message, "Clase OperadorDAO", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }


        public static implicit operator Operador(DataRow fila)
        {
            Operador operador = new Operador
            {
                Id = int.Parse(fila["Id"].ToString()),
                Usuario = fila["Usuario"].ToString(),
                Nombre = fila["Nombre"].ToString(),
                Apellido = fila["Apellido"].ToString(),
                Domicilio = fila["Domicilio"].ToString(),
                IdSector = int.Parse(fila["IdSector"].ToString()),
                Sector = fila["Sector"].ToString()
            };

            return operador;
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAPA.Clases;
using SAPAFacturacionCFDI33;

namespace Clases
{
    public class Usuario
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public int IdTipoUsuario => TipoUsuario.Id;
        public string DescripcionTipoUsuario => TipoUsuario.Descripcion;

        public string NombreCompleto => $"{ApellidoPaterno} {ApellidoMaterno} {Nombre}";

        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string Telefono { get; set; }

        [Browsable(false)]
        public TipoUsuario TipoUsuario { get; set; } = new TipoUsuario();

        public static DataTable Select()
        {
            DataTable dt = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter dat = new SqlDataAdapter("ClientesSelect", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.CommandTimeout = 300;

                    dat.Fill(dt);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Select - " + ex.Message, "Clase Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return dt;
        }


        public DataTable ClientesSelectById()
        {
            DataTable dt = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter dat = new SqlDataAdapter("ClientesSelectById", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = this.Id;
                    dat.SelectCommand.CommandTimeout = 300;

                    dat.Fill(dt);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Select - " + ex.Message, "Clase Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return dt;
        }

        public bool Guardar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addUsuario", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", IdTipoUsuario);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@RFC", RFC);
                    cmd.Parameters.AddWithValue("@CURP", CURP);
                    cmd.Parameters.AddWithValue("@Telefono", Telefono);

                    this.Id = int.Parse(cmd.ExecuteScalar().ToString());

                    agregado = Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("addUsuario - " + ex.Message, "Clase UsuarioDAO", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("deleteUsuario", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", Id);
                    eliminado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("deleteUsuario - " + ex.Message, "Clase UsuarioDAO", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminado;
        }


        public static List<Usuario> GetUsuarios()
        {
            DataTable tabla = new DataTable();
            List<Usuario> lista = new List<Usuario>();

            try
            {
                _conexion.Actual.Open();  

                using (SqlDataAdapter adapter = new SqlDataAdapter("getUsuarios", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Usuario usuario = fila;
                            lista.Add(usuario);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetUsuarios - " + ex.Message, "Clase Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        internal bool Actualizar()
        {
            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("updateUsuario", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", IdTipoUsuario);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@RFC", RFC);
                    cmd.Parameters.AddWithValue("@CURP", CURP);
                    cmd.Parameters.AddWithValue("@Telefono", Telefono);
                    cmd.Parameters.AddWithValue("@Id", Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("updateUsuario - " + ex.Message, "Clase UsuarioDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public static DataTable GetUsuariosLikeNombre(string usuario = "")
        {
            DataTable dt = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getUsuariosLikeName", _conexion.Actual))
                {
                    adapter.SelectCommand.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = string.IsNullOrWhiteSpace(usuario) ? string.Empty : usuario;
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getUsuariosLikeNombre - " + ex.Message, "Clase UsuarioDAO", MessageBoxButtons.OK, MessageBoxIcon.Error); return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return dt;
        }


        public static Usuario GetUsuarioById(int id)
        {
            Usuario usuario = null;

            DataTable dt = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getUsuariosById", _conexion.Actual))
                {
                    adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0) usuario = dt.Rows[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetUsuarioById - " + ex.Message, "Clase Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return usuario;
        }

        public static implicit operator Usuario(DataRow fila)
        {
            Usuario usuario = new Usuario
            {
                Id = int.Parse(fila["Id"].ToString()),
                Nombre = fila["Nombre"].ToString(),
                ApellidoPaterno = fila["ApellidoPaterno"].ToString(),
                ApellidoMaterno = fila["ApellidoMaterno"].ToString(),
                TipoUsuario = new TipoUsuario
                {
                    Id = int.Parse(fila["IdTipoUsuario"].ToString()),
                    Descripcion = fila["DescripcionTipoUsuario"].ToString()
                },
                FechaNacimiento = DateTime.Parse(fila["FechaNacimiento"].ToString()),
                Email = fila["Email"].ToString(),
                RFC = fila["RFC"].ToString(),
                CURP = fila["CURP"].ToString(),
                Telefono = fila["Telefono"].ToString()
            };

            return usuario;
        }
    }
}


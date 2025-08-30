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
    public class UsuarioDireccion
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int IdUsuario { get; set; }

        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }

        public string CodigoPostal { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }

        public bool Predeterminada { get; set; }

        public string DireccionCompleta
        {
            get
            {
                var calle = string.IsNullOrWhiteSpace(Calle) ? string.Empty : Calle;
                var noExterior = string.IsNullOrWhiteSpace(NumeroExterior) ? string.Empty : $" No. {NumeroExterior}";
                var noInterior = string.IsNullOrWhiteSpace(NumeroInterior) ? string.Empty : $" Int. {NumeroInterior}";
                var colonia = string.IsNullOrWhiteSpace(Colonia) ? string.Empty : $"Col. {Colonia}";
                var codigoPostal = string.IsNullOrWhiteSpace(CodigoPostal) ? string.Empty : $"CP. {CodigoPostal} ";
                var municipio = string.IsNullOrWhiteSpace(Municipio) ? string.Empty : Municipio;
                var estado = string.IsNullOrWhiteSpace(Estado) ? string.Empty : Estado;

                return $"{calle}{noExterior}{noInterior}, {colonia}, {codigoPostal}{municipio}, {estado}".ToUpper();
            }
        }


        public bool Agregar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addUsuarioDireccion", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                    cmd.Parameters.AddWithValue("@Estado", Estado);
                    cmd.Parameters.AddWithValue("@Municipio", Municipio);
                    cmd.Parameters.AddWithValue("@Colonia", Colonia);
                    cmd.Parameters.AddWithValue("@Calle", Calle);
                    cmd.Parameters.AddWithValue("@CodigoPostal", CodigoPostal);
                    cmd.Parameters.AddWithValue("@NumeroExterior", NumeroExterior);
                    cmd.Parameters.AddWithValue("@NumeroInterior", NumeroInterior);

                    Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase UsuarioDireccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("updateUsuarioDireccion", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Estado", Estado);
                    cmd.Parameters.AddWithValue("@Municipio", Municipio);
                    cmd.Parameters.AddWithValue("@Colonia", Colonia);
                    cmd.Parameters.AddWithValue("@Calle", Calle);
                    cmd.Parameters.AddWithValue("@CodigoPostal", CodigoPostal);
                    cmd.Parameters.AddWithValue("@NumeroExterior", NumeroExterior);
                    cmd.Parameters.AddWithValue("@NumeroInterior", NumeroInterior);

                    cmd.Parameters.AddWithValue("@Id", Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Actualizar - " + ex.Message, "Clase UsuarioDireccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }



        public bool HacerPredeterminada()
        {
            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("usuarioDireccionHacerPredeterminada", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HacerPredeterminada - " + ex.Message, "Clase UsuarioDireccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public static List<UsuarioDireccion> GetByIdUsuario(int idUsuario)
        {
            DataTable tabla = new DataTable();
            List<UsuarioDireccion> lista = new List<UsuarioDireccion>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getUsuarioDireccionesByIdUsuario", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            UsuarioDireccion usuarioDireccion = fila;
                            lista.Add(usuarioDireccion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetByIdUsuario - " + ex.Message, "Clase UsuarioDireccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static implicit operator UsuarioDireccion(DataRow fila)
        {
            UsuarioDireccion usuarioDireccion = new UsuarioDireccion
            {
                Id = int.Parse(fila["Id"].ToString()),
                IdUsuario = int.Parse(fila["IdUsuario"].ToString()),
                Estado = fila["Estado"].ToString(),
                Municipio = fila["Municipio"].ToString(),
                Colonia = fila["Colonia"].ToString(),
                Calle = fila["Calle"].ToString(),
                CodigoPostal = fila["CodigoPostal"].ToString(),
                NumeroExterior = fila["NumeroExterior"].ToString(),
                NumeroInterior = fila["NumeroInterior"].ToString(),
                Predeterminada = bool.Parse(fila["Predeterminada"].ToString())
            };

            return usuarioDireccion;
        }
    }
}


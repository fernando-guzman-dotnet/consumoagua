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
    public class Organismo
    {
        private static Conexion _conexion = new Conexion();

        public static Organismo Actual { get; set; }

        public int Id { get; set; }
        public byte[] Imagen { get; set; }
        public string Nombre { get; set; }
        public string RFC { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Colonia { get; set; }
        public int CodigoPostal { get; set; }
        public string Calle { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public string DireccionCompleta { get; set; }

        public static DataTable Select()
        {
            DataTable dt = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter dat = new SqlDataAdapter("OrganismosSelect", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.CommandTimeout = 300;

                    dat.Fill(dt);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Organismo.Select - " + ex.Message, "Clase Organismo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return dt;
        }

        public DataTable EmisoresSelectById()
        {
            DataTable dt = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter dat = new SqlDataAdapter("EmisoresSelectById", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = this.Id;
                    dat.SelectCommand.CommandTimeout = 300;

                    dat.Fill(dt);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario.Select - " + ex.Message, "Clase Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return dt;
        }


        public static Organismo GetOrganismo()
        {
            DataTable tabla = new DataTable();
            Organismo obj = null;

            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("getOrganismo", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            obj = fila;

                            // Solo cargamos el primer registro, ignoramos los demás
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getOrganismo - " + ex.Message, "Clase OrganismoDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return obj;
        }

        public bool Agregar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addOrganismo", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Imagen", this.Imagen);
                    cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                    cmd.Parameters.AddWithValue("@RFC", this.RFC);
                    cmd.Parameters.AddWithValue("@Telefono", this.Telefono);
                    cmd.Parameters.AddWithValue("@Estado", this.Estado);
                    cmd.Parameters.AddWithValue("@Municipio", this.Municipio);
                    cmd.Parameters.AddWithValue("@Colonia", this.Colonia);
                    cmd.Parameters.AddWithValue("@CodigoPostal", this.CodigoPostal);
                    cmd.Parameters.AddWithValue("@Calle", this.Calle);
                    cmd.Parameters.AddWithValue("@NoExterior", this.NumeroExterior);
                    cmd.Parameters.AddWithValue("@NoInterior", this.NumeroInterior);
                    cmd.Parameters.AddWithValue("@DireccionCompleta", this.DireccionCompleta);

                    this.Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                    agregado = this.Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("addOrganismo - " + ex.Message, "Clase OrganismoDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("updateOrganismo", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Imagen", this.Imagen);
                    cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                    cmd.Parameters.AddWithValue("@RFC", this.RFC);
                    cmd.Parameters.AddWithValue("@Telefono", this.Telefono);
                    cmd.Parameters.AddWithValue("@Estado", this.Estado);
                    cmd.Parameters.AddWithValue("@Municipio", this.Municipio);
                    cmd.Parameters.AddWithValue("@Colonia", this.Colonia);
                    cmd.Parameters.AddWithValue("@CodigoPostal", this.CodigoPostal);
                    cmd.Parameters.AddWithValue("@Calle", this.Calle);
                    cmd.Parameters.AddWithValue("@NoExterior", this.NumeroExterior);
                    cmd.Parameters.AddWithValue("@NoInterior", this.NumeroInterior);
                    cmd.Parameters.AddWithValue("@DireccionCompleta", this.DireccionCompleta);
                    cmd.Parameters.AddWithValue("@IdOrganismo", this.Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("updateOrganismo - " + ex.Message, "Clase OrganismoDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public static implicit operator Organismo(DataRow fila)
        {
            Organismo organismo = new Organismo
            {
                Id = int.Parse(fila["Id"].ToString()),
                Imagen = (byte[]) fila["Imagen"],
                Nombre = fila["Nombre"].ToString(),
                RFC = fila["RFC"].ToString(),
                Telefono = fila["Telefono"].ToString(),
                Estado = fila["Estado"].ToString(),
                Municipio = fila["Municipio"].ToString(),
                Colonia = fila["Colonia"].ToString(),
                CodigoPostal = int.Parse(fila["CodigoPostal"].ToString()),
                Calle = fila["Calle"].ToString(),
                NumeroExterior = fila["NumeroExterior"].ToString(),
                NumeroInterior = fila["NumeroInterior"].ToString(),
                DireccionCompleta = fila["DireccionCompleta"].ToString()
            };
            return organismo;
        }

        public static implicit operator DataTable(Organismo organismo)
        {
            DataTable tablaOrganismo = new DataTable
            {
                TableName = "Organismo",
                Columns =
                {
                    { "Imagen", typeof(byte[]) },
                    { "Nombre", typeof(string) },
                    { "RFC", typeof(string) },
                    { "Telefono", typeof(string) },
                    { "DireccionCompleta", typeof(string) }
                }
            };

            DataRow fila = tablaOrganismo.NewRow();

            fila["Imagen"] = organismo.Imagen;
            fila["Nombre"] = organismo.Nombre;
            fila["RFC"] = organismo.RFC;
            fila["Telefono"] = organismo.Telefono;
            fila["DireccionCompleta"] = organismo.DireccionCompleta;

            tablaOrganismo.Rows.Add(fila);

            return tablaOrganismo;
        }

    }
}


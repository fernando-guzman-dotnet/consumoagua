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

namespace Clases
{
    public class Contrato
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int NoContrato { get; set; }
        public DateTime Fecha { get; set; }

        public int IdUsuario => Usuario.Id;
        public string NombreUsuario => Usuario == null ? string.Empty :  Usuario.NombreCompleto.ToUpper();

        public string Direccion
        {
            get
            {
                var calle = string.IsNullOrWhiteSpace(Calle.Descripcion) ? string.Empty : Calle.Descripcion;
                var noExterior = string.IsNullOrWhiteSpace(NumeroExterior) ? string.Empty : $" No. {NumeroExterior}";
                var noInterior = string.IsNullOrWhiteSpace(NumeroInterior) ? string.Empty : $" Int. {NumeroInterior}";
                var colonia = string.IsNullOrWhiteSpace(Colonia.Descripcion) ? string.Empty : $"Col. {Colonia.Descripcion}";
                var codigoPostal = string.IsNullOrWhiteSpace(CodigoPostal) ? string.Empty : $"CP. {CodigoPostal} ";
                //var municipio = string.IsNullOrWhiteSpace(Municipio.Nombre) ? string.Empty : Municipio.Nombre;
                //var estado = string.IsNullOrWhiteSpace(Estado.Nombre) ? string.Empty : Estado.Nombre;

                //return $"{calle}{noExterior}{noInterior}, {colonia}, {codigoPostal}{municipio}, {estado}".ToUpper();
                return $"{calle}{noExterior}{noInterior}, {colonia}".ToUpper();
            }
        }

        public int IdTipoVivienda => TipoVivienda.Id;
        public string DescripcionTipoVivienda => TipoVivienda.Descripcion;
        public int IdTipoContrato => TipoContrato.Id;
        public string DescripcionTipoContrato => TipoContrato.Descripcion;
        public int IdTarifa => Tarifa.Id;
        public string NombreTarifa => Tarifa.Descripcion;

        public int IdEstado => Estado.Id;
        public int IdLocalidad => Localidad.Id;
        public int IdMunicipio => Municipio.Id;
        public int IdSector => Sector.Id;
        public int IdSeccion => Seccion.Id;
        public int IdColonia => Colonia.Id;
        
        public int IdCalle => Calle.Id;
        
        public string CodigoPostal { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public string Manzana { get; set; }

        public bool TieneAgua{ get; set; }
        public bool TieneAlcantarillado { get; set; }

        public bool Activo { get; set; }

        [Browsable(false)]
        public Usuario Usuario { get; set; }
        [Browsable(false)]
        public TipoVivienda TipoVivienda { get; set; }
        [Browsable(false)]
        public TipoContrato TipoContrato { get; set; }
        [Browsable(false)]
        public Tarifa Tarifa { get; set; }
        [Browsable(false)]
        public Estado Estado { get; set; }
        [Browsable(false)]
        public Municipio Municipio { get; set; }
        [Browsable(false)]
        public Localidad Localidad { get; set; }
        [Browsable(false)]
        public Seccion Seccion { get; set; }
        [Browsable(false)]
        public Sector Sector { get; set; }
        [Browsable(false)]
        public Colonia Colonia { get; set; }
        [Browsable(false)]
        public Calle Calle { get; set; }
        [Browsable(false)]
        public Medidor Medidor { get; set; }

        [Browsable(false)]
        public List<AdeudoVista> Adeudos { get; set; } = new List<AdeudoVista>();

        [Browsable(false)]
        public List<Convenio> Convenios { get; set; } = new List<Convenio>();

        [Browsable(false)]
        public List<ConceptoAdicional> ConceptosAdicionales { get; set; } = new List<ConceptoAdicional>();

        [Browsable(false)]
        public List<ContratoDescuento> Descuentos { get; set; } = new List<ContratoDescuento>();

        public enum Tipo
        {
            CuotaFija = 1,
            ServicioMedido
        }

        public bool Guardar()
        {
            bool agregado = false;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("addContrato", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NoContrato", this.NoContrato);
                    cmd.Parameters.AddWithValue("@Fecha", this.Fecha);
                    cmd.Parameters.AddWithValue("@IdUsuario", this.IdUsuario);
                    cmd.Parameters.AddWithValue("@IdTipoVivienda", this.IdTipoVivienda);
                    cmd.Parameters.AddWithValue("@IdTipoContrato", this.IdTipoContrato);
                    cmd.Parameters.AddWithValue("@IdTarifa", this.IdTarifa);
                    cmd.Parameters.AddWithValue("@IdEstado", this.IdEstado);
                    cmd.Parameters.AddWithValue("@IdMunicipio", this.IdMunicipio);
                    cmd.Parameters.AddWithValue("@IdLocalidad", this.IdLocalidad);
                    cmd.Parameters.AddWithValue("@IdSector", this.IdSector);
                    cmd.Parameters.AddWithValue("@IdSeccion", this.IdSeccion);
                    cmd.Parameters.AddWithValue("@IdColonia", this.IdColonia);
                    cmd.Parameters.AddWithValue("@IdCalle", this.IdCalle);
                    cmd.Parameters.AddWithValue("@CodigoPostal", string.IsNullOrWhiteSpace(this.CodigoPostal) ? DBNull.Value : (object)this.CodigoPostal);
                    cmd.Parameters.AddWithValue("@NumeroExterior", string.IsNullOrWhiteSpace(this.NumeroExterior) ? DBNull.Value : (object)this.NumeroExterior);
                    cmd.Parameters.AddWithValue("@NumeroInterior", string.IsNullOrWhiteSpace(this.NumeroInterior) ? DBNull.Value : (object)this.NumeroInterior);
                    cmd.Parameters.AddWithValue("@TieneAgua", TieneAgua);
                    cmd.Parameters.AddWithValue("@TieneAlcantarillado", TieneAlcantarillado);
                    cmd.Parameters.AddWithValue("@Activo", this.Activo);

                    this.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    agregado = this.Id > 0;

                    if (agregado)
                    {
                        if (this.IdTipoContrato == 2)
                        {
                            ContratoMedidor medidor = new ContratoMedidor();
                            medidor.NoContrato = this.NoContrato;
                            medidor.IdMedidor = this.Medidor.Id;

                            if (!medidor.Guardar())
                            {
                                MessageBox.Show(
                                    "Hubo un error al intentar asignar el medidor al contrato. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                                    "Clase Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        ContratoHistoricoEstatus contratoHistoricoEstatus = new ContratoHistoricoEstatus
                        {
                            NoContrato = this.NoContrato,
                            Estatus = this.Activo,
                            Fecha = this.Fecha
                        };

                        if (!contratoHistoricoEstatus.Agregar())
                        {
                            MessageBox.Show(
                                "Hubo un error al intentar registrar el historico del estatus del contrato. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                                "Clase Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Guardar - " + ex.Message, "Clase Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return agregado;
        }


        public static List<Contrato> GetContratos()
        {
            List<Contrato> lista = new List<Contrato>();
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("getContratos", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Contrato contrato = fila;
                            lista.Add(contrato);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getContratos - " + ex.Message, "Clase Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return lista;
        }



        public static List<Contrato> GetContratosByParams(string nombreUsuario = null, int? noContrato = null)
        {
            DataTable tabla = new DataTable();
            List<Contrato> lista = new List<Contrato>();

            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("getContratosByParams", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.Add("@NombreUsuario", SqlDbType.NVarChar).Value =
                        string.IsNullOrWhiteSpace(nombreUsuario) ? DBNull.Value : (object)nombreUsuario;
                    adapter.SelectCommand.Parameters.Add("@NoContrato", SqlDbType.Int).Value =
                        noContrato == null ? DBNull.Value : (object)noContrato;

                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Contrato contrato = fila;
                            lista.Add(contrato);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetContratosByParams - " + ex.Message, "Clase Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return lista;
        }



        public static Contrato GetContrato(int noContrato)
        {
            Contrato contrato = null;
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getContrato", _conexion.Actual))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@noContrato", noContrato);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            contrato = fila;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getContrato - " + ex.Message, "Clase Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return contrato;
        }

        internal bool Actualizar()
        {
            bool actualizado = false;
            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("updateContrato", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Fecha", this.Fecha);
                    cmd.Parameters.AddWithValue("@IdUsuario", this.IdUsuario);
                    cmd.Parameters.AddWithValue("@IdTipoVivienda", this.IdTipoVivienda);
                    cmd.Parameters.AddWithValue("@IdTipoContrato", this.IdTipoContrato);
                    cmd.Parameters.AddWithValue("@IdTarifa", this.IdTarifa);
                    cmd.Parameters.AddWithValue("@IdEstado", this.IdEstado);
                    cmd.Parameters.AddWithValue("@IdLocalidad", this.IdLocalidad);
                    cmd.Parameters.AddWithValue("@IdMunicipio", this.IdMunicipio);
                    cmd.Parameters.AddWithValue("@IdSector", this.IdSector);
                    cmd.Parameters.AddWithValue("@IdSeccion", this.IdSeccion);
                    cmd.Parameters.AddWithValue("@IdColonia", this.IdColonia);
                    cmd.Parameters.AddWithValue("@IdCalle", this.IdCalle);
                    cmd.Parameters.AddWithValue("@CodigoPostal", string.IsNullOrWhiteSpace(this.CodigoPostal) ? DBNull.Value : (object)this.CodigoPostal);
                    cmd.Parameters.AddWithValue("@NumeroExterior", string.IsNullOrWhiteSpace(this.NumeroExterior) ? DBNull.Value : (object)this.NumeroExterior);
                    cmd.Parameters.AddWithValue("@NumeroInterior", string.IsNullOrWhiteSpace(this.NumeroInterior) ? DBNull.Value : (object)this.NumeroInterior);
                    cmd.Parameters.AddWithValue("@TieneAgua", TieneAgua);
                    cmd.Parameters.AddWithValue("@TieneAlcantarillado", TieneAlcantarillado);
                    cmd.Parameters.AddWithValue("@Activo", this.Activo);
                    cmd.Parameters.AddWithValue("@Id", this.Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;

                    if (actualizado)
                    {
                        if (this.IdTipoContrato == 2)
                        {
                            ContratoMedidor medidor = new ContratoMedidor();

                            medidor.NoContrato = this.NoContrato;
                            medidor.IdMedidor = this.Medidor.Id;

                            if (!medidor.Guardar())
                            {
                                MessageBox.Show(
                                    "Hubo un error al intentar asignar el medidor al contrato. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                                    "Clase Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("updateContrato - " + ex.Message, "Clase Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return actualizado;
        }

        public static bool Existe(int noContrato) => GetContrato(noContrato) != null;

        public static int GetUltimoNoContrato()
        {
            int ultimoNoContrato = 0;

            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getUltimoNoContrato", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        ultimoNoContrato = int.Parse(tabla.Rows[0][0].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("getUltimoContrato - " + ex.Message, "Clase Contrato", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return ultimoNoContrato;
        }

        public static implicit operator Contrato(DataRow fila)
        {
            Contrato contrato = new Contrato
            {
                Id = int.Parse(fila["Id"].ToString()),
                NoContrato = int.Parse(fila["NoContrato"].ToString()),
                Fecha = DateTime.Parse(fila["Fecha"].ToString()),
                Usuario = new Usuario
                {
                    Id = int.Parse(fila["IdUsuario"].ToString()),
                    Nombre = fila["Nombre"].ToString(),
                    ApellidoPaterno = fila["ApellidoPaterno"].ToString(),
                    ApellidoMaterno = fila["ApellidoMaterno"].ToString(),
                    Email = fila["Email"].ToString(),
                    RFC = fila["RFC"].ToString(),
                    CURP = fila["CURP"].ToString(),
                    Telefono = fila["Telefono"].ToString()
                },
                TipoVivienda = new TipoVivienda
                {
                    Id = int.Parse(fila["IdTipoVivienda"].ToString()),
                    Descripcion = fila["TipoVivienda"].ToString()
                },
                TipoContrato = new TipoContrato
                {
                    Id = int.Parse(fila["IdTipoContrato"].ToString()),
                    Descripcion = fila["TipoContrato"].ToString()
                },
                Tarifa = new Tarifa
                {
                    Id = int.Parse(fila["IdTarifa"].ToString()),
                    Descripcion = fila["Tarifa"].ToString()
                },
                Estado = new Estado
                {
                    Id = int.Parse(fila["IdEstado"].ToString()),
                    Nombre = fila["Estado"].ToString()
                },
                Localidad = new Localidad
                {
                    Id = int.Parse(fila["IdLocalidad"].ToString()),
                    Nombre = fila["Localidad"].ToString(),
                },
                Municipio = new Municipio
                {
                    Id = int.Parse(fila["IdMunicipio"].ToString()),
                    Nombre = fila["Municipio"].ToString()
                },
                Sector = new Sector
                {
                    Id = int.Parse(fila["IdSector"].ToString()),
                    Descripcion = fila["Sector"].ToString()
                },
                Seccion = new Seccion
                {
                    Id = int.Parse(fila["IdSeccion"].ToString()),
                    Descripcion = fila["Seccion"].ToString()
                },
                Colonia = new Colonia
                {
                    Id = int.Parse(fila["IdColonia"].ToString()),
                    Descripcion = fila["Colonia"].ToString()
                },
                Calle = new Calle
                {
                    Id = int.Parse(fila["IdCalle"].ToString()),
                    Descripcion = fila["Calle"].ToString()
                },
                CodigoPostal = fila["CodigoPostal"].ToString(),
                NumeroExterior = fila["NumeroExterior"].ToString(),
                NumeroInterior = fila["NumeroInterior"].ToString(),
                TieneAgua = bool.Parse(fila["TieneAgua"].ToString()),
                TieneAlcantarillado = bool.Parse(fila["TieneAlcantarillado"].ToString()),
                Activo = bool.Parse(fila["Activo"].ToString())
            };

            if ((Tipo)contrato.IdTipoContrato == Tipo.ServicioMedido)
                contrato.Medidor = new Medidor
                {
                    Id = int.Parse(fila["IdMedidor"].ToString()),
                    NoMedidor = int.Parse(fila["NoMedidor"].ToString()),
                    Marca = fila["Marca"].ToString(),
                    Fecha = DateTime.Parse(fila["FechaMedidor"].ToString()),
                    Estatus = bool.Parse(fila["Estatus"].ToString())
                };

            return contrato;
        }
    }
}



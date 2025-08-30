using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPA.Clases
{
    public class Medicion
    {
        private static readonly Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int NoContrato { get; set; }

        public int IdLecturista => Lecturista.Id;
        public int IdMedidor { get; set; }

        public string NombreLecturista => Lecturista.NombreCompleto;
        public DateTime Fecha { get; set; }
        public string Periodo => Fecha.ToString("MMMM yyyy", new CultureInfo("es-MX"));
        public decimal LitrosLeidos { get; set; }
        public decimal LitrosConsumidos { get; set; }
        public bool TieneAnomalia { get; set; }
        public string DescripcionAnomalia { get; set; }
        public bool Pagada => IdPago > 0;

        public int IdPago { get; set; }


        [Browsable(false)]
        public Empleado Lecturista { get; set; }


        public bool Agregar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addMedicion", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NoContrato", NoContrato);
                    cmd.Parameters.AddWithValue("@IdMedidor", IdMedidor);
                    cmd.Parameters.AddWithValue("@IdLecturista", IdLecturista);
                    cmd.Parameters.AddWithValue("@Fecha", Fecha);
                    cmd.Parameters.AddWithValue("@LitrosLeidos", LitrosLeidos);
                    cmd.Parameters.AddWithValue("@LitrosConsumidos", LitrosConsumidos);
                    cmd.Parameters.AddWithValue("@TieneAnomalia", TieneAnomalia);
                    cmd.Parameters.AddWithValue("@DescripcionAnomalia", string.IsNullOrWhiteSpace(DescripcionAnomalia) ? (object)DBNull.Value : DescripcionAnomalia);

                    Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase Medicion", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("updateMedicion", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NoContrato", NoContrato);
                    cmd.Parameters.AddWithValue("@IdMedidor", IdMedidor);
                    cmd.Parameters.AddWithValue("@IdLecturista", IdLecturista);
                    cmd.Parameters.AddWithValue("@Fecha", Fecha);
                    cmd.Parameters.AddWithValue("@LitrosLeidos", LitrosLeidos);
                    cmd.Parameters.AddWithValue("@LitrosConsumidos", LitrosConsumidos);
                    cmd.Parameters.AddWithValue("@TieneAnomalia", TieneAnomalia);
                    cmd.Parameters.AddWithValue("@DescripcionAnomalia", string.IsNullOrWhiteSpace(DescripcionAnomalia) ? (object)DBNull.Value : DescripcionAnomalia);
                    cmd.Parameters.AddWithValue("@IdMedicion", Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Actualizar - " + ex.Message, "Clase Medicion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }


        public static List<Medicion> GetMedicionesByNoContrato(int noContrato)
        {
            DataTable tabla = new DataTable();
            List<Medicion> lista = new List<Medicion>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getMedicionesByNoContrato", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@NoContrato", noContrato);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Medicion medicion = new Medicion();
                            medicion = fila;
                            lista.Add(medicion);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetMediciones - " + ex.Message, "Clase Medicion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static bool ActualizarPagoMediciones(Pago pago)
        {
            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("updatePagoMediciones", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NoContrato", pago.NoContrato);
                    cmd.Parameters.AddWithValue("@PeriodoInicio", pago.Detalles.PeriodoInicio);
                    cmd.Parameters.AddWithValue("@PeriodoFin", pago.Detalles.PeriodoFin);
                    cmd.Parameters.AddWithValue("@IdPago", pago.Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }



        public static implicit operator Medicion(DataRow fila)
        {
            Medicion medicion = new Medicion
            {
                Id = int.Parse(fila["Id"].ToString()),
                NoContrato = int.Parse(fila["NoContrato"].ToString()),
                IdMedidor = int.Parse(fila["IdMedidor"].ToString()),
                Lecturista = new Empleado
                {
                    Id = int.Parse(fila["IdLecturista"].ToString()),
                    Nombre = fila["LecturistaNombre"].ToString(),
                    ApellidoPaterno = fila["LecturistaApellidoPaterno"].ToString(),
                    ApellidoMaterno = fila["LecturistaApellidoMaterno"].ToString()

                },
                Fecha = DateTime.Parse(fila["Fecha"].ToString()),
                LitrosLeidos = decimal.Parse(fila["LitrosLeidos"].ToString()),
                LitrosConsumidos = decimal.Parse(fila["LitrosConsumidos"].ToString()),
                TieneAnomalia = bool.Parse(fila["TieneAnomalia"].ToString()),
                DescripcionAnomalia = fila["DescripcionAnomalia"].ToString()
            };

            if (!string.IsNullOrWhiteSpace(fila["IdPago"].ToString()))
                medicion.IdPago = int.Parse(fila["IdPago"].ToString());

            return medicion;
        }
    }
}




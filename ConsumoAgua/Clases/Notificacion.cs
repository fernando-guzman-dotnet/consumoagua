using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPA.Clases
{
    public class Notificacion
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int NoContrato { get; set; }
        public DateTime Fecha { get; set; }

        public int IdEmpleado => Empleado.Id;

        public int IdEmpleadoNotificador => Notificador.Id;

        public string Observaciones { get; set; }

        public int IdEstatus { get; set; }
        public string NotificacionEstatus { get; set; }

        public string Pagada => IdPago > 0 ? "PAGADA" : "NO PAGADA";
        public int IdPago { get; set; }

        [Browsable(false)]
        public DateTime FechaAplicada { get; set; }

        [Browsable(false)]
        public Empleado Empleado { get; set; }

        [Browsable(false)]
        public Empleado Notificador { get; set; }


        public enum Estatus
        {
            Cancelada = 1,
            Impresa,
            Aplicada
        }

        public bool Agregar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addNotificacion", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NoContrato", NoContrato);
                    cmd.Parameters.AddWithValue("@Fecha", Fecha);
                    cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                    cmd.Parameters.AddWithValue("@IdEmpleadoNotificador", IdEmpleadoNotificador);
                    cmd.Parameters.AddWithValue("@Observaciones", Observaciones);
                    cmd.Parameters.AddWithValue("@IdEstatus", IdEstatus);
                    Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase Notificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("updateNotificacion", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NoContrato", NoContrato);
                    cmd.Parameters.AddWithValue("@Fecha", Fecha);
                    cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                    cmd.Parameters.AddWithValue("@IdEmpleadoNotificador", IdEmpleadoNotificador);
                    cmd.Parameters.AddWithValue("@Observaciones", Observaciones);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Actualizar - " + ex.Message, "Clase Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }


        public static List<Notificacion> GetNotificaciones()
        {
            DataTable tabla = new DataTable();
            List<Notificacion> lista = new List<Notificacion>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getNotificaciones", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Notificacion notificacion = fila;
                            lista.Add(notificacion);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetNotificaciones - " + ex.Message, "Clase Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static implicit operator Notificacion(DataRow fila)
        {
            Notificacion notificacion = new Notificacion
            {
                Id = int.Parse(fila["Id"].ToString()),
                NoContrato = int.Parse(fila["NoContrato"].ToString()),
                Fecha = DateTime.Parse(fila["Fecha"].ToString()),
                Empleado = new Empleado
                {
                    Id = int.Parse(fila["IdEmpleado"].ToString()),
                    Nombre = fila["Nombre"].ToString(),
                    ApellidoPaterno = fila["ApellidoPaterno"].ToString(),
                    ApellidoMaterno = fila["ApellidoMaterno"].ToString()
                },
                Notificador = new Empleado
                {
                    Id = int.Parse(fila["IdEmpleadoNotificador"].ToString()),
                    Nombre = fila["NotificadorNombre"].ToString(),
                    ApellidoPaterno = fila["NotificadorApellidoPaterno"].ToString(),
                    ApellidoMaterno = fila["NotificadorApellidoMaterno"].ToString()
                },
                Observaciones = fila["Observaciones"].ToString(),
                NotificacionEstatus = fila["Estatus"].ToString(),
                IdEstatus = int.Parse(fila["IdEstatus"].ToString())
            };

            if (!string.IsNullOrWhiteSpace(fila["IdPago"].ToString()))
                notificacion.IdPago = int.Parse(fila["IdPago"].ToString());


            return notificacion;
        }
    }
}


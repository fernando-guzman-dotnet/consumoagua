using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;

namespace SAPA.Clases
{
    public class PagoConvenio
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int IdConvenio { get; set; }
        public DateTime Fecha { get; set; }
        public string Referencia { get; set; }

        public decimal Importe { get; set; }

        public string DescripcionFormaPago => (FormaPago == null) ? string.Empty : FormaPago.Descripcion;
        public string NombreEmpleado => (Empleado == null) ? string.Empty : Empleado.NombreCompleto;
        public string NombreBanco => (Banco == null) ? "N/A" : Banco.Nombre;
        public string NombreCaja => (Caja == null) ? string.Empty : Caja.Descripcion;

        public int IdFormaPago => FormaPago.Id;
        public int IdEmpleado => Empleado.Id;
        public int IdBanco => Banco.Id;
        public int IdCaja => Caja.Id;

        public FormaPago FormaPago { get; set; }
        public Empleado Empleado { get; set; }
        public Banco Banco { get; set; }
        public Caja Caja { get; set; }

        public bool Agregar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addPagoConvenio", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdConvenio", IdConvenio);
                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@IdFormaPago", IdFormaPago);
                    cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado == 0 ? SqlInt32.Null : IdEmpleado);
                    cmd.Parameters.AddWithValue("@IdCaja", IdCaja == 0 ? SqlInt32.Null : IdCaja);
                    cmd.Parameters.AddWithValue("@IdBanco", IdBanco == 0 ? SqlInt32.Null : IdBanco);
                    cmd.Parameters.AddWithValue("@Referencia", string.IsNullOrWhiteSpace(Referencia) ? SqlString.Null : Referencia);
                    cmd.Parameters.AddWithValue("@Importe", Importe);

                    Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase PagoConvenio", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("deletePagoConvenio", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPagoConvenio", Id);

                    eliminado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eliminar - " + ex.Message, "Clase PagoConvenio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminado;
        }


        public static List<PagoConvenio> GetPagosByIdConvenio(int IdConvenio)
        {
            DataTable tabla = new DataTable();
            List<PagoConvenio> lista = new List<PagoConvenio>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getPagosByIdConvenio", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@IdConvenio", IdConvenio);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            // casteo implicito
                            PagoConvenio pagoConvenio = fila;
                            lista.Add(pagoConvenio);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetPagosByIdConvenio - " + ex.Message, "Clase PagoConvenio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }


        public static implicit operator PagoConvenio(DataRow fila)
        {
            PagoConvenio pagoConvenio = new PagoConvenio
            {
                Id = int.Parse(fila["Id"].ToString()),
                IdConvenio = int.Parse(fila["IdConvenio"].ToString()),
                Fecha = DateTime.Parse(fila["Fecha"].ToString()),
                FormaPago = new FormaPago
                {
                    Id = int.Parse(fila["IdFormaPago"].ToString()),
                    Descripcion = fila["DescripcionFormaPago"].ToString()
                },
                Empleado = new Empleado
                {
                    Id = int.Parse(fila["IdEmpleado"].ToString()),
                    Nombre = fila["EmpleadoNombre"].ToString(),
                    ApellidoPaterno = fila["EmpleadoApellidoPaterno"].ToString(),
                    ApellidoMaterno = fila["EmpleadoApellidoMaterno"].ToString()
                },
                Banco = string.IsNullOrWhiteSpace(fila["IdBanco"].ToString()) ? new Banco { Nombre = "N/A" } : new Banco
                {
                    Id = int.Parse(fila["IdBanco"].ToString()),
                    Nombre = fila["BancoNombre"].ToString()
                },
                Caja = new Caja
                {
                    Id = int.Parse(fila["IdCaja"].ToString()),
                    Descripcion = fila["DescripcionCaja"].ToString()
                },
                Referencia = fila["Referencia"].ToString(),
                Importe = decimal.Parse(fila["Importe"].ToString())
            };

            return pagoConvenio;
        }
    }
}


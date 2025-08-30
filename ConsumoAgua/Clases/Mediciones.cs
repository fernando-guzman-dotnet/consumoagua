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
    public class Mediciones
    {
        private static Conexion _conexion = new Conexion();


        public int IdMedicion { get; set; }
        public int NoContrato { get; set; }
        public decimal Litros { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cantidad { get; set; }
        public string Descripcion { get; set; }
        public int MesQueSePaga { get; set; }
        public int AñoQueSePaga { get; set; }
        public int IdMedidor { get; set; }
        public int Pagada { get; set; }
        public int Anomalia { get; set; }
        public string DescAnomalia { get; set; }
        public int idLecturista { get; set; }
        public string Lecturista { get; set; }
        public decimal TotalPago { get; set; }

        public int IdTarifa { get; set; }

        public BitacoraEmpleado Bitacora = new BitacoraEmpleado();
        public Empleado CurrentEmpleado = new Empleado();

        int aux = 0;

        public int Mediciones_Insert()
        {
            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("Mediciones_Insert", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@noContrato", SqlDbType.Int).Value = NoContrato;
                    cmd.Parameters.Add("@litros", SqlDbType.Float).Value = Litros;
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Fecha;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = Cantidad;
                    cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = Descripcion;
                    cmd.Parameters.Add("@MesQueSePaga", SqlDbType.Int).Value = MesQueSePaga;
                    cmd.Parameters.Add("@AñoQueSePaga", SqlDbType.Int).Value = AñoQueSePaga;
                    cmd.Parameters.Add("@idMedidor", SqlDbType.Int).Value = IdMedidor;
                    cmd.Parameters.Add("@Pagada", SqlDbType.Int).Value = 0;
                    cmd.Parameters.Add("@Anomalia", SqlDbType.Bit).Value = Anomalia;
                    cmd.Parameters.Add("@DescAnomalia", SqlDbType.NVarChar).Value = DescAnomalia;
                    cmd.Parameters.Add("@idLecturista", SqlDbType.Int).Value = idLecturista;
                    aux = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (aux > 0)
                    {
                        Bitacora.Agregar(CurrentEmpleado.Id,
                            "Se asigno una lectura con el Id " + aux + " al contrato " + NoContrato + ", el lecturista" + Lecturista,
                            "Mediciones", DateTime.Now);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Mediciones_Insert - " + ex.Message, "Clase Mediciones", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return aux;
        }

        public static DataTable Mediciones_Select_Todas(int noContrato)
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("Mediciones_Select_Todas", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@noContrato", SqlDbType.Int).Value = noContrato;
                    dat.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mediciones_Select_Todas - " + ex.Message, "Clase Mediciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return tabla;
        }

        public static DataTable Mediciones_SelectNoPagadasByNoCuenta(int noContrato)
        {
            DataTable tabla = new DataTable();
            Conexion con = new Conexion();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("Mediciones_SelectNoPagadasByNoCuenta", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@noContrato", SqlDbType.Int).Value = noContrato;
                    dat.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mediciones_SelectNoPagadasByNoCuenta - " + ex.Message, "Clase Mediciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return tabla;
        }

        public static List<Mediciones> GetNoPagadas(int IdContrato)
        {
            List<Mediciones> mediciones = new List<Mediciones>();

            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("MedicionesNoPagadasByNoContrato", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@IdContrato", SqlDbType.Int).Value = IdContrato;
                    dat.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in tabla.Rows)
                        {
                            Mediciones medicion = new Mediciones();
                            medicion = item;
                            mediciones.Add(medicion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MedicionesNoPagadasByIdContrato - " + ex.Message, "Clase Mediciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return mediciones;
        }

        public static DataTable ObtenerUltimaMedicionPagada(int noContrato)
        {
            DataTable tabla = new DataTable();
            Conexion con = new Conexion();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("ObtenerUltimaMedicionPagada", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@noContrato", SqlDbType.Int).Value = noContrato;
                    dat.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ObtenerUltimaMedicionPagada - " + ex.Message, "Clase Mediciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return tabla;
        }

        public int UpdateMedicioneAPagadas(int Id)
        {
            int aux = 0;
            Conexion con = new Conexion();
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("UpdateMedicioneAPagadas", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);
                    aux = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("UpdateMedicioneAPagadas - " + ex.Message, "Clase Mediciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return aux;
        }

        public static DataTable Mediciones_SelectByNoContrato(int noContrato, DateTime Fecha1, DateTime Fecha2)
        {
            DataTable tabla = new DataTable();
            
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("Mediciones_SelectByNoContrato", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;

                    dat.SelectCommand.Parameters.Add("@NoContrato", SqlDbType.Int).Value = noContrato;
                    dat.SelectCommand.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha1;
                    dat.SelectCommand.Parameters.Add("@Fecha2", SqlDbType.DateTime).Value = Fecha2;

                    dat.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mediciones_SelectByNoContrato - " + ex.Message, "Clase Mediciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return tabla;
        }
        public static DataTable Mediciones_Last10(int noContrato)
        {
            DataTable tabla = new DataTable();
            Conexion con = new Conexion();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("Mediciones_Last10", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@noContrato", SqlDbType.Int).Value = noContrato;
                    dat.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mediciones_Last10 - " + ex.Message, "Clase Mediciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return tabla;
        }

        public static int MedicionesTempToMediciones()
        {
            int aux = 0;
            Conexion con = new Conexion();
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("MedicionesTempToMediciones", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    aux = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MedicionesTempToMediciones - " + ex.Message, "Clase Mediciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return aux;
        }
        public static int MedicionesTempDelete()
        {
            int aux = 0;
            Conexion con = new Conexion();
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("MedicionesTempDelete", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    aux = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MedicionesTempDelete - " + ex.Message, "Clase Mediciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return aux;
        }

        public static implicit operator Mediciones(DataRow fila)
        {
            Mediciones medicion = new Mediciones
            {
                NoContrato = Convert.ToInt32(fila["noContrato"].ToString()),
                Litros = decimal.Parse(fila["litros"].ToString()),
                Fecha = Convert.ToDateTime(fila["fecha"].ToString()),
                Cantidad = Convert.ToDecimal(fila["cantidad"].ToString()),
                MesQueSePaga = Convert.ToInt32(fila["MesQueSePaga"].ToString()),
                AñoQueSePaga = Convert.ToInt32(fila["AñoQueSePaga"].ToString()),
                IdTarifa = Convert.ToInt32(fila["IdTarifa"].ToString())
            };


            return medicion;
        }
    }
}


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
    public class Porcentajes
    {
        private static Conexion _conexion = new Conexion();


        public int Id { get; set; }

        public decimal IVA { get; set; }
        public decimal Alcantarillado { get; set; }
        public decimal Saneamiento { get; set; }
        public decimal SalarioMinimo { get; set; }
        public decimal DescuentoAnual { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public DateTime FechaRegistrados { get; set; }

        public decimal Multas { get; set; }
        public decimal Recargos { get; set; }
        public decimal AumentoAnual { get; set; }

        public bool Guardar()
        {
            bool agregado = false;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("addPorcentajes", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IVA", SqlDbType.Decimal).Value = IVA;
                    cmd.Parameters.Add("@Alcantarillado", SqlDbType.Decimal).Value = Alcantarillado;
                    cmd.Parameters.Add("@Saneamiento", SqlDbType.Decimal).Value = Saneamiento;
                    cmd.Parameters.Add("@SalarioMinimo", SqlDbType.Decimal).Value = SalarioMinimo;
                    cmd.Parameters.Add("@DescuentoAnual", SqlDbType.Decimal).Value = DescuentoAnual;
                    cmd.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = FechaInicio;
                    cmd.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = FechaFin;
                    cmd.Parameters.Add("@Multas", SqlDbType.Decimal).Value = Multas;
                    cmd.Parameters.Add("@Recargos", SqlDbType.Decimal).Value = Recargos;
                    cmd.Parameters.Add("@AumentoAnual", SqlDbType.Decimal).Value = AumentoAnual;
                    cmd.Parameters.Add("@FechaRegistrados", SqlDbType.DateTime).Value = DateTime.Now;
                    agregado = Convert.ToInt32(cmd.ExecuteScalar().ToString()) > 0;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Guardar - " + ex.Message, "Clase Porcentajes", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("updatePorcentajes", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IVA", SqlDbType.Decimal).Value = IVA;
                    cmd.Parameters.Add("@Alcantarillado", SqlDbType.Decimal).Value = Alcantarillado;
                    cmd.Parameters.Add("@Saneamiento", SqlDbType.Decimal).Value = Saneamiento;
                    cmd.Parameters.Add("@SalarioMinimo", SqlDbType.Decimal).Value = SalarioMinimo;
                    cmd.Parameters.Add("@DescuentoAnual", SqlDbType.Decimal).Value = DescuentoAnual;
                    cmd.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = FechaInicio;
                    cmd.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = FechaFin;
                    cmd.Parameters.Add("@Multas", SqlDbType.Decimal).Value = Multas;
                    cmd.Parameters.Add("@Recargos", SqlDbType.Decimal).Value = Recargos;
                    cmd.Parameters.Add("@AumentoAnual", SqlDbType.Decimal).Value = AumentoAnual;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Porcentaje_Update - " + ex.Message, "Clase Porcentajes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return actualizado;
        }

        public static List<Porcentajes> GetPorcentajes()
        {
            DataTable tabla = new DataTable();
            List<Porcentajes> lista = new List<Porcentajes>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getPorcentajes", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Porcentajes porcentajes = new Porcentajes();
                            porcentajes = fila;
                            lista.Add(porcentajes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Porcentaje_Select - " + ex.Message, "Clase Porcentajes", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("deletePorcentajes", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdPorcentajes", SqlDbType.Int).Value = Id;
                    eliminado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eliminar - " + ex.Message, "Clase Porcentajes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminado;
        }


        public static implicit operator Porcentajes(DataRow fila)
        {
            Porcentajes porcentajes = new Porcentajes
            {
                Id = int.Parse(fila["Id"].ToString()),
                IVA = decimal.Parse(fila["IVA"].ToString()),
                Alcantarillado = decimal.Parse(fila["Alcantarillado"].ToString()),
                Saneamiento = decimal.Parse(fila["Saneamiento"].ToString()),
                SalarioMinimo = decimal.Parse(fila["SalarioMinimo"].ToString()),
                DescuentoAnual = decimal.Parse(fila["DescuentoAnual"].ToString()),
                FechaInicio = DateTime.Parse(fila["FechaInicio"].ToString()),
                FechaFin = DateTime.Parse(fila["FechaFin"].ToString()),
                FechaRegistrados = DateTime.Parse(fila["FechaRegistrados"].ToString()),
                Multas = decimal.Parse(fila["Multas"].ToString()),
                Recargos = decimal.Parse(fila["Recargos"].ToString()),
                AumentoAnual = decimal.Parse(fila["AumentoAnual"].ToString()),
            };

            return porcentajes;
        }
    }
}


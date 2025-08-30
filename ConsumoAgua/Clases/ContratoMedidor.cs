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
    public class ContratoMedidor
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int NoContrato { get; set; }
        public int IdMedidor { get; set; }
        public DateTime Fecha { get; set; }

        public bool Guardar()
        {
            bool agregado = false;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("addContratoMedidor", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NoContrato", SqlDbType.Int).Value = NoContrato;
                    cmd.Parameters.Add("@IdMedidor", SqlDbType.Int).Value = IdMedidor;
                    cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = DateTime.Now;

                    agregado = Convert.ToInt32(cmd.ExecuteScalar().ToString()) > 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Guardar - " + ex.Message, "Clase Medidores", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return agregado;
        }



        public static List<ContratoMedidor> GetTodos()
        {
            DataTable tabla = new DataTable();
            List<ContratoMedidor> lista = new List<ContratoMedidor>();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter dat = new SqlDataAdapter("getContratosMedidores", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure; dat.SelectCommand.CommandTimeout = 300;
                    dat.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            ContratoMedidor contratoMedidor = new ContratoMedidor();
                            contratoMedidor = fila;
                            lista.Add(contratoMedidor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MedidoresSelectTodos - " + ex.Message, "Clase Medidores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return lista;
        }

        public static List<ContratoMedidor> GetOcupadosByNoMedidor(int noMedidor)
        {
            DataTable tabla = new DataTable();
            List<ContratoMedidor> lista = new List<ContratoMedidor>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getMedidoresOcupadossByNoMedidor", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.Add("@NoMedidor", SqlDbType.Int).Value = noMedidor;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            ContratoMedidor contratoMedidor = new ContratoMedidor();
                            contratoMedidor = fila;
                            lista.Add(contratoMedidor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MedidoresAsignadosByNoMedidor - " + ex.Message, "Clase Medidores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return lista;
        }

        public static implicit operator ContratoMedidor(DataRow fila)
        {
            ContratoMedidor medidor = new ContratoMedidor
            {
                Id = Convert.ToInt32(fila["Id"].ToString()),
                NoContrato = Convert.ToInt32(fila["NoContrato"].ToString()),
                IdMedidor = Convert.ToInt32(fila["IdMedidor"].ToString()),
                Fecha = Convert.ToDateTime(fila["Fecha"].ToString())
            };

            return medidor;
        }
    }
}


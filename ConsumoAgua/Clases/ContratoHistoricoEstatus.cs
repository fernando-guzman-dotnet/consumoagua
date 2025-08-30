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
    public class ContratoHistoricoEstatus
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public int NoContrato { get; set; }
        public bool Estatus { get; set; }
        public DateTime Fecha { get; set; }

        public bool Agregar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addContratoHistoricoEstatus", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NoContrato", this.NoContrato);
                    cmd.Parameters.AddWithValue("@Estatus", this.Estatus);
                    cmd.Parameters.AddWithValue("@Fecha", this.Fecha);

                    Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase ContratoHistoricoEstatus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregado;
        }


        public static List<ContratoHistoricoEstatus> GetContratoHistoricoEstatus(int noContrato)
        {
            DataTable tabla = new DataTable();
            List<ContratoHistoricoEstatus> lista = new List<ContratoHistoricoEstatus>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getContratoHistoricoEstatus", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@NoContrato", noContrato);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            ContratoHistoricoEstatus contratoHistoricoEstatus = fila;
                            lista.Add(contratoHistoricoEstatus);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetContratoHistoricoEstatus - " + ex.Message, "Clase ContratoHistoricoEstatus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static implicit operator ContratoHistoricoEstatus(DataRow fila)
        {
            ContratoHistoricoEstatus contratoHistoricoEstatus = new ContratoHistoricoEstatus();

            contratoHistoricoEstatus.Id = int.Parse(fila["Id"].ToString());
            contratoHistoricoEstatus.NoContrato = int.Parse(fila["NoContrato"].ToString());
            contratoHistoricoEstatus.Estatus = bool.Parse(fila["Estatus"].ToString());
            contratoHistoricoEstatus.Fecha = DateTime.Parse(fila["Fecha"].ToString());

            return contratoHistoricoEstatus;
        }
    }
}


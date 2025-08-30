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
    public class ContratoBlob
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }

        public string GuidBlob { get; set; }
        public int NoContrato { get; set; }

        public string Nombre { get; set; }
        public string Extension { get; set; }

        public DateTime FechaSubida { get; set; }


        public bool Subir()
        {
            bool subido = false;

            try
            {
                _conexion.Actual.Open();

                SqlCommand cmd = new SqlCommand();

                cmd = new SqlCommand("addContratoBlob", _conexion.Actual);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@GuidBlob", SqlDbType.NVarChar).Value = this.GuidBlob;
                cmd.Parameters.Add("@NoContrato", SqlDbType.Int).Value = this.NoContrato;
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = this.Nombre;
                cmd.Parameters.Add("@Extension", SqlDbType.NVarChar).Value = this.Extension;
                cmd.Parameters.Add("@FechaSubida", SqlDbType.DateTime).Value = DateTime.Now;

                subido = Convert.ToInt32(cmd.ExecuteScalar()) > 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Subir - " + ex.Message, "Clase ContratoBlob", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return subido;
        }


        public static List<ContratoBlob> GetContratoBlobs(int noContrato)
        {
            List<ContratoBlob> lista = new List<ContratoBlob>();
            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getContratoBlobs", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.Add("@NoContrato", SqlDbType.Int).Value = noContrato;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            ContratoBlob contratoBlob = new ContratoBlob();
                            contratoBlob = fila;

                            lista.Add(contratoBlob);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetContratosBlobs - " + ex.Message, "Clase ContratoBlob", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }


        public static implicit operator ContratoBlob(DataRow fila)
        {
            ContratoBlob contratoBlob = new ContratoBlob()
            {
                Id = Convert.ToInt32(fila["Id"].ToString()),
                GuidBlob = fila["GuidBlob"].ToString(),
                NoContrato = Convert.ToInt32(fila["NoContrato"].ToString()),
                Nombre = fila["Nombre"].ToString(),
                Extension = fila["Extension"].ToString(),
                FechaSubida = DateTime.Parse(fila["FechaSubida"].ToString())
            };

            return contratoBlob;
        }

    }
}


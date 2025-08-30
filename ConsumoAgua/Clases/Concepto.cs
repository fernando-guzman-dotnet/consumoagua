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
    public class Concepto
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
        public bool AplicaIVA { get; set; }
        public bool EsFijo { get; set; }

        public bool Guardar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("addConcepto", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                    cmd.Parameters.AddWithValue("@Importe", this.Importe);
                    cmd.Parameters.AddWithValue("@AplicaIVA", this.AplicaIVA);
                    cmd.Parameters.AddWithValue("@EsFijo", this.EsFijo);

                    this.Id = int.Parse(cmd.ExecuteScalar().ToString());

                    agregado = this.Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("addConcepto - " + ex.Message, "Clase Concepto", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                using (SqlCommand cmd = new SqlCommand("updateConcepto", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                    cmd.Parameters.AddWithValue("@Importe", this.Importe);
                    cmd.Parameters.AddWithValue("@AplicaIVA", this.AplicaIVA);
                    cmd.Parameters.AddWithValue("@EsFijo", this.EsFijo);
                    cmd.Parameters.AddWithValue("@Id", this.Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("updateConcepto - " + ex.Message, "Clase Concepto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public bool Eliminar()
        {
            bool eliminado = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("deleteConcepto", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", this.Id);
                    eliminado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("deleteConcepto - " + ex.Message, "Clase Concepto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminado;
        }

        public static List<Concepto> GetConceptos()
        {
            List<Concepto> lista = new List<Concepto>();
            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("getConceptos", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Concepto concepto = new Concepto();
                            concepto = fila;

                            lista.Add(concepto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetConceptos - " + ex.Message, "Clase Concepto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }


        public static implicit operator Concepto(DataRow fila)
        {
            Concepto concepto = new Concepto
            {
                Id = int.Parse(fila["Id"].ToString()),
                Descripcion = fila["Descripcion"].ToString(),
                Importe = decimal.Parse(fila["Importe"].ToString()),
                AplicaIVA = bool.Parse(fila["AplicaIVA"].ToString()),
                EsFijo = bool.Parse(fila["EsFijo"].ToString())
            };

            return concepto;
        }
    }
}


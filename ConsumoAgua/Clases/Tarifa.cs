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

    public class Tarifa
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public bool GeneraIVA { get; set; }

        public bool Guardar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("addTarifa", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", this.Descripcion);
                    cmd.Parameters.AddWithValue("@GeneraIVA", GeneraIVA);
                    Id = Convert.ToInt32(cmd.ExecuteScalar());
                    agregado = Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("addTarifa - " + ex.Message, "Clase Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            bool actualizada = false;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("updateTarifa", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", this.Descripcion);
                    cmd.Parameters.AddWithValue("@GeneraIVA", this.GeneraIVA);
                    cmd.Parameters.AddWithValue("@idTarifa", this.Id);

                    actualizada = cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return actualizada;
        }

        public bool Eliminar()
        {
            bool eliminado = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("deleteTarifa", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTarifa", this.Id);

                    eliminado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("deleteTarifa - " + ex.Message, "Clase Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminado;
        }

        public static List<Tarifa> GetTarifas()
        {
            DataTable tabla = new DataTable();
            List<Tarifa> lista = new List<Tarifa>();

            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("getTarifas", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Tarifa tarifa = new Tarifa();
                            tarifa = fila;

                            lista.Add(tarifa);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getTarifas - " + ex.Message, "Clase Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public bool AgregarConcepto(int idConcepto, decimal cantidad)
        {
            bool agregado = false;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("addTarifaConcepto", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTarifa", this.Id);
                    cmd.Parameters.AddWithValue("@idConcepto", idConcepto);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);

                    agregado = int.Parse(cmd.ExecuteScalar().ToString()) > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("addTarifaConcepto - " + ex.Message, "Clase Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return agregado;
        }



        public bool EliminarConceptos()
        {
            bool eliminados = false;

            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("deleteTarifaConceptos", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTarifa", this.Id);
                    eliminados = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EliminarConceptos - " + ex.Message, "Clase Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminados;
        }


        public static DataTable GetTarifaConceptos(int idTarifa)
        {
            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("getTarifaConceptos", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.Add("@idTarifa", SqlDbType.Int).Value = idTarifa;
                    adapter.Fill(tabla);
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

            return tabla;
        }

        public static implicit operator Tarifa(DataRow fila)
        {
            Tarifa tarifa = new Tarifa()
            {
                Id = int.Parse(fila["Id"].ToString()),
                Descripcion = fila["Descripcion"].ToString(),
                GeneraIVA = bool.Parse(fila["GeneraIVA"].ToString())
            };

            return tarifa;
        }
    }
}


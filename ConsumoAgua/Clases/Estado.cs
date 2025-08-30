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
    public class Estado
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public string Nombre { get; set; }

        public bool Agregar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addEstado", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);

                    agregado = Convert.ToInt32(cmd.ExecuteScalar().ToString()) > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase Estado", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("updateEstado", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 150).Value = this.Nombre;
                    cmd.Parameters.Add("@IdEstado", SqlDbType.Int).Value = this.Id;

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Actualizar - " + ex.Message, "Clase Estado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public static List<Estado> GetEstados()
        {
            DataTable tabla = new DataTable();
            List<Estado> lista = new List<Estado>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getEstados", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Estado estado = new Estado();
                            estado = fila;
                            lista.Add(estado);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetEstados - " + ex.Message, "Clase Estado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static implicit operator Estado(DataRow fila)
        {
            Estado estado = new Estado()
            {
                Id = int.Parse(fila["Id"].ToString()),
                Nombre = fila["Nombre"].ToString()
            };

            return estado;
        }
    }
}


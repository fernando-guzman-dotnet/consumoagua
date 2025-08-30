using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPA.Clases
{
    public class TipoDescuento
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public string Descripcion { get; set; }

        [Browsable(false)]
        public bool UnicoPorUsuario { get; set; }

        public bool Guardar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addTipoDescuento", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                    cmd.Parameters.AddWithValue("@UnicoPorUsuario", UnicoPorUsuario);

                    agregado = int.Parse(cmd.ExecuteScalar().ToString()) > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Guardar - " + ex.Message, "Clase TipoDescuentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("updateTipoDescuento", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = Descripcion;
                    cmd.Parameters.AddWithValue("@UnicoPorUsuario", UnicoPorUsuario);
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Actualizar - " + ex.Message, "Clase TipoDescuentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public static List<TipoDescuento> GetTiposDescuento()
        {
            List<TipoDescuento> lista = new List<TipoDescuento>();
            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getTiposDescuento", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            TipoDescuento tipoDescuento = new TipoDescuento();
                            tipoDescuento = fila;

                            lista.Add(tipoDescuento);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TipoDescuentos_Select - " + ex.Message, "Clase TipoDescuentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("deleteTipoDescuento", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idDescuento", Id);
                    eliminado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TipoDescuentos_Delete - " + ex.Message, "Clase TipoDescuentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminado;
        }



        public static implicit operator TipoDescuento(DataRow fila)
        {
            TipoDescuento descuento = new TipoDescuento
            {
                Id = Convert.ToInt32(fila["Id"].ToString()),
                Descripcion = fila["Descripcion"].ToString(),
                UnicoPorUsuario = bool.Parse(fila["UnicoPorUsuario"].ToString())
            };

            return descuento;
        }
    }
}



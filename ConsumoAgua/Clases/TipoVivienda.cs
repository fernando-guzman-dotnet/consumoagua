using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAPA.Clases;

namespace Clases
{

    public class TipoVivienda
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public bool Guardar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addTipoVivienda", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", Descripcion);

                    agregado = Convert.ToInt32(cmd.ExecuteScalar().ToString()) > 0;

                    /*if (aux > 0)
                    {
                        Bitacora.EmpleadoLogInsert(CurrentEmpleado.Id,
                                 "Tipo de Vivienda ingresa con la descripción " +
                                 tipoVivienda.descripcion, "TipoViviendas", DateTime.Now);
                        MessageBox.Show("Tipo de Vivienda ingresada correctamente", "Formulario Tipo Vivienda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("addTipoVivienda - " + ex.Message, "Clase TipoViviendaDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("deleteTipoVivienda", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTipoVivienda", Id);
                    eliminado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("deleteTipoVivienda - " + ex.Message, "Clase TipoViviendaDAO", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminado;
        }

        public static List<TipoVivienda> GetTiposVivienda()
        {
            DataTable tabla = new DataTable();
            List<TipoVivienda> lista = new List<TipoVivienda>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getTiposVivienda", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            TipoVivienda tipoVivienda = new TipoVivienda();
                            tipoVivienda = fila;
                            lista.Add(tipoVivienda);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("getTiposVivienda - " + ex.Message, "Clase TipoViviendaDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public bool Actualizar()
        {
            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("updateTipoVivienda", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@descripcion", Descripcion);
                    cmd.Parameters.AddWithValue("@idTipoVivienda", Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;

                    /*if (aux > 0)
                    {
                        Bitacora.EmpleadoLogInsert(CurrentEmpleado.Id,
                            "Se actualizó el Tipo de Vivienda con Id " + tipoVivienda.idTipoVivienda,
                            "TipoViviendas", DateTime.Now);
                        MessageBox.Show("Tipo de Vivienda actualizado correctamente", "Formulario Tipo Vivienda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("updateTipoVivienda - " + ex.Message, "Clase TipoViviendaDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public static implicit operator TipoVivienda(DataRow fila)
        {
            TipoVivienda tipoVivienda = new TipoVivienda
            {
                Id = int.Parse(fila["idTipoVivienda"].ToString()),
                Descripcion = fila["Descripcion"].ToString(),
            };

            return tipoVivienda;
        }
    }
}


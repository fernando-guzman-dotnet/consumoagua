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
    public class TipoOrdenTrabajo
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public string Tipo { get; set; }

        public static List<TipoOrdenTrabajo> GetTiposOrdenesTrabajo()
        {
            List<TipoOrdenTrabajo> lista = new List<TipoOrdenTrabajo>();

            DataTable tabla = new DataTable();

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("getTipoOrdenesTrabajo", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            TipoOrdenTrabajo tipoOrdenTrabjo = fila;
                            lista.Add(tipoOrdenTrabjo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetTiposOrdenesTrabajo - " + ex.Message, "Clase TipoOrdenTrabajo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }



        public bool Agregar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addTipoOrdenTrabajo", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Tipo", Tipo);

                    Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    agregado = Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase TipoOrdenTrabjo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("updateTipoOrdenTrabajo", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Tipo", Tipo);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Actualizar - " + ex.Message, "Clase nombreClase", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("deleteTipoOrdenTrabajo", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);

                    eliminado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eliminar - " + ex.Message, "Clase TipoOrdenTrabajo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminado;
        }


        public static implicit operator TipoOrdenTrabajo(DataRow fila)
        {
            TipoOrdenTrabajo tipoOrdenTrabajo = new TipoOrdenTrabajo();

            tipoOrdenTrabajo.Id = int.Parse(fila["Id"].ToString());
            tipoOrdenTrabajo.Tipo = fila["Tipo"].ToString();

            return tipoOrdenTrabajo;
        }
    }
}


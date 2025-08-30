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
    public class Configuracion
    {
        private static Conexion _conexion = new Conexion();

        public static Configuracion Actual { get; set; }

        public int Id { get; set; }
        public decimal LimiteAñosCobro { get; set; }
        public int LimiteBimestresVencidos { get; set; }

        public bool Agregar()
        {
            bool agregado = false;


            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("addConfiguracion", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@LimiteAñosCobro", SqlDbType.Int).Value = this.LimiteAñosCobro;
                    cmd.Parameters.Add("@LimiteBimestresVencidos", SqlDbType.Int).Value = this.LimiteBimestresVencidos;

                    this.Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                    agregado = this.Id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agregar - " + ex.Message, "Clase Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("updateConfiguracion", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@LimiteAñosCobro", SqlDbType.Int).Value = this.LimiteAñosCobro;
                    cmd.Parameters.Add("@LimiteBimestresVencidos", SqlDbType.Int).Value = this.LimiteBimestresVencidos;
                    cmd.Parameters.Add("@IdConfiguracion", SqlDbType.Int).Value = Id;

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Actualizar - " + ex.Message, "Clase Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public static Configuracion GetConfiguracion()
        {
            Configuracion obj = null;

            DataTable tabla = new DataTable();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getConfiguracion", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            obj = fila;

                            // Solo cargamos el primer registro, ignoramos los demás
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getOrganismo - " + ex.Message, "Clase OrganismoDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return obj;
        }



        public static implicit operator Configuracion(DataRow fila)
        {
            Configuracion configuracion = new Configuracion
            {
                Id = int.Parse(fila["Id"].ToString()),
                LimiteAñosCobro = int.Parse(fila["LimiteAñosCobro"].ToString()),
                LimiteBimestresVencidos = int.Parse(fila["LimiteBimestresVencidos"].ToString())
            };

            return configuracion;
        }
    }
}


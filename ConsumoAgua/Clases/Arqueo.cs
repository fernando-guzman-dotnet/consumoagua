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
    public class Arqueo
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public int MonedasCincuentaCentavos { get; set; }
        public int MonedasUnPeso { get; set; }
        public int MonedasDosPesos { get; set; }
        public int MonedasCincoPesos { get; set; }
        public int MonedasDiezPesos { get; set; }
        
        public int BilletesVeintePesos { get; set; }
        public int BilletesCincuentaPesos { get; set; }
        public int BilletesCienPesos { get; set; }
        public int BilletesDoscientosPesos { get; set; }
        public int BilletesQuinientosPesos { get; set; }
        public int BilletesMilPesos { get; set; }

        public decimal Vauchers { get; set; }
        public decimal ChequesTransferencias { get; set; }

        public bool Guardar()
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addArqueo", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Fecha", Fecha);
                    cmd.Parameters.AddWithValue("@MonedasCincuentaCentavos", MonedasCincuentaCentavos);
                    cmd.Parameters.AddWithValue("@MonedasUnPeso", MonedasUnPeso);
                    cmd.Parameters.AddWithValue("@MonedasDosPesos", MonedasDosPesos);
                    cmd.Parameters.AddWithValue("@MonedasCincoPesos", MonedasCincoPesos);
                    cmd.Parameters.AddWithValue("@MonedasDiezPesos", MonedasDiezPesos);
                    cmd.Parameters.AddWithValue("@BilletesVeintePesos", BilletesVeintePesos);
                    cmd.Parameters.AddWithValue("@BilletesCincuentaPesos", BilletesCincuentaPesos);
                    cmd.Parameters.AddWithValue("@BilletesCienPesos", BilletesCienPesos);
                    cmd.Parameters.AddWithValue("@BilletesDoscientosPesos", BilletesDoscientosPesos);
                    cmd.Parameters.AddWithValue("@BilletesQuinientosPesos", BilletesQuinientosPesos);
                    cmd.Parameters.AddWithValue("@BilletesMilPesos", BilletesMilPesos);
                    cmd.Parameters.AddWithValue("@Vauchers", Vauchers);
                    cmd.Parameters.AddWithValue("@ChequesTransferencias", ChequesTransferencias);

                    Id = int.Parse(cmd.ExecuteScalar().ToString());

                    agregado = Id > 0;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Guardar - " + ex.Message, "Clase Arqueo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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

                using (SqlCommand cmd = new SqlCommand("updateArqueo", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MonedasCincuentaCentavos", MonedasCincuentaCentavos);
                    cmd.Parameters.AddWithValue("@MonedasUnPeso", MonedasUnPeso);
                    cmd.Parameters.AddWithValue("@MonedasDosPesos", MonedasDosPesos);
                    cmd.Parameters.AddWithValue("@MonedasCincoPesos", MonedasCincoPesos);
                    cmd.Parameters.AddWithValue("@MonedasDiezPesos", MonedasDiezPesos);
                    cmd.Parameters.AddWithValue("@BilletesVeintePesos", BilletesVeintePesos);
                    cmd.Parameters.AddWithValue("@BilletesCincuentaPesos", BilletesCincuentaPesos);
                    cmd.Parameters.AddWithValue("@BilletesCienPesos", BilletesCienPesos);
                    cmd.Parameters.AddWithValue("@BilletesDoscientosPesos", BilletesDoscientosPesos);
                    cmd.Parameters.AddWithValue("@BilletesQuinientosPesos", BilletesQuinientosPesos);
                    cmd.Parameters.AddWithValue("@BilletesMilPesos", BilletesMilPesos);
                    cmd.Parameters.AddWithValue("@Vauchers", Vauchers);
                    cmd.Parameters.AddWithValue("@ChequesTransferencias", ChequesTransferencias);
                    cmd.Parameters.AddWithValue("@Id", Id);

                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Actualizar - " + ex.Message, "Clase Arqueo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }


        public static Arqueo GetArqueoByFecha(DateTime fecha)
        {
            DataTable tabla = new DataTable();
            Arqueo arqueo = new Arqueo();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getArqueoByFecha", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@Fecha", fecha.Date);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        arqueo = tabla.Rows[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetArqueoByFecha - " + ex.Message, "Clase Arqueo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return arqueo;
        }



        public static List<Arqueo> GetArqueosByFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable tabla = new DataTable();
            List<Arqueo> lista = new List<Arqueo>();

            try
            {
                _conexion.Actual.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("getArqueosByFechas", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    adapter.SelectCommand.Parameters.AddWithValue("@FechaFin", fechaFin);
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            Arqueo arqueo = fila;
                            lista.Add(arqueo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetArqueoByFecha - " + ex.Message, "Clase Arqueo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return lista;
        }

        public static implicit operator Arqueo(DataRow fila)
        {
            Arqueo arqueo = new Arqueo
            {
                Id = int.Parse(fila["Id"].ToString()),
                Fecha = DateTime.Parse(fila["Fecha"].ToString()),
                MonedasCincuentaCentavos = int.Parse(fila["MonedasCincuentaCentavos"].ToString()),
                MonedasUnPeso = int.Parse(fila["MonedasUnPeso"].ToString()),
                MonedasDosPesos = int.Parse(fila["MonedasDosPesos"].ToString()),
                MonedasCincoPesos = int.Parse(fila["MonedasCincoPesos"].ToString()),
                MonedasDiezPesos = int.Parse(fila["MonedasDiezPesos"].ToString()),
                BilletesVeintePesos = int.Parse(fila["BilletesVeintePesos"].ToString()),
                BilletesCincuentaPesos = int.Parse(fila["BilletesCincuentaPesos"].ToString()),
                BilletesCienPesos = int.Parse(fila["BilletesCienPesos"].ToString()),
                BilletesDoscientosPesos = int.Parse(fila["BilletesDoscientosPesos"].ToString()),
                BilletesQuinientosPesos = int.Parse(fila["BilletesQuinientosPesos"].ToString()),
                BilletesMilPesos = int.Parse(fila["BilletesMilPesos"].ToString()),
                Vauchers = decimal.Parse(fila["Vauchers"].ToString()),
                ChequesTransferencias = decimal.Parse(fila["ChequesTransferencias"].ToString())
            };

            return arqueo;
        }
    }
}

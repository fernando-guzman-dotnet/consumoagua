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
    public class Queja
    {
        private static Conexion _conexion = new Conexion();

        public int idQueja { get; set; }
        public DateTime fechaCaptura { get; set; }
        public string horaCaptura { get; set; }
        public int idTarifa { get; set; }
        public string tarifa { get; set; }
        public int idSector { get; set; }
        public string sector { get; set; }
        public int idUsuario { get; set; }
        public string usuarioReporto { get; set; }
        public string usuarioCapturo { get; set; }
        public string descripcion { get; set; }
        public string Calle { get; set; }
        //public string Colonia { get; set; }
        public string NumeroInterior { get; set; }
        public string CP { get; set; }
        public string Referencias { get; set; }
        public string telefonoReporto { get; set; }
        public int idColonia { get; set; }
        public string colonia { get; set; }
        public int codigoPostal { get; set; }
        public bool Resuelta { get; set; }
        public DateTime FechaResuelta { get; set; }
        public bool eliminada { get; set; }



        public static bool addQueja(Queja queja)
        {
            bool agregado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("addQueja", _conexion.Actual))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar, 500).Value = queja.descripcion;
                    cmd.Parameters.Add("@Calle", SqlDbType.NVarChar, 500).Value = queja.Calle;
                    cmd.Parameters.Add("@NoInt", SqlDbType.NVarChar, 500).Value = queja.NumeroInterior;
                    cmd.Parameters.Add("@Ref", SqlDbType.NVarChar, 500).Value = queja.Referencias;
                    cmd.Parameters.Add("@fechaCaptura", SqlDbType.Date).Value = queja.fechaCaptura;
                    cmd.Parameters.Add("@horaCaptura", SqlDbType.Time).Value = queja.horaCaptura;
                    cmd.Parameters.Add("@idSector", SqlDbType.Int).Value = queja.idSector;
                    cmd.Parameters.Add("@idColonia", SqlDbType.Int).Value = queja.idColonia;
                    cmd.Parameters.Add("@codigoPostal", SqlDbType.Int).Value = queja.codigoPostal;
                    cmd.Parameters.Add("@reporto", SqlDbType.NVarChar, 250).Value = queja.usuarioReporto;
                    cmd.Parameters.Add("@telefonoReporto", SqlDbType.NVarChar, 20).Value = queja.telefonoReporto;
                    cmd.Parameters.Add("@capturo", SqlDbType.NVarChar, 250).Value = queja.usuarioCapturo;

                    int id = int.Parse(cmd.ExecuteScalar().ToString());

                    agregado = id > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("addQueja - " + ex.Message, "Clase QuejaDAO", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return agregado;
        }



        public static bool deleteQueja(int idQueja)
        {
            bool eliminado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("deleteQueja", _conexion.Actual))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = idQueja;

                    eliminado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("deleteQueja - " + ex.Message, "Clase QuejaDAO", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return eliminado;
        }



        public static DataTable getQuejas()
        {
            DataTable tabla = new DataTable();
            try
            {
                _conexion.Actual.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("getQuejas", _conexion.Actual))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getQuejas - " + ex.Message, "Clase QuejaDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return tabla;
        }

        public static bool updateQueja(Queja queja)
        {

            bool actualizado = false;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("updateQueja", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", queja.descripcion);
                    cmd.Parameters.AddWithValue("@Calle", queja.Calle);
                    //cmdParameters.AddWithValue("@Colonia", queja.colonia);
                    cmd.Parameters.AddWithValue("@NoInt", queja.NumeroInterior);
                    cmd.Parameters.AddWithValue("@Ref", queja.Referencias);
                    cmd.Parameters.AddWithValue("@fechaCaptura", queja.fechaCaptura);
                    cmd.Parameters.AddWithValue("@horaCaptura", queja.horaCaptura);
                    cmd.Parameters.AddWithValue("@idSector", queja.idSector);
                    cmd.Parameters.AddWithValue("@idColonia", queja.idColonia);
                    cmd.Parameters.AddWithValue("@codigoPostal", queja.codigoPostal);
                    cmd.Parameters.AddWithValue("@reporto", queja.usuarioReporto);
                    cmd.Parameters.AddWithValue("@telefonoReporto", queja.telefonoReporto);
                    cmd.Parameters.AddWithValue("@capturo", queja.usuarioCapturo);
                    cmd.Parameters.AddWithValue("@idQueja", queja.idQueja);
                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("updateQueja - " + ex.Message, "Clase QuejaDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return actualizado;
        }

        public static int QuejasDelete(int IdQueja)
        {
            int aux = 0;

            try
            {
                _conexion.Actual.Open();

                using (SqlCommand cmd = new SqlCommand("QuejasDelete", _conexion.Actual))
                {
                    cmd.Parameters.Add("@IdQueja", SqlDbType.Int).Value = IdQueja;
                    aux = cmd.ExecuteNonQuery();

                    // TODO: Agregar a la bitacora del empleado
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("QuejasDelete - " + ex.Message, "Clase QuejaDAO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }

            return aux;
        }

        //public List<Queja> _getQuejas()
        //{
        //    try
        //    {
        //        DataTable tabla = new DataTable();
        //        List<Queja> quejas = new List<Queja>();
        //        _con.Open();
        //        _con.cn.Close();
        //        using (SqlDataAdapter dat = new SqlDataAdapter("getQuejas", _con.cn))
        //        {
        //            dat.SelectCommand.CommandType = CommandType.StoredProcedure; dat.SelectCommand.CommandTimeout = 300;
        //            dat.Fill(tabla);
        //            if (tabla.Rows.Count > 0)
        //            {
        //                foreach (DataRow fila in tabla.Rows)
        //                {
        //                    Queja _queja = new Queja();
        //                    _queja = fila;
        //                    quejas.Add(_queja);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Clase QuejaDAO - QuejasSelectNoResueltas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        public static implicit operator Queja(DataRow fila)
        {
            Queja queja = new Queja
            {
                idQueja = Convert.ToInt32(fila["IdQueja"].ToString()),
                fechaCaptura = Convert.ToDateTime(fila["Fecha_De_Captura"].ToString()),
                horaCaptura = (fila["Hora_De_Captura"].ToString()),
                Calle = fila["Calle"].ToString(),
                NumeroInterior = fila["Numero_Interior"].ToString(),
                colonia = fila["Colonia"].ToString(),
                codigoPostal = Convert.ToInt32(fila["Codigo_Postal"].ToString()),
                Referencias = fila["referencias"].ToString(),
                usuarioReporto = fila["Usuario_que_reporto"].ToString(),
                telefonoReporto = fila["Telefono_quien_reporto"].ToString(),
                usuarioCapturo = fila["Usuario_que_capturo"].ToString(),
                descripcion = fila["Descripcion"].ToString(),
                idSector = Convert.ToInt32(fila["idSector"].ToString()),
                idColonia = Convert.ToInt32(fila["idColonia"].ToString()),
                Resuelta = Convert.ToBoolean(fila["resuelta"].ToString()),
                FechaResuelta = Convert.ToDateTime(fila["fechaResuelta"].ToString()),
                eliminada = Convert.ToBoolean(fila["eliminado"].ToString())
            };

            return queja;
        }
    }
}


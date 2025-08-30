using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SAPA.Clases.Facturacion
{
    public class Emisor
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public String Nombre { get; set; }
        public String RFC { get; set; }
        public String RazonSocial { get; set; }
        public String Calle { get; set; }
        public String NoInterior { get; set; }
        public String NoExterior { get; set; }
        public String Colonia { get; set; }
        public String Municipio { get; set; }
        public String Estado { get; set; }
        public String Pais { get; set; }
        public String CP { get; set; }
        public String Telefono { get; set; }
        public String Telefono2 { get; set; }
        public String Regimen_Fiscal { get; set; }
        public String Correo { get; set; }
        //public Image Logo { get; set; }


        public int Guardar()  
        {
            int res = 0;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("GuardarEmisores", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = Nombre;
                    cmd.Parameters.Add("@RFC", SqlDbType.NVarChar).Value = RFC;
                    cmd.Parameters.Add("@RazonSocial", SqlDbType.NVarChar).Value = RazonSocial;
                    cmd.Parameters.Add("@Calle", SqlDbType.NVarChar).Value = Calle;
                    cmd.Parameters.Add("@NoExterior", SqlDbType.NVarChar).Value = NoExterior;
                    cmd.Parameters.Add("@NoInterior", SqlDbType.NVarChar).Value = NoInterior;
                    cmd.Parameters.Add("@Colonia", SqlDbType.NVarChar).Value = Colonia;
                    cmd.Parameters.Add("@Municipio", SqlDbType.NVarChar).Value = Municipio;
                    cmd.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = Estado;
                    cmd.Parameters.Add("@Pais", SqlDbType.NVarChar).Value = Pais;
                    cmd.Parameters.Add("@CP", SqlDbType.NVarChar).Value = CP;
                    cmd.Parameters.Add("@Telefono1", SqlDbType.NVarChar).Value = Telefono;
                    cmd.Parameters.Add("@Telefono2", SqlDbType.NVarChar).Value = Telefono2;
                    cmd.Parameters.Add("@Regimen_Fiscal", SqlDbType.NVarChar).Value = Regimen_Fiscal;
                    //if (this.Logo == null)
                    //{
                    //    cmd.Parameters.Add("@Logo", System.Data.SqlDbType.Image).Value = DBNull.Value;
                    //}
                    //else
                    //{
                    //    System.IO.MemoryStream arg = new System.IO.MemoryStream();
                    //    Logo.Save(arg, System.Drawing.Imaging.ImageFormat.Png);
                    //    cmd.Parameters.Add("@Logo", System.Data.SqlDbType.Image).Value = arg.GetBuffer();
                    //}
                    cmd.Parameters.Add("@Correo", SqlDbType.NVarChar).Value = Correo;
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                {
                    _conexion.Actual.Close();
                }
            }
            return res;
        }

        public int Actualizar()  
        {
            int res = 0;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("ActualizarEmisores", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = Nombre;
                    cmd.Parameters.Add("@RFC", SqlDbType.NVarChar).Value = RFC;
                    cmd.Parameters.Add("@RazonSocial", SqlDbType.NVarChar).Value = RazonSocial;
                    cmd.Parameters.Add("@Calle", SqlDbType.NVarChar).Value = Calle;
                    cmd.Parameters.Add("@NoExterior", SqlDbType.NVarChar).Value = NoExterior;
                    cmd.Parameters.Add("@NoInterior", SqlDbType.NVarChar).Value = NoInterior;
                    cmd.Parameters.Add("@Colonia", SqlDbType.NVarChar).Value = Colonia;
                    cmd.Parameters.Add("@Municipio", SqlDbType.NVarChar).Value = Municipio;
                    cmd.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = Estado;
                    cmd.Parameters.Add("@Pais", SqlDbType.NVarChar).Value = Pais;
                    cmd.Parameters.Add("@CP", SqlDbType.NVarChar).Value = CP;
                    cmd.Parameters.Add("@Telefono1", SqlDbType.NVarChar).Value = Telefono;
                    cmd.Parameters.Add("@Telefono2", SqlDbType.NVarChar).Value = Telefono2;
                    cmd.Parameters.Add("@Regimen_Fiscal", SqlDbType.NVarChar).Value = Regimen_Fiscal;
                    //if (this.Logo == null)
                    //{
                    //    cmd.Parameters.Add("@Logo", System.Data.SqlDbType.Image).Value = DBNull.Value;
                    //}
                    //else
                    //{
                    //    System.IO.MemoryStream arg = new System.IO.MemoryStream();
                    //    Logo.Save(arg, System.Drawing.Imaging.ImageFormat.Png);
                    //    cmd.Parameters.Add("@Logo", System.Data.SqlDbType.Image).Value = arg.GetBuffer();
                    //}
                    cmd.Parameters.Add("@Correo", SqlDbType.NVarChar).Value = Correo;
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                {
                    _conexion.Actual.Close();
                }
            }
            return res;
        }

        public int Eliminar()
        {
            int res = 0;
            try
            {
                _conexion.Actual.Open();
                using (SqlCommand cmd = new SqlCommand("EliminarEmisores", _conexion.Actual))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                {
                    _conexion.Actual.Close();
                }
            }
            return res;
        }

        public DataTable SelectEmisores(int Consulta)  
        {
            DataTable tabla = new DataTable();
            try
            {

                using (SqlDataAdapter dat = new SqlDataAdapter("SelectEmisores", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@Consulta", SqlDbType.Int).Value = Consulta;
                    //consulta=1 muestra todos los datos
                    //consulta=2 muestra datos para datagridview
                    //dat.SelectCommand.Parameters.Add
                    dat.Fill(tabla);
                }
            }
            catch
            {

            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return tabla;
        }

        public DataTable SelectEmisoresPorID()  
        {
            DataTable tabla = new DataTable();
            try
            {

                using (SqlDataAdapter dat = new SqlDataAdapter("SelectEmisoresPorID", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                    //dat.SelectCommand.Parameters.Add("@Consulta", SqlDbType.Int).Value = Consulta;
                    //dat.SelectCommand.Parameters.Add
                    dat.Fill(tabla);
                }
            }
            catch
            {

            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return tabla;
        }

        public DataTable SelectEmisoresPorNombre(int Consulta)  
        {
            DataTable tabla = new DataTable();
            try
            {

                using (SqlDataAdapter dat = new SqlDataAdapter("SelectEmisoresPorNombre", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = Nombre;
                    dat.SelectCommand.Parameters.Add("@Consulta", SqlDbType.Int).Value = Consulta;
                    //dat.SelectCommand.Parameters.Add
                    dat.Fill(tabla);
                }
            }
            catch
            {

            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return tabla;
        }

        public DataTable SelectEmisoresPorRFC()  
        {
            DataTable tabla = new DataTable();
            try
            {

                using (SqlDataAdapter dat = new SqlDataAdapter("SelectEmisoresPorRFC", _conexion.Actual))
                {
                    dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dat.SelectCommand.Parameters.Add("@RFC", SqlDbType.NVarChar).Value = RFC;
                    //dat.SelectCommand.Parameters.Add
                    dat.Fill(tabla);
                }
            }
            catch
            {

            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
            return tabla;
        }

    }
}


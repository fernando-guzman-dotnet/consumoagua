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
    public class EnvioMasivo
    {
        private static Conexion _conexion = new Conexion();



        public static void InsertTabuladorMasivo(DataTable tbl, string name)
        {

            try
            {
                _conexion.Actual.Open();

                //------------------------------------------------------------------------

                using (SqlBulkCopy bulkcopy = new SqlBulkCopy(_conexion.Actual))
                {
                    bulkcopy.BulkCopyTimeout = 6600;
                    bulkcopy.DestinationTableName = name;
                    bulkcopy.WriteToServer(tbl);
                    bulkcopy.Close();
                }

                //------------------------------------------------------------------------
                // MessageBox.Show("Archivo procesado de forma correcta", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("InsertTabuladorMasivo - " + ex.Message, "Clase EnvioMasivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_conexion.Actual.State != ConnectionState.Closed)
                    _conexion.Actual.Close();
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Municipios = SAPA.Clases.Globales.Municipios;

namespace SAPA.Clases
{
    internal class Conexion
    {
        // Generamos un campo con una conexión diferente para cada instancia

        public SqlConnection Actual { get; } = new SqlConnection(GenerarCadenaConexion().ToString());

        // Usar este singleton causará problemas al estar en hilos diferentes -- en algunas clases sí es importante inicializar una nueva, el pooling ya se maneja por sí solo
        
        // public static SqlConnection Actual => _currentConn ?? (_currentConn = new SqlConnection(GenerarCadenaConexion().ToString()));
        // private static SqlConnection _currentConn;

        public static string Servidor => GenerarCadenaConexion().DataSource;

        private static SqlConnectionStringBuilder GenerarCadenaConexion()
        {
            string connStr;

            switch (Globales.MunicipioActual)
            {
                case Municipios.Jacona:
                    //connStr = @"Data Source=(LocalDB)\SAPA;Initial Catalog=ConsumoAgua;Integrated Security=True;MultipleActiveResultSets=True";
                    connStr = @"Data Source=dahlia.arvixe.com;Initial Catalog=ConsumoAgua;Persist Security Info=True;User ID=JaimeHere;Password=C327da5f2D;MultipleActiveResultSets=True";
                    break;

                case Municipios.Tinguindin:
                    // connStr = @"Data Source=dahlia.arvixe.com;Initial Catalog=ConsumoAguaTest;Persist Security Info=True;User ID=JaimeHere;Password=C327da5f2D;MultipleActiveResultSets=True";
                    connStr = @"Data source=sapa-tinguindin.database.windows.net;Initial Catalog=SAPA; user id=dep_agua; password='#527CBF.h2o.5DD700#';Connection Timeout=999";
                    break;

                case Municipios.Pruebas:
                    connStr = @"Data source=ws207.win.arvixe.com;Initial Catalog=SAPATest;user id=sapaAdmin; password='Admin123+-@';Connection Timeout=999";
                    break;

                default:
                    throw new NotImplementedException("No hay una cadena de conexión para este municipio.");
            }

            return new SqlConnectionStringBuilder(connStr);
        }

        #region Conexión - Facturación
        private static SqlConnection _connTokens;
        public static SqlConnection ActualTokens => _connTokens ?? (_connTokens = new SqlConnection("Data source=sapadevelopmentsadhoc.database.windows.net;Initial Catalog=CatalogoSat; user id=SAPADEP_CatalogoSat; password='=#D3P.4D12?=';Connection Timeout=999"));
        #endregion

        #region Lógica — Licencias SAPA

        private void etc()
        {

        }

        #endregion
    }
}


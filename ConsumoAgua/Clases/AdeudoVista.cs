using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPA.Clases
{
    public class AdeudoVista
    {
        public DateTime FechaPeriodo { get; set; }

        public string Periodo =>
            $"{Utilerias.GetInicioPeriodoBimestral(FechaPeriodo).ToString("MMM yy", new CultureInfo("es-MX"))} - {Utilerias.GetFinPeriodoBimestral(FechaPeriodo).ToString("MMM yy", new CultureInfo("es-MX"))}";

        public decimal Agua { get; set; }
        public decimal Alcantarillado { get; set; }
        public decimal Saneamiento { get; set; }
        public decimal Recargos { get; set; }
        public decimal Multas { get; set; }
        public decimal GastosEjecucion { get; set; }
        public decimal Redondeo { get; set; }
        public decimal IVA { get; set; }

        public decimal AdeudoTotal { get; set; }


        public static implicit operator AdeudoVista(DataRow fila)
        {
            AdeudoVista adeudoVista = new AdeudoVista
            {
                FechaPeriodo = DateTime.Parse(fila["Periodo"].ToString()),

                Agua = decimal.Parse(fila["Agua"].ToString()),
                Alcantarillado = decimal.Parse(fila["Alcantarillado"].ToString()),
                Saneamiento = decimal.Parse(fila["Saneamiento"].ToString()),
                Recargos = decimal.Parse(fila["Recargos"].ToString()),
                Multas = decimal.Parse(fila["Multas"].ToString()),
                GastosEjecucion = decimal.Parse(fila["GastosEjecucion"].ToString()),
                Redondeo = decimal.Parse(fila["Redondeo"].ToString()),
                IVA = decimal.Parse(fila["IVA"].ToString()),

                AdeudoTotal = decimal.Parse(fila["AdeudoTotal"].ToString())
            };

            return adeudoVista;
        }

    }
}


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
    public class DescuentoValores
    {
        public int Id { get; set; }
        public decimal Agua { get; set; }
        public decimal Alcantarillado { get; set; }
        public decimal Saneamiento { get; set; }
        public decimal Recargos { get; set; }
        public decimal Multas { get; set; }
        public decimal GastosEjecucion { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }


        public static implicit operator DescuentoValores(DataRow fila)
        {
            DescuentoValores descuentoValores = new DescuentoValores();

            descuentoValores.Id = int.Parse(fila["Id"].ToString());
            descuentoValores.Agua = decimal.Parse(fila["Agua"].ToString());
            descuentoValores.Alcantarillado = decimal.Parse(fila["Alcantarillado"].ToString());
            descuentoValores.Saneamiento = decimal.Parse(fila["Saneamiento"].ToString());
            descuentoValores.Recargos = decimal.Parse(fila["Recargos"].ToString());
            descuentoValores.Multas = decimal.Parse(fila["Multas"].ToString());
            descuentoValores.GastosEjecucion = decimal.Parse(fila["GastosEjecucion"].ToString());
            descuentoValores.IVA = decimal.Parse(fila["IVA"].ToString());
            descuentoValores.Total = decimal.Parse(fila["Total"].ToString());

            return descuentoValores;
        }
    }
}


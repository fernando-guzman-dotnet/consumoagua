using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPA.Clases
{
    public class BitacoraNotificacion
    {
        private static Conexion _conexion = new Conexion();

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdNotificacion { get; set; }
        public int IdEstatus { get; set; }
        public string Estatus { get; set; }
        public string Observaciones { get; set; }
        public int IdEmpleado { get; set; }
    }
}


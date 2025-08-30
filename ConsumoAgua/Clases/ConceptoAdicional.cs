using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPA.Clases
{
    public class ConceptoAdicional
    {
        public int Id { get; set; }
        public int IdConcepto => Concepto.Id;
        public decimal Importe { get; set; }

        [Browsable(false)]
        public Concepto Concepto { get; set; }


        public static implicit operator ConceptoAdicional(DataRow fila)
        {
            ConceptoAdicional conceptoAdicional = new ConceptoAdicional
            {
                Id = int.Parse(fila["Id"].ToString()),
                Concepto = new Concepto
                {
                    Id = int.Parse(fila["IdConcepto"].ToString()),
                    Descripcion = fila["DescripcionConcepto"].ToString()
                },
                Importe = decimal.Parse(fila["Importe"].ToString())
            };
            return conceptoAdicional;
        }
    }
}


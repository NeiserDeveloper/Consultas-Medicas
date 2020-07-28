using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Pagos
    {
        public int CodPago { get; set; }
        public DateTime Fecha { get; set; }
        public int CodTipoPago { get; set; }
        public int CodConsulta { get; set; }
        public int Estado { get; set; }
        public decimal Monto { get; set; }

    }
}

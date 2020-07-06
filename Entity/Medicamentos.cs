using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Medicamentos
    {
        public int CodMedicamento { get; set; }
        public string Nombre { get; set; }
        public string Concentracion { get; set; }
        public string Forma { get; set; }
        public string Presentacion { get; set; }
        public decimal precio { get; set; }

        public int Estado { get; set; }
    }
}

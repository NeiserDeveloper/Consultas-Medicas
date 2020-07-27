using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AtenderConsulta
    {

        public int CodAtencion { get; set; }
        public int CodMedicamento { get; set; }
        public string Indicacion { get; set; }
        public DateTime FechaAtencion { get; set; }
        public int CodConsulta { get; set; }
        public int Estado { get; set; }
        public int CodDoctor { get; set; }
        public string Examen { get; set; }
        public string Diagnostico { get; set; }
        public int EstadoConsulta{get; set; }
    }
}

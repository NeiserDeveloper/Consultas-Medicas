using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Consulta
    {

        public int CodConsulta { get; set; }
        public int Tipo { get; set; }
        public string TipoTexto { get; set; }
        public int CodPaciente { get; set; }
        public decimal Peso { get; set; }
        public decimal Estatura { get; set; }
        public DateTime Fecha { get; set; }
        public string FechaFormato { get; set; }
        public string Descripcion { get; set; }
        public int EstadoConsulta { get; set; }
        public string EstConsultaTexto { get; set; }
        public int Estado { get; set; }
        public string Observacion { get; set; }

        //Adiocionales
        public string Paciente { get; set; }
        public string DireccionPaciente { get; set; }
    }
}

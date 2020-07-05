using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Pacientes
    {
        public int CodPaciente {get; set;}
        public int Documento { get; set; }
        public string Nombres { get; set; }
        //public string Apellidos { get; set; }
        public DateTime FechaNacimiento{ get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int Estado { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Doctor
    {
        public int CodDoctor { get; set; }
        public string Nombres { get; set; }
        public int CodEspecialidad { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Colegiado { get; set; }
        public int Estado { get; set; }
    }
}

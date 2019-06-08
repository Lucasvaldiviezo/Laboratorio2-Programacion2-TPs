using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoExcepcion : Exception
    {
        public AlumnoRepetidoExcepcion() : base("Ese alumno ya se encuentra agregado")
        {

        }
    }
}

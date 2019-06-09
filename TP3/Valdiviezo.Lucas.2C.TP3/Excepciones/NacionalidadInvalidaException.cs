using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public NacionalidadInvalidaException() : this("Error")
        {

        }
        /// <summary>
        /// Constructor de instancia.
        /// <param name="message">Mensaje a mostrar. </param>
        /// </summary>
        public NacionalidadInvalidaException(string message) : base(message)
        {

        }
    }
}

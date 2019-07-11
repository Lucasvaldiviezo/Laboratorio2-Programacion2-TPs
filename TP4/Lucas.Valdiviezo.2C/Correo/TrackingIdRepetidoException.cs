using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Constructor de instancia
        /// <param name="mensaje">Mensaje que se guardar en la excepcion y notificara al usuario. </param>
        /// </summary>
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        {

        }
        /// Constructor de instancia
        /// <param name="mensaje">Mensaje que se guardar en la excepcion y notificara al usuario. </param>
        /// <param name="innerException">Excepcion controlada para mas informacion. </param>
        /// </summary>
        public TrackingIdRepetidoException(string mensaje, Exception innerException) : base(mensaje,innerException)
        {

        }
    }
}

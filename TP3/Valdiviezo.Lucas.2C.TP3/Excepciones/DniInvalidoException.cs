using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public DniInvalidoException() : this("Error",null)
        {
          
        }
        /// <summary>
        /// Constructor de instancia.
        /// <param name="e">Excepcion Recibida. </param>
        /// </summary>
        public DniInvalidoException(Exception e) : this("Error",e)
        {

        }
        /// <summary>
        /// Constructor de instancia.
        /// <param name="message">Mensaje a mostrar. </param>
        /// </summary>
        public DniInvalidoException(string message) : this(message,null)
        {

        } /// <summary>
          /// Constructor de instancia.
          /// <param name="message">Mensaje a mostrar. </param>
          /// <param name="e">Excepcion recibida. </param>
          /// </summary>
        public DniInvalidoException(string message, Exception e) : base(message,e)
        {
            mensajeBase = message;
        }
    }
}

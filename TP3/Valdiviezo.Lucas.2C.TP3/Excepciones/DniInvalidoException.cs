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

        public DniInvalidoException() : this("Error",null)
        {
          
        }

        public DniInvalidoException(Exception e) : this("Error",e)
        {

        }

        public DniInvalidoException(string message) : this(message,null)
        {

        }
        public DniInvalidoException(string message, Exception e) : base(message,e)
        {
            mensajeBase = message;
        }
    }
}

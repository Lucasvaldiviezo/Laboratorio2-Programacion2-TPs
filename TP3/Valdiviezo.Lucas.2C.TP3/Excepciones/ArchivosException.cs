using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor de instancia.
        /// <param name="e">Excepcion Recibida. </param>
        /// </summary>
        public ArchivosException(Exception innerException) : base("Error al Leer/Guardar el archivo",innerException)
        {

        }
    }
}

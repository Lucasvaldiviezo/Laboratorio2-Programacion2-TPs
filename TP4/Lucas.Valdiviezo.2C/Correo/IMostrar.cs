using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfaz con un generico T que obliga a implementar el metodo MostrarDatos
    /// </summary>
    public interface IMostrar <T>
    {
        string MostrarDatos(IMostrar<T> elemento);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public string Apellido
        {
            set { ValidarNombreApellido(apellido); }
            get { return apellido; }
        }
        public string Nombre
        {
            set { ValidarNombreApellido(nombre); }
            get { return nombre; }
        }

        private string ValidarNombreApellido(string dato)
        {
            string retorno = dato;
            for(int i = 0;i<dato.Length;i++)
            {
                if (dato[i] < '0' && dato[i] > '9')
                {
                    retorno = "";
                    break;
                }
            }
            return retorno;
        }
    }
}

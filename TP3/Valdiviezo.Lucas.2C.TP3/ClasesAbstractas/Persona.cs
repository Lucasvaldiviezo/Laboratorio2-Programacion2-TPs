using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

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
        /// <summary>
        /// Aplica o Devuelve el Apellido de una Persona luego de validarlo.
        /// </summary>
        public string Apellido
        {
            set { apellido = ValidarNombreApellido(apellido); }
            get { return apellido; }
        }
        /// <summary>
        /// Aplica o Devuelve el Nombre de una Persona luego de validarlo.
        /// </summary>
        public string Nombre
        {
            set { nombre = ValidarNombreApellido(nombre); }
            get { return nombre; }
        }
        /// <summary>
        /// Aplica o Devuelve el DNI de una Persona luego de validarlo.
        /// </summary>
        public int DNI
        {
            set { dni = ValidarDni(nacionalidad, value); }
            get { return dni; }
        }
        /// <summary>
        /// Aplica o Devuelve la nacionalidad de una Persona.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            set { nacionalidad = value; }
            get { return nacionalidad; }
        }

        public string StringToDNI
        {
            set { dni = ValidarDni(nacionalidad, value); }
        }

        public Persona() : this("","",ENacionalidad.Argentino)
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) 
        {
            Apellido = apellido;
            Nombre = nombre;
            Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {  
            DNI = dni; 
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder mostrar = new StringBuilder();
            mostrar.AppendFormat("NOMBRE COMPLETO: {0},{1}\n", Apellido, Nombre);
            mostrar.AppendFormat("NACIONALIDAD: {0}\nDNI: {1}", Nacionalidad, DNI);

            return mostrar.ToString();
        }
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = 0;
            if(dni > 1 && dni < 99999999)
            {
                if (nacionalidad == ENacionalidad.Argentino && dato < 89999999)
                {
                    retorno = dato;
                }
                else if (nacionalidad == ENacionalidad.Extranjero && dato > 90000000 && dato < 99999999)
                {
                    retorno = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("El DNI y la Nacionalidad no coinciden");
                }
            }
            

            return retorno;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = 0;
            int auxDato;
            
            if(int.TryParse(dato, out auxDato))
            {
                retorno = ValidarDni(nacionalidad, auxDato);
            }else
            {
                throw new DniInvalidoException("El DNI ingresado contiene caracteres invalidos");
            }

            return retorno;
        }
        private string ValidarNombreApellido(string dato)
        {
            string retorno = dato;
            if(dato != null)
            {
                for (int i = 0; i < dato.Length; i++)
                {
                    if (dato[i] < '0' && dato[i] > '9')
                    {
                        retorno = "";
                        break;
                    }
                }
            }else
            {
                dato = "";
            }
            return retorno;
        }
    }
}

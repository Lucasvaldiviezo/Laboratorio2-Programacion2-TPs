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

        public string Apellido
        {
            set { apellido = ValidarNombreApellido(apellido); }
            get { return apellido; }
        }
        public string Nombre
        {
            set { nombre = ValidarNombreApellido(nombre); }
            get { return nombre; }
        }

        public int DNI
        {
            set { dni = ValidarDni(nacionalidad, value); }
            get { return dni; }
        }
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

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this(nombre,apellido,0,nacionalidad)
        {
        }

        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad)
        {
            Apellido = apellido;
            Nombre = nombre;
            DNI = dni;
            Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            Apellido = apellido;
            Nombre = nombre;
            StringToDNI = dni;
            Nacionalidad = nacionalidad;
        }

        public override string ToString()
        {
            StringBuilder mostrar = new StringBuilder();
            mostrar.AppendFormat("Nombre: {0}\nApellido: {1}\n", Nombre, Apellido);
            mostrar.AppendFormat("Nacionalidad: {0}\nDNI: {1}", Nacionalidad, DNI);

            return mostrar.ToString();
        }
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = 0;
            if(nacionalidad == ENacionalidad.Argentino && dato > 1 && dato < 89999999)
            {
                retorno = dato;
            }else if (nacionalidad == ENacionalidad.Extranjero && dato > 90000000 && dato < 99999999)
            {
                retorno = dato;
            }else
            {
                throw new NacionalidadInvalidaException("Ingreso una nacionalidad invalida, revise su nacionalidad o numnero de DNI");
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
                throw new NacionalidadInvalidaException("Lo que ingreso no es un DNI, ingrese solo valores numericos");
            }
            return retorno;
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

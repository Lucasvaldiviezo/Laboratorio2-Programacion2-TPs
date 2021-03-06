﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

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
        /// Guarda o Devuelve el Apellido de una Persona luego de validarlo.
        /// </summary>
        public string Apellido
        {
            set { apellido = ValidarNombreApellido(value); }
            get { return apellido; }
        }
        /// <summary>
        /// Guarda o Devuelve el Nombre de una Persona luego de validarlo.
        /// </summary>
        public string Nombre
        {
            set { nombre = ValidarNombreApellido(value); }
            get { return nombre; }
        }
        /// <summary>
        /// Guarda o Devuelve el DNI de una Persona luego de validarlo.
        /// </summary>
        public int DNI
        {
            set { dni = ValidarDni(nacionalidad, value); }
            get { return dni; }
        }
        /// <summary>
        /// Guarda o Devuelve la nacionalidad de una Persona.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            set { nacionalidad = value; }
            get { return nacionalidad; }
        }
        /// <summary>
        /// Guarda un DNI(String) luego de validarlo.
        /// </summary>
        public string StringToDNI
        {
            set { dni = ValidarDni(nacionalidad, value); }
        }
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona()
        {
        }
        /// <summary>
        /// Constructor publico de instancia.
        /// <param name="nombre">Nombre de la persona. </param>
        /// <param name="apellido">Apellido de la persona. </param>
        /// <param name="nacionalidad">Nacionalidad de la persona(Puede ser Argentino o Extranjero). </param>
        /// </summary>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) 
        {
            Apellido = apellido;
            Nombre = nombre;
            Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor publico de instancia.
        /// <param name="nombre">Nombre de la persona. </param>
        /// <param name="apellido">Apellido de la persona. </param>
        /// <param name="dni">DNI(INT) de la persona. </param>
        /// <param name="nacionalidad">Nacionalidad de la persona(Puede ser Argentino o Extranjero). </param>
        /// </summary>
        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {  
            DNI = dni; 
        }
        /// <summary>
        /// Constructor publico de instancia.
        /// <param name="nombre">Nombre de la persona. </param>
        /// <param name="apellido">Apellido de la persona. </param>
        /// <param name="dni">DNI(STRING) de la persona. </param>
        /// <param name="nacionalidad">Nacionalidad de la persona(Puede ser Argentino o Extranjero). </param>
        /// </summary>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            StringToDNI = dni;
        }
        /// <summary>
        /// Metodo sobreescrito de ToString, el cual devuelve todos los datos de una persona.
        /// </summary>
        /// <returns>Datos de la persona.</returns>
        public override string ToString()
        {
            StringBuilder mostrar = new StringBuilder();
            mostrar.AppendFormat("NOMBRE COMPLETO: {0},{1}\n", Apellido, Nombre);
            mostrar.AppendFormat("NACIONALIDAD: {0}", Nacionalidad);

            return mostrar.ToString();
        }
        /// <summary>
        /// Validador de DNI(INT).
        /// <param name="nacionalidad">Nacionalidad de la persona. </param>
        /// <param name="dato">DNI de la persona(INT). </param>
        /// </summary>
        /// <returns>DNI si es valido o 0 si es invalido.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = 0;
            if(dato > 1 && dato < 99999999)
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
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                }
            }else
            {
                throw new DniInvalidoException("El DNI ingresado esta fuera de rango");
            }
            

            return retorno;
        }
        /// <summary>
        /// Validador de DNI(String).
        /// <param name="nacionalidad">Nacionalidad de la persona. </param>
        /// <param name="dato">DNI de la persona(String). </param>
        /// </summary>
        /// <returns>DNI si es valido o un string vacio si es invalido.</returns>
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
        /// <summary>
        /// Validador de String, mas especificamente nombre o apellido de una persona.
        /// <param name="dato">Nombre o Apellido de la persona. </param>
        /// </summary>
        /// <returns>La cadena recibida si es valida o un string vacio si es invalido.</returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = dato;
            for (int i = 0; i < dato.Length; i++)
            {
                if (dato[i] < 'A' && dato[i] > 'Z' || dato[i] < 'a' && dato[i] > 'z')
                {
                    retorno = "";
                    break;
                }
            }
            return retorno;
        }
    }
}

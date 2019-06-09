using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Alumno()
        {

        }
        /// <summary>
        /// Constructor publico de instancia.
        /// <param name="id">Legajo del alumno(persona). </param>
        /// <param name="nombre">Nombre del alumno(persona). </param>
        /// <param name="apellido">Apellido del alumno(persona). </param>
        /// <param name="dni">DNI del alumno(persona). </param>
        /// <param name="nacionalidad">Nacionalidad del alumno(persona(Puede ser Argentino o Extranjero)). </param>
        /// <param name="nacionalidad">Clases que toma el alumno(persona(Programacion, Laboratorio, SPD o Legislacion)). </param>
        /// </summary>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,Universidad.EClases claseQueToma) : base(id,nombre,apellido,dni,nacionalidad)
        {

        }
        /// <summary>
        /// Constructor publico de instancia.
        /// <param name="id">Legajo del alumno(persona). </param>
        /// <param name="nombre">Nombre del alumno(persona). </param>
        /// <param name="apellido">Apellido del alumno(persona). </param>
        /// <param name="dni">DNI del alumno(persona). </param>
        /// <param name="nacionalidad">Nacionalidad del alumno(persona(Puede ser Argentino o Extranjero)). </param>
        /// <param name="nacionalidad">Clases que toma el alumno(persona(Programacion, Laboratorio, SPD o Legislacion)). </param>
        /// <param name="estadoCuenta">Estado de la cuenta del alumno(persona(Becado, Deudor, AlDia)). </param>
        /// </summary>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta) : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;
        }
        /// <summary>
        /// Sobrecarga del operador == que verifica si un alumnmo toma una clase especifica.
        /// <param name="a">Alumno a comparar. </param>
        /// <param name="clase">Clase a comparar. </param>
        /// </summary>
        /// <returns>True si el alumno toma la clase o false si no lo hace.</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }

            return retorno;
        }
        /// <summary>
        /// Sobrecarga del operador != que verifica si un alumnmo no toma una clase especifica.
        /// <param name="a">Alumno a comparar. </param>
        /// <param name="clase">Clase a comparar. </param>
        /// </summary>
        /// <returns>True si el alumno no toma la clase o false si lo hace.</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if (a.claseQueToma != clase)
            {
                retorno = true;
            }

            return retorno;
        }
        /// <summary>
        /// Sobrecarga del metodo MostrarDatos que solo puede ser usada por la clase o derivadas y devuelve los datos del alumno.
        /// </summary>
        /// <returns>String con los datos del alumno.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder mostrar = new StringBuilder();
            mostrar.AppendFormat("{0} Estado de Cuenta: {1}\n", base.MostrarDatos(), estadoCuenta);
            return mostrar.ToString();
        }
        /// <summary>
        /// Sobrecarga del metodo ParticiparEnClase que solo puede ser usada por la clase o derivadas y devuelve la clase que toma el alumno.
        /// </summary>
        /// <returns>String con la clase que toma el alumno.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder mostrar = new StringBuilder();
            mostrar.AppendFormat("\nTOMA CLASE DE: {0}",claseQueToma);
            return mostrar.ToString();
        }
        /// <summary>
        /// Sobrecarga del metodo ToString la cual puede ser llamada fuera de la clase y devuelve los datos del alumno.
        /// </summary>
        /// <returns>String con la clase que toma el alumno.</returns>
        public override string ToString()
        {
            StringBuilder mostrar = new StringBuilder();
            mostrar.AppendFormat(MostrarDatos(), ParticiparEnClase());
            return mostrar.ToString();
        }
    }
}

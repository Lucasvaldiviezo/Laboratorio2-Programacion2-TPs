using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;
        /// <summary>
        /// Sobreescritura del metodo Equals, el cual recibe un objeto y lo devuelve solo si es del Tipo Universitario.
        /// <param name="obj">Objeto a validar. </param>
        /// </summary>
        /// <returns>Objeto del tipo universitario.</returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Universitario()
        {
            
        }
        /// <summary>
        /// Constructor publico de instancia.
        /// <param name="legajo">Legajo del Universitario. </param>
        /// <param name="nombre">Nombre de la Universitario(persona). </param>
        /// <param name="apellido">Apellido de la Universitario(persona). </param>
        /// <param name="dni">DNI de la Universitario(persona). </param>
        /// <param name="nacionalidad">Nacionalidad de la  Universitario(persona(Puede ser Argentino o Extranjero)). </param>
        /// </summary>
        public Universitario(int legajo, string nombre, string apellido,string dni, ENacionalidad nacionalidad) : base(nombre,apellido,dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        /// <summary>
        /// Metodo que podra ser sobreescrito y solo es accesible por la misma clase o sus hijas, el cual devuelve un string con todos los datos del Universitario.
        /// </summary>
        ///  <returns>String con los datos del universitario.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder mostrar = new StringBuilder();
            mostrar.AppendFormat("{0}\nLEGAJO NÚMERO: {1}", base.ToString(), legajo);

            return mostrar.ToString();
        }
        /// <summary>
        /// Metodo abstracto que podra ser sobreescrito por sus clases hijas.
        /// </summary>
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// Sobrecarga del operador == que compara si 2 univesitarios son iguales.
        /// <param name="pg1">Primer univesitario a comparar. </param>
        /// <param name="pg2">Segundo univesitario a comparar. </param>
        /// </summary>
        /// <returns>True si son iguales. False sino lo son.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (pg1.Equals(pg2) && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo))
            {
                retorno = true;
            }

            return retorno;
        }
        /// <summary>
        /// Sobrecarga del operador != que compara si 2 univesitarios son distintos.
        /// <param name="pg1">Primer univesitario a comparar. </param>
        /// <param name="pg2">Segundo univesitario a comparar. </param>
        /// </summary>
        /// /// <returns>True si son distintos. False sino lo son.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}

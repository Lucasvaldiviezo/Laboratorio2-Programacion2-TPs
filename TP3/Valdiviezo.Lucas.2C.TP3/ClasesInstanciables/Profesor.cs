using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> claseDelDia;
        private static Random random;
        /// <summary>
        /// Constructor de clase el cual inicializa el random.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Profesor()
        {
            
        }
        /// <summary>
        /// Constructor publico de instancia que inicializa la cola de clases del dia y llamada al metodo _randomClases.
        /// <param name="id">Legajo del profesor(persona). </param>
        /// <param name="nombre">Nombre del profesor(persona). </param>
        /// <param name="apellido">Apellido del profesor(persona). </param>
        /// <param name="dni">DNI del profesor(persona). </param>
        /// <param name="nacionalidad">Nacionalidad del profesor(persona(Puede ser Argentino o Extranjero)). </param>
        /// </summary>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id,nombre,apellido,dni,nacionalidad)
        {
            claseDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }
        /// <summary>
        /// Metodo el cual selecciona 2 clases random para el profesor.
        /// </summary>
        private void _randomClases()
        {
            int contador = 0;
            
            while(contador < 2)
            {
                int numero = random.Next(0,3);
                
                switch (numero)
                {
                    case 0:
                        claseDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 1:
                        claseDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 2:
                        claseDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 3:
                        claseDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                }
                System.Threading.Thread.Sleep(100);
                contador++;
            }

        }
        /// <summary>
        /// Sobrecarga del operador == que verifica si un profesor esta dando una clase.
        /// <param name="i">Profesor a comparar. </param>
        /// <param name="clase">Clase a comparar. </param>
        /// </summary>
        /// <returns>True si el profesor da la clase o false sino la da..</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach(Universidad.EClases c in i.claseDelDia)
            {
                if(c == clase)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        /// <summary>
        /// Sobrecarga del operador != que verifica si un profesor no esta dando una clase.
        /// <param name="i">Profesor a comparar. </param>
        /// <param name="clase">Clase a comparar. </param>
        /// </summary>
        /// <returns>True si el profesor no da la clase o false si la da..</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i==clase);
        }
        /// <summary>
        /// Sobrecarga del metodo ParticiparEnClase que solo puede ser usada por la clase o derivadas y devuelve las clases que da el profesor.
        /// </summary>
        /// <returns>String con las clases del profesor.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder mostrar = new StringBuilder();
            mostrar.AppendLine("||CLASES DEL DIA:||");
            foreach(Universidad.EClases clase in claseDelDia)
            {
                mostrar.AppendFormat("{0}\n", clase);
            }

            return mostrar.ToString();
        }
        /// <summary>
        /// Sobrecarga del metodo MostrarDatos que solo puede ser usada por la clase o derivadas y devuelve los datos del profesor.
        /// </summary>
        /// <returns>String con los datos del alumno.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder mostrar = new StringBuilder();
            mostrar.AppendLine(base.MostrarDatos());
            return mostrar.ToString();
        }
        /// <summary>
        /// Sobrecarga del metodo ToString la cual puede ser llamada fuera de la clase y devuelve los datos del profesor.
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

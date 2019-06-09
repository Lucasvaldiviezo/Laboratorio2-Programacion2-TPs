using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;


namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        /// <summary>
        /// Constructor por defecto el cual inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            Alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor publico de instancia.
        /// <param name="clase">Nombre de la clase que se dara en la Jornada. </param>
        /// <param name="instructor">Nombre del Instructor que dara esa clase. </param>
        /// </summary>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            Clase = clase;
            Instructor = instructor;
        }
        /// <summary>
        /// Inicializa o Devuelve la lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
            
        }
        /// <summary>
        /// Guarda o Devuelve la clase de esta jornada.
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return clase; }
            set { clase = value; }
        }
        /// <summary>
        /// Guarda o Devuelve el profesor de esta jornada.
        /// </summary>
        public Profesor Instructor
        {
            get { return instructor; }
            set { instructor = value; }
        }
        /// <summary>
        /// Sobrecarga del metodo ToString la cual puede ser llamada fuera de la clase y devuelve los datos de la Jornada.
        /// </summary>
        /// <returns>String con la clase que toma el alumno.</returns>
        public override string ToString()
        {
            StringBuilder mostrar = new StringBuilder();
            mostrar.AppendFormat("CLASE DE {0} \n POR NOMBRE COMPLETO:", Clase);
            mostrar.AppendFormat(Instructor.ToString());
            mostrar.AppendLine("ALUMNOS:\n");
            foreach(Alumno a in Alumnos)
            {
                mostrar.AppendFormat(a.ToString());
            }

            return mostrar.ToString();
        }
        /// <summary>
        /// Metodo Guardar de clase, el cual Guardar un archivo de texto con los datos de la jornada.
        /// <param name="jornada">Datos de la jornada a guardar. </param>
        /// </summary>
        /// <returns>True si se guardo el archivo con exito o false si ocurrio una excepcion y no se guardo.</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            Texto nuevoTexto = new Texto();
            try
            {
                nuevoTexto.Guardar("Jornada.txt", jornada.ToString());
                retorno = true;
            }
            catch(ArchivosException e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
        /// <summary>
        /// Metodo Guardar de clase, el cual Leer un archivo de texto con los datos de la jornada.
        /// </summary>
        /// <returns>Devuelve un cadena con los datos del archivo si este se pudo leer, devuelve el string vacio sino se logro leer.</returns>
        public static string Leer()
        {
            string retorno="";
            Texto nuevoTexto = new Texto();
            try
            {
                nuevoTexto.Leer("Jornada.txt", out retorno);
            }
            catch(ArchivosException e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
        /// <summary>
        /// Sobrecarga del operador == que verifica si un alumnmo se encuentra en la jornada.
        /// <param name="j">Jornada a comparar. </param>
        /// <param name="a">Alumno a comparar. </param>
        /// </summary>
        /// <returns>True si el alumno se encuentra en la jornada o false sino se encuentra.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach(Alumno alumno in j.Alumnos)
            {
                if(a == alumno)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        /// <summary>
        /// Sobrecarga del operador == que verifica si un alumnmo no se encuentra en la jornada.
        /// <param name="j">Jornada a comparar. </param>
        /// <param name="a">Alumno a comparar. </param>
        /// </summary>
        /// <returns>True si el alumno no se encuentra en la jornada o false si se encuentra.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j==a);
        }
        /// <summary>
        /// Sobrecarga del operador + que agrega un alumno a la Jornada si este no se encuentra ya dentro.
        /// <param name="j">Jornada donde se agregara. </param>
        /// <param name="a">Alumno a agregar. </param>
        /// </summary>
        /// <returns>Devuelve la Jornada con cambios o sin cambios dependiendo si se pudo agregar o no el alumno.</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j!=a)
            {
                j.Alumnos.Add(a);
            }

            return j;
        }
    }
}

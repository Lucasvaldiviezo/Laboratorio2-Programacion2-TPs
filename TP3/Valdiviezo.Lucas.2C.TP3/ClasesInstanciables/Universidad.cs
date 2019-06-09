using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        /// <summary>
        /// Constructor de clase el cual inicializa las listas de Alumno, Jornadas y Profesores.
        /// </summary>
        public Universidad()
        {
            Alumnos = new List<Alumno>();
            Jornadas = new List<Jornada>();
            Profesores = new List<Profesor>();
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
        /// Inicializa o Devuelve la lista de profesores.
        /// </summary>
        public List<Profesor> Profesores
        {
            get { return profesores; }
            set { profesores = value; }
        }
        /// <summary>
        /// Inicializa o Devuelve la lista de jornadas.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return jornada; }
            set { jornada = value; }
        }
        /// <summary>
        /// Guarda o Devuelve una jornada en una posicion especifica de la lista de jornadas.
        /// </summary>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < Jornadas.Count)
                {
                    return Jornadas[i];
                } else
                {
                    return null;
                }

            }
            set
            {
                if (i >= 0 && i < Jornadas.Count)
                {
                    Jornadas[i] = value;
                }
            }
        }
        /// <summary>
        /// Metodo privado y de clase el cual recibe una universidad y devuelve un string con sus datos.
        /// <param name="uni">Universidad de la cual se devolveran los datos. </param>
        /// </summary>
        /// <returns>String con los datos de la universidad.</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder mostrar = new StringBuilder();
            foreach (Jornada j in uni.Jornadas)
            {
                mostrar.AppendLine(j.ToString());
            }
            foreach (Profesor p in uni.Profesores)
            {
                mostrar.AppendLine(p.ToString());
            }
            foreach (Alumno a in uni.Alumnos)
            {
                mostrar.AppendLine(a.ToString());
            }

            return mostrar.ToString();
        }
        /// <summary>
        /// Sobrecarga del metodo ToString la cual puede ser llamada fuera de la clase y devuelve los datos de la universidad.
        /// </summary>
        /// <returns>String con los datos de la universidad.</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        /// <summary>
        /// Metodo Guardar de clase, el cual guarda un archivo serializado con los datos de la universidad.
        /// <param name="uni">Datos de la universidad a guardar. </param>
        /// </summary>
        /// <returns>True si se guardo el archivo con exito o false si ocurrio una excepcion y no se guardo.</returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            Xml<Universidad> nuevoSerializacion = new Xml<Universidad>();
            try
            {
                nuevoSerializacion.Guardar("Jornada.txt", uni);
                retorno = true;
            }
            catch(ArchivosException e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }
        /// <summary>
        /// Metodo Guardar de clase, el cual lee un archivo serializado con los datos de la universidad.
        /// </summary>
        /// <returns>Devuelve un objeto del tipo Universidad con su datos, devuelve el objeto Universidad vacio sino se logro leer.</returns>
        public static Universidad Leer()
        {

            Xml<Universidad> nuevoSerializacion = new Xml<Universidad>();
            Universidad retorno;
            try
            {
                
                nuevoSerializacion.Leer("Jornada.txt", out retorno);
                
            }
            catch (ArchivosException e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }
        /// <summary>
        /// Sobrecarga del operador == que verifica que profesor esta dando una clase en especifico.
        /// <param name="g">Universidad con el profesor a comparar. </param>
        /// <param name="clase">Clase a comparar. </param>
        /// </summary>
        /// <returns>El primer profesor que de la clase, lanza una excepcion si ningun profesor da esa clase.</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor p in g.Profesores)
            {
                if (p == clase)
                {
                    return p;
                }
            }

            throw new SinProfesorException();
        }
        /// <summary>
        /// Sobrecarga del operador != que verifica que profesor no esta dando una clase en especifico.
        /// <param name="g">Universidad con el profesor a comparar. </param>
        /// <param name="clase">Clase a comparar. </param>
        /// </summary>
        /// <returns>El primer profesor que no de la clase, lanza una excepcion si ningun profesor no da esa clase.</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor p in g.Profesores)
            {
                if (p != clase)
                {
                    return p;
                }
            }

            throw new SinProfesorException();
        }
        /// <summary>
        /// Sobrecarga del operador == que verifica que el profesor pertenezca a la universidad.
        /// <param name="g">Universidad a comparar. </param>
        /// <param name="i">Profesor a comparar. </param>
        /// </summary>
        /// <returns>True si el profesor pertenece a la universidad, false si no pertenece.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach (Profesor p in g.Profesores)
            {
                if (i == p)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        /// <summary>
        /// Sobrecarga del operador != que verifica que el profesor no pertenezca a la universidad.
        /// <param name="g">Universidad a comparar. </param>
        /// <param name="i">Profesor a comparar. </param>
        /// </summary>
        /// <returns>True si el profesor no pertenece a la universidad, false si pertenece.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g==i);
        }
        /// <summary>
        /// Sobrecarga del operador == que verifica que el alumno pertenezca a la universidad.
        /// <param name="g">Universidad a comparar. </param>
        /// <param name="a">Alumno a comparar. </param>
        /// </summary>
        /// <returns>True si el alumno pertenece a la universidad, false si no pertenece.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach(Alumno al in g.Alumnos)
            {
                if(a == al)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        /// <summary>
        /// Sobrecarga del operador != que verifica que el alumno no pertenezca a la universidad.
        /// <param name="g">Universidad a comparar. </param>
        /// <param name="a">Alumno a comparar. </param>
        /// </summary>
        /// <returns>True si el alumno no pertenece a la universidad, false si pertenece.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g==a);
        }
        /// <summary>
        /// Sobrecarga del operador + que agrega un alumno a la universidad si este no forma parte de ella.
        /// <param name="g">Universidad donde se agregara. </param>
        /// <param name="a">Alumno a agregar. </param>
        /// </summary>
        /// <returns>Retorna la universidad con o sin cambios si se agrego o no el alumno.</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
                
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }
        /// <summary>
        /// Sobrecarga del operador + que agrega un profesor a la universidad si este no forma parte de ella.
        /// <param name="g">Universidad donde se agregara. </param>
        /// <param name="a">Profesor a agregar. </param>
        /// </summary>
        /// <returns>Retorna la universidad con o sin cambios si se agrego o no el profesor.</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Profesores.Add(i);
            }
            return u;
        }
        /// <summary>
        /// Sobrecarga del operador + que agregara una jornada nueva agregandole un Profesor y alumnos que tengan la misma clase.
        /// <param name="g">Universidad donde se agregara. </param>
        /// <param name="clase">Clase de la Jornada a crear </param>
        /// </summary>
        /// <returns>Retorna la universidad con o sin cambios si se agrego o no la jornada.</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, g == clase);
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                {
                    jornada.Alumnos.Add(alumno);
                }
            }
            g.Jornadas.Add(jornada);

            return g;
        }
    }
}

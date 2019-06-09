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
        /// <returns>String con los datos del alumno.</returns>
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

        public override string ToString()
        {
            return MostrarDatos(this);
        }

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

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g==i);
        }

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

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g==a);
        }

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

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Profesores.Add(i);
            }
            return u;
        }

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

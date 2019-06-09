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

        public Universidad()
        {
            Alumnos = new List<Alumno>();
            Jornadas = new List<Jornada>();
            Profesores = new List<Profesor>();
        }
        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }

        public List<Profesor> Profesores
        {
            get { return profesores; }
            set { profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return jornada; }
            set { jornada = value; }
        }

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

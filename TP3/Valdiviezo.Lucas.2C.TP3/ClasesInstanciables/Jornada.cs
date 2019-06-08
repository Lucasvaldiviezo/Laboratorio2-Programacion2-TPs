using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        private Jornada()
        {
            Alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            Clase = clase;
            Instructor = instructor;
        }

        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
            
        }

        public Universidad.EClases Clase
        {
            get { return clase; }
            set { clase = value; }
        }

        public Profesor Instructor
        {
            get { return instructor; }
            set { instructor = value; }
        }

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

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j==a);
        }

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

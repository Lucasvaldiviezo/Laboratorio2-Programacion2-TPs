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

        static Profesor()
        {
            random = new Random();
        }

        public Profesor()
        {
            
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id,nombre,apellido,dni,nacionalidad)
        {
            claseDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

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

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i==clase);
        }
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

        protected override string MostrarDatos()
        {
            StringBuilder mostrar = new StringBuilder();
            mostrar.AppendLine(base.MostrarDatos());
            return mostrar.ToString();
        }

        public override string ToString()
        {
            StringBuilder mostrar = new StringBuilder();
            mostrar.AppendFormat(MostrarDatos(), ParticiparEnClase());
            return mostrar.ToString();
        }
    }
}

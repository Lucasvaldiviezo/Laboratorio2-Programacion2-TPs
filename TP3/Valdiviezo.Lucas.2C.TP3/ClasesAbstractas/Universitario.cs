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

        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }

        public Universitario() : this(0,"","","",ENacionalidad.Argentino)
        {
            
        }

        public Universitario(int legajo, string nombre, string apellido,string dni, ENacionalidad nacionalidad) : base(nombre,apellido,dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder mostrar = new StringBuilder();
            mostrar.AppendFormat("{0}\nN° Legajo: {1}\n", base.ToString(), legajo);

            return mostrar.ToString();
        }

        protected abstract string ParticiparEnClase();

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (pg1.Equals(pg2) && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo))
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}

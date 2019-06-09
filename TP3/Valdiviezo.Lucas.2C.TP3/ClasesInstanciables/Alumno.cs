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

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,Universidad.EClases claseQueToma) : base(id,nombre,apellido,dni,nacionalidad)
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta) : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if (a.claseQueToma != clase)
            {
                retorno = true;
            }

            return retorno;
        }



        protected override string MostrarDatos()
        {
            StringBuilder mostrar = new StringBuilder();
            mostrar.AppendFormat("{0} Estado de Cuenta: {1}\n", base.MostrarDatos(), estadoCuenta);
            return mostrar.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder mostrar = new StringBuilder();
            mostrar.AppendFormat("\nTOMA CLASE DE: {0}",claseQueToma);
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

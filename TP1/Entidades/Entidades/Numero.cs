using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Numero
    {
        private double numero;

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
          
        }

        private double ValidarNumero(string strNumero)
        {
            int i;
            double retorno=1;
            int flag = 1;

            for(i=0;i<strNumero.Length;i++)
            {
                if(strNumero[i] < '0' || strNumero[i] > '9')
                {
                    retorno = 0;
                    flag = 0;
                    break;
                }
            }
            if(flag == 1)
            {
                double.TryParse(strNumero,out retorno);
            }

            return retorno;
        }
    }
}

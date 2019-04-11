using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Numero
    {
        private double numero;

        private string SetNumero
        {
            set { numero = ValidarNumero(value); }
        }

        public Numero()
        {
            SetNumero = Convert.ToString(0);
        }

        public Numero(double numero)
        {
            SetNumero = Convert.ToString(numero);
        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
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

        public string DecimalBinario(double numero)
        {
            String cadena = "";
            if (numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        cadena = cadena + "0";
                    }
                    else
                    {
                        cadena = cadena + "1";
                    }
                    numero = (int)(numero / 2);
                }
            }else
            {
                cadena = "Valor invalido";
            }
            return cadena;   
        }

        public string DecimalBinario(string numero)
        {
            String cadena = "";
            
            return cadena;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double resultado;
            resultado = n1.numero + n2.numero;
            return resultado;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double resultado;
            resultado = n1.numero - n2.numero;
            return resultado;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double resultado;
            resultado = n1.numero * n2.numero;
            return resultado;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double resultado;
            resultado = n1.numero / n2.numero;
            return resultado;
        }
    }
}

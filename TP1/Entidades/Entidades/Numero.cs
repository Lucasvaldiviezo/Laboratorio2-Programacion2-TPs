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
            set
            {
               numero = ValidarNumero(value);
            }
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
            int contadorPuntos = 0;
            int contadorGuiones = 0;
            int flag = 1;

            for(i=0;i<strNumero.Length;i++)
            {
                if (strNumero[i] == '.' && contadorPuntos == 0)
                {
                    contadorPuntos=1;
                    i++;
                    continue;
                }
                if(strNumero[i] == '-' && contadorGuiones == 0)
                {
                    contadorGuiones = 1;
                    i++;
                    continue;
                }
                if (strNumero[i] < '0' || strNumero[i] > '9')
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
            int auxNumero = (int)numero;
            if (auxNumero > 0)
            {
                while (auxNumero > 0)
                {
                    if (auxNumero % 2 == 0)
                    {
                        cadena =  "0" + cadena ;
                    }
                    else
                    {
                        cadena = "1" + cadena;
                    }
                    auxNumero = auxNumero / 2;
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
            int auxNumero;
            if (int.TryParse(numero, out auxNumero)  && auxNumero > 0)
            {
                while (auxNumero > 0)
                {
                    if (auxNumero % 2 == 0)
                    {
                        cadena = "0" + cadena;
                    }
                    else
                    {
                        cadena = "1" + cadena;
                    }
                    auxNumero = auxNumero / 2;
                }
            }
            else
            {
                cadena = "Valor invalido";
            }
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

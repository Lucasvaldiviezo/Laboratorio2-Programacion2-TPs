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
            double retorno=0;
            int contadorComas = 0;
            int contadorGuiones = 0;
            int flag = 1;

            for(i=0;i<strNumero.Length;i++)
            {
                if (strNumero[i] == ',' || strNumero[i] == '.' && contadorComas == 0)
                {
                    if(strNumero[i] == '.')
                    {
                        strNumero = strNumero.Replace('.', ',');
                    }
                    contadorComas =1;
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
                    double.TryParse(strNumero, out retorno);   
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
            double convert;
            int auxNumero;
            double.TryParse(numero, out convert);
            auxNumero = (int)convert;
            cadena = DecimalBinario(auxNumero);
            return cadena;
        }

        public string BinarioDecimal(string binario)
        {
            int i;
            double total = 0;
            double potencia = 0;
            int flag = 0;
            string cadena="";


            for(i=binario.Length-1;i>=0;i--)
            {
              if(binario[i] == '1')
              {
                    total = total + (Math.Pow(2,potencia)*1);
                    potencia++;
              }else if (binario[i] == '0')
              {
                    potencia++;
              }else
              {
                    cadena = "Valor invalido";
                    flag = 1;
                    break;
              }
            }
            if(flag==0)
            {
                cadena = Convert.ToString(total);
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

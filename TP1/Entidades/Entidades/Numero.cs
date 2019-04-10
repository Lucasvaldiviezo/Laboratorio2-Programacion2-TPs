﻿using System;
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
            }
            else
            {
                cadena = "Valor invalido";
            }
            return cadena;
        }
    }
}

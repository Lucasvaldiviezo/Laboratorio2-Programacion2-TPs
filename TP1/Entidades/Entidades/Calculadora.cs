﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Entidades
{
    public class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            string retorno;

            if(operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                retorno = operador;
            }else
            {
                retorno = "+";
            }

            return retorno;
        }

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado=0;
            string auxOperador;
            auxOperador = Calculadora.ValidarOperador(operador);

            if(auxOperador == "+")
            {
                resultado = num1 + num2;  
            }else if(auxOperador == "-")
            {
                resultado = num1 - num2;
            }
            else if(auxOperador == "*")
            {
                resultado = num1 * num2;

            }
            else if(auxOperador == "/")
            {
                resultado = num1 / num2;
                if(Double.IsInfinity(resultado))
                {
                    resultado = double.MinValue;
                }
            }

            return resultado;
        }
    }
}

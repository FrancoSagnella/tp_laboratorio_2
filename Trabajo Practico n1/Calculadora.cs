using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Practico_n1
{
    public static class Calculadora
    {
        private static string Validar(char operador)
        {
            string retorno;
            switch(operador)
            {
                case '+':
                    retorno = "+";
                    break;

                case '-':
                    retorno = "-";
                    break;

                case '*':
                    retorno = "*";
                    break;

                case '/':
                    retorno = "/";
                    break;

                default:
                    retorno = "+";
                    break;
            }
            return retorno;
        }
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;
            
            operador = Calculadora.Validar(Convert.ToChar(operador));

            switch (operador)
            {
                case "+":
                    retorno = num1 + num2;
                    break;

                case "-":
                    retorno = num1 - num2;
                    break;

                case "*":
                    retorno = num1 * num2;
                    break;

                case "/":
                    retorno = num1 / num2;
                    break;
            }
            return retorno;
        }
    }
}

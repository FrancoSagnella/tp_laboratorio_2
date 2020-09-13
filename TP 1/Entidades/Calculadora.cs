using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Recibe el operador y verifica que sea +, - ,* o /
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>
        /// Devuelve uns tring on el operador, en caso de que sea invalido
        /// devuelve +
        /// </returns>
        private static string Validar(string operador)
        {
            string retorno;
            switch (operador)
            {
                case "-":
                    retorno = "-";
                    break;

                case "*":
                    retorno = "*";
                    break;

                case "/":
                    retorno = "/";
                    break;

                case "+":
                default:
                    retorno = "+";
                    break;
            }
            return retorno;
        }
        /// <summary>
        /// Realiza las operaciones correspondientes entre las instancias de Numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>
        /// Un double con el resultado
        /// </returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;

            operador = Calculadora.Validar(operador);

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

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

        /// <summary>
        /// Constructor por defecto, inicializa en 0 el atributo numero
        /// </summary>
        public Numero():this(0)
        {
        }
        /// <summary>
        /// Inicializa en el atributo el parametro recibido
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Inicializa en el atributo el parametro recibido como string
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Valida que la cadena recibida sea un valor numerico
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>
        /// Devuelve el numero validado, o 0 en caso de que sea invalido
        /// </returns>
        private static double ValidarNumero(string strNumero)
        {
            double retorno;

            //Si TryParse lo puede transformar, quiere decir que la cadena era numerica y valida
            if (double.TryParse(strNumero, out retorno) == false)
            {
                retorno = 0;
            }
            return retorno;
        }

        /// <summary>
        /// Setea en el atributo numero el valor recibido como string
        /// (ValidarNumero lo devuelve como double)
        /// </summary>
        public string SetNumero//Es de instancia, accedo por el objeto
        {
            set
            {
                this.numero = Numero.ValidarNumero(value);
            }
        }


        /// <summary>
        /// Valida que la cadena este compuesta por 0 y 1
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>
        /// Devuelve true si es valida, false si es invalida
        /// </returns>
        private static bool EsBinario(string binario)
        {
            int largo = binario.Length;
            bool retorno = true;

            if(binario != null && binario != "")
            {
                for (int i = 0; i < largo; i++)
                {
                    if (binario[i] != '1' && binario[i] != '0')
                    {
                        retorno = false;
                        break;
                    }
                }
            }
            else
            {
                retorno = false;
            }
            
            return retorno;
        }


        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>
        /// Devuelve el numero decimal en formato string
        /// En caso de que la cadena no sea un binario valdo, devuelve el mensaje valor invalido
        /// </returns>
        public static string BinarioDecimal(string binario)
        {
            string retorno;
            int largo = binario.Length;
            int numAux;
            double numResult = 0;

            if (Numero.EsBinario(binario))
            {
                for (int i = 1; i <= largo; i++)
                {
                    numAux = binario[i - 1] - '0';//'0' es 48, al restarlo con cualquier numero, por ejemplo '9' es 57, entonces 57 - 48 = 9
                                                  //i-1 porque quiero el indice 0
                    numResult += (numAux * Math.Pow(2, largo - i));//Elevo el caracter 0 o 1 por la posicion en la que esta, 
                                                                   //pongo - i porque quiero que sea 4, despues 3, 2, 1, 0
                }
                retorno = numResult.ToString();
            }
            else
            {
                retorno = "Valor invalido";
            }
            return retorno;
        }


        /// <summary>
        /// Convierte un numero recibido como double a binario
        /// El double se casstea a int para trabajar solo con la parte entera
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>
        /// Devuelve una cadena con el numero binario
        /// En caso de que el double no sea positivo, por ende invalido,
        /// Devuelve valor invalido
        /// </returns>
        public static string DecimalBinario(double numero)
        {
            int resultado = (int)numero;
            string binario = "";

            if (resultado > 0)
            {
                while (resultado > 0)
                {
                    if (resultado % 2 == 0)
                    {
                        binario = "0" + binario;//no puedo hacer +=, tiene que ser asi, para que el 0 o el 1 se pongan a la izquierda
                    }
                    else
                    {
                        binario = "1" + binario;
                    }
                    resultado = (int)(resultado / 2);
                }
            }
            else if (resultado == 0)
            {
                binario = "0";
            }
            else
            {
                binario = "Valor invalido";
            }

            return binario;
        }

        /// <summary>
        /// Recibe un numero en formato de cadena, lo transforma a double 
        /// y lo transforma en binario llamando a la otra sobrecarga
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>
        /// Devuelve la cadena con el binario
        /// En caso de que el string recibido con el double sea invalida, 
        /// devuelve Valor invalido
        /// </returns>
        public static string DecimalBinario(string numero)
        {
            string retorno;
            double valor;
            if (double.TryParse(numero, out valor) && numero != null)//Para validar si la string que me viene es un numero
            {
                retorno = Numero.DecimalBinario(valor);
            }
            else
            {
                retorno = "Valor invalido";
            }
            return retorno;
        }

        /// <summary>
        /// Operador -, permite restar dos instancias de tipo Numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>
        /// Devuelve el resultado de la resta de los atributos numero de dos instancias
        /// </returns>
        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }
        /// <summary>
        /// Operador +,permite sumar dos instanciasde tipo Numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>
        /// El resultado de la suma de los atributos numero de dos instancias
        /// </returns>
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }
        /// <summary>
        /// Operador *, permite multiplicar dos instancias de tipo Numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>
        /// El resultado del producto de los atributos numero de las dos instancias
        /// </returns>
        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }
        /// <summary>
        /// Operador /, permite dividir dos instancias de tipo numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>
        /// Devuelve el resultado de dividir los atributos de las instancias
        /// En caso de que sea division por 0 devuelve MinValue
        /// </returns>
        public static double operator /(Numero num1, Numero num2)
        {
            double retorno;
            if (num2.numero == 0)
            {
                retorno = double.MinValue;
            }
            else
            {
                retorno = num1.numero / num2.numero;
            }
            return retorno;
        }
    }
}

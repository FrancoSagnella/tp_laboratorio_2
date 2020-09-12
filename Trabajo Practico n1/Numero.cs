using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Practico_n1
{
    public class Numero
    {
        private double numero;

        
        public Numero()
        {
            numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            this.numero = double.Parse(strNumero);
        }

        private static double ValidarNumero(string strNumero)
        {
            double retorno;

            //Si TryParse lo puede transformar, quiere decir que la cadena era numerica y valida
            if(double.TryParse(strNumero, out retorno) == false)
            {
                retorno = 0;
            }
            return retorno;
        }
        public string SetNumero//Es de instancia, accedo por el objeto
        {
            set
            {
                this.numero = Numero.ValidarNumero(value);
            }
        }

        private static bool EsBinario(string binario)
        {
            int largo = binario.Length;
            bool retorno = true;

            for(int i = 0; i < largo; i++)
            {
                if(binario[i] != '1' && binario[i] != '0')
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }

        public static string BinarioDecimal(string binario)
        {
            string retorno;
            int largo = binario.Length;
            int numAux;
            double numResult = 0;

            if(Numero.EsBinario(binario))
            {
                for (int i = 1; i <= largo; i++)
                {
                    numAux = binario[i - 1] - '0';//'0' es 48, al restarlo con cualquie numero, por ejemplo '9' es 57, entonces 57 - 48 = 9
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
            else if(resultado == 0)
            {
                binario = "0";
            }
            else
            {
                binario = "Valor invalido";
            }

            return binario;
        }
        public static string DecimalBinario(string numero)
        {
            string retorno;
            double valor;
            if (double.TryParse(numero, out valor))//Para validar si la string que me viene es un numero
            { 
                retorno = Numero.DecimalBinario(valor);
            }
            else
            {
                retorno = "Valor invalido";
            }
            return retorno;
        }

        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }
        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }
        public static double operator /(Numero num1, Numero num2)
        {
            double retorno;
            if(num2.numero == 0)
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

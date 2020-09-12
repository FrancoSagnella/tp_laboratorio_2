using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Practico_n1
{
    class Program
    {
        static void Main(string[] args)
        {
            Numero num1 = new Numero(3);
            Numero num2 = new Numero(5);

            num1.SetNumero = "13,4";
            num2.SetNumero = "10";
            double numero = Calculadora.Operar(num1, num2, "/");
            Console.WriteLine(numero);

            string binario = Numero.DecimalBinario(numero);
            Console.WriteLine(binario);

            binario = Numero.BinarioDecimal(binario);
            Console.WriteLine(binario);

            binario = Numero.DecimalBinario(binario);
            Console.WriteLine(binario);

            binario = Numero.BinarioDecimal(binario);
            Console.WriteLine(binario);

            num1.SetNumero = binario;
            Console.WriteLine(binario);

            Console.ReadKey();
        }
    }
}

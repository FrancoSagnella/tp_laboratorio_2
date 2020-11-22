using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using EntidadesInstanciables;

namespace Archivos
{
    public class Ticketeadora<T> where T : Electrodomestico
    {
        /// <summary>
        /// Permite imprimir los datos de una venta en un archivo de texto
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool imprimirHistorialVentas(T obj, string path)
        {
            IArchivos<string> archivoAux = new ArchivoTexto();
            return archivoAux.Guardar(path, obj.ToString(), true);
        }
        /// <summary>
        /// Permite leer de un archivo de texto los datos de las ventas
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string Leer(string path)
        {
            string aux;
            IArchivos<string> archivoAux = new ArchivoTexto();
            archivoAux.Leer(path, out aux);
            return aux;
        }
    }
}

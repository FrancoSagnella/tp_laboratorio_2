using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivos<T>
    {
        /// <summary>
        /// Firma para metodo guardar, permitira escribir en un archivo de texto
        /// </summary>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        /// <param name="append"></param>
        /// <returns></returns>
        bool Guardar(string path, T obj, bool append);
        /// <summary>
        /// Firma para metodo Leer, permitira leer un archivo de texto
        /// </summary>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Leer(string path, out T obj);
    }
}

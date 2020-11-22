using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion que se lanza en caso de que se intente asignar un modelo
    /// erroneo a un objeto Electrodomestico
    /// (por ejemplo, si se crea una cafetera y se le asigna un modelo propio de televisores)
    /// </summary>
    public class ModeloException : Exception
    {
        public ModeloException()
            :base("El modelo que se intento asignar no coindice con el tipo de electrodomestico, " +
                 "Los productos de tipo TV solo pueden tener modelos de TVs, y los productos de tipo cafetera " +
                 "solo pueden ser modelos de cafetera")
        {
        }
    }
}

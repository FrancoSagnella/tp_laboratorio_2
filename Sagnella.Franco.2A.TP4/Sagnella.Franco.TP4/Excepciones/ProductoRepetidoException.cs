using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion que se lanza si se intenta agregar al carrito un elemento que ya fue
    /// agregado anteriormente
    /// </summary>
    public class ProductoRepetidoException : Exception
    {
        public ProductoRepetidoException()
            :base("Se intento agregar al carrito un producto que ya habia sido agregado anteriormente")
        {

        }
    }
}

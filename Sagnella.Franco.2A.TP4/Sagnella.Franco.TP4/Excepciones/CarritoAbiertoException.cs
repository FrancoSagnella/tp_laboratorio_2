using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion que se lanzara en caso de que se intente hacer alguna accion sobre
    /// el carrito mientras este no este abierto, o si intenten abrir dos al mismo tiempo
    /// </summary>
    public class CarritoAbiertoException : Exception
    {
        public CarritoAbiertoException()
            :base("Ya hay un carrito abierto")
        {

        }
        public CarritoAbiertoException(string mensaje)
            :base(mensaje)
        {
            
        }
    }
}

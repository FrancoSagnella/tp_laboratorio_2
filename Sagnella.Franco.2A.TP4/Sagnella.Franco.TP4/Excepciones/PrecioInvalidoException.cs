using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion para cuando se ingrese un precio con un formato invalido
    /// a un producto
    /// </summary>
    public class PrecioInvalidoException : Exception
    {
        public PrecioInvalidoException()
            :base("Se intento instanciar un objeto con un precio invalido ")
        {

        }
    }
}

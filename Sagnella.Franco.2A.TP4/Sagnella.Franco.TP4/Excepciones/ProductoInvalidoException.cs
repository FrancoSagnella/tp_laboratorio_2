using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion que se lanza cuando no se especifica el tipo
    /// de producto al crearlo
    /// </summary>
    public class ProductoInvalidoException : Exception
    {
        public ProductoInvalidoException()
            :base("El objeto no fue instanciado porque alguno de" +
                            "los campos no fue llenado")
        {

        }
    }
}

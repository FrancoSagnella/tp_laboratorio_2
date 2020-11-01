using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException()
            :this("El DNI teiene un formato invalido")
        {
        }
        public DniInvalidoException(Exception e)
            :this("El DNI teiene un formato invalido", e)
        {
        }
        public DniInvalidoException(string message)
            :this(message, null)
        {
        }
        public DniInvalidoException(string message, Exception e)
            :base(message, e)
        {
        }
    }
}

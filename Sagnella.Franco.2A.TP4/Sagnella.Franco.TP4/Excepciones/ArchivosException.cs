using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Clase archivos exception, se lanzaria en caso de que se genere algun 
    /// error leyendo o escribiendo en archivos
    /// </summary>
    public class ArchivosException : Exception
    {
        public ArchivosException()
            :base("Se produjo un error al intentar leer o escribir en un archivo")
        {

        }
    }
}

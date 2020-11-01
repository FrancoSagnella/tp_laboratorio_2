using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda en el Path recibido como parametro un archivo que contiene el
        /// string recibido en el parametro datos, en el caso de una excepcion,
        /// lanza la excepcion ArchivosException
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool IArchivo<string>.Guardar(string archivo, string datos)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(archivo, false, Encoding.UTF8))
                {
                    sw.Write(datos);
                }
                return true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            
        }
        /// <summary>
        /// Lee del path recibido en el parametro archivo los contenidos (en forma de texto)
        /// y los guarda en el parametro datos para retornarlos
        /// en caso de error, lanza ArchivosException
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool IArchivo<string>.Leer(string archivo, out string datos)
        {
            try
            {
                datos = "";
                using(StreamReader sr = new StreamReader(archivo, Encoding.UTF8))
                {
                    string linea;
                    while((linea = sr.ReadLine()) != null)
                    {
                        datos += ("\n"+linea);
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            
        }
    }
}

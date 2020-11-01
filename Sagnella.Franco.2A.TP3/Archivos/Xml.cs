using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Permite serializar los datos del objeto recibido como parametro (datos)
        /// en un archivo XML, en el path recibido tambien como parametro
        /// en caso de error, lanza AerchivosException
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool IArchivo<T>.Guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer, datos);
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }
        /// <summary>
        /// Permite deserializar los datos en el archivo xml del path recibido como parametro (archivo)
        /// y cargarlos en un objeto del mismo tipo, el cual se retorna (out T datos)
        /// en caso de error lanza ArchivosException
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool IArchivo<T>.Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }
    }
}

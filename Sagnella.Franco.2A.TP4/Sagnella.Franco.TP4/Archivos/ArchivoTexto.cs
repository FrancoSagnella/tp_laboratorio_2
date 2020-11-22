using Excepciones;
using System;
using System.IO;
using System.Text;

namespace Archivos
{
    public class ArchivoTexto : IArchivos<string>
    {
        /// <summary>
        /// Implementacion del metodo de la interfaz, escribe en un aarchivo de 
        /// texto 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        /// <param name="append"></param>
        /// <returns></returns>
        public bool Guardar(string path, string obj, bool append)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, append, Encoding.UTF8))
                {
                    sw.WriteLine("Compra realizada el dia: {0}", DateTime.Now);
                    sw.WriteLine("Detalles de la compra:");
                    sw.Write(obj);
                    sw.WriteLine("----------------------------------");
                }
                return true;
            }
            catch(Exception e)
            {
                throw new ArchivosException();
            }
        }
        /// <summary>
        /// Implementacion del metodo de la interfaz, lee un aarchivo de 
        /// texto 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        /// <param name="append"></param>
        /// <returns></returns>
        public bool Leer(string path, out string obj)
        {
            try
            {
                obj = "";
                using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
                {
                    string linea;
                    StringBuilder sb = new StringBuilder();

                    while ((linea = sr.ReadLine()) != null)
                    {
                        sb.AppendLine(linea);
                    }
                    obj = sb.ToString();
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException();
            }
        }
    }
}


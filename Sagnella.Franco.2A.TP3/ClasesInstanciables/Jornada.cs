using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private Universidad.EClases clase;
        private List<Alumno> alumnos;
        private Profesor instructor;
        
        /// <summary>
        /// Propiedad de lectura y escritura del atributo clase
        /// GET: devuelve la clase que tiene la jornada
        /// SET: agrega a la jornada la clase recibido como value
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo alumnos
        /// GET: devuelve la lista de alumnos que tiene la jornada
        /// SET: agrega a la jornada la lista de alumnos recibido como value
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo instructor
        /// GET: devuelve el instructor que tiene la jornada
        /// SET: agrega a la jornada el instructor recibido como value
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        /// <summary>
        /// Constructor privado, instancia la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor con parametros, reutiliza al constructor privado
        /// para instanciar la lista
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        /// <summary>
        /// Agrega un alumno a la jornada, solo se agrega si: si el alumno no esta ya dentro de la lista,
        /// si la clase en la que participa el alumno es igual a la clase de la jornada y 
        /// si el alumno no es deudor
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                if (a == j.clase)
                {
                    j.alumnos.Add(a);
                }
            }
            return j;
        }
        /// <summary>
        /// Compara una jornada con un alumno, son iguales si el alumno forma parte de
        /// la lista de alumnos de la jornada, caso contrario devuelve false
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool ret = false;
            foreach(Alumno item in j.alumnos)
            {
                if (a.Equals(item))
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
        /// <summary>
        /// Compara una jornada con un alumno, son distintos si el alumno forma no parte de
        /// la lista de alumnos de la jornada, caso contrario devuelve false
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Retorna una cadena con todos los datos de la jornada, reutiliza 
        /// todos los ToString sobreescritos en las demas clases
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Clases de {0} dictadas por:\n", (this.clase.ToString()).ToUpper());
            sb.AppendLine(this.instructor.ToString());
            sb.AppendLine("ALUMNOS:\n");

            if(this.alumnos.Count != 0)
            {
                foreach(Alumno item in this.alumnos)
                {
                   sb.AppendLine(item.ToString());
                }
            }
            else
            {
                sb.AppendLine("Ningun alumno cursa esta jornada");
            }
            
            return sb.ToString();
        }
        /// <summary>
        /// Permite guardar los datos del objeto recibido como parametro
        /// en un archivo de texto
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada j)
        {
            IArchivo<string> archivoAux = new Texto();
            return archivoAux.Guardar("Datos_Jornada.txt", j.ToString());
        }
        /// <summary>
        /// Lee un archivo de texto y retorna una cadena con su contenido
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string aux;
            IArchivo<string> archivoAux = new Texto();
            archivoAux.Leer("Datos_Jornada.txt", out aux);
            return aux;
        }
    }
}

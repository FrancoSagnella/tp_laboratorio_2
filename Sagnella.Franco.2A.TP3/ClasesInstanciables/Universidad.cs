using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;
        /// <summary>
        /// Propiedad de lectura y escritura para el atributo alunos
        /// GET: devuelve la lista de alumnos
        /// SET: agrega al objeto la lista recibida como parametro
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
        /// Propiedad de lectura y escritura para el atributo profesores
        /// GET: devuelve la lista de profesores
        /// SET: agrega al objeto la lista recibida como parametro
        /// </summary>
        public List<Profesor> Profesores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura para el atributo jornadas
        /// GET: devuelve la lista de jornadas
        /// SET: agrega al objeto la lista recibida como parametro
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }
        /// <summary>
        /// Indexador de jornadas, me permite acceder a una jornada especifica dentro de la lista
        /// GET: devuelve la jornada que se encuentra en el inidce especificado, siempre y cuando
        /// el indice sea valido
        /// SET: Si el indice es igual al Count de la lista de jornadas, agrega a la misma 
        /// la jornada recibida como value, si llegase a ser un indice intermedio lo sobreescribe
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                try
                {
                    return this.jornadas[i];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
            set
            {
                try
                {
                    if(i >= 0 && i < this.jornadas.Count)
                    {
                        this.jornadas[i] = value;
                    }
                    else if(i == this.jornadas.Count)
                    {
                        this.jornadas.Add(value);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }  
            }
        }
        /// <summary>
        /// Constructor por defecto de universidad, instancia las listas
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        /// <summary>
        /// Compara una universidad con un alumno, son iguales si el alumno 
        /// ya esta el la lista de alumnos
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>
        /// Bool que indica si se cumple o no la igualdad
        /// </returns>
        public static bool operator ==(Universidad u, Alumno a)
        {
            bool ret = false;
            foreach(Alumno item in u.alumnos)
            {
                if(a.Equals(item))
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
        /// <summary>
        /// Compara universidad con un alumno, son distintos si el alumno no
        /// esta en la lista, devuelve true en ese caso
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>
        /// Bool que indica si se cumple o no la igualdad
        /// </returns>
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }
        /// <summary>
        /// Cpmpara una universidad con un profesor, son iguales si el profesor
        /// ya esta en la lista de la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns>
        /// Bool que indica si se cumple o no la igualdad
        /// </returns>
        public static bool operator ==(Universidad u, Profesor p)
        {
            bool ret = false;
            foreach (Profesor item in u.profesores)
            {
                if (p.Equals(item))
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
        /// <summary>
        ///Compara universidad con un profesor, son distintos si el profesro no
        /// esta en la lista, devuelve true en ese caso
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns>
        /// Bool que indica si se cumple o no la igualdad
        /// </returns>
        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }
        /// <summary>
        /// Compara una universidad con una clase, busca dentro de la 
        /// universidad al primer profesor que de la clase recibida como parametro y lo devuelve,
        /// si no llegase a tener ninguno que coincida lanza la excepcion sin profesor
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>
        /// Devuelve el primer profesor que se encuentre que da la clase, si no 
        /// hay ninguno, lanza excepcion
        /// </returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor ret = null;
            bool aux = false;
            foreach(Profesor item in u.profesores)
            {
                if(item == clase)
                {
                    aux = true;
                    ret = item;
                    break;
                }
            }

            if (aux)
                return ret;
            else
                throw new SinProfesorException();
        }
        /// <summary>
        /// Al contrario del ==, este operador busca al primer profesor que NO pueda dar 
        /// la clase recibida como parametro y lo retorna
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>
        /// Devuelve el primer profesor que NO de la clase, caso contrario lanza excepcion
        /// </returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor ret = null;
            bool aux = false;
            foreach (Profesor item in u.profesores)
            {
                if (item != clase)
                {
                    aux = true;
                    ret = item;
                    break;
                }
            }

            if (aux)
                return ret;
            else
                throw new SinProfesorException();
        }
        /// <summary>
        /// Agrega un alumno a la universidad, siempre y cuando este ya no este dentro de la lista,
        /// (reutulizando al != entre universidad y alumno) caso contrario lanza la excepcion
        /// de alumno repetido
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>
        /// Devuelve la universidad con los cambios aplicados
        /// </returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }
        /// <summary>
        /// Agrega un profesor a la universidad siempre y cuando este no ester ya dentro 
        /// de la lista
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns>
        /// Devuelve la universidad con los cambios aplicados
        /// </returns>
        public static Universidad operator +(Universidad u, Profesor p)
        {
            if(u != p)
            {
                u.profesores.Add(p);
            }
            return u;
        }
        /// <summary>
        /// Crea una jornada, dentro de la lista de jornadas de la universidad, 
        /// de la clase recibida como parametro, dentro de esta jornada se asigna
        /// un profesor que la pueda dar (reutilizando el == entre universidad y clase)
        /// y todos los alumnos que participen en esa clase y no sean deudores
        /// (reutilizando el operador + entre jornada y alumno)
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>
        /// Devuelve la universidad con los cambios aplicados
        /// </returns>
        public static Universidad operator +(Universidad u, EClases clase)
        {
            Jornada aux = u[u.jornadas.Count] = new Jornada(clase, u == clase);
            foreach(Alumno item in u.alumnos)
            {
                aux += item;
            }
            return u;
        }
        /// <summary>
        /// Crea una cadena con una lista de jornadas de la universidad, cada una
        /// con los datos del profesor que la da y los alumnos que asisten
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\nJORNADAS:");
            for(int i = 0; i < uni.jornadas.Count; i++)
            {
                sb.AppendLine("<----------------------------------->\n");
                sb.Append(uni[i].ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Retorna la cadena creada por el metodo MostrarDatos,
        /// vuelve publicos sus datos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// Permite guardar los datos de la universidad recibida como parametro
        /// en Xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            IArchivo<Universidad> u = new Xml<Universidad>();
            return u.Guardar("Universidad.xml", uni);
        }
        /// <summary>
        /// Permite leer de un XML los datos de una universidad, crea un objeto 
        /// con esos datos y los retorna
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Universidad aux;
            IArchivo<Universidad> u = new Xml<Universidad>();
            u.Leer("Universidad.xml", out aux);
            return aux;
        }
    }
}

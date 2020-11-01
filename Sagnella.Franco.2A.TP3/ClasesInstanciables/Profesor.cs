using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// Constructor por estatico de profesor, instancia
        /// el objeto Random para el atributo random
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }
        /// <summary>
        /// Constructor por defecto de Profesor
        /// </summary>
        public Profesor()
        {
        }
        /// <summary>
        /// Constructor con parametros, realiza la llamada al constructor base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }
        /// <summary>
        /// Genera una clase random para el profesor,
        /// utiliza los valores numericos del enumerado, generando un numero
        /// random mayor o igual a 0 y menor o igual a 3
        /// </summary>
        private void _randomClases()
        {
            switch(Profesor.random.Next(0, 4))
            {
                case 0:
                    this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                    break;

                case 1:
                    this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                    break;

                case 2:
                    this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                    break;

                case 3:
                    this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                    break;
            }
        }
        /// <summary>
        /// Retorna una cadena que expone las clases que da el profesor
        /// (atributo clasesDelDia)
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Clases del dia: ");
            foreach(Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        /// <summary>
        /// Genera una cadena con todos los datos del profesor, incluidas las clases 
        /// que da (reutiliza al metodo participarEnClase)
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }
        /// <summary>
        /// Retorna todos los datos del profesor generados por el metodo
        /// MostrarDatos, los vuelve publicos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Compara un profesor con una clase, son iguales
        /// si alguna de las clases que da el profesor coincide con la clase 
        /// recibida como parametro (devuelve true) caso contrario devuelve false
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool ret = false;
            foreach(Universidad.EClases item in i.clasesDelDia)
            {
                if(item == clase)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
        /// <summary>
        /// Compara un profesor con una clase, niega al operador ==,
        /// si el profesor da la clase recibida como parametro devuelve false
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}

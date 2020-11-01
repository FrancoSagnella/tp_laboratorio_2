using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// Constructor por defecto, inicializa los atributos con valores default
        /// </summary>
        public Universitario()
            : base()
        {
        }
        /// <summary>
        /// Constructor con parametros, inicializa todos los atributos recibidos,
        /// reutiliza al constructor de la clase base
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        /// <summary>
        /// Compara dos Universitarios, son iguales si si legajo o 
        /// su dni son iguales
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns>
        /// Bool que indica si se cumple o no la igualdad
        /// </returns>
        public static bool operator ==(Universitario u1, Universitario u2)
        {
            bool ret = false;
            if(u1.legajo == u2.legajo || u1.DNI == u2.DNI)
            {
                ret = true;
            }
            return ret;
        }
        /// <summary>
        /// Compara dos Universitarios, son distintos si legajo o 
        /// su dni son distintos 
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns>
        /// Bool que indica si se cumple o no la igualdad
        /// </returns>
        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return !(u1 == u2);
        }
        /// <summary>
        /// Sobrecarga de Equals, Compara que los universitarios sean 
        /// iguales despues de verificar que el objeto sea en efecto de tipo
        /// universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// Bool que indica si se cumple o no la igualdad
        /// </returns>
        public override bool Equals(object obj)
        {
            bool ret = false;
            if(obj is Universitario)
            {
                ret = this == (Universitario)obj;
            }
            return ret;
        }
        /// <summary>
        /// Metodo abstracto y protegido
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// Retorna una cadena con todos los datos del universitario,
        /// reutiliza ToString de persona
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            return String.Format("{0}\nLegajo: {1}", base.ToString(), this.legajo);
        }
    }
}

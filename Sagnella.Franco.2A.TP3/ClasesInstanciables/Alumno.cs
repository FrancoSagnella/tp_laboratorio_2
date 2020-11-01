using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Constructor por defecto de alumno
        /// </summary>
        public Alumno()
            :base()
        {
        }
        /// <summary>
        /// Constructor con parametros, reutiliza al constructor de la clase base,
        /// inicializa la clase que toma
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="clase"></param>
        public Alumno(int id, string nombre, string apellido, string dni,
            ENacionalidad nacionalidad, Universidad.EClases clase)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = clase;
        }
        /// <summary>
        /// Constructor con parametros, reutiliza al otro constructor con arametros,
        /// inicializa estado de cuenta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="clase"></param>
        /// <param name="estado"></param>
        public Alumno(int id, string nombre, string apellido, string dni,
            ENacionalidad nacionalidad, Universidad.EClases clase, EEstadoCuenta estado)
            : this(id, nombre, apellido, dni, nacionalidad, clase)
        {
            this.estadoCuenta = estado;
        }
        /// <summary>
        /// Retorna la clase a la que asiste el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return String.Format("Toma clases de: {0}", this.claseQueToma.ToString());
        }
        /// <summary>
        /// retorna una cadena con todos los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendFormat("Estado de la cuenta: {0}\n", this.estadoCuenta.ToString());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }
        /// <summary>
        /// retorna una cadena con todos los datos del alumno, permite hacerlos publicos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Compara un alumno con una clase, son iguales si esta en esa clase y si no es deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (!(a != clase) && a.estadoCuenta != EEstadoCuenta.Deudor);
        }
        /// <summary>
        /// Compara un alumno con una clase, son diferentes si el amlumno no esta en la clase 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma != clase);
        }
    }
}

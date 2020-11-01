using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad 
        { 
            Argentino,
            Extranjero
        }


        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;

        /// <summary>
        /// Propiedad de lectura y escritura, devuelve el atributo nombre del objeto,
        /// agrega la cadena recibida luego de validarla
        /// </summary>
        public string Nombre 
        { 
            get
            {
                return this.nombre;
            }
            set 
            {
                this.nombre = Persona.ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura, devuelve el atributo nombre del objeto,
        /// agrega la cadena recibida luego de validarla
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = Persona.ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiadad de lectura y escritura, devuelve la nacionalidad del objeto,
        /// agrega la nacionalidad recibida
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura, devuelve el dni del objeto,
        /// agrega el DNI recibido como entero despues de validar que corresponda con la nacionalidad
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = Persona.ValidarDni(this.nacionalidad, value);
            }
        }
        /// <summary>
        /// Propiedad de solo lectura, agrega el DNI recibido como string
        /// despues de validar que cumpla con el formato y corresponda con la 
        /// nacionalidad
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = Persona.ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Constructor por defecto 
        /// </summary>
        public Persona()
        {
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            :this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor con parametros, inicializa el DNI a partir de un int
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// Constructor con parametros, inicializa DNI a partir de una cadena
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        /// <summary>
        /// Valida que el DNI este dentro del rango establecido
        /// (entre 1 y 99999999) y que corresponda con la nacionalidad de la persona
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>
        /// Devuelve el DNI si esta todo correcto, caso contrario lanza una excepcion NacionalidadInvalida
        /// </returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:

                    if(!(dato >=1 && dato <= 89999999))
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;

                case ENacionalidad.Extranjero:

                    if(!(dato>=90000000 && dato <= 99999999))
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;

                default:
                    throw new NacionalidadInvalidaException();
            }
            return dato;
        }
        /// <summary>
        /// Valida que el DNI recibido como string cumpla el formato de DNI
        /// (Que sea numerico y que el largo sea valido), si corresponde,
        /// se pasa a validar la nacionalidad, caso contrario se lanza una excepcion
        /// Dni Invalido
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Devuelve el DNI como int ya validado</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux;
            if(int.TryParse(dato, out aux) && dato.Length >= 1 && dato.Length <= 8)
            {
                aux = Persona.ValidarDni(nacionalidad, aux);
            }
            else
            {
                throw new DniInvalidoException();
            }
            return aux;
        }
        /// <summary>
        /// valida que la cadena recibida contenga solo caracteres validos como nombre
        /// (letras)
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>Devuelve el string con el nombre validado, si no es valido
        /// no lo carga
        /// </returns>
        private static string ValidarNombreApellido(string dato)
        {
            string retorno = "";
            bool rta = true;
            foreach(char item in dato)
            {
                if(!char.IsLetter(item))
                {
                    rta = false;
                    break;
                }
            }
            if (rta)
            {
                retorno =  dato;
            }
            return retorno;
        }
        /// <summary>
        /// Devuelve una cadena con todos los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Nombre Completo: {0}, {1}\nNacionalidad: {2}", 
                this.Apellido, this.Nombre, this.Nacionalidad.ToString());
        }
    }
}

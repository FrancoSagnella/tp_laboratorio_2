using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EntidadesAbstractas
{
    public abstract class Electrodomestico
    {
        /// <summary>
        /// Enumerado con los podibles marcas de los electrodomesticos
        /// </summary>
        public enum EMarcas
        {
            Philips,
            Oster
        }
        /// <summary>
        /// Enumerado con los diferentes modelos 
        /// </summary>
        public enum EModelos
        {
            ModeloTV1 ,
            ModeloTV2 ,
            ModeloCafetera1 ,
            ModeloCafetera2 
        }

        protected EMarcas marca;
        protected EModelos modelo;
        protected double precio;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Electrodomestico()
        {
        }

        /// <summary>
        /// Constructor con parametros,
        /// inicializa los atributos de electrodomestico
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="precio"></param>
        public Electrodomestico(EMarcas marca, EModelos modelo, double precio)
            :this()
        {
            this.marca = marca;
            this.Modelo = modelo;
            this.precio = precio;
        }

        /// <summary>
        /// Propiedad abstracta de lectura y escritura para el 
        /// atributo modelo
        /// </summary>
        public abstract EModelos Modelo { get; set; }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo marca
        /// </summary>
        public EMarcas Marca
        {
            get { return this.marca; }
            set { this.marca = value; }
        }

        /// <summary>
        /// propiedad de lectura y escritura para el precio
        /// </summary>
        public double Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }

        /// <summary>
        /// Override de tostring, devuelve los datos del electrofomestico 
        /// en una cadena
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Marca: ");
            sb.AppendLine(this.marca.ToString());
            sb.Append("Modelo: ");
            sb.AppendLine(this.modelo.ToString());
            sb.Append("Precio: ");
            sb.AppendLine(this.precio.ToString());

            return sb.ToString();
        }
        /// <summary>
        /// Recibe una cadena indicando la marca, y la devuelve como un enumerado
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static EMarcas StringAMarca(string cadena)
        {
            EMarcas retorno = 0;
            switch (cadena)
            {
                case "Philips":
                    retorno = EMarcas.Philips;
                    break;
                case "Oster":
                    retorno = EMarcas.Oster;
                    break;
            }
            return retorno;
        }
        /// <summary>
        /// Recibe una cadena indicando el mdelo, y la devuelve como un enumerado
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static EModelos StringAModelo(string cadena)
        {
            EModelos retorno = 0;
            switch (cadena)
            {
                case "ModeloTV1":
                    retorno = EModelos.ModeloTV1;
                    break;
                case "ModeloTV2":
                    retorno = EModelos.ModeloTV2;
                    break;
                case "ModeloCafetera1":
                    retorno = EModelos.ModeloCafetera1;
                    break;
                case "ModeloCafetera2":
                    retorno = EModelos.ModeloCafetera2;
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// Compara los datos de un electrodomestico con los de una fila de
        /// tipo DATAROW, si son iguales decuelve true
        /// </summary>
        /// <param name="e"></param>
        /// <param name="fila"></param>
        /// <returns></returns>
        public static bool operator ==(Electrodomestico e, DataRow fila)
        {
            if (e.Marca.ToString() == fila["Marca"].ToString() &&
                e.Modelo.ToString() == fila["Modelo"].ToString() &&
                e.Precio == float.Parse(fila["precio"].ToString()))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Compara los datos de un electrodomestico con los de una fila de
        /// tipo DATAROW, si son distintos decuelve true
        /// </summary>
        /// <param name="e"></param>
        /// <param name="fila"></param>
        /// <returns></returns>
        public static bool operator !=(Electrodomestico e, DataRow fila)
        {
            return !(e == fila);
        }
    }
}

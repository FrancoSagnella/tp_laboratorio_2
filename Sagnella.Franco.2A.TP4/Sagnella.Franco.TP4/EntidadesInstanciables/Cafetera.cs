using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Cafetera : Electrodomestico
    {
        /// <summary>
        /// Enumerado con los tipos de cafetera
        /// </summary>
        public enum ETipoCafetera
        {
            Express,
            Comun
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Cafetera():this(0, (EModelos)2, 0)
        {
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="precio"></param>
        public Cafetera(EMarcas marca, EModelos modelo, double precio)
            :base(marca, modelo, precio)
        {
        }

        /// <summary>
        /// implementacion de la propiedad abstracta Modelo
        /// GET: devuelve el modelo de la cafetera
        /// SET: establece el modelo a la cafetera, validando que este coincida con un modelo de cafetera
        /// De no coincidir, lanza ModeloException
        /// </summary>
        public override EModelos Modelo
        {
            get
            {
                return this.modelo;
            }
            set
            {
                if (value == EModelos.ModeloCafetera1 || value == EModelos.ModeloCafetera2)
                {
                    this.modelo = value;
                }
                else
                {
                    throw new ModeloException();
                }
            }
        }

        /// <summary>
        /// Propiedad de lectura, Dependiendo el modelo de la cafetera, devuelve
        /// un valor de tipo ETipoCafetera, indicando su tipo
        /// </summary>
        public ETipoCafetera Tipo
        {
            get 
            {
                ETipoCafetera ret;
                switch (this.modelo)
                {
                    case EModelos.ModeloCafetera1:
                        ret = ETipoCafetera.Comun;
                        break;
                    case EModelos.ModeloCafetera2:
                        ret = ETipoCafetera.Express;
                        break;
                    default:
                        throw new ModeloException();
                }
                return ret;
            }
        }

        /// <summary>
        /// override de tostring, Devuelve una cadena con todos los datos de la cafetera
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.Append("Tipo: ");
            sb.AppendLine(this.Tipo.ToString());

            return sb.ToString();
        }
    }
}

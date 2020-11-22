using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Tv : Electrodomestico
    {
        /// <summary>
        /// Enumerado con los tipos de TV
        /// </summary>
        public enum ETipoTv
        {
            LedTv,
            SmartTv
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Tv():this(0, 0, 0)
        {
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="precio"></param>
        public Tv(EMarcas marca, EModelos modelo, double precio)
            :base(marca, modelo, precio)
        {
        }

        /// <summary>
        /// Implementacion de la propiedad abstracta Modelo,
        /// GET: devuelve el atributo modelo
        /// SET: Establece el modelo recibido como value en el electrodomestico,
        /// al tratarese de una TV, valida que los modelos correspondan con los 
        /// modelos de TVs
        /// Si el modelo no es valido, lanza ModeloException
        /// </summary>
        public override EModelos Modelo 
        {
            get
            {
                return this.modelo;
            }
            set
            {
                if (value == EModelos.ModeloTV1 || value == EModelos.ModeloTV2)
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
        /// propiedad de lectura, dependiendo el modelo de TV, devuelve
        /// un int que indica la cantidad de pulgadas que tiene
        /// </summary>
        public int Pulgadas
        {
            get 
            {
                int ret;
                switch (this.modelo)
                {
                    case EModelos.ModeloTV1:
                        ret = 55;
                        break;
                    case EModelos.ModeloTV2:
                        ret = 70;
                        break;
                    default:
                        throw new ModeloException();
                }
                return ret;
            }
        }

        /// <summary>
        /// propiedad de lectura, dependiendo del modelo de TV, devuelve
        /// un ETipoTv que indica si es smart o led
        /// </summary>
        public ETipoTv Tipo
        {
            get 
            {
                ETipoTv ret;
                switch (this.modelo)
                {
                    case EModelos.ModeloTV1:
                        ret = ETipoTv.LedTv;
                        break;
                    case EModelos.ModeloTV2:
                        ret = ETipoTv.SmartTv;
                        break;
                    default:
                        throw new ModeloException();
                }
                return ret;
            }
        }

        /// <summary>
        /// override de tostring, Devuelve una cadena con todos los datos de la TV
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.Append("Tipo: ");
            sb.AppendLine(this.Tipo.ToString());
            sb.Append("Pulgadas: ");
            sb.AppendLine(this.Pulgadas.ToString());

            return sb.ToString();
        }
    }
}

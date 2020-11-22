using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.Data;

namespace EntidadesInstanciables
{
    public class ListaElectrodomesticos
    {
        private List<Electrodomestico> lista;
        
        public ListaElectrodomesticos()
        {
            this.lista = new List<Electrodomestico>();
        }

        public List<Electrodomestico> Lista
        {
            get { return this.lista; }
            set { this.lista = value; }
        }

        public static ListaElectrodomesticos operator +(ListaElectrodomesticos lista, DataRow fila)
        {
            switch (fila["Tipo"].ToString())
            {
                case "Tv":

                    lista.lista.Add(new Tv(Electrodomestico.StringAMarca(fila["Marca"].ToString()),
                                        Electrodomestico.StringAModelo(fila["Modelo"].ToString()),
                                        float.Parse(fila["Precio"].ToString())));
                    break;
                case "Cafetera":
                    lista.lista.Add(new Cafetera(Electrodomestico.StringAMarca(fila["Marca"].ToString()),
                                        Electrodomestico.StringAModelo(fila["Modelo"].ToString()),
                                        float.Parse(fila["Precio"].ToString())));
                    break;
            }
            return lista;
        }
        public static ListaElectrodomesticos operator -(ListaElectrodomesticos lista, DataRow fila)
        {
            foreach(Electrodomestico e in lista.lista)
            {
                if (e == fila)
                {
                    lista.lista.Remove(e);
                    break;
                }
            }
            return lista;
        }
    }
}

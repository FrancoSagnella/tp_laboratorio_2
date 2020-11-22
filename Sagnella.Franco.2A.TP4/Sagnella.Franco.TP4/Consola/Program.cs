using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Archivos;
using Excepciones;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instancio un par de objetos
            Tv tv1 = new Tv(Electrodomestico.EMarcas.Philips, Electrodomestico.EModelos.ModeloTV1, 30000);
            Tv tv2 = new Tv(Electrodomestico.EMarcas.Philips, Electrodomestico.EModelos.ModeloTV2, 70000);
            Cafetera caf1 = new Cafetera(Electrodomestico.EMarcas.Oster, Electrodomestico.EModelos.ModeloCafetera1, 19000);
            Cafetera caf2 = new Cafetera(Electrodomestico.EMarcas.Oster, Electrodomestico.EModelos.ModeloCafetera1, 22113);

            //Instancio un par de objetos esperando excepciones
            try
            {
                Tv tv3 = new Tv(Electrodomestico.EMarcas.Philips, Electrodomestico.EModelos.ModeloCafetera1, 30000);
            }
            catch(ModeloException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Cafetera caf3 = new Cafetera(Electrodomestico.EMarcas.Oster, Electrodomestico.EModelos.ModeloTV1, 19000);
            }
            catch (ModeloException e)
            {
                Console.WriteLine(e.Message);
            }

            //Muestro los objetos
            Console.WriteLine(tv1.ToString());
            Console.WriteLine(caf1.ToString());
            Console.WriteLine(tv2.ToString());
            Console.WriteLine(caf2.ToString());

            Console.ReadLine();
            Console.Clear();

            try
            {
                //Imprimo un par de tickets
                Ticketeadora<Tv>.imprimirHistorialVentas(tv1, "Ticket_Ventas.log");
                Ticketeadora<Cafetera>.imprimirHistorialVentas(caf1, "Ticket_Ventas.log");
                Ticketeadora<Tv>.imprimirHistorialVentas(tv2, "Ticket_Ventas.log");
                Ticketeadora<Cafetera>.imprimirHistorialVentas(caf2, "Ticket_Ventas.log");

                //Muestro los tickets
                Console.WriteLine(Ticketeadora<Electrodomestico>.Leer("Ticket_Ventas.log"));
            }
            catch(ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;
using Archivos;

namespace Testsunitarios
{
    [TestClass]
    public class TestsUnitarios
    {
        /// <summary>
        /// Metodo Test que valida que se instancie bien un objeto Tv
        /// </summary>
        [TestMethod]
        public void Validar_Instancia_Tv()
        {
            Tv tv1 = new Tv(Electrodomestico.EMarcas.Philips, Electrodomestico.EModelos.ModeloTV1, 30000);
            Tv tv2 = new Tv(Electrodomestico.EMarcas.Philips, Electrodomestico.EModelos.ModeloTV2, 70000);
            Tv tv3 = new Tv();

            Assert.IsNotNull(tv1);
            Assert.IsNotNull(tv2);
            Assert.IsNotNull(tv3);
        }
        /// <summary>
        /// Metodo test prueba que se instancien objetos Cafetera
        /// </summary>
        [TestMethod]
        public void Validar_Instancia_Cafetera()
        {
            Cafetera caf1 = new Cafetera(Electrodomestico.EMarcas.Oster, Electrodomestico.EModelos.ModeloCafetera1, 19000);
            Cafetera caf2 = new Cafetera(Electrodomestico.EMarcas.Oster, Electrodomestico.EModelos.ModeloCafetera2, 22113);
            Cafetera caf3 = new Cafetera();


            Assert.IsNotNull(caf1);
            Assert.IsNotNull(caf2);
            Assert.IsNotNull(caf3);
        }

        /// <summary>
        /// Prueba que se lance correctamente la excepcion 
        /// ModeloException al crear un objeto con un modelo invalido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ModeloException))]
        public void ModeloException_Prueba_Tv()
        {
            Tv tv = new Tv(Electrodomestico.EMarcas.Philips, Electrodomestico.EModelos.ModeloCafetera1, 30000);
        }

        /// <summary>
        /// Prueba que se lance correctamente la excepcion 
        /// ModeloException al crear un objeto con un modelo invalido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ModeloException))]
        public void ModeloException_Prueba_Cafetera()
        {
            Cafetera caf3 = new Cafetera(Electrodomestico.EMarcas.Oster, Electrodomestico.EModelos.ModeloTV1, 19000);
        }

        /// <summary>
        /// Prueba que se imprima correctamente un archivo de texto
        /// </summary>
        [TestMethod]
        public void Prueba_ImprimirTicket()
        {
            Tv tv = new Tv(Electrodomestico.EMarcas.Philips, Electrodomestico.EModelos.ModeloTV1, 30000);

            Assert.IsTrue(Ticketeadora<Tv>.imprimirHistorialVentas(tv, "Ticket_Ventas.log")); 
        }
        /// <summary>
        /// Prueba que se lea correctamente de un archivo de texto
        /// </summary>
        [TestMethod]
        public void Prueba_LeerTicket()
        {
            Tv tv = new Tv(Electrodomestico.EMarcas.Philips, Electrodomestico.EModelos.ModeloTV1, 30000);

            Ticketeadora<Tv>.imprimirHistorialVentas(tv, "Ticket_Ventas.log");
            string resultado = Ticketeadora<Electrodomestico>.Leer("Ticket_Ventas.log");

            Assert.IsNotNull(resultado);
        }
    }
}

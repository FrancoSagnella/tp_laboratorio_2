using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace TestsUnitariosTP3
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Metodo de test que prueba que se lance la excepcion de DNI invalido,
        /// pasandole un dni que no contenga valores numericos
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ValidarDNI_ExcepcionLetras()
        {
            Alumno a = new Alumno(1, "Pepe", "Pepe", "12as3456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
        }
        /// <summary>
        /// Metodo de test que prueba que se lance la excepcion de DNI invalido,
        /// pasandole un dni que exceda el numero de caracteres permitido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ValidarDNI_ExcepcionMasCaracteres()
        {
            Alumno a = new Alumno(1, "Pepe", "Pepe", "122233321113456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
        }

        /// <summary>
        /// Metodo de test que prueba que se lance la expecion Nacionalidad Invalida,
        /// pasandole un DNI con el formato de Argentino y la nacionalidad Extranjero
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void ValidarNacionalidad_ExcepcionExtranjero()
        {
            Alumno a = new Alumno(1, "Pepe", "Pepe", "12233456",
            EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
        }

        /// <summary>
        /// Metodo de test que prueba que se lance la expecion Nacionalidad Invalida,
        /// pasandole un DNI con el formato de Extranjero y la nacionalidad Argentino
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void ValidarNacionalidad_ExcepcionArgentino()
        {
            Alumno a = new Alumno(1, "Pepe", "Pepe", "99999998",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
        }

        /// <summary>
        /// Metodo de test que prueba que se instancien las listas de alumnos, jornadas, y profesores
        /// dentro de un objeto Universidad
        /// </summary>
        [TestMethod]
        public void ValidarListasInstanciadas()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Alumnos);
            Assert.IsNotNull(uni.Profesores);
            Assert.IsNotNull(uni.Jornadas);
        }
    }
}

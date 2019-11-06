using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Instanciables;
using EntidadesAbstractas;
using Archivos;

namespace PruebaUnitariaDeUniversidad
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test para saber si lanza la excepcion NacionalidadInvalidaException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidad()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "juan", "Lopez", "99999999", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);

            uni += a1;
            
        }
        /// <summary>
        /// Test para saber si lanza la excepcion DniInvalidoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestFormatoDNI()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "juan", "Lopez","zzfe", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);

            uni += a1;
        }
        /// <summary>
        /// Test para saber si el DNI(string) pasa a formato int
        /// </summary>
        [TestMethod]
        public void TestValorNumerico()
        {
            Alumno a1 = new Alumno(1, "juan", "Lopez", "12345678", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);

            Assert.AreEqual(a1.DNI,12345678);
        }
        /// <summary>
        /// Test para saber si las clases intanciables no son nulas
        /// </summary>
        [TestMethod]
        public void TestValidarValoresNulos()
        {
            //Alumno a1=null;
            //Universidad uni = new Universidad();
            //Jornada j1 = new Jornada();
            Profesor i1 = new Profesor(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            Jornada j2 = new Jornada(Universidad.EClases.Laboratorio,i1);
            Assert.IsNotNull(j2);
        }
    }
}

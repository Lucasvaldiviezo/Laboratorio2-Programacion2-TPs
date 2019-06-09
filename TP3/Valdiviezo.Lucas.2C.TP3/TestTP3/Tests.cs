using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesAbstractas;
using ClasesInstanciables;
using Excepciones;
using Archivos;

namespace TestTP3
{
    [TestClass]
    public class Tests
    {
        /// <summary>
        /// Comprueba que salte la Excepcion Alumno Repetido al crear 2 alumnos iguales e intentar agregarlos a la universidad.
        /// </summary>
        [TestMethod]
        public void TestAlumnoRepetidoException()
        {
            //arrange
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Torto", "10000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(2, "Carlos", "Rodriguez", "10000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            //act
            try
            {
                uni += a1;
                uni += a2;
            }
            catch (AlumnoRepetidoException e)
            {
                //assert
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }
        /// <summary>
        /// Comprueba que salte la Excepcion Alumno Repetido al crear 2 alumnos iguales e intentar agregarlos a la universidad.
        /// </summary>
        [TestMethod]
        public void TestSinProfesorException()
        {
            //arrange
            Universidad uni = new Universidad();
            //act
            try
            {
                uni += Universidad.EClases.Legislacion;
            }
            catch (SinProfesorException e)
            {
                //assert
                Assert.IsInstanceOfType(e, typeof(SinProfesorException));
            }
        }
        /// <summary>
        /// Comprueba que salte la Excepcion Alumno Repetido al crear 2 alumnos iguales e intentar agregarlos a la universidad
        /// </summary>
        [TestMethod]
        public void TestValorNumerico()
        {
            //arrange
            Alumno a1 = new Alumno(1, "Carlos", "Chau","12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            //assert
            
        }

    }
}

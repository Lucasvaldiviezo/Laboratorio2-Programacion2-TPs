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
        /// Comprueba que el DNI se haya ingresado y validado correctamente.
        /// </summary>
        [TestMethod]
        public void TestValorNumerico()
        {
            //arrange
            Alumno a1 = new Alumno(1,"Mario","Juarez", "12345678",Persona.ENacionalidad.Argentino,Universidad.EClases.Laboratorio);
            //assert
            Assert.IsTrue(12345678 == a1.DNI);
        }
        /// <summary>
        /// Comprueba que el objeto no tenga ninguno de sus atributos en NULL
        /// </summary>
        [TestMethod]
        public void TestValorNoNull()
        {
            //arrange
            Alumno a1 = new Alumno(1, "Mario", "Juarez", "12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Profesor p1 = new Profesor(1, "Mario", "Juarez", "12345678", Persona.ENacionalidad.Argentino);
            Jornada j1 = new Jornada(Universidad.EClases.Laboratorio, p1);
            //act
            j1 += a1;
            //assert
            //Alumno
            Assert.IsNotNull(a1.DNI);
            Assert.IsNotNull(a1.Nacionalidad);
            Assert.IsNotNull(a1.Nombre);
            Assert.IsNotNull(a1.Apellido);
            //Profesor
            Assert.IsNotNull(p1.DNI);
            Assert.IsNotNull(p1.Nacionalidad);
            Assert.IsNotNull(p1.Nombre);
            Assert.IsNotNull(p1.Apellido);
            //Jornada
            Assert.IsNotNull(j1.Alumnos);
            Assert.IsNotNull(j1.Clase);
            Assert.IsNotNull(j1.Instructor);
        }

    }
}

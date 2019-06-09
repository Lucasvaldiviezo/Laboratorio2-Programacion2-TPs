using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<String>
    {
        /// <summary>
        /// Permite guardar lo datos recibidos en un archivo de texto. 
        /// </summary>
        /// <param name="archivo">Ruta donde se guardará el archivo.</param>
        /// <param name="datos">Datos que se guardaran en el archivo.</param>
        /// <returns>Devuelve true si guardo satisfactoriamente o false si se produjeron excepciones.</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = true;
            StreamWriter archivotxt = null;
            try
            {
                archivotxt = new StreamWriter(archivo, false);
                archivotxt.Write(datos);
            }catch(Exception)
            {
                retorno = false;
            }finally
            {
                archivotxt.Close();
            }

            return retorno;
        }
        /// <summary>
        /// Permite leer datos de un archivo de texto. 
        /// </summary>
        /// <param name="archivo">Ruta de donde se obtendra el archivo.</param>
        /// <param name="datos">Variable donde se guardaran los datos del archivo.</param>
        /// <returns>Devuelve true si leyo satisfactoriamente o false si se produjeron excepciones.</returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader archivotxt = null;
            bool retorno = true;
            try
            {
                archivotxt = new StreamReader(archivo);
                datos = archivotxt.ReadToEnd();
            }
            catch (Exception)
            {
                datos = "";
                retorno = false;
            }
            finally
            {
                archivotxt.Close();
            }

            return retorno;
        }
    }
}

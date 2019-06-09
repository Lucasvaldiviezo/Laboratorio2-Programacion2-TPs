using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Permite guardar datos recibidos en un archivo serializado. 
        /// </summary>
        /// <param name="archivo">Ruta de donde se obtendra el archivo.</param>
        /// <param name="datos">Datos a guardar en el archivo.</param>
        /// <returns>Devuelve true si guardo satisfactoriamente o false si se produjeron excepciones.</returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(T));
            XmlTextWriter escritor = null;
            bool retorno = true;
            try
            {
                escritor = new XmlTextWriter(archivo,null);
                serializador.Serialize(escritor, datos);
            }
            catch (Exception)
            {
                retorno = false; 
            }
            finally
            {
                escritor.Close();
            }
            return retorno;
        }
        /// <summary>
        /// Permite leer datos de un archivo serializado. 
        /// </summary>
        /// <param name="archivo">Ruta de donde se obtendra el archivo.</param>
        /// <param name="datos">Variable donde se guardaran los datos del archivo.</param>
        /// <returns>Devuelve true si leyo satisfactoriamente o false si se produjeron excepciones.</returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(T));
            XmlTextReader lector = null;
            bool retorno = true;
            try
            {
                lector = new XmlTextReader(archivo);
                datos = (T)serializador.Deserialize(lector);
            }
            catch (Exception)
            {
                retorno = false;
                datos = default(T);
            }
            finally
            {
                lector.Close();
            }
            return retorno;
        }
    }
}

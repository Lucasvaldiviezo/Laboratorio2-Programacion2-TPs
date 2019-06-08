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

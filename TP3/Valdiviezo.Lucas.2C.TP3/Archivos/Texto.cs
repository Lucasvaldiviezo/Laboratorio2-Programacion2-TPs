using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<String>
    {
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

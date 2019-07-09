using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = true;
            StreamWriter archivotxt = null;
            try
            {
                archivotxt = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), archivo), true);
                archivotxt.Write(texto);
            }
            catch (Exception)
            {
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

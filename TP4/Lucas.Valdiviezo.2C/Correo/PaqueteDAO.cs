using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Entidades
{
    public static class PaqueteDAO
    {
        private static String connectionStr = "Data Source=LAB3PC19\\SQLEXPRESS; Initial Catalog = Comiqueria; Integrated Security = True";
        private static SqlConnection conexion;
        private static SqlCommand comando;

        static PaqueteDAO()
        {
            conexion = new SqlConnection(connectionStr);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        public static bool Insertar(Paquete P)
        {
            return true;
        }
    }
}

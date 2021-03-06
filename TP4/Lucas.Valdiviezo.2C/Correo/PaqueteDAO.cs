﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Entidades
{
    public static class PaqueteDAO
    {
        private static String connectionStr = "Data Source=DESKTOP-JHTFNKN\\SQLEXPRESS; Initial Catalog=correo-sp-2017; Integrated Security = True";
        private static SqlConnection conexion;
        private static SqlCommand comando;
        /// <summary>
        /// Constructor estatico que inicializa la conexion con la base de datos
        /// </summary>
        static PaqueteDAO()
        {
            try
            {
                conexion = new SqlConnection(connectionStr);
                comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Metodo estatico que se encargara de guardar los datos recibidos del paquete en la base datos.
        /// <param name="p">Paquete que contiene los datos a guardar. </param>
        /// </summary>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            string consulta;
            try
            {
                consulta = String.Format("INSERT INTO dbo.Paquetes (direccionEntrega, trackingID, alumno) VALUES ('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, "Lucas Valdiviezo");
                comando.CommandText = consulta;
                conexion.Open();
                comando.ExecuteNonQuery();
                retorno = true;
            }

            catch (Exception e)
            {
                throw e;
            }

            finally
            {
                 conexion.Close();
            }

            return retorno;
        }
    }
}

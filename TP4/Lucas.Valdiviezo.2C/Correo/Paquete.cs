using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public delegate void DelegadoDAOException(object paquete, Exception exception);
        public event DelegadoEstado InformarEstado;
        public event DelegadoDAOException InformarDAO;

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        /// <summary>
        /// Metodo de instancia
        ///<param name="direccionEntrega">direccion donde se entregara el paquete. </param>
        ///<param name="trackingID">numero para hacer seguimiento del paquete. </param>
        /// </summary>
        public Paquete(string direccionEntrega, string trackingID)
        {
            DireccionEntrega = direccionEntrega;
            TrackingID = trackingID;
        }
        /// <summary>
        /// Propiedad que instancia o devuelve la direccion del paquete.
        /// </summary>
        public string DireccionEntrega
        {
            set { direccionEntrega = value; }
            get { return direccionEntrega; }
        }
        /// <summary>
        /// Propiedad que instancia o devuelve el estado del paquete.
        /// </summary>
        public EEstado Estado
        {
            set { estado = value; }
            get { return estado; }
        }
        /// <summary>
        /// Propiedad que instancia o devuelve el trackingId del paquete.
        /// </summary>
        public string TrackingID
        {
            set { trackingID = value; }
            get { return trackingID; }
        }
        /// <summary>
        /// Metodo que hace pasar al Paquete por cada uno de los 3 estados, y al finalizar ingresa ese paquete en la base de datos.
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                System.Threading.Thread.Sleep(4000);
                this.Estado = EEstado.EnViaje;
                this.InformarEstado(this, null);
                System.Threading.Thread.Sleep(4000);
                this.Estado = EEstado.Entregado;
                this.InformarEstado(this, null);

                try
                {
                    PaqueteDAO.Insertar(this);
                }
                catch (Exception e)
                {
                    this.InformarDAO(this, e); 
                }
            }
        }

        /// <summary>
        /// Metodo que devuelve un string con todos los datos del Paquete.
        ///<param name="elementos">Lista de elementos el cual sera convertido a Paquete para obtener sus datos. </param>
        /// </summary>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string mostrar;
            mostrar = string.Format("{0} para {1}\n", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
            return mostrar;
        }
        /// <summary>
        /// Sobrecarga del metodo ToString el cual llamada al metodo MostrarDatos y devuelve los datos del paquete.
        /// </summary>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        /// <summary>
        /// Sobrecarga del operador == en donde compara si 2 paquetes son iguales en base a su trackingID.
        ///<param name="p1">Paquete 1 a comparar. </param>
        ///<param name="p2">Paquete 2 a comparar. </param>
        /// </summary>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if(p1.TrackingID == p2.TrackingID)
            {
                retorno = true; 
            }
            return retorno;
        }
        /// <summary>
        /// Sobrecarga del operador != en donde compara si 2 paquetes son distintos en base a su trackingID.
        ///<param name="p1">Paquete 1 a comparar. </param>
        ///<param name="p2">Paquete 2 a comparar. </param>
        /// </summary>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
    }
}

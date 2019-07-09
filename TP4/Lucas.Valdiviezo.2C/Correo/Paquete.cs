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

        public Paquete(string direccionEntrega, string trackingID)
        {
            DireccionEntrega = direccionEntrega;
            TrackingID = trackingID;
        }

        public string DireccionEntrega
        {
            set { direccionEntrega = value; }
            get { return direccionEntrega; }
        }

        public EEstado Estado
        {
            set { estado = value; }
            get { return estado; }
        }

        public string TrackingID
        {
            set { trackingID = value; }
            get { return trackingID; }
        }
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
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string mostrar;
            mostrar = string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
            return mostrar;
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if(p1.TrackingID == p2.TrackingID)
            {
                retorno = true; 
            }
            return retorno;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
    }
}

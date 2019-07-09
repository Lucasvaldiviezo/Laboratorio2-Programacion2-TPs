using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }

        public List<Paquete> Paquetes
        {
            get { return paquetes; }
            set { paquetes = value; }
        }

        public void FinEntregas()
        {
            foreach (Thread t in mockPaquetes)
            {
                if (t.IsAlive)
                {
                    t.Abort();
                }
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder mostrar = new StringBuilder();
            foreach (Paquete pqtAux in ((Correo)elementos).Paquetes)
            {
                mostrar.AppendFormat("{0} para {1} ({2}) \n", pqtAux.TrackingID, pqtAux.DireccionEntrega, pqtAux.Estado.ToString());
            }
            return mostrar.ToString();
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete auxPaquete in c.paquetes)
            {
                if(auxPaquete == p)
                {
                    throw new TrackingIdRepetidoException(string.Format("El paquete con el tracking {0} ya se encuentra en la lista",p.TrackingID));
                }
            }
            c.paquetes.Add(p);
            Thread MockCicloDeVidaHilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(MockCicloDeVidaHilo);
            MockCicloDeVidaHilo.Start();

            return c;
        }
    }
}

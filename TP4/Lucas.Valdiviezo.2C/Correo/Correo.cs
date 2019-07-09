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

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete auxPaquete in c.paquetes)
            {
                if(auxPaquete == p)
                {
                    throw new TrackingIdRepetidoException("El paquete ya se encuentra en la lista");
                }else
                {
                    c.paquetes.Add(p);
                }
            }

            Thread MockCicloDeVidaHilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(MockCicloDeVidaHilo);
            MockCicloDeVidaHilo.Start();

            return c;
        }
    }
}

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
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }
        /// <summary>
        /// Inicializa o Devuelve la lista de paquetes.
        /// </summary>
        public List<Paquete> Paquetes
        {
            get { return paquetes; }
            set { paquetes = value; }
        }
        /// <summary>
        /// Metodo que revisa la lista de hilos y finaliza los que aun estan vivos.
        /// </summary>
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
        /// <summary>
        /// Metodo que devuelve un string con todos los datos de cada Paquete en la lista paquetes del correo.
        ///<param name="elementos">Lista de elementos el cual sera convertido a Correo para obtener sus datos. </param>
        /// </summary>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder mostrar = new StringBuilder();
            foreach (Paquete pqtAux in ((Correo)elementos).Paquetes)
            {
                mostrar.AppendFormat("{0} para {1} ({2}) \n", pqtAux.TrackingID, pqtAux.DireccionEntrega, pqtAux.Estado.ToString());
            }
            return mostrar.ToString();
        }
        /// <summary>
        /// Sobrecarga del operador + el cual recibe un paquete para agregarlo a la lista de paquetes del correo.
        ///<param name="c">Correo en el que se agregara el paquete. </param>
        ///<param name="p">Paquete que se agregara a la lista. </param>
        /// </summary>
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

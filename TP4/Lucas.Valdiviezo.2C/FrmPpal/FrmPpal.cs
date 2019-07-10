using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace FrmPpal
{
    public partial class FrmPpal : Form
    {
        private Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete nuevoPaquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
                nuevoPaquete.InformarEstado += paq_InformarEstado;//asocia el evento(InformarEstado) al manejador de eventos(paq_InformarEstado).
                nuevoPaquete.InformarDAO += informar_DAO;//asocia el evento(InformarSQlException) al manejador de eventos(informar_SQLException).
                correo += nuevoPaquete;//Agrega el paquete nuevo a la lista de paquetes de la clase correo
                ActualizarEstados(); //actualiza los estados con el metodo ActualizarEstados().
            }
            catch (TrackingIdRepetidoException exception) // Captura la posible excepcion de que un paquete tenga el mismo TrackingId que otro paquete.
            {
                MessageBox.Show(exception.Message, "El paquete ya se encuentra en la lista", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void informar_DAO(object paquete, Exception exception)
        {
            MessageBox.Show(string.Format("Error al cargar los datos datos del paquete: {0} \n Descripcion: \n {1}", paquete.ToString(), exception.Message),
                "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void paq_InformarEstado(object sender, EventArgs e)
        {
            if(this.InvokeRequired)
            {
                Paquete.DelegadoEstado aux = new Paquete.DelegadoEstado(paq_InformarEstado);
                this.Invoke(aux, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete p in this.correo.Paquetes)
            {
                if (p.Estado == Paquete.EEstado.Ingresado)
                {
                    lstEstadoIngresado.Items.Add(p);
                }
                else if (p.Estado == Paquete.EEstado.EnViaje)
                {
                    lstEstadoEnViaje.Items.Add(p);
                }
                else if ((p.Estado == Paquete.EEstado.Entregado))
                {
                    lstEstadoEntregado.Items.Add(p);
                }
            }
        }
    }
}

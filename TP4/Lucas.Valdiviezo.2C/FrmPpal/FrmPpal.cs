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
            this.correo = new Correo();
            richTextBoxMostrar.Enabled = false;
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete nuevoPaquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
                nuevoPaquete.InformarEstado += paq_InformarEstado;
                nuevoPaquete.InformarDAO += informar_DAO;
                correo += nuevoPaquete;
                ActualizarEstados();
            }
            catch (TrackingIdRepetidoException exception)
            {
                MessageBox.Show(exception.Message, "El paquete ya se encuentra en la lista", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void informar_DAO(object paquete, Exception exception)
        {
            MessageBox.Show(string.Format("Error al cargar los datos datos del paquete: {0} \nDescripcion: \n{1}", paquete.ToString(), exception.Message),
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

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            
            string rutaArchivo = @"salida.txt";

            if (elemento != null)
            {
                this.richTextBoxMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    GuardaString.Guardar(this.richTextBoxMostrar.Text, rutaArchivo);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }
}

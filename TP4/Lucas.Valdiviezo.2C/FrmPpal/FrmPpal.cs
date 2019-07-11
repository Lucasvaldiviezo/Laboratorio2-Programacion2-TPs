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
        /// <summary>
        /// Constructor por defecto que instancia el nuevo correo y desactiva el richTextBoxMostrar.
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
            richTextBoxMostrar.Enabled = false;
        }
        /// <summary>
        /// Se pondra fin a todos los hilos cuando el Form se cierre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }
        /// <summary>
        /// Este metodo obtendra la direccion y el TrackingID de los txt correspondientes y lo agregar al correo para luego mostrarlo en pantalla y cargarlo en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Manejador del evento InformarDao que avisa si se lanza una excepcion al intentar cargar los datos en la base de datos.
        /// </summary>
        /// <param name="paquete">Paquete que no se pudo cargar</param>
        /// <param name="exception">Excepcion que se lanzo</param>
        private void informar_DAO(object paquete, Exception exception)
        {
            MessageBox.Show(string.Format("Error al cargar los datos datos del paquete: {0} \nDescripcion: \n{1}", paquete.ToString(), exception.Message),
                "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Manejador del evento InformarEstado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Este metodo se encarga de borras los datos de los listbox actuales y cargarlos de nuevo con la informacion correspondiente de cada paquete.
        /// </summary>
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
        /// <summary>
        /// Este metodo llama al MostrarInformacion y le envia la lista de Paquetes del correo para luego mostrarla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
        /// <summary>
        /// Este metodo llama al MostrarInformacion y le envia el Paquete seleccion en el lstEstadoEntregado para mostrarlo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
        /// <summary>
        /// Mostrará los datos del parametro elemento en el rtbMostrar y ademas utilizara el método de extensión para guardar los datos en un archivo llamado salida.txt.
        /// </summary>
        /// <typeparam name="T">Tipo generico que recibira el metodo</typeparam>
        /// <param name="elemento">Elemento con la informacion necesaria</param>
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

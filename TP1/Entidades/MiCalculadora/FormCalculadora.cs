using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace MiCalculadora
{
    public partial class MiCalculadora : Form
    {
        
        public MiCalculadora()
        {
            InitializeComponent();
        }

        private void MiCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
          MiCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double retorno=0;
            
           
            return retorno;
        }

        private void Limpiar()
        {
            txtNumero2.Clear();
            txtNumero1.Clear();
            cmbOperador.ResetText();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

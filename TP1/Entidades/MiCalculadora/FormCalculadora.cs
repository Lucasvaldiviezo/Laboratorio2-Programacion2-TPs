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
          lblResultado.Text = Convert.ToString(MiCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text));
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
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            retorno = Calculadora.Operar(num1, num2, operador);
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

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            //Version con Double
            /*double auxNumero;
            if(double.TryParse(lblResultado.Text, out auxNumero))
            {
                Numero numDecimal = new Numero(auxNumero);
                lblResultado.Text = numDecimal.DecimalBinario(auxNumero);
            }*/
            //Version con String
            Numero numDecimal = new Numero(0);
            lblResultado.Text = numDecimal.DecimalBinario(lblResultado.Text);
        }
    }
}

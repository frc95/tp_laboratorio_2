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
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        #region 
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            
        }
       
        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        /// <summary>
        /// Borrara datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Realizara las operaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numeroUno = txtNumero1.Text;
            string numeroDos = txtNumero2.Text;
            string operador = cmbOperador.Text;
            double total=Operar(numeroUno, numeroDos, operador);
            lblResultado.Text = Convert.ToString(total);
        }

        /// <summary>
        /// Borrara los datos de los textbox, combobox y label
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }
        /// <summary>
        /// Realizara las operaciones del metodo Operar de la clase calculadora
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operardor"></param>
        /// <returns> El resultado del metodo Operar </returns>
        private static double Operar(string numero1, string numero2, string operardor)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            
            return Entidades.Calculadora.Operar(n1, n2, operardor); ;
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Convierte el resultado de lblResultado en binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero binario = new Numero();
            lblResultado.Text=binario.DecimalBinario(lblResultado.Text);
            
        }
        /// <summary>
        /// Convierte el resultado de lblResultado en decimal, si esta en binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero _decimal= new Numero();
            lblResultado.Text = _decimal.BinarioDecimal(lblResultado.Text);
        }

        
    }
}

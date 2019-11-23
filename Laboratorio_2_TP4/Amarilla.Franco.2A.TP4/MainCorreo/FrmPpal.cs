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

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
            this.CenterToScreen();
        }
        /// <summary>
        /// Limpiará los 3 ListBox y luego recorrerá la lista de paquetes
        /// agregando cada uno de ellos en el listado que corresponda.
        /// </summary>
        private void ActualizarEstados()
        {
            
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoIngresado.Items.Clear();
            foreach(Paquete aux in correo.Paquetes)
            {
                if(aux.Estado==Paquete.EEstado.Ingresado)
                {
                    this.lstEstadoIngresado.Items.Add(aux);
                }
                else if(aux.Estado == Paquete.EEstado.EnViaje)
                {
                    this.lstEstadoEnViaje.Items.Add(aux);
                }
                else
                {
                    this.lstEstadoEntregado.Items.Add(aux);
                }
            }
        }

        /// <summary>
        /// Agrega un paquete al correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            string direccionEntrega = this.txtDireccion.Text;
            string trackingID = this.mtxtTrackingID.Text;
            Paquete p = new Paquete(direccionEntrega, trackingID);
            p.InformaEstado += new Paquete.DelegadoEstado(this.paq_InformaEstado);

            PaqueteDAO.lanzarException += new PaqueteDAO.DelegadoException(this.LanzarException);


            try
            {
                
                correo += p;
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.ActualizarEstados();
            PaqueteDAO.lanzarException -= new PaqueteDAO.DelegadoException(this.LanzarException);
        }


        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();

            }
        }

        /// <summary>
        /// Antes de cerrar el formulario cerrara todos los hilos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        /// <summary>
        /// Saltara un mensaje que describe la excepcion actual
        /// </summary>
        /// <param name="e"></param>
        private void LanzarException(Exception e)
        {
            MessageBox.Show(e.Message);
        }

        /// <summary>
        /// Mostrara la informacion de todos los paquetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Mostrara los datos en el Rich text box
        /// Despues guardara los datos en un archivo de texto en el escritorio
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(!Object.Equals(elemento,null))
            {
                
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                elemento.MostrarDatos(elemento).Guardar("salida.txt");
            }
        }

        /// <summary>
        /// Mostrara la inforamacion del paquete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
            
        }
    }
}

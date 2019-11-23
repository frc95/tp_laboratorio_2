using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region ATRIBUTOS
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region EVENTO
        public event DelegadoEstado InformaEstado;
        #endregion

        #region PROPIEDADES
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }
        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }
        #endregion

        #region METODOS
        /// <summary>
        /// El paquete pasara de estado cada 4 segundos hasta llegar al estado "Entregado"
        /// </summary>
        public void MockCicloDeVida()
        {
            while(true)
            {
                Thread.Sleep(4000);
                this.estado += 1;
                this.InformaEstado(this.estado,null);
                if ((int)this.estado == 2)
                {
                    
                    PaqueteDAO.Insertar(this);
                    break;
                }
            }
            
        }
        /// <summary>
        /// Retornara los datos del paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento) 
        {
            Paquete p = (Paquete)elemento;
            return string.Format("{0} para {1}", p.trackingID, p.direccionEntrega);
            
        }
        /// <summary>
        /// Retorna los datos del paquete mediante el uso del metodo MostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region OPERADORES
        /// <summary>
        /// verifica si los 2 paquetes tienen la misma trackingID
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns> TRUE son iguales
        ///           FALSE no son iguales </returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool validar = false;
            if(!Object.Equals(p1,null) && !Object.Equals(p2,null))
            {
                if(p1.trackingID==p2.trackingID)
                {
                    validar = true;
                }
            }
            return validar;
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            
            return !(p1==p2);
        }
        #endregion

        #region CONSTRUCTOR
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.estado = EEstado.Ingresado;
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }
        #endregion

        public delegate void DelegadoEstado(object sender, EventArgs e);

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

    }
}

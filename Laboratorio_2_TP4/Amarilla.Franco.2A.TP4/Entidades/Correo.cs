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
        #region ATRIBUTOS
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region PROPIEDAD
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }
        #endregion

        #region CONSTRUCTOR
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }
        #endregion

        #region METODOS

        /// <summary>
        /// Cierra todos los hilos
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread t in this.mockPaquetes)
            {
                t.Abort();
            }
        }
        /// <summary>
        /// Retornara todos los paquetes del correo
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            
            Correo c = (Correo)elemento;
            StringBuilder datos = new StringBuilder();
            foreach(Paquete p in c.Paquetes)
            {
                datos.AppendLine(string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString()));
            }
            return datos.ToString();
            
        }
        #endregion

        #region OPERADOR
        /// <summary>
        /// Agrega un paquete al correo
        /// verificando que el paquete no este en el correo,
        /// caso contrario lanzara una excepcion (TrackingIdRepetidoException)
        /// Si el paquete es agregado se creara un hilo para el metodo MockCicloDeVida y se agrega
        /// dicho hilo a mockPaquetes despues se ejecuta el hilo.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns> Retornara el correo que recibe como parametro </returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            bool validar = false;
            foreach(Paquete aux in c.paquetes)
            {
                if(aux==p)
                {
                    validar = true;
                }
            }
            if(validar)
            {
                throw new TrackingIdRepetidoException("El Tracking ID "+p.TrackingID+" ya figura en la lista de envios");
            }
            c.paquetes.Add(p);

            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();
            
            return c;
        }
        #endregion
    }
}

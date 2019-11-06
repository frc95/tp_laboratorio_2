using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// Hereda la clase universitario
    /// </summary>
    public sealed class Profesor : Universitario
    {
        #region ATRIBUTOS
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region METODOS
        /// <summary>
        /// Se asignan dos clases al azar al profesor
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
        }
        /// <summary>
        /// Sobreescribe el método MostrarDatos con todos los datos del profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.Append(base.MostrarDatos());
            datos.AppendLine(this.ParticiparEnClase());
            return datos.ToString();
        }

        /// <summary>
        /// Retornará el nombre de la clases que da.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder datos = new StringBuilder();
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                datos.Append(clase + "\n");
            }
            return "CLASES DEL DIA: \n" + datos.ToString();
        }

        /// <summary>
        /// Retornara todos los datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region OPERADORES
        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool validar = false;
            if(!Object.Equals(i,null))
            {
                foreach(Universidad.EClases auxClase in i.clasesDelDia)
                {
                    if(auxClase==clase)
                    {
                        validar = true;
                        break;
                    }
                }
            }
            return validar;
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        { 
            return !(i==clase);
        }
        #endregion

        #region CONSTRUCTORES
        public Profesor() : base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        static Profesor()
        {
            Profesor.random = new Random();
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
           :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion
       
    }
}

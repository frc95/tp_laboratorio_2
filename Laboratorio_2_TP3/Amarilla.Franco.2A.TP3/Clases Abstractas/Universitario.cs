using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    /// <summary>
    /// La clase Universitario no deberá permitir que se instancien elementos de este tipo.
    /// Hereda la clase Persona
    /// </summary>
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region METODOS
        /// <summary>
        /// Valida si el objeto es de tipo Universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns> True si es Universitario, False no es universitario </returns>
        public override bool Equals(object obj)
        {
            bool validar = false;
            
            if(obj is Universitario)
            {
                validar = true;
            }
            return validar;
        }

        /// <summary>
        /// Retorna los datos del universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.Append(base.ToString());
            datos.AppendFormat("LEGAJO: {0}\n", this.legajo);
            return datos.ToString();
        }
        protected abstract string ParticiparEnClase();
        #endregion

        #region OPERADORES
        /// <summary>
        /// Valida si los 2 universitarios son del tipo Universitario y si tienen el mismo DNI o legajo
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns> True si tienen el mismo legajo o DNI , False sus legajos o DNI no son iguales
        /// o no son de tipo universitario</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool validar = false;
            if(!Object.Equals(pg1,null) && !Object.Equals(pg2, null))
            {
                
                if(pg1.Equals(pg2)  && pg2.Equals(pg1))
                {
                    if( (pg1.DNI==pg2.DNI) || (pg1.legajo==pg2.legajo) )
                    {
                        validar = true;
                    }
                }
            }
            return validar;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            
            return !(pg1==pg2);
        }
        #endregion

        #region CONSTRUCTORES
        public Universitario():base()
        {
            this.legajo = 0;
        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):
            base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion
    }
}

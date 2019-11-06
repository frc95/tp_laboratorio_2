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
    /// Hereda la clase Universitario
    /// </summary>
    public sealed class Alumno : Universitario
           
    {
        #region ATRIBUTOS
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region CONSTRUCTORES
        public Alumno():base()
        {
            this.claseQueToma = 0;
            this.estadoCuenta = 0;
        }
        public Alumno
            (int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad) 
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = 0;
        }

        public Alumno
            (int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad,claseQueToma)
        {
            
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region OPERADORES
        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool validar = false;
            if(!Object.Equals(a,null))
            {
                if(clase == a.claseQueToma && a.estadoCuenta!=EEstadoCuenta.Deudor)
                {
                    validar = true;
                }
            }
            return validar;
        }
        
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            
            return !(a==clase);
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Sobreescribe el metodo con todos los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.Append(base.MostrarDatos());
            datos.AppendLine(this.ParticiparEnClase());
            datos.AppendFormat("Estado de cuenta: {0}\n", this.estadoCuenta);
            return datos.ToString();

        }

        /// <summary>
        /// Retorna la clase que toma el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE "+this.claseQueToma;
        }

        /// <summary>
        /// Retornara todos los datos del alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
    }
}

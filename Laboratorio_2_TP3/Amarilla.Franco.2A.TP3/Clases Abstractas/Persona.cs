using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    /// <summary>
    /// La clase Persona no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Persona
    {
        #region ATRIBUTOS
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// En caso de escritura se validara el apellido.
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = this.ValidarNombreApellido(value); }
        }
        /// <summary>
        /// En caso de escritura se validara el DNI.
        /// </summary>
        public int DNI
        {
            get { return this.dni; }
            set { this.dni = this.ValidarDni(this.Nacionalidad,value); }
        }
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }
        /// <summary>
        /// En caso de escritura se validara el nombre.
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = this.ValidarNombreApellido(value); }
        }
        /// <summary>
        /// En caso de escritura se validara el DNI.
        /// </summary>
        public string StringToDNI
        {
            set { this.DNI = this.ValidarDni(this.Nacionalidad,value); }
        }
        #endregion

        #region CONSTRUCTORES
        public Persona()
        {
            this.Nombre = "";
            this.Apellido = "";
            this.Nacionalidad = 0;
            this.DNI = 0;
        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad):this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.StringToDNI = dni;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Retorna los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine("NOMBRE COMPLETO: " + this.Apellido+", " + this.Nombre);
            datos.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);
            datos.AppendFormat("DNI: {0}\n", this.DNI);
            return datos.ToString();
        }

        /// <summary>
        /// Valida si el DNI es el correcto teniendo en cuenta la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns> Retornara el DNI si se valido correctamente, caso contrario lanzara una excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {

            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
            {
                return dato;
            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {
                return dato;
            }
            else
            {
                throw  new NacionalidadInvalidaException();               
            }
        }

        /// <summary>
        /// Valida si el DNI tiene el formato correcto (numero de caracteres, letras, etc)
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns> Retornara el DNI si se valido correctamente, caso Contrario lanzara una excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            
           
            if ((nacionalidad == ENacionalidad.Extranjero || nacionalidad == ENacionalidad.Argentino) && dato.Length < 9 && true == Int32.TryParse(dato, out dni))
            {
                return dni;
                    
            }
            else
            {
                throw new DniInvalidoException();
            }
            


        }

        /// <summary>
        /// Valida el nombre o el apellido (Si contiene numeros o otros caracteres que no sean letras)
        /// </summary>
        /// <param name="dato"></param>
        /// <returns> Retornara el nombre o apellido, caso contrario nada</returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach(char letra in dato)
            {
                if(!char.IsLetter(letra))
                {
                    dato = "";
                    break;
                }
            }
            return dato;
        }
        #endregion

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}

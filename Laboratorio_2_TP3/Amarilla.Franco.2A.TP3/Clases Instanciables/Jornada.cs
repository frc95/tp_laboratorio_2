using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region ATRIBUTOS

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region PROPIEDADES

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        #endregion

        #region CONSTRUCTORES
        public Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.Clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region METODOS

        /// <summary>
        /// Guardara los datos en un archivo de texto
        /// La ruta es: Laboratorio_2_TP3\Amarilla.Franco.2A.TP3\Test\bin\Debug\Jornada.txt
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns> True OK, False lanzara excepcion </returns>
        public static bool Guardar(Jornada jornada)
        {
            bool validar = false;
            Texto t = new Texto();
            try
            {
                if (t.Guardar("Jornada.txt", jornada.ToString()))
                {
                    validar = true;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return validar;
        }

        /// <summary>
        /// Retornara los datos como texto
        /// La ruta es: Laboratorio_2_TP3\Amarilla.Franco.2A.TP3\Test\bin\Debug\Jornada.txt
        /// </summary>
        /// <returns> Si no hubo ningun problema retornara los datos, caso contrario lanzara excepcion</returns>
        public static string Leer()
        {
            Texto t = new Texto();

            string datos="";

            try
            {
                if (t.Leer("Jornada.txt", out datos))
                {
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return datos;
        }

        /// <summary>
        /// Mostrara todos los datos de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.Append("CLASE DE " + Clase.ToString() + " POR ");
            datos.AppendLine(this.Instructor.ToString());
            datos.AppendLine("ALUMNOS: ");

            foreach (Alumno auxAlumno in this.Alumnos)
            {
                datos.AppendLine(auxAlumno.ToString());
            }

            datos.AppendLine("<-------------------------------------->");

            return datos.ToString();
        }
        #endregion

        #region OPERADORES
        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool validar = false;
            if(!Object.Equals(j,null) && !Object.Equals(a, null))
            {
               
                    foreach (Alumno auxAlumno in j.Alumnos)
                    {
                        if (auxAlumno == a)
                        {
                            
                                validar = true;
                                break;

                        }
                    }
                
            }
            return validar;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j==a);
        }
        /// <summary>
        /// Agregarara Alumnos a la clase validando que no estén previamente cargados
        /// y si la EClase del alumno es igual a la EClase de jornada 
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns> Retorna la jornada </returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j!=a && a==j.Clase)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
        #endregion


        
    }
}

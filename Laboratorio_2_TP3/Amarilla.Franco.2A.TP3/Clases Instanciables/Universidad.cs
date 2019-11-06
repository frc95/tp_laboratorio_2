using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region ATRIBUTOS
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region PROPIEDADES

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        public Jornada this[int i]
        {
            get { return this.Jornadas[i]; }
            set { this.Jornadas[i] = value; }

        }
        #endregion

        #region METODOS
        /// <summary>
        /// Serializa los datos de la Universidad en un XML,
        /// incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
        /// La ruta es: Laboratorio_2_TP3\Amarilla.Franco.2A.TP3\Test\bin\Debug\Universidad.xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns> True Ok, caso contrario lanzara una excepcion</returns>
        public static bool Guardar(Universidad uni)
        {
            bool validar = false;
            Xml<Universidad> serie = new Xml<Universidad>();
            try
            {
                if (serie.Guardar("Universidad.xml", uni))
                {
                    validar = true;
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
            return validar;
        }
        /// <summary>
        /// Retornará una Universidad con todos los datos previamente serializados.
        /// La ruta es: Laboratorio_2_TP3\Amarilla.Franco.2A.TP3\Test\bin\Debug\Universidad.xml
        /// </summary>
        /// <returns> Retornara universidad, caso contrario lanzara una excepcion</returns>
        public Universidad Leer()
        {
            Universidad uni;
            Xml<Universidad> serie = new Xml<Universidad>();
            try
            {
                if(!serie.Leer("Universidad.xml", out uni))
                {
                    throw new Exception();
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return uni;
        }

        /// <summary>
        /// Retornara todos los datos de la universidad para que despues sea usado en el ToString
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine("JORNADA: ");
            foreach(Jornada aux in uni.Jornadas)
            {
                datos.AppendLine(aux.ToString());

            }
            
            return datos.ToString();
        }

        /// <summary>
        /// Retornara los datos de universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion

        #region OPERADORES

        /// <summary>
        /// Una Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool validar = false;
            if(!Object.Equals(g,null) && !Object.Equals(a, null))
            {
                foreach (Alumno aux in g.Alumnos)
                {
                    if (aux == a)
                    {
                        validar = true;
                        break;
                    }
                }
            }
            
            return validar;
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g==a);
        }
        /// <summary>
        /// Se agregarán Alumnos, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns> Retornara la universidad, caso contrario lanzara una excepcion</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u!=a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }
        /// <summary>
        /// Una Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool validar = false;
            if(!Object.Equals(g,null) && !Object.Equals(i,null))
            {
                foreach(Profesor aux in g.Instructores)
                {
                    if(aux==i)
                    {
                        validar = true;
                    }
                }
            }
            return validar;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {      
            return !(g==i);
        }

        /// <summary>
        /// Se agregarán Profesores, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(u!=i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }

        /// <summary>
        /// La igualación entre una Universidad y una Clase
        /// retornará el primer Profesor capaz de dar esa clase. Sino,
        /// lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns> Retornara el profesor, caso contrario lanzara una excepcion</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor aux=null;
            foreach(Profesor p in u.Instructores)
            {
                if(p==clase)
                {   
                    aux = p;                    
                    break;                   
                }

            }
            if(Object.Equals(aux,null))
            {
                throw new SinProfesorException();
            }
            
            return aux;
        }
        /// <summary>
        /// La desigualdad retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor aux=null;
            foreach (Profesor p in u.Instructores)
            {
                if (p != clase)
                {
                    aux = p;
                    break;
                }
            }
          
            return aux;
        }
        /// <summary>
        /// Genera y agrega una nueva Jornada a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns> Retornara la universidad</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor aux = (g == clase);
            Jornada nuevaJornada = new Jornada(clase,aux);
            foreach(Alumno a in g.Alumnos)
            {
                nuevaJornada += a;
            }
            g.Jornadas.Add(nuevaJornada);
            return g;
        }
        #endregion
        
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}

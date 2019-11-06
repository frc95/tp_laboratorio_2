using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Archivos
{
    /// <summary>
    /// Xml sera una clase generica que implementara la interfaz siendo T cualquier tipo de dato
    /// Para que despues los datos sean serializados o deserializados.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializara los datos a formato XML
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns> True los datos fueron serializados correctamente, False no se encontro la ruta </returns>
        public bool Guardar(string archivo, T datos)
        {
            bool validar = false;
            if (File.Exists(archivo))
            {
                StreamWriter write = new StreamWriter(archivo);
                XmlSerializer serie = new XmlSerializer(typeof(T));
                serie.Serialize(write, datos);
                write.Close();
                validar = true;
            }
            return validar;
        }

        /// <summary>
        /// Deserializara los datos
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns> True los datos fueron deserializados, False no se encontro la ruta</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool validar = false;


            datos = default(T);
            if (File.Exists(archivo))
            {
                StreamReader read = new StreamReader(archivo);
                XmlSerializer serie = new XmlSerializer(typeof(T));

                datos = (T)serie.Deserialize(read);
                
                validar = true;
                read.Close();
            }
            return validar;
        }
    }
}

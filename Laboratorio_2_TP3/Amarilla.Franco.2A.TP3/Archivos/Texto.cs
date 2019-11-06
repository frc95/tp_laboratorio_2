using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Archivos
{
    /// <summary>
    /// Texto implementara la interfaz para el manejo de archivos siendo T un string
    /// para que guarde o lea los datos en formato de texto
    /// </summary>
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Recibira la ruta y los datos para guardarlos en un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns> True se guardo correctamente, False no encontro la ruta </returns>
        public bool Guardar(string archivo, string datos)
        {
            bool validar = false;
            
            if (File.Exists(archivo))
            {
                StreamWriter escrbir = new StreamWriter(archivo);
                escrbir.WriteLine(datos);
                escrbir.Close();
                validar = true;
            }
            return validar;
        }
        /// <summary>
        /// Leera un archivo de texto para que despues sea guardado en una variable (out string datos)
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns> True El archivo fue leido correctamente, False no encontro la ruta </returns>
        public bool Leer(string archivo, out string datos)
        {
            bool validar = false;

            datos = null;
            if(File.Exists(archivo))
            {
                StreamReader leer = new StreamReader(archivo);
                
                datos = leer.ReadToEnd();

                leer.Close();
                validar = true;
            }
            

            return validar;
        }
    }
}

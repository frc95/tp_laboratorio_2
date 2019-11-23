using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guarda un archivo de texto en el escritorio de la maquina
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns> TRUE si el archivo existe se agregara informacion
        ///           FALSE El archivo se crea por primera vez </returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool validar = false;


            StringBuilder path = new StringBuilder();
            path.Append(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            path.Append(@"\" + archivo);



            if (File.Exists(path.ToString()))
            {
                TextWriter agregar = File.AppendText(path.ToString());
                agregar.WriteLine(texto);
                agregar.Close();


                validar = true;
            }
            else
            {
                TextWriter write = new StreamWriter(path.ToString());
                write.WriteLine(texto);
                write.Close();
            }

            return validar;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        public static event DelegadoException lanzarException;
        public delegate void DelegadoException(Exception e);

        /// <summary>
        /// Guardar los datos de un paquete en la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns> TRUE Los datos fueron guardados sin problema.
        ///           Caso contrario puede lanzar una excepcion si hubo algun tipo de problema
        ///           a la hora de querer guardar los datos. 
        ///           Se usara un evento para llevarlo al formulario</returns>
        public static bool Insertar(Paquete p)
        {
            bool validar = false;
            try
            {
                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO Paquetes(direccionEntrega, trackingID, alumno) " +
                                      "VALUES(@direccionEntrega, @trackingID, @alumno)";

                comando.Parameters.Clear();

                comando.Parameters.AddWithValue("@direccionEntrega", p.DireccionEntrega);
                comando.Parameters.AddWithValue("@trackingID", p.TrackingID);
                comando.Parameters.AddWithValue("@alumno", "Franco");

                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();

                validar = true;
            }
            catch(Exception e)
            {
                PaqueteDAO.lanzarException(e);
            }
            
            return validar;
        }

        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.connect);
            PaqueteDAO.comando = new SqlCommand();
        }
    }
}

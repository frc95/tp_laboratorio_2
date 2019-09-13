using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase estatica Calculadora
    /// Validara el operador y realizara operaciones entre ambos numeros
    /// </summary>
    public static class Calculadora
    {
        //METODOS

        /// <summary>
        /// Recibe un operador y lo valida si es +,-,* o / , caso contrario retornara un +
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>  operador </returns>
        private static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            else
            {
                operador = "+";
            }
            return operador;
        }
        /// <summary>
        /// Valida y realiza la operacion entre ambos numeros
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>  total </returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double total = 0;
            operador = Calculadora.ValidarOperador(operador);
            if (operador == "+")
            {
                total = num1 + num2;
            }
            else if (operador == "-")
            {
                total = num1 - num2;
            }
            else if (operador == "*")
            {
                total = num1 * num2;
            }
            else if (operador == "/")
            {
                total = num1 / num2;
            }
            return total;
        }
    }
}

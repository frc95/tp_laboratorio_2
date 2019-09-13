using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase numero
    /// Tendra constructores para inicializar el atributo numero.
    /// Habra metodos que validen el numero,  conversion de binario a decimal y decimal a bionario.
    /// Operadores que facilitaran la operacion entre 2 numeros.
    /// </summary>
    public class Numero
    {
        //ATRIBUTOS

        private double numero;

        //CONSTRUCTORES

        /// <summary>
        /// Constructor que inicializara el atributo numero en 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor que inicializara el atributo numero dependiendo de lo que reciba como parametro 
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor que inicializara el atributo numero dependiendo de lo que reciba como parametro 
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
            
        }

        // PROPIEDAD

        /// <summary>
        /// Propiedad que inicializa el atributo numero
        /// con el valor que retornara el metodo ValidarNumero.
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        //METODOS

        /// <summary>
        /// Valida si es un numero lo que recibe como parametro.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns> El mismo numero que recibe como parametro, caso contrario 0 </returns>
        private double ValidarNumero(string strNumero)
        {
            double valor;
            bool validar = false;
            validar = double.TryParse(strNumero, out valor);
            if (validar)
            {
                return valor;
            }
            valor = 0;
            return valor;
        }

        

        /// <summary>
        /// Convierte en binario a decimal validando si la cadena de caracteres son ceros y unos
        /// </summary>
        /// <param name="binario"></param>
        /// <returns> "Valor invalido" si la cadena no esta compuesta por ceros y unos 
        ///           Caso contrario el resultado decimal </returns>
        public string BinarioDecimal(string binario)
        {
            double total = 0;
            int n;
            bool validar = true;
            string resultado = "";
            foreach (char caracter in binario)
            {
                if (caracter != '0' && caracter != '1')
                {
                    resultado = "Valor inválido";
                    validar = false;
                    break;
                }
            }
            if (validar == true)
            {
                for (int i = binario.Length; i > 0; i--)
                {
                    n = (int)char.GetNumericValue(binario[i - 1]);

                    total = (n * Math.Pow(2, (binario.Length - i))) + total;
                }
                resultado = Convert.ToString(total);

            }

            return resultado;
        }
        /// <summary>
        /// Convierte en decimal a binario 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns> El resultado en binario </returns>
        public string DecimalBinario(double numero)
        {
            string binario = "";

            while (numero > 0)
            {
                if (numero % 2 == 0)
                {
                    binario = "0" + binario;
                }
                else
                {
                    binario = "1" + binario;
                }
                numero = (int)(numero / 2);
            }

            return binario;
        }
        /// <summary>
        /// Convierte en decimal a binario validando que el numero que recibe sea entero positivo.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns> "Valor invalido" si el numero que recibio no es entero positivo.
        ///           Caso contrario el resultado en binario </returns>
        public string DecimalBinario(string numero)
        {
            string binario = "";
            bool validar = Int32.TryParse(numero, out int entero);
            if (validar == true && entero > 0)
            {
                binario = DecimalBinario(Convert.ToDouble(entero));
            }
            else
            {
                binario = "Valor inválido";
            }


            return binario;
        }

        //OPERADORES

        /// <summary>
        /// Realiza la suma entre 2 numeros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns> El resultado </returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double total;

            total = n1.numero + n2.numero;
            return total;
        }
        /// <summary>
        /// Realiza la resta entre 2 numeros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns> El resultado </returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double total;
            total = n1.numero - n2.numero;
            return total;
        }
        /// <summary>
        /// Realiza la multiplicacion entre 2 numeros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns> El resultado </returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double total;
            total = n1.numero * n2.numero;
            return total;
        }
        /// <summary>
        /// Realiza la division entre 2 numeros validando si n2 es 0
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns> El resultado si esta ok
        ///           Caso contrario double.MinValue </returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double total;
            if (n2.numero != 0)
            {
                total = n1.numero / n2.numero;
            }
            else
            {
                total = double.MinValue;
            }
            return total;
        }

    }
}

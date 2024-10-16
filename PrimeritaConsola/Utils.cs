using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeritaConsola
{
    public static class Utils
    {
        /// <summary>
        /// Metodo que devuelve una lista de arrays dado un string
        /// </summary>
        /// <param name="datosTriangulo"></param>
        /// <returns></returns>
        public static List<int> GetListNumbersFromString(string? datosTriangulo)
        {
            string[] splittedDatosTriangulo = datosTriangulo?.Split(",") ?? [];

            List<int> splittedDatosIntTriangulo = new List<int>();
            foreach (string dato in splittedDatosTriangulo)
            {
                if (!int.TryParse(dato, out int val))
                {
                    return [];
                }
                splittedDatosIntTriangulo.Add(val);
            }
            return splittedDatosIntTriangulo;
        }
        /// <summary>
        /// Comprueba que un numero sea primo
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsNumberPrime(int val)
        {
            for (int i = 2; i < val; i++)
            {
                if (val % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Devuelve un numero obtenido por consola
        /// </summary>
        /// <returns></returns>
        public static int GetNumeroPorConsola()
        {
            Console.WriteLine("Escribe un número por consola");
            string? edad = Console.ReadLine();
            if (!int.TryParse(edad, out int val))
            {
                Console.WriteLine("No has introducido un número");
                return 0;
            }
            return val;
        }

    }
}

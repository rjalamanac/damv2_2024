using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeritaConsola
{
    internal class EjercicioPrimo : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Hello, World!, write your age");
            string? edad = Console.ReadLine();
            if (!int.TryParse(edad, out int val))
            {
                Console.WriteLine("No has introducido un número");
                return;
            }

            if (Utils.IsNumberPrime(val))
            {
                Console.WriteLine($"El número {val} es primo");
            }
            else
            {
                Console.WriteLine($"El número {val} no es primo");
            }
        }
    }
}

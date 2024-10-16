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
            int val = Utils.GetNumeroPorConsola();
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

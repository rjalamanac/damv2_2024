using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeritaConsola
{
    internal class EjercicioArrayPrimos : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Introduce un array separado por comas");
            string? datosTriangulo = Console.ReadLine();
            List<int> splittedDatosIntTriangulo = Utils.GetListNumbersFromString(datosTriangulo);
            List<int> arraysNumerosPrimos = new List<int>();
            foreach (var element in splittedDatosIntTriangulo)
            {
                if (Utils.IsNumberPrime(element))
                {
                    arraysNumerosPrimos.Add(element);
                }
            }
            string resultado = string.Empty;
            arraysNumerosPrimos.ForEach(arr => resultado = resultado + arr + ",");
            resultado= resultado.TrimEnd(',');
            Console.WriteLine(resultado); 
        }  
    }
}

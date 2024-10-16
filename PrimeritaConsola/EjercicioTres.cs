using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeritaConsola
{
    internal class EjercicioTres : IEjecutarEjercicio
    {
        /*Haz una función que como parámetro reciba un array de números y
        obtenga el número que menos repeticiones haya tenido. En caso de
        empate devuelve el número más pequeño.
        */
        public void Ejecutar()
        {
            Console.WriteLine("Introduce un array separado por comas");
            string? datosArray = Console.ReadLine();

            List<int> splittedDatos = Utils.GetListNumbersFromString(datosArray);

            Dictionary<int, int> diccionarioRepeticiones = new Dictionary<int, int>();

            foreach (int i in splittedDatos)
            {
                if (diccionarioRepeticiones.ContainsKey(i))
                {
                    diccionarioRepeticiones[i] += 1;
                }
                else
                {
                    diccionarioRepeticiones.Add(i, 1);
                }
            }
            int valueDiccionarioMenorValor = int.MaxValue;

            foreach (var element in diccionarioRepeticiones)
            {
                if (element.Value< valueDiccionarioMenorValor)
                {
                    valueDiccionarioMenorValor = element.Value;
                }
            }

            int smallestValueWithLessRepittions = int.MaxValue;
            foreach (var element in diccionarioRepeticiones)
            {
                if (element.Value == valueDiccionarioMenorValor && element.Key< smallestValueWithLessRepittions)
                {
                    smallestValueWithLessRepittions = element.Key;
                }
            }

            Console.WriteLine($"El número que se repite menos veces es {smallestValueWithLessRepittions} " +
                $"con {valueDiccionarioMenorValor} repeticiones");
        }
    }
}

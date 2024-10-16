using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeritaConsola
{
    internal class EjercicioTriangulo : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Introduce 3 dígitos separados con comas");
            string? datosTriangulo = Console.ReadLine();

            List<int> splittedDatosIntTriangulo = Utils.GetListNumbersFromString(datosTriangulo);
           
            if (splittedDatosIntTriangulo.Count !=3) {
                Console.WriteLine("Tienes que introducir 3 dígitos separados con comas");
                return;
            }
            if (splittedDatosIntTriangulo.Min() == splittedDatosIntTriangulo.Max())
            {
                Console.WriteLine("Es equilatero");
                return;
            }

            if (splittedDatosIntTriangulo.First() == splittedDatosIntTriangulo.Last() 
                || splittedDatosIntTriangulo.First() == splittedDatosIntTriangulo.Skip(1).First()
                || splittedDatosIntTriangulo.Skip(1).First() == splittedDatosIntTriangulo.Last())
            {
                Console.WriteLine("Es isósceles");
                return;
            }

            Console.WriteLine("Es escaleno");

        }
    }
}

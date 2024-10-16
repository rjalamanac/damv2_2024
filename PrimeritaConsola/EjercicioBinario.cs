using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeritaConsola
{
    internal class EjercicioBinario : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            int val=Utils.GetNumeroPorConsola();

            string resultado = string.Empty;
            while (val != 1 && val!=0)
            {
                resultado += val % 2;
                val = val /2;
            }
            resultado += val;

            resultado = new string(resultado.Reverse().ToArray());
            Console.WriteLine(resultado);
        }

       
    }
}

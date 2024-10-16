using PrimeritaConsola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeritaConsola
{
    internal class EjercicioSingleton : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            var libreria=LibrarySingleton.GetInstance();

            var libreriaDos= LibrarySingleton.GetInstance();
        }
    }
}

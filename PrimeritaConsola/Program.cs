namespace PrimeritaConsola
{
    public class Program
    {
        public static void Main()
        {
           IEjecutarEjercicio ejercicio;

           ejercicio= new EjercicioSingleton();
           ejercicio.Ejecutar();

        }
    }

}


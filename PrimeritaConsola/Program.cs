namespace PrimeritaConsola
{
    public class Program
    {
        public static void Main()
        {
            IEjecutarEjercicio ejercicio;

            ejercicio = new EjercicioPrimo();
            ejercicio.Ejecutar();

            ejercicio = new EjercicioTriangulo();
            ejercicio.Ejecutar();

        }
    }

}


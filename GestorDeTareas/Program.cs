using GestorDeTareas.Interfaces;
using GestorDeTareas.Services;

namespace GestorDeTareas
{
    public class Program
    {
        public  static void Main()
        {
            IMenuPrinterService menuPrinterService = new MenuPrinterService();
            IMenuUserService userService = new MenuUserService();
            IGestorTareas tareas= new GestorTareas();
            IGestorOpciones gestorOpciones = new GestorOpciones(tareas);
            int? resultado=null;
            do
            {
                menuPrinterService.MostrarMenu();
                resultado = userService.ObtenerOpciónCliente();

            } while (resultado==null);

            switch (resultado)
            {
                case 1:
                    menuPrinterService.MostrarLista(gestorOpciones.ListarTareas());
                    break;
                case 2:
                    menuPrinterService.MostrarLista(gestorOpciones.ListarTareasIncompletas());
                    break;
                case 3:
                    menuPrinterService.MostrarLista(gestorOpciones.ListarTareasPorFechaVencimiento());
                    break;
                case 4:
                    gestorOpciones.AgregarTarea(userService.ObtenerDatosTarea());
                    break;
                case 5:
                    gestorOpciones.CompletarTarea(userService.ObtenerIdtarea());
                    break;
                case 6:
                    gestorOpciones.GuardarTareasEnArchivo();
                    break;
            }

        }

    }

}
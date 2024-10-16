using GestorDeTareas.Interfaces;
using GestorDeTareas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas.Services
{
    internal  class MenuPrinterService : IMenuPrinterService
    {
        public  void MostrarMenu()
        {
            Console.WriteLine($"     ________________________________________________________{Environment.NewLine}   " +
               $" | Aplicación de Gestión de Tareas                        |{Environment.NewLine}    " +
                $"|________________________________________________________|{Environment.NewLine}    " +
                $"Selecciona una opción:{Environment.NewLine}   " +
                $" 1. Listar todas las tareas{Environment.NewLine}   " +
                $" 2. Listar tareas incompletas{Environment.NewLine}    " +
                $"3. Listar tareas por fecha de vencimiento{Environment.NewLine}    " +
                $"4. Agregar nueva tarea{Environment.NewLine}    " +
                $"5. Marcar tarea como completada{Environment.NewLine}    " +
               $"6. Guardar tareas en archivo{Environment.NewLine}    " +
                $"7. Cargar tareas desde archivo{Environment.NewLine}   " +
                " 8. Salir");
        }

        public void MostrarLista(List<Tarea> tareas)
        {
            tareas.ForEach(tarea => Console.WriteLine(tarea));
        }


    }
}

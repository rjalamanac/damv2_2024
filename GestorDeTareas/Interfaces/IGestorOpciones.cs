using GestorDeTareas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas.Interfaces
{
    /*
     * Listar todas las tareas
2. Listar tareas incompletas
3. Listar tareas por fecha de vencimiento
4. Agregar nueva tarea
5. Marcar tarea como completada
6. Guardar tareas en archivo
7. Cargar tareas desde archivo
8. Salir*/

    internal interface IGestorOpciones
    {
        public List<Tarea> ListarTareas();
        public List<Tarea> ListarTareasIncompletas();
        public List<Tarea> ListarTareasPorFechaVencimiento();
        public Tarea AgregarTarea(Tarea tarea);
        public bool CompletarTarea(Guid idTarea);
        public Task<bool> GuardarTareasEnArchivo();
        public Task CargarTareasDesdeArchivo();

    }
}

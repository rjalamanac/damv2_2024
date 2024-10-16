using GestorDeTareas.Interfaces;
using GestorDeTareas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestorDeTareas.Services
{
    internal class GestorOpciones : IGestorOpciones
    {

        private const string FILE_NAME = "Tareas.json";

        private readonly IGestorTareas _gestorTareas;
        public GestorOpciones(IGestorTareas gestorTareas)
        {
            _gestorTareas = gestorTareas;
        }
        public Tarea AgregarTarea(Tarea tarea)
        {
            return _gestorTareas.Add(tarea);
        }
        
        public bool CompletarTarea(Guid idTarea)
        {
            Tarea? tarea= _gestorTareas.Get(idTarea);
            if (tarea == null)
            {
                return false;
            }
            tarea.Completado = true;
            return true;
        }

        public async Task<bool> GuardarTareasEnArchivo()
        {
            return await Utils.FileUtils<List<Tarea>>.WriteFile(FILE_NAME, _gestorTareas.GetAll());
        }

        public async Task CargarTareasDesdeArchivo()
        {
            List<Tarea> tareas = await Utils.FileUtils<List<Tarea>>.ReadFile(FILE_NAME);
            _gestorTareas.Set(tareas);
        }


        public List<Tarea> ListarTareas()
        {
            return _gestorTareas.GetAll();
        }

        public List<Tarea> ListarTareasIncompletas()
        {
            return _gestorTareas.GetAll().Where(x=>!x.Completado).ToList();
        }

        public List<Tarea> ListarTareasPorFechaVencimiento()
        {
            return _gestorTareas.GetAll().OrderBy(x=>x.FechaVencimiento).ToList();

        }
    }
}

using GestorDeTareas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas.Models
{
    internal class ListaTareas : IGestorTareas
    {

        private static ListaTareas gestorTareas;
        private List<Tarea> tareas;
        private ListaTareas()
        {
            tareas= new List<Tarea>();
        }

        public static ListaTareas GetInstance()
        {
            if (gestorTareas == null)
            {
                gestorTareas = new ListaTareas();
            }
            return gestorTareas;
        }

        public Tarea Add(Tarea tarea)
        {
            if (tareas.Count>=100)
            {
                return null;
            }
            tarea.Id = Guid.NewGuid();
            tareas.Add(tarea);
            return tarea;
        }

        public Tarea? Get(Guid guid)
        {
            return tareas.FirstOrDefault(x => x.Id == guid);
        }

        public List<Tarea> GetAll()
        {
            return tareas;
        }

        public bool Remove(Tarea tarea)
        {
            return tareas.Remove(tarea);
        }

        public void Set(List<Tarea> tareas)
        {
            tareas.Clear();
            tareas.AddRange(tareas);
        }
    }
}

using GestorDeTareas.Interfaces;
using GestorDeTareas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestorDeTareas.Services
{
    internal class GestorTareas : IGestorTareas
    {
        public GestorTareas() { }

        public Tarea Add(Tarea tarea)
        {
            return ListaTareas.GetInstance().Add(tarea);
        }

        public bool Remove(Tarea tarea)
        {
            return ListaTareas.GetInstance().Remove(tarea);
        }

        public List<Tarea> GetAll()
        {
           return ListaTareas.GetInstance().GetAll();
        }

        public Tarea? Get(Guid guid)
        {
            return ListaTareas.GetInstance().Get(guid);
        }

        public void Set(List<Tarea> tareas)
        {
            ListaTareas.GetInstance().Set(tareas);
        }
    }
}

using GestorDeTareas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas.Interfaces
{
    internal interface IGestorTareas
    {
        public Tarea Add(Tarea tarea);
        public bool Remove(Tarea tarea);
        public List<Tarea> GetAll();
        public Tarea? Get(Guid guid);
        public void Set(List<Tarea> tareas);
    }
}

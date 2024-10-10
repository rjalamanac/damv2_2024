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
            throw new NotImplementedException();
        }

        public List<Tarea> GetAll()
        {
            throw new NotImplementedException();
        }

        public Tarea? Get(Guid guid)
        {
            return ListaTareas.GetInstance().Get(guid);
        }
    }
}

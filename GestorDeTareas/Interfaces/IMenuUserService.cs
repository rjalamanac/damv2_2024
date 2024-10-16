using GestorDeTareas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas.Interfaces
{
    internal interface IMenuUserService
    {
        public int? ObtenerOpciónCliente();
        public Tarea ObtenerDatosTarea();
        public Guid ObtenerIdtarea();

    }
}

using GestorDeTareas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas.Interfaces
{
    internal interface IMenuPrinterService
    {
        public void MostrarMenu();
        public void MostrarLista(List<Tarea> taresa);
    }
}

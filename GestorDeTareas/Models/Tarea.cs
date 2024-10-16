using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas.Models
{
    internal class Tarea
    {
        //Descripción, Fecha de Vencimiento, Estado de Completado, etc.
        public Guid Id { get; set; }  
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Completado { get; set; }

        public override string? ToString()
        {
            return $"Id: {Id} {Environment.NewLine} " +
                $"Descripcion: {Descripcion}{Environment.NewLine} " +
                $"FechaVencimiento: {FechaVencimiento}{Environment.NewLine} " +
                $"Completado: {Completado} ";
        }
    }
}

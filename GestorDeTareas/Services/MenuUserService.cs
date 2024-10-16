using GestorDeTareas.Interfaces;
using GestorDeTareas.Models;
using GestorDeTareas.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas.Services
{
    internal class MenuUserService : IMenuUserService
    {
        public Tarea ObtenerDatosTarea()
        {
            Tarea tarea = new Tarea();

            Console.WriteLine("Dime la descripción de la tarea");
            tarea.Descripcion = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Escribe fecha vecimiento en formato dd/MM/AAAA");
            string fechaVencimiento=Console.ReadLine() ?? string.Empty;
     
            //TODO Gestionar errores fecha
            int year= StringUtils.ConvertToNumber(fechaVencimiento.Split("/").Last()) ?? 0;
            int month = StringUtils.ConvertToNumber(fechaVencimiento.Split("/").Skip(1).First()) ?? 0;
            int day = StringUtils.ConvertToNumber(fechaVencimiento.Split("/").First()) ?? 0;

            tarea.FechaVencimiento = new DateTime(year, month, day);

            return tarea;

        }

        public Guid ObtenerIdtarea()
        {
            Guid result= Guid.Empty;
            bool datoCorrecto=false;
            do
            {
                Console.WriteLine("Dame el id de la tarea");
                string id = Console.ReadLine() ?? string.Empty;
                datoCorrecto=Guid.TryParse(id, out result);
                if (!datoCorrecto)
                {
                    LogService.WriteLog($"El usuario ha escrito un id incorrecto: {id}");
                }
            }while(!datoCorrecto);
            
            return result;
        }

        public int? ObtenerOpciónCliente()
        {
            int val= StringUtils.ConvertToNumber(Console.ReadLine() ?? string.Empty) ?? 0;
            if (val<1 || val>8)
            {
                LogService.WriteLog($"El usuario ha elegido una opcion incorrecta: {val}");
                return null;
            }
            return val;
        }
    }
}
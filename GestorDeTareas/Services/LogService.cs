using GestorDeTareas.Interfaces;
using GestorDeTareas.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas.Services
{
    internal static class LogService 
    {
        private const string LOG_PATH = "excepcion.txt";
        public static async Task WriteLog(string mensaje)
        {
             FileUtils<string>.WriteFile(LOG_PATH, mensaje);
        }

        public static async Task WriteLog(Exception ex)
        {
            FileUtils<Exception>.WriteFile(LOG_PATH, ex);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestorDeTareas.Utils
{
    class FileUtils<T>
    {
        public static async Task<bool> WriteFile(string path, T obj)
        {
            try
            {
                string listaSerializada = JsonSerializer.Serialize(obj);
                await File.WriteAllTextAsync(path, listaSerializada);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static async Task<T> ReadFile(string path)
            {
                try
                {
                    string contenidoArchivo = await File.ReadAllTextAsync(path);
                    return JsonSerializer.Deserialize<T>(contenidoArchivo);
                }
                catch (Exception ex)
                {

                }
                return default(T);
            }
        }
}

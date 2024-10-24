using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace CambioDivisa.Utils
{
    public static class FileUtils<T>
    {
        public static async Task<bool> OverWriteFile(string path, T obj)
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
        public static async Task<bool> AppendLineToFile(string path, T obj)
        {
            try
            {
                using (StreamWriter w = File.AppendText(path))
                {
                    string listaSerializada = JsonSerializer.Serialize(obj);
                    w.WriteLine(listaSerializada);
                }

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
                return default(T);
            }
        }

        public static async Task<IEnumerable<T>> ReadFileLineByLine(string path)
        {
            var result = new List<T>();
            try
            {
                string line;
                using (StreamReader reader = new StreamReader(path))
                {
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        result.Add(JsonSerializer.Deserialize<T>(line));
                    }
                }
                return result;

            }
            catch (Exception ex)
            {
                return result;
            }
        }
    }
}

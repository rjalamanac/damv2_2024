using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WPF_FirstAPP.Utils
{
    public static class HttpJsonClient<T>
    {
        public static async Task<T?> Get(string path)
        {
            try
            {
                using HttpClient httpClient = new HttpClient();
                {
                    HttpResponseMessage datos = await httpClient.GetAsync($"{Constants.BASE_URL}{path}");
                    string dataget = await datos.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(dataget);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default;
        }
    }
}

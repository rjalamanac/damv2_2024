using PokemonBackRules.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokemonBackRules.Utils
{
    public static class HttpJsonClient<T>
    {
        public static async Task<T?> Get(string url)
        {
            using HttpClient httpClient = new HttpClient();
            {
                HttpResponseMessage datos = await httpClient.GetAsync(url);
                string dataget = await datos.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(dataget);
            }
        }
    }
}

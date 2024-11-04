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
        public static T Get(string url)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage datos = await httpClient.GetAsync("https://pokeapi.co/api/v2/type/");
            string dataget = await datos.Content.ReadAsStringAsync();
            PokeTypesModel? nuestroModelo = JsonSerializer.Deserialize<T>(dataget);
        }
    }
}

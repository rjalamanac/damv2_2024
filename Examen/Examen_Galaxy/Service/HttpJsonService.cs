using Examen_Galaxy.Constants;
using Examen_Galaxy.Interface;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Examen_Galaxy.Service
{
    internal class HttpJsonService<T> : IHttpJsonProvider<T> where T : class
    {
        public async Task<IEnumerable<T>> GetAsync(string api_url)
        {
            try
            {
                using HttpClient httpClient = new HttpClient();
                {
                    HttpResponseMessage datos = await httpClient.GetAsync($"{Constantes.BASE_URL}{api_url}");
                    string dataget = await datos.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<T>>(dataget);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default;
        }

        public async Task<T> PostAsync(T data, string api_url)
        {
            try
            {
                using HttpClient httpClient = new HttpClient();
                {
                    HttpContent httpContent = new StringContent(JsonSerializer.Serialize(data));

                    HttpResponseMessage datos = await httpClient.PostAsync($"{Constantes.BASE_URL}{api_url}", httpContent);
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

        public async Task<bool> RemoveAsync(T data, string api_url,int id)
        {
            try
            {
                using HttpClient httpClient = new HttpClient();
                {
                    HttpResponseMessage datos = await httpClient.GetAsync($"{Constantes.BASE_URL}{api_url}/{id}");
                    string dataget = await datos.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<bool>(dataget);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}

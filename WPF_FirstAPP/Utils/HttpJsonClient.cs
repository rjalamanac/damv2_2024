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
        public static string Token = string.Empty;
        public static async Task<T?> Get(string path)
        {
            try
            {
                using HttpClient httpClient = new HttpClient();
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");
                    HttpResponseMessage request = await httpClient.GetAsync($"{Constants.BASE_URL}{path}");
                    if (request.StatusCode==System.Net.HttpStatusCode.Unauthorized)
                    {
                        HttpResponseMessage requestToken = await httpClient.GetAsync($"{Constants.BASE_URL}{Constants.LOGIN_PATH}/login");
                    }
                    string dataRequest = await request.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(dataRequest);
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

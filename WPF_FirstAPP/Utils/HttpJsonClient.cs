using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WPF_FirstAPP.DTO;

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
                        LoginDTO loginDTO = new LoginDTO
                        {
                            Password = "u76x&s~:vtDVX*[4%#",
                            UserName = "Bimba_Joga"
                        };
                        HttpContent httpContent = new StringContent(JsonSerializer.Serialize(loginDTO),  Encoding.UTF8, "application/json");

                        HttpResponseMessage requestToken = await httpClient.PostAsync($"{Constants.BASE_URL}{Constants.LOGIN_PATH}/login", httpContent);

                        string dataTokenRequest = await requestToken.Content.ReadAsStringAsync();
                        UserDTO tokenUser = JsonSerializer.Deserialize<UserDTO>(dataTokenRequest);

                        Token=tokenUser?.Result?.Token ??string.Empty;
                        httpClient.DefaultRequestHeaders.Remove("Authorization");
                        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");
                        request = await httpClient.GetAsync($"{Constants.BASE_URL}{path}");
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

using System;
using System.Collections.Generic;
using System.Text;
using AristovaHttp.Models;
using AristovaHttp.Services;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AristovaHttp.Services
{
    public class PlayerService
    {
        private readonly string _token;

        public PlayerService(string token)
        {
            _token = token ?? throw new ArgumentNullException(nameof(token));
        }

        public async Task Add(Player player)
        {
            string serializedPlayer = JsonConvert.SerializeObject(player);

            var content = new StringContent(serializedPlayer, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    AuthenticationHeaderValue.Parse(_token);

                var response = await client.PostAsync("http://dev.trainee.dex-it.ru/api/Player/Add", content);

                var json = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
            }
        }
        
        public async Task<PlayerResponse> GetPlayers()
        {
            HttpResponseMessage responseMessage;
            PlayerResponse playerResponse;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    AuthenticationHeaderValue.Parse(_token);

                responseMessage = await client.GetAsync("http://dev.trainee.dex-it.ru/api/Player/GetPlayers");

                responseMessage.EnsureSuccessStatusCode();

                string serializeMessage = await responseMessage.Content.ReadAsStringAsync();
                playerResponse = JsonConvert.DeserializeObject<PlayerResponse>(serializeMessage);
            }

            return playerResponse;
        }
    }
}

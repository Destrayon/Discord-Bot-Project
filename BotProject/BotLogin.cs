using BotProject.Inheritance;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BotProject
{
    public class BotLogin : Singleton
    {
        private readonly IConfiguration _configs;

        private readonly HttpClient _client;

        public BotLogin(IConfiguration configs, HttpClient client)
        {
            _configs = configs;
            _client = client;
        }

        public async Task LoginToBot()
        {
            string url = await GetGatewayUrl();

            _ = Task.Run(() => Receive(url));
        }

        private async Task Receive(string url)
        {
            using ClientWebSocket socket = new();

            await socket.ConnectAsync(new Uri(url), CancellationToken.None);

            byte[] bytes = new byte[1024];

            while (true)
            {
                var receive = await socket.ReceiveAsync(bytes, CancellationToken.None);

                string str = Encoding.UTF8.GetString(bytes.Take(receive.Count).ToArray());
            }
        }

        public async Task<HttpResponseMessage> GetGatewayResponseMessage()
        {
            return await _client.GetAsync("/api/gateway");
        }

        public async Task<string> GetGatewayUrl()
        {
            var response = await GetGatewayResponseMessage();

            using JsonDocument doc = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());

            JsonElement element = doc.RootElement;

            return element.GetProperty("url").GetString();
        }
    }
}

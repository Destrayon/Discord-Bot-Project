using BotProject.Inheritance;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotProject
{
    public class LoginHandler : Singleton
    {
        private readonly IConfiguration config;
        private readonly DiscordSocketClient client;

        public LoginHandler(IConfiguration config, DiscordSocketClient client)
        {
            this.config = config;
            this.client = client;
        }

        public async Task Login()
        {
            string token = config.GetValue<string>("Token");

            await client.LoginAsync(TokenType.Bot, token);

            await client.StartAsync();
        }
    }
}

using BotProject.Inheritance;
using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotProject
{
    public class Logger : Singleton
    {
        private readonly DiscordSocketClient client;

        public Logger(DiscordSocketClient client)
        {
            this.client = client;
        }
        public void Setup()
        {
            client.Log += LogClient;
        }

        private Task LogClient(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }
    }
}

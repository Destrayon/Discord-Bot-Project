using BotProject.Inheritance;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BotProject
{
    public class CommandHandler : Singleton
    {
        private readonly DiscordSocketClient client;
        private readonly IConfiguration config;
        private readonly CommandService cmd;
        private readonly IHost host;

        public CommandHandler(DiscordSocketClient client, IConfiguration config, CommandService cmd, IHost host)
        {
            this.client = client;
            this.config = config;
            this.cmd = cmd;
            this.host = host;
        }
        public async Task RegisterCommandAsync()
        {
            client.MessageReceived += HandleCommandAsync;
            await cmd.AddModulesAsync(Assembly.GetEntryAssembly(), host.Services);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(client, message);

            if (message.Author.IsBot) return;

            string prefix = config.GetValue<string>("Prefix");

            int argPos = 0;
            if (message.HasStringPrefix(prefix, ref argPos))
            {
                var result = await cmd.ExecuteAsync(context, argPos, host.Services);
                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
            }
        }
    }
}

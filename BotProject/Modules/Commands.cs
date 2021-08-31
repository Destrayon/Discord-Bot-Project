using BotProject.Inheritance;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotProject.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        private readonly DiscordSocketClient client;
        private readonly IConfiguration config;

        public Commands(DiscordSocketClient client, IConfiguration config)
        {
            this.client = client;
            this.config = config;
        }

        [Command("respond")]
        public async Task Ping()
        {
            await ReplyAsync("No.");
        }

        public async Task Testing(string message)
        {
            ulong channelId = config.GetValue<ulong>("ChannelId");
            await (client.GetChannel(channelId) as ISocketMessageChannel).SendMessageAsync(message);
        }
    }
}

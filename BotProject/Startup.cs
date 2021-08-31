using BotProject.Inheritance;
using BotProject.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BotProject
{
    public class Startup : IHostedService
    {
        private readonly LoginHandler login;
        private readonly Logger logger;
        private readonly CommandHandler commands;
        private readonly Commands cmds;

        public Startup(LoginHandler login, Logger logger, CommandHandler commands, Commands cmds)
        {
            this.login = login;
            this.logger = logger;
            this.commands = commands;
            this.cmds = cmds;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await commands.RegisterCommandAsync();
            logger.Setup();
            await login.Login();

            while (true)
            {
                string str = Console.ReadLine();
                await cmds.Testing(str);
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}

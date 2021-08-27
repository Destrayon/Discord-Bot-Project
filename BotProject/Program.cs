using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BotProject
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddHostedService<Startup>();
                    services.AddSingleton(service =>
                    {
                        HttpClient client = new();
                        client.BaseAddress = new Uri("https://discordapp.com");
                        return client;
                    });
                })
                .ConfigureHostConfiguration(host =>
                {
                    host.SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .AddSingletonClasses();
                
    }
}

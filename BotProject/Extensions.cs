using BotProject.Inheritance;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BotProject
{
    public static class Extensions
    {
        public static IHostBuilder AddSingletonClasses(this IHostBuilder builder)
        {
            IEnumerable<Type> types = Assembly.GetExecutingAssembly()
                                              .GetTypes()
                                              .Where(x => x.BaseType == typeof(Singleton) && !x.IsAbstract);

            builder.ConfigureServices(services =>
            {
                foreach (var i in types)
                {
                    services.AddSingleton(i);
                }
            });

            return builder;
        }
    }
}

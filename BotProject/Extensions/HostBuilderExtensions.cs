using BotProject.Inheritance;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BotProject.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddSingletonClasses(this IHostBuilder builder)
        {
            IEnumerable<Type> types = Assembly.GetExecutingAssembly()
                                              .GetTypes()
                                              .Where((x) => 
                                              {
                                                  if (x.IsAbstract) return false;

                                                  var type = x.BaseType;

                                                  while (type is not null)
                                                  {
                                                      if (type.Equals(typeof(Singleton))) return true;

                                                      type = type.BaseType;
                                                  }

                                                  return false;
                                              });

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

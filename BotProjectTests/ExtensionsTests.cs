using Microsoft.VisualStudio.TestTools.UnitTesting;
using BotProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BotProject.Inheritance;

namespace BotProject.Tests
{
    [TestClass()]
    public class ExtensionsTests
    {
        [TestMethod()]
        public void AddSingletonClassesTest_ChecksForBotLoginSingleton_ReturnsTrueIfExists()
        {
            IHostBuilder builder = Host.CreateDefaultBuilder(null)
                                       .AddSingletonClasses();

            Singleton singleton = builder.Build().Services.GetService<BotLogin>();

            Assert.IsNotNull(singleton);
        }
    }
}
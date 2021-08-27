using Microsoft.VisualStudio.TestTools.UnitTesting;
using BotProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace BotProject.Tests
{
    [TestClass()]
    public class BotLoginTests
    {
        private readonly BotLogin login;
        public BotLoginTests()
        {
            login = Program.CreateHostBuilder(null).Build().Services.GetService<BotLogin>();
        }

        [TestMethod()]
        public async Task GetGatewayResponseMessageTest_GetDiscordGatewayResponse_ReturnsStatusOK()
        {
            var response = await login.GetGatewayResponseMessage();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod()]
        public async Task GetGatewayUrlTest_GetDiscordGatewayResponse_ReturnsValidUrl()
        {
            var url = await login.GetGatewayUrl();

            Assert.IsTrue(url.Contains("discord.gg"));
        }

        [TestMethod()]
        public async Task LoginToBotTest()
        {
            await login.LoginToBot();
            Assert.Fail();
        }
    }
}
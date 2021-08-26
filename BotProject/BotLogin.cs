using BotProject.Inheritance;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotProject
{
    public class BotLogin : Singleton
    {
        private readonly IConfiguration _configs;

        public BotLogin(IConfiguration configs)
        {
            _configs = configs;
        }

        public void LoginToBot()
        {

        }
    }
}

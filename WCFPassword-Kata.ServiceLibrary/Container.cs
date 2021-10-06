using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WCFPassword_Kata.Services.Services;

namespace WCFPassword_Kata.ServiceLibrary {
    public class Container {
        public static IServiceProvider Build() {
            var Container = new ServiceCollection()
                .AddTransient<IHashService, HashService>()
                .AddSingleton<IMailService, MailService>()
                .AddSingleton<ITokenService, TokenService>()
                .AddSingleton<IUserService, UserService>();
            return Container.BuildServiceProvider();
        }
    }
}

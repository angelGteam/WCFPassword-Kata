using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace WCFPassword_Kata.ServiceLibrary {

    public class WCFPasswordService {
        private static IServiceProvider provider;
        IHashService hashService;
        IMailService mailService;
        ITokenService tokenService;
        IUserService userService;

        public WCFPasswordService() {
            provider = Container.Build();
            hashService = provider.GetService<IHashService>();
            mailService = provider.GetService<IMailService>();
            tokenService = provider.GetService<ITokenService>();
            userService = provider.GetService<IUserService>();
        }
    }
}

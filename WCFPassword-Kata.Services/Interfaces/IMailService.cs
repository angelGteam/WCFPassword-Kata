using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFPassword_Kata.Services.Models;

namespace WCFPassword_Kata.Services.Interfaces {
    public interface IMailService {
        void SendResetEmail(User user);
    }

}

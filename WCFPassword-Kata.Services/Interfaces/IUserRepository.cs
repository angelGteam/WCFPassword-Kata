using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFPassword_Kata.Services.Models;

public interface IUserRepository {
    void AddUser(User user);
    bool CheckPassword(string userName, string hashedPassword);
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFPassword_Kata.Domain.Models;

public interface IUserService {
    void AddUser(User user);
    bool CheckPassword(string storedUserPassword, string userPassword);
    string GetPasswordByUser(string userName);
    bool ContainsEmail(string email);
}
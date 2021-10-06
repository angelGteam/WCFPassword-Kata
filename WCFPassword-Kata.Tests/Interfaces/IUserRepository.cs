using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public interface IUserRepository {
    void AddUser(User user);
    bool CheckPassword(string userName, string hashedPassword);
}
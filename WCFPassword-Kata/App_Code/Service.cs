using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

public class Service : IService {
    public void AddUser(User user) {
        var newSalt = HashService.GenerateSalt();
        var hashedPassword = HashService.ComputeHash(Encoding.UTF8.GetBytes(user.Password), Encoding.UTF8.GetBytes(newSalt));
        user.Password = hashedPassword;
        UserRepository.AddUser(user);
    }

    public bool AreValidUserCredentials(User user) {
        var newSalt = HashService.GenerateSalt();
        var hashedPassword = HashService.ComputeHash(Encoding.UTF8.GetBytes(user.Password), Encoding.UTF8.GetBytes(newSalt));
        return UserRepository.CheckPassword(user.UserName, hashedPassword);
    }

    public bool SendResetEmail(string email) {
        throw new NotImplementedException();
    }
}
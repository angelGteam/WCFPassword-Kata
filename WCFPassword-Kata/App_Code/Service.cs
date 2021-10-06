using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFPassword_Kata.Services.Models;

public class Service : IService {
    public void AddUser(User user) {
        var _userRepository = new UserRepository();
        var _hashService = new HashService();
        var newSalt = _hashService.GenerateSalt();
        var hashedPassword = _hashService.ComputeHash(Encoding.UTF8.GetBytes(user.Password), Encoding.UTF8.GetBytes(newSalt));
        user.Password = hashedPassword;
        _userRepository.AddUser(user);
    }

    public bool AreValidUserCredentials(User user) {
        var _userRepository = new UserRepository();
        var _hashService = new HashService();
        var newSalt = _hashService.GenerateSalt();
        var hashedPassword = _hashService.ComputeHash(Encoding.UTF8.GetBytes(user.Password), Encoding.UTF8.GetBytes(newSalt));
        string userPassword = _userRepository.GetPasswordByUser(user.UserName);
        return _userRepository.CheckPassword(userPassword, hashedPassword);
    }

    public bool SendResetEmail(string email) {
        throw new NotImplementedException();
    }
}
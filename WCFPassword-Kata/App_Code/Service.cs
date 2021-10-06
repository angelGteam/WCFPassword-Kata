using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFPassword_Kata.Domain.Models;
using WCFPassword_Kata.Services.Services;

public class Service : IService {
    UserService _userRepository;
    HashService _hashService;
    MailService _mailService;

    public Service() {
        _userRepository = new UserService();
        _hashService = new HashService();
        _mailService = new MailService();
    }

    public void AddUser(User user) {
        var newSalt = _hashService.GenerateSalt();
        var hashedPassword = _hashService.ComputeHash(Encoding.UTF8.GetBytes(user.Password), Encoding.UTF8.GetBytes(newSalt));
        user.Password = hashedPassword;
        user.Salt = newSalt;
        _userRepository.AddUser(user);
    }

    public bool AreValidUserCredentials(User user) {
        var hashedPassword = _hashService.ComputeHash(Encoding.UTF8.GetBytes(user.Password), Encoding.UTF8.GetBytes(user.Salt));
        string userPassword = _userRepository.GetPasswordByUser(user.UserName);
        return _userRepository.CheckPassword(userPassword, hashedPassword);
    }

    public void SendResetEmail(User user) {
        if(_userRepository.ContainsEmail(user.Email)) {
            _mailService.SendResetEmail(user);
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WCFPassword_Kata.Domain.Models;

public class UserRepository {
    private List<User> _userList =  new List<User>(); //JsonConvert.DeserializeObject<List<User>>(ReadRepositoryOfItems());
    private string _path = @"C:\Users\gteam\source\repos\Katas\WCFPassword-Kata\WCFPassword-Kata\BBDD\UserDB.json";

    public UserRepository() {
        _userList = JsonConvert.DeserializeObject<List<User>>(ReadRepositoryOfItems());
        if(_userList ==null) {
            _userList = new List<User>();
        }
    }

    private string ReadRepositoryOfItems() {
        return File.ReadAllText(_path);
    }

    public void AddUser(User user) {
        _userList.Add(user);
        SaveChanges();
    }
    
    private int GetIndex(string userName) {
        return _userList.FindIndex(m => m.UserName == userName);
    }

    public bool CheckPassword(string storedUserPassword, string userPassword) {
        return userPassword == storedUserPassword;
    }

    public string GetPasswordByUser(string userName) {
        int position = GetIndex(userName);
        return _userList[position].Password;
    }

    public bool ContainsEmail(string email) {
        return _userList.Any(m => m.Email.Contains(email));
    }

    private void SaveChanges() {
        string ToJson = JsonConvert.SerializeObject(_userList);
        File.WriteAllText(_path, ToJson);
    }
}
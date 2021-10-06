using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WCFPassword_Kata.Services.Models;

public class UserRepository : IUserRepository{
    private List<User> _userList =  new List<User>(); //JsonConvert.DeserializeObject<List<User>>(ReadRepositoryOfItems());
    private string _path = @"C:\Users\gteam\source\repos\Katas\WCFPassword-Kata\WCFPassword-Kata\BBDD\UserDB.json";

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

    public bool CheckPassword(string userName, string hashedPassword) {
        int position = GetIndex(userName);
        return _userList[0].Password == hashedPassword;
    }
    
    private void SaveChanges() {
        string ToJson = JsonConvert.SerializeObject(_userList);
        File.WriteAllText(_path, ToJson);
    }
}
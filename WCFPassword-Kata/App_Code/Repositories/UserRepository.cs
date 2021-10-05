using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

public class UserRepository {
    private static List<User> _userList;
    private string _path = @"~\..\BBDD\UserDB.json";
    public UserRepository() {
        _userList = JsonConvert.DeserializeObject<List<User>>(ReadRepositoryOfItems());
    }

    private string ReadRepositoryOfItems() {
        return File.ReadAllText(_path);
    }
    private static int GetIndex(string userName) {
        return _userList.FindIndex(m => m.UserName == userName);
    }


    public static bool CheckPassword(string userName, string hashedPassword) {
        int position = GetIndex(userName);
        return _userList[0].Password == hashedPassword;
    }
}
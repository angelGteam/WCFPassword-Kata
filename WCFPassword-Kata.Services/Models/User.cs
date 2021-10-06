using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFPassword_Kata.Services.Models {
    [DataContract]
    public class User {
        public User(string userName, string password) {
            UserName = userName;
            Password = password;
        }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFPassword_Kata.Domain.Models {
    [DataContract]
    public class User {
        public User(string userName, string password, string email, string salt) {
            UserName = userName;
            Password = password;
            Email = email;
            Salt = salt;
        }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Salt { get; set; }
    }
}

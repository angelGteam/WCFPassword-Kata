using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFPassword_Kata.Domain.Models;

namespace WCFPassword_Kata.Services.Services {
    public class UserService : IUserService {
        UserRepository _userRepository;

        public UserService() {
            _userRepository = new UserRepository();
        }

        public void AddUser(User user) =>
            _userRepository.AddUser(user);

        public bool CheckPassword(string storedUserPassword, string userPassword) =>
            _userRepository.CheckPassword(storedUserPassword, userPassword);

        public string GetPasswordByUser(string userName) =>
            _userRepository.GetPasswordByUser(userName);

        public bool ContainsEmail(string email) =>
            _userRepository.ContainsEmail(email);
    }
}

using Moq;
using System;
using System.Text;
using WCFPassword_Kata.Services.Models;
using Xunit;

namespace WCFPassword_Kata.Tests {
    public class WCFPasswordShould {
        UserRepository _userRepository;
        HashService _hashService;
        Mock<IUserRepository> _userRepositoryMock;
        public WCFPasswordShould() {
            _userRepository = new UserRepository();
            _hashService = new HashService();
            _userRepositoryMock = new Mock<IUserRepository>();
            //It.IsAny<string>()
            _userRepositoryMock.Setup(a => a.GetPasswordByUser("Jose")).Returns("HTowO6ps87aufXRfyYEytDqKuAix93i/");
        }

        [Fact]
        public void CheckPassWord_WithStandardUser() {
            var testUser = new User("Jose", "Password","email@gmail.com","aQKTD52Vw70ekOndsrPR0A==");
            var userPass = _userRepositoryMock.Object.GetPasswordByUser("Jose");
            var hashedPassword = _hashService.ComputeHash(Encoding.UTF8.GetBytes(testUser.Password), Encoding.UTF8.GetBytes(testUser.Salt));
            Assert.NotNull(hashedPassword);
            Assert.NotNull(userPass);
            Assert.True(_userRepository.CheckPassword(userPass, hashedPassword));
        }

        [Fact]
        public void CheckPassWord_ReturnsCorrectPassword() {
            string checkedPassword = _userRepository.GetPasswordByUser("Jose");
            Assert.True(checkedPassword.Equals("HTowO6ps87aufXRfyYEytDqKuAix93i/"));
        }
    }
}

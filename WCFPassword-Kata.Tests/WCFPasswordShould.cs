using Moq;
using System;
using System.Text;
using WCFPassword_Kata.Domain.Models;
using WCFPassword_Kata.Services.Services;
using Xunit;

namespace WCFPassword_Kata.Tests {
    public class WCFPasswordShould {
        IUserService userRepository;
        IHashService hashService;
        Mock<IUserService> userRepositoryMock;
        Mock<ITokenService> tokenServiceMock;
        ITokenService tokenService;
        public WCFPasswordShould() {
            userRepository = new UserService();
            hashService = new HashService();
            tokenService = new TokenService();
            userRepositoryMock = new Mock<IUserService>();
            tokenServiceMock = new Mock<ITokenService>();
            //It.IsAny<string>()
            
            tokenServiceMock.Setup(a => a.GenerateToken(It.IsAny<User>())).Returns("I5Ce8biI2UhUisD73p/6SJByaYi6iw44Sm9zZQ==");
            userRepositoryMock.Setup(a => a.GetPasswordByUser("Jose")).Returns("HTowO6ps87aufXRfyYEytDqKuAix93i/");
        }

        [Fact]
        public void CheckPassWord_WithStandardUser() {
            var testUser = new User("Jose", "Password","email@gmail.com","aQKTD52Vw70ekOndsrPR0A==");
            var userPass = userRepositoryMock.Object.GetPasswordByUser("Jose");
            var hashedPassword = hashService.ComputeHash(Encoding.UTF8.GetBytes(testUser.Password), Encoding.UTF8.GetBytes(testUser.Salt));
            Assert.NotNull(hashedPassword);
            Assert.NotNull(userPass);
            Assert.True(userRepository.CheckPassword(userPass, hashedPassword));
        }

        [Fact]
        public void CheckPassWord_ReturnsCorrectPassword() {
            string checkedPassword = userRepository.GetPasswordByUser("Jose");
            Assert.True(checkedPassword.Equals("HTowO6ps87aufXRfyYEytDqKuAix93i/"));
        }

        [Fact]
        public void Check_Token_Validation_Failed_When_Date_Is_Expired() {
            var testUser = new User("Jose", "Password","email@gmail.com","aQKTD52Vw70ekOndsrPR0A==");
            string testToken = tokenServiceMock.Object.GenerateToken(testUser);
            tokenService.CheckToken(testToken);
        }
        [Fact]
        public void Add_User_Have_Proper_Method_Call() {
            var testObject = new User("Jose", "Password","email@gmail.com","aQKTD52Vw70ekOndsrPR0A==");
            userRepositoryMock.Setup(x => x.AddUser(It.IsAny<User>()));
        }
        //void AddUser(User user);
        //bool CheckPassword(string storedUserPassword, string userPassword);
        //string GetPasswordByUser(string userName);
    }
}
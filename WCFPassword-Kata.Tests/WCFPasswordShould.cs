using Moq;
using System;
using Xunit;

namespace WCFPassword_Kata.Tests {
    public class WCFPasswordShould {
        Mock<IUserRepository> _userRepositoryMock;
        public WCFPasswordShould() {
            _userRepositoryMock = new Mock<IUserRepository>();
            //It.IsAny<string>()
            _userRepositoryMock.Setup(a => a.CheckPassword("Angel", "nBJuSdtnRfcbHApWvWT6CfMOi8bWv0NF")).Returns(true);
        }

        [Fact]
        public void CheckPassWord_Password() {

            Assert.True(_userRepositoryMock.Object.CheckPassword("Angel", "nBJuSdtnRfcbHApWvWT6CfMOi8bWv0NF"));
        }
    }
}

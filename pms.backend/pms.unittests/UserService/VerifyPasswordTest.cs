using DataAccessLayer.Models;
using NUnit.Framework;
using Moq;
using DataLayer.repos.users;
using BusinessLayer.services.Users;
using System;
using System.Threading.Tasks;
using AutoMapper;

namespace pms.unittests.UserServiceTest
{
    [TestFixture]
    public class VerifyPasswordTest
    {
        [Test]
        public void UserService_VerifyPassword_PasswordsDoNotMatch_ReturnFalse()
        {
            string userPassword = BCrypt.Net.BCrypt.HashPassword("testonetwothree");
            string inputPassword = "sffhfdfd";

            var RepoMock = new Mock<IUsersRepo<User>>();
            var MapperMock = new Mock<IMapper>();

            var sut = new UserService(RepoMock.Object, MapperMock.Object);

            var result = sut.ValidatePassword(inputPassword, userPassword);

            Assert.IsFalse(result);
        }

        [Test]
        public void UserService_VerifyPassword_PasswordsDoMatch_ReturnTrue()
        {
            string userPassword = BCrypt.Net.BCrypt.HashPassword("TestThreeThwoFOur");
            string inputPassword = "TestThreeThwoFOur";

            var RepoMock = new Mock<IUsersRepo<User>>();
            var MapperMock = new Mock<IMapper>();

            var sut = new UserService(RepoMock.Object, MapperMock.Object);

            var result = sut.ValidatePassword(inputPassword, userPassword);

            Assert.IsTrue(result);
        }
    }
}

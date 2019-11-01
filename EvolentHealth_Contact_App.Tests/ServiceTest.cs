using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvolentHealth_Contact_App.Repository;
using Moq;
using EvolentHealth_Contact_App.BL;
using EvolentHealth_Contact_App.Entities;

namespace EvolentHealth_Contact_App.Tests
{
    [TestClass]
    public class ServiceTest
    {
        IUserRepository _userRepository;
        IContactService _contactService;

        [TestInitialize]
        public void Setup()
        {
            var repo = new Mock<IUserRepository>();
            repo.Setup(r => r.GetUser(It.IsAny<int>())).Returns(new User {
                UserId=1,
                FirstName="Test1",
                LastName="TestLast",
                Email="test@test.com",
                PhoneNumber="232342424",
                Status=true
            });
            repo.Setup(r => r.GetUsers()).Returns(new System.Collections.Generic.List<User> {
               new User {
                UserId=1,
                FirstName="Test1",
                LastName="TestLast",
                Email="test@test.com",
                PhoneNumber="232342424",
                Status=true
            },
               new User {
                UserId=2,
                FirstName="Test2",
                LastName="TestLast2",
                Email="test2@test2.com",
                PhoneNumber="22222222",
                Status=true
            }
            });

            repo.Setup(r=>r.UpdateUser(It.IsAny<User>())).Returns(true);
            _userRepository = repo.Object;
            _contactService = new ContactService(_userRepository);
        }

        [TestMethod]
        public void ShouldReturnCorrectUser()
        {
            var user = _contactService.GetUser(1);
            Assert.AreEqual(user.UserId, 1);  
        }

        [TestMethod]
        public void ShouldReturnAllUsers()
        {
            var users = _contactService.GetUsers();
            Assert.AreEqual(users.Count, 2);
        }

        [TestMethod]
        public void ShouldReturnTrueInactivateUser()
        {
            var result = _contactService.InactivateUser(1);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void ShouldReturnFalseInactivateUser()
        {
            var repo = new Mock<IUserRepository>();
            repo.Setup(r => r.UpdateUser(It.IsAny<User>())).Returns(false);
            _userRepository = repo.Object;
            _contactService = new ContactService(_userRepository);
            var result = _contactService.InactivateUser(1);
            Assert.AreEqual(result, false);
        }


    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvolentHealth_Contact_App.Controllers;
using EvolentHealth_Contact_App.BL;
using EvolentHealth_Contact_App.Utilities;
using Moq;
using EvolentHealth_Contact_App.Entities;
using System.Web.Http.Results;
using System.Collections.Generic;

namespace EvolentHealth_Contact_App.Tests
{
    [TestClass]
    public class ControllerTest
    {
        IContactService _contactService;
        ILogManager _logManager;

        [TestInitialize]
        public void Setup()
        {

            _logManager = new Mock<ILogManager>().Object;
        }

        [TestMethod]
        public void ShouldReturnNotFoundStatusForNotExistingUser()
        {
            var contServ = new Mock<IContactService>();
            contServ.Setup(c => c.GetUser(It.IsAny<int>())).Returns<User>(null);
            _contactService = contServ.Object;

            var _userController = new UserController(_contactService, _logManager);
            var result = _userController.GetUser(1);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void ShouldReturnOKStatusWithUserObjectForExistingUser()
        {
            var contServ = new Mock<IContactService>();
            contServ.Setup(c => c.GetUser(It.IsAny<int>())).Returns(new User
            {
                UserId = 1,
                FirstName = "Test1",
                LastName = "TestLast",
                Email = "test@test.com",
                PhoneNumber = "232342424",
                Status = true
            });
            _contactService = contServ.Object;

            var _userController = new UserController(_contactService, _logManager);
            var result = _userController.GetUser(1) as OkNegotiatedContentResult<User>;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.UserId, 1);
        }

        [TestMethod]
        public void ShouldReturnNotFoundStatusForEmptyUserList()
        {
            var contServ = new Mock<IContactService>();
            contServ.Setup(c => c.GetUsers()).Returns(new List<User>());
            _contactService = contServ.Object;

            var _userController = new UserController(_contactService, _logManager);
            var result = _userController.GetAllUsers();
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void ShouldReturnOKStatusWithUserListForUsers()
        {
            var contServ = new Mock<IContactService>();
            contServ.Setup(c => c.GetUsers()).Returns(new List<User> {
                new User
                {
                    UserId = 1,
                    FirstName = "Test1",
                    LastName = "TestLast",
                    Email = "test@test.com",
                    PhoneNumber = "232342424",
                    Status = true
                },
                new User
                {
                UserId=2,
                FirstName="Test2",
                LastName="TestLast2",
                Email="test2@test2.com",
                PhoneNumber="22222222",
                Status=true
            }
            });
            _contactService = contServ.Object;

            var _userController = new UserController(_contactService, _logManager);
            var result = _userController.GetAllUsers() as OkNegotiatedContentResult<List<User>>;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Count, 2);
        }

        [TestMethod]
        public void ShouldReturnBadRequestForAddUser()
        {
            var _userController = new UserController(_contactService, _logManager);

            _userController.ModelState.AddModelError("FirstName","FirstName is required");
            var result = _userController.AddUser(new User {
                FirstName="",
            }) as InvalidModelStateResult;

            Assert.AreEqual(result.ModelState.IsValid, false);
            Assert.AreEqual(result.ModelState.Count, 1);
        }

        [TestMethod]
        public void ShouldReturnCreatedResponseForAddUser()
        {
            var contServ = new Mock<IContactService>();
            var user = new User
            {
                UserId=1,
                FirstName = "Test1",
                LastName = "TestLast",
                Email = "test@test.com",
                PhoneNumber = "232342424"
            };

            contServ.Setup(c => c.AddUser(It.IsAny<User>())).Returns(true);
            _contactService = contServ.Object;

            var _userController = new UserController(_contactService, _logManager);



            var result = _userController.AddUser(new User
            {
                FirstName = "Test1",
                LastName = "TestLast",
                Email = "test@test.com",
                PhoneNumber = "232342424"
            }) as CreatedAtRouteNegotiatedContentResult<User>;

            Assert.AreEqual(result.RouteName, "GetUser");
        }

        [TestMethod]
        public void ShouldReturnInternalServerErrorForAddUser()
        {
            var contServ = new Mock<IContactService>();
            var user = new User
            {
                UserId = 1,
                FirstName = "Test1",
                LastName = "TestLast",
                Email = "test@test.com",
                PhoneNumber = "232342424"
            };

            contServ.Setup(c => c.AddUser(user)).Returns(false);

            var _userController = new UserController(_contactService, _logManager);



            var result = _userController.AddUser(new User
            {
                FirstName = "Test1",
                LastName = "TestLast",
                Email = "test@test.com",
                PhoneNumber = "232342424"
            });

            Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
        }

        [TestMethod]
        public void ShouldReturnBadRequestForUpdateUser()
        {
            var _userController = new UserController(_contactService, _logManager);

            _userController.ModelState.AddModelError("FirstName", "FirstName is required");
            var result = _userController.AddUser(new User
            {
                FirstName = "",
            }) as InvalidModelStateResult;

            Assert.AreEqual(result.ModelState.IsValid, false);
            Assert.AreEqual(result.ModelState.Count, 1);
        }

        [TestMethod]
        public void ShouldReturnCreatedResponseForUpdateUser()
        {
            var contServ = new Mock<IContactService>();
            var user = new User
            {
                UserId = 1,
                FirstName = "Test1",
                LastName = "TestLast",
                Email = "test@test.com",
                PhoneNumber = "232342424"
            };

            contServ.Setup(c => c.UpdateUser(It.IsAny<User>())).Returns(true);
            _contactService = contServ.Object;
            var _userController = new UserController(_contactService, _logManager);



            var result = _userController.UpdateUser(new User
            {
                FirstName = "Test1",
                LastName = "TestLast",
                Email = "test@test.com",
                PhoneNumber = "232342424"
            }) ;

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<string>));
        }

        [TestMethod]
        public void ShouldReturnInternalServerErrorForUpdateUser()
        {
            var contServ = new Mock<IContactService>();
            var user = new User
            {
                UserId = 1,
                FirstName = "Test1",
                LastName = "TestLast",
                Email = "test@test.com",
                PhoneNumber = "232342424"
            };

            contServ.Setup(c => c.UpdateUser(user)).Returns(false);

            var _userController = new UserController(_contactService, _logManager);

            var result = _userController.UpdateUser(new User
            {
                FirstName = "Test1",
                LastName = "TestLast",
                Email = "test@test.com",
                PhoneNumber = "232342424"
            });

            Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
        }
                
        [TestMethod]
        public void ShouldReturnOKResponseForInactivateUser()
        {
            var contServ = new Mock<IContactService>();
            
            contServ.Setup(c => c.InactivateUser(1)).Returns(true);
            _contactService = contServ.Object;
            var _userController = new UserController(_contactService, _logManager);

            var result = _userController.InactivateUser(1);

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<string>));
        }

        [TestMethod]
        public void ShouldReturnInternalErrorForInactivateUser()
        {
            var contServ = new Mock<IContactService>();

            contServ.Setup(c => c.InactivateUser(1)).Returns(false);
            _contactService = contServ.Object;
            var _userController = new UserController(_contactService, _logManager);

            var result = _userController.InactivateUser(1);

            Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
        }
    }
}

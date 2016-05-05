using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Interfaces;
using Services.Services;
using ElectronRepository.Interfaces;
using System.Collections.Generic;
using ElectronRepository;
using ElectronRepository.Repositories;
using System.Linq;
using Services.Tests.TestData;
using Moq;

namespace Services.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        private Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
        private IUserService userService;

        [TestMethod]
        public void GetByUsername_CurrentDatabase_ExpectedUser()
        {
            ////Arrange
            User expectedUser = MockUserData.dummyUser;
            SetupUserRepositoryGetById(expectedUser);
            userService = new UserService(userRepository.Object);

            ////Act
            User actualUser = userService.GetByUsername("dummy");

            ////Assert
            Assert.AreEqual(expectedUser, actualUser);
        }

        [TestMethod]
        public void GetByUsername_WrongUsername_ExpectedNullUser()
        {
            ////Arrange
            User expectedUser = null;
            SetupUserRepositoryGetById(expectedUser);
            userService = new UserService(userRepository.Object);

            ////Act
            User actualUser = userService.GetByUsername("dummy");

            ////Assert
            Assert.AreEqual(expectedUser, actualUser);
        }

        [TestMethod]
        public void GetAll_CurrentDatabase_ExpectedUserCount()
        {
            //Arrange
            int expcetedCount = 3;
            SetupUserRepositoryGetAll(MockUserData.users);
            userService = new UserService(userRepository.Object);

            //Act
            int actualCount = userService.GetAllUser().Count();

            //Assert
            Assert.AreEqual(expcetedCount, actualCount);
        }

        [TestMethod]
        public void GetAll_NoUserInDatabase_ExpectedUserZeroCount()
        {
            //Arrange
            int expcetedCount = 0;
            SetupUserRepositoryGetAll(new List<User>());
            userService = new UserService(userRepository.Object);

            //Act
            int actualCount = userService.GetAllUser().Count();

            //Assert
            Assert.AreEqual(expcetedCount, actualCount);
        }

        private void SetupUserRepositoryGetById(User user)
        {
            this.userRepository.Setup(r => r.GetByUsername(It.IsAny<string>())).Returns(user);
        }

        private void SetupUserRepositoryGetAll(IEnumerable<User> users)
        {
            this.userRepository.Setup(r => r.GetAll()).Returns(users);
        }
    }
}

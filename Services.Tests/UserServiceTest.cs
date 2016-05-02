using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Interfaces;
using Services.Services;
using ElectronRepository.Interfaces;
using System.Collections.Generic;
using ElectronRepository;
using ElectronRepository.Repositories;
using System.Linq;

namespace Services.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void GetAll_CurrentDatabase_ExpectedUserCount()
        {
            ////Arrange
            //int expectedUserCount = 5;
            //IUserService userService = new UserService(new UserRepository());

            ////Act
            //IEnumerable<User> users = userService.GetAllUser();
            //int actualUserCount = users.Count();

            ////Assert
            //Assert.AreEqual(expectedUserCount, actualUserCount);
        }
    }
}

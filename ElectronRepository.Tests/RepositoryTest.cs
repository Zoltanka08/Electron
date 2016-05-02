using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronRepository.Repositories;
using System.Linq;
using ElectronRepository.Interfaces;

namespace ElectronRepository.Tests
{
    /// <summary>
    /// Summary description for RepositoryTest
    /// </summary>
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            int expectedUserCount = 5;
            IUserRepository userRepo = new UserRepository();

            //Act
            IEnumerable<User> users = userRepo.GetAll();
            int actualUserCount = users.Count();

            //Assert
            Assert.AreEqual(expectedUserCount, actualUserCount);
        }
    }
}

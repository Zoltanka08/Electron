using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronRepository;
using Services.Tests.TestData;
using ElectronRepository.Interfaces;
using Moq;
using Services.Interfaces;
using Services.Services;
using System.Collections.Generic;
using System.Linq;

namespace Services.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
        private IOrderService orderService;

        [TestMethod]
        public void GetByID_CurrentDatabase_ExpectedOrder()
        {
            //Arrange
            Order expectedOrder = MockOrderData.order;
            SetupOrderRepositoryGetById(expectedOrder);
            orderService = new OrderService(orderRepository.Object);

            //Act
            Order actualOrder = orderService.GetOrderById(1);

            //Assert
            Assert.AreEqual(expectedOrder, actualOrder);
        }

        [TestMethod]
        public void GetByID_WrongId_ExpectedNullOrder()
        {
            //Arrange
            Order expectedOrder = null;
            SetupOrderRepositoryGetById(expectedOrder);
            orderService = new OrderService(orderRepository.Object);

            //Act
            Order actualOrder = orderService.GetOrderById(1);

            //Assert
            Assert.AreEqual(expectedOrder, actualOrder);
        }

        [TestMethod]
        public void GetByUserId_WrongId_ExpectedZeroOrderCount()
        {
            //Arrange
            int expectedCount = 0;
            SetupOrderRepositoryGetByUserId(new List<Order>());
            orderService = new OrderService(orderRepository.Object);

            //Act
            int actualCount = orderService.getOrdersByUserId(1).Count();

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void GetByUserId_CorrectId_ExpectedOrderCount()
        {
            //Arrange
            int expectedCount = 2;
            SetupOrderRepositoryGetByUserId(MockOrderData.orders);
            orderService = new OrderService(orderRepository.Object);

            //Act
            int actualCount = orderService.getOrdersByUserId(1).Count();

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        private void SetupOrderRepositoryGetById(Order order)
        {
            orderRepository.Setup(o => o.GetOrderById(It.IsAny<int>())).Returns(order);
        }

        private void SetupOrderRepositoryGetByUserId(IEnumerable<Order> orders)
        {
            orderRepository.Setup(o => o.getOrdersByUserId(It.IsAny<int>())).Returns(orders);
        }
    }
}

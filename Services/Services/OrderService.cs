using ElectronRepository;
using ElectronRepository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void InsertOrder(Order product)
        {
            this.orderRepository.Insert(product);
            this.orderRepository.Save();
        }

        public void DeleteOrder(Order product)
        {
            this.orderRepository.Delete(product);
            this.orderRepository.Save();
        }

        public void UpdateOrder(Order product)
        {
            this.orderRepository.Update(product);
            this.orderRepository.Save();
        }

        public IEnumerable<Order> getOrdersByUserId(int userId)
        {
            return this.orderRepository.getOrdersByUserId(userId);
        }


        public Order GetOrderById(int id)
        {
            return this.orderRepository.GetOrderById(id);
        }
    }
}
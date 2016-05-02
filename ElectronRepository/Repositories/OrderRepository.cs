using ElectronRepository.BaseRepository;
using ElectronRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronRepository.Repositories
{
    public class OrderRepository : GenericRepository<ElectroShopEntities, Order>, IOrderRepository
    {
        public IEnumerable<Order> getOrdersByUserId(int userId)
        {
            return base.Get(o => o.user_id == userId);
        }

        public Order GetOrderById(int id)
        {
            return base.Get(o => o.id == id).First();
        }
    }
}
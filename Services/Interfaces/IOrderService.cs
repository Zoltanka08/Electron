using ElectronRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IOrderService
    {
        void InsertOrder(Order product);
        void DeleteOrder(Order product);
        void UpdateOrder(Order product);
        IEnumerable<Order> getOrdersByUserId(int userId);
        Order GetOrderById(int id);
    }
}

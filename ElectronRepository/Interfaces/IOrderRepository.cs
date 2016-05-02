using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronRepository.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> getOrdersByUserId(int userId);
        void Insert(Order product);
        void Delete(Order product);
        void Update(Order product);
        Order GetOrderById(int id);
        void Save();
    }
}

using ElectronRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tests.TestData
{
    public class MockOrderData
    {
        public static Order order = new Order()
        {
            id = 1,
            bargain = 1000.0
        };

        public static IEnumerable<Order> orders = new List<Order>()
        {
            new Order()
            {
                id = 1,
                user_id = 2
            },
            new Order()
            {
                id = 2,
                user_id = 3
            }
        };
    }
}

using ElectronRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tests.TestData
{
    public class MockUserData
    {
        public static User dummyUser = new User()
        {
            city = "dummyText",
            country = "dummyText",
            firstname = "dummyText",
            IBAN = "dummyText",
            id = 1,
            lastname = "dummyText",
            mail = "dummyText",
            mobile = "dummyText",
            number = "dummyText",
            Orders = null,
            pass = "dummyText",
            street = "dummyText",
            username = "dummyText",
            UserRoles = null
        };

        public static IEnumerable<User> users = new List<User>()
        {
            new User()
            {
                username = "first"
            },
            new User()
            {
                username = "second"
            },
            new User()
            {
                username = "third"
            }
        };
    }
}

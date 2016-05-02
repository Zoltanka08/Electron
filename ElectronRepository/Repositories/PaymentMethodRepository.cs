using ElectronRepository.BaseRepository;
using ElectronRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronRepository.Repositories
{
    public class PaymentMethodRepository : GenericRepository<ElectroShopEntities, PaymentMethod>, IPaymentMethodRepository
    {
        public IEnumerable<PaymentMethod> getAllMethods()
        {
            return base.Get();
        }
    }
}
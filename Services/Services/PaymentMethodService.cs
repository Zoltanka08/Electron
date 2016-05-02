using ElectronRepository;
using ElectronRepository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private IPaymentMethodRepository paymentMethodRepository;

        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository)
        {
            this.paymentMethodRepository = paymentMethodRepository;
        }
        public IEnumerable<PaymentMethod> getAllMethods()
        {
            return this.paymentMethodRepository.getAllMethods();
        }
    }
}
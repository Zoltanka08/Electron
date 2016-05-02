using ElectronRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electron.ViewModels
{
    public class OrderViewModel
    {
        public int id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> product_id { get; set; }
        public Nullable<int> payment_id { get; set; }
        public Nullable<int> order_state_id { get; set; }
        public Nullable<System.DateTime> data { get; set; }

        public virtual OrderState OrderState { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
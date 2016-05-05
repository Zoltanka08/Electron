//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ElectronRepository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> product_id { get; set; }
        public Nullable<int> payment_id { get; set; }
        public Nullable<int> order_state_id { get; set; }
        public Nullable<System.DateTime> data { get; set; }
        public Nullable<double> bargain { get; set; }
    
        public virtual OrderState OrderState { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}

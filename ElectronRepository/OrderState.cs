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
    
    public partial class OrderState
    {
        public OrderState()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int id { get; set; }
        public string state { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
    }
}

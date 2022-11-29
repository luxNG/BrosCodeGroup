using System;
using System.Collections.Generic;

namespace FurnitureCompany.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerAddresses = new HashSet<CustomerAddress>();
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public string? CustomerName { get; set; }
        public string CustomerPhone { get; set; } = null!;

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

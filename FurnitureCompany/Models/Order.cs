using System;
using System.Collections.Generic;

namespace FurnitureCompany.Models
{
    public partial class Order
    {
        public Order()
        {
            Assigns = new HashSet<Assign>();
            OrderServices = new HashSet<OrderService>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int? WorkingStatusId { get; set; }
        public string Address { get; set; } = null!;
        public string? TotalPrice { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual WorkingStatus? WorkingStatus { get; set; }
        public virtual ICollection<Assign> Assigns { get; set; }
        public virtual ICollection<OrderService> OrderServices { get; set; }
    }
}

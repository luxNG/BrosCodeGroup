using System;
using System.Collections.Generic;

namespace FurnitureCompany.Models
{
    public partial class Service
    {
        public Service()
        {
            OrderServices = new HashSet<OrderService>();
            ServiceDetails = new HashSet<ServiceDetail>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = null!;
        public string? ServiceDescription { get; set; }
        public string Price { get; set; } = null!;
        public int? Type { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<OrderService> OrderServices { get; set; }
        public virtual ICollection<ServiceDetail> ServiceDetails { get; set; }
    }
}

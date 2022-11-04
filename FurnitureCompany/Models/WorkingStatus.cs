using System;
using System.Collections.Generic;

namespace FurnitureCompany.Models
{
    public partial class WorkingStatus
    {
        public WorkingStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}

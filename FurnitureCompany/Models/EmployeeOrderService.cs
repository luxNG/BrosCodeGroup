using System;
using System.Collections.Generic;

namespace FurnitureCompany.Models
{
    public partial class EmployeeOrderService
    {
        public int EmployeeOrderServiceId { get; set; }
        public int EmployeeId { get; set; }
        public int OrderServiceId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual OrderService OrderService { get; set; } = null!;
    }
}

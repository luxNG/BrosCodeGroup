using System;
using System.Collections.Generic;

namespace FurnitureCompany.Models
{
    public partial class Assign
    {
        public int AssignId { get; set; }
        public int OrderId { get; set; }
        public int ManagerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CreateAssignAt { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Manager Manager { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}

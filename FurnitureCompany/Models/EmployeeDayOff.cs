using System;
using System.Collections.Generic;

namespace FurnitureCompany.Models
{
    public partial class EmployeeDayOff
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string? Reason { get; set; }
        public DateTime DayOff { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}

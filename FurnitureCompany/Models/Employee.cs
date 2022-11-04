using System;
using System.Collections.Generic;

namespace FurnitureCompany.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Assigns = new HashSet<Assign>();
            EmployeeDayOffs = new HashSet<EmployeeDayOff>();
            EmployeeOrderServices = new HashSet<EmployeeOrderService>();
        }

        public int EmployeeId { get; set; }
        public int AccountId { get; set; }
        public int SpecialtyId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string EmployeePhoneNumber { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public bool? WorkingStatus { get; set; }
        public bool Status { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Specialty Specialty { get; set; } = null!;
        public virtual ICollection<Assign> Assigns { get; set; }
        public virtual ICollection<EmployeeDayOff> EmployeeDayOffs { get; set; }
        public virtual ICollection<EmployeeOrderService> EmployeeOrderServices { get; set; }
    }
}

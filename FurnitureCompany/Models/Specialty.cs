using System;
using System.Collections.Generic;

namespace FurnitureCompany.Models
{
    public partial class Specialty
    {
        public Specialty()
        {
            Employees = new HashSet<Employee>();
        }

        public int SpecialtyId { get; set; }
        public string SpecialtyName { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

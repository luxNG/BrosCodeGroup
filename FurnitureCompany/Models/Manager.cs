using System;
using System.Collections.Generic;

namespace FurnitureCompany.Models
{
    public partial class Manager
    {
        public Manager()
        {
            Assigns = new HashSet<Assign>();
        }

        public int ManagerId { get; set; }
        public int AccountId { get; set; }
        public string ManagerName { get; set; } = null!;
        public string ManagerPhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Status { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<Assign> Assigns { get; set; }
    }
}

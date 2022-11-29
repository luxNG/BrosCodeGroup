using System;
using System.Collections.Generic;

namespace FurnitureCompany.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool AccountStatus { get; set; }
        public string? RefreshToken { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual Customer? Customer { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Manager? Manager { get; set; }
    }
}

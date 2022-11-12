using System;
using System.Collections.Generic;

namespace ProjectElearning.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Avatar { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int RoleId { get; set; }
        public bool Status { get; set; }
        public string PublicId { get; set; } = null!;
    }
}

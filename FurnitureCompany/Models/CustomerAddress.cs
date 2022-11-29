using System;
using System.Collections.Generic;

namespace FurnitureCompany.Models
{
    public partial class CustomerAddress
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public string? HomeNumber { get; set; }
        public string? Street { get; set; }
        public string? Ward { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public bool IsDefault { get; set; }

        public virtual Customer Customer { get; set; } = null!;
    }
}

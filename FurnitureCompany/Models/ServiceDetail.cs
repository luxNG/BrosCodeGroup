using System;
using System.Collections.Generic;

namespace FurnitureCompany.Models
{
    public partial class ServiceDetail
    {
        public int ServiceDetailId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceDetailName { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string? Type { get; set; }
        public string? Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Status { get; set; }

        public virtual Service Service { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace FurnitureCompany.Models
{
    public partial class OrderImage
    {
        public int OrderImageId { get; set; }
        public int OrderId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public bool Status { get; set; }

        public virtual Order Order { get; set; } = null!;
    }
}

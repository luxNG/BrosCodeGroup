using System;
using System.Collections.Generic;

namespace FurnitureCompany.Models
{
    public partial class Category
    {
        public Category()
        {
            Services = new HashSet<Service>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}

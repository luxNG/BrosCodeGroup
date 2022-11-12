using System;
using System.Collections.Generic;

namespace ProjectElearning.Models
{
    public partial class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Icon { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}

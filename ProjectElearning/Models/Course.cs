using System;
using System.Collections.Generic;

namespace ProjectElearning.Models
{
    public partial class Course
    {
        public Course()
        {
            Targets = new HashSet<Target>();
            Videos = new HashSet<Video>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Image { get; set; }
        public int? LecturesCount { get; set; }
        public int? HourCount { get; set; }
        public int? ViewCount { get; set; }
        public double Price { get; set; }
        public int? Discount { get; set; }
        public double? PromotionPrice { get; set; }
        public string? Description { get; set; }
        public string CourseContent { get; set; } = null!;
        public int CategoryId { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Target> Targets { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}

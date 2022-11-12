using System;
using System.Collections.Generic;

namespace ProjectElearning.Models
{
    public partial class Target
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;
    }
}

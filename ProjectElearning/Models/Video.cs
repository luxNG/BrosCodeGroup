using System;
using System.Collections.Generic;

namespace ProjectElearning.Models
{
    public partial class Video
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public int? TimeCount { get; set; }
        public int? CourseId { get; set; }

        public virtual Course? Course { get; set; }
    }
}

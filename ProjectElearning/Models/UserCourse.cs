using System;
using System.Collections.Generic;

namespace ProjectElearning.Models
{
    public partial class UserCourse
    {
        public int? UserId { get; set; }
        public int? CourseId { get; set; }
        public int? RoleId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual User? User { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

namespace ProjectElearning.Models
{
    public partial class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = null!;
        public string? Description { get; set; }
    }
}

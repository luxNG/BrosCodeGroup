﻿using System;
using System.Collections.Generic;

namespace FurnitureCompany.Models
{
    public partial class OrderService
    {
        public int OrderServiceId { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public string? EstimateTimeFinish { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
    }
}

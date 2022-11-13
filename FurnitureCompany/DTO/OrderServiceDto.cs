﻿namespace FurnitureCompany.DTO
{
    public class OrderServiceDto
    {
        public int OrderServiceId { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Price { get; set; } = null!;
        public string? EstimateTimeFinish { get; set; }


    }
}

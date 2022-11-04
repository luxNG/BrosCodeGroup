namespace FurnitureCompany.DTO
{
    public class CustomerFullOrderDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int? WorkingStatusId { get; set; }
        public string Address { get; set; } = null!;
        public string? TotalPrice { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
        public int ServiceId { get; set; }
        public string? EstimateTimeFinish { get; set; }
    }
}

namespace FurnitureCompany.DTO
{
    public class CustomerGetListOrderAndOrderServiceDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int? WorkingStatusId { get; set; }
        public string Address { get; set; } = null!;
        public string? TotalPrice { get; set; }
        public DateTime? ImplementationDate { get; set; }
        public string? ImplementationTime { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? Description { get; set; }
        public int OrderServiceId { get; set; }
        public int? Quantity { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = null!;
        public string? Price { get; set; }
    }
}

namespace FurnitureCompany.DTO
{
    public class OrderDto
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
    }
}

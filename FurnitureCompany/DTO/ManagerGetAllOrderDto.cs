namespace FurnitureCompany.DTO
{
    public class ManagerGetAllOrderDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string CustomerPhone { get; set; } = null!;
        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? TotalPrice { get; set; }
        public DateTime? ImplementationDate { get; set; }
        public string? ImplementationTime { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? Description { get; set; }
    }
}

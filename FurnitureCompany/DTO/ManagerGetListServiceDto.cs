namespace FurnitureCompany.DTO
{
    public class ManagerGetListServiceDto
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = null!;
        public string? ServiceDescription { get; set; }
        public string? Type { get; set; }
        public string? Price { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool ServiceStatus { get; set; }
    }
}

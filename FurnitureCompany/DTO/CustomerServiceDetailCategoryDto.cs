namespace FurnitureCompany.DTO
{
    public class CustomerServiceDetailCategoryDto
    {
        public int ServiceId { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string ServiceName { get; set; } = null!;
        public string? ServiceDescription { get; set; }
        public string? Type { get; set; }
        public string? Price { get; set; }
    }
}

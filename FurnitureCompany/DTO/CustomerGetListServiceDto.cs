namespace FurnitureCompany.DTO
{
    public class CustomerGetListServiceDto
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = null!;
        public string? Price { get; set; }
    }
}

namespace FurnitureCompany.DTO
{
    public class CustomerGetListOrderServiceDto
    {
        public int OrderServiceId { get; set; }
        public int? Quantity { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = null!;
        public string? Price { get; set; }
       // public List<CustomerGetListServiceDto> listServiceDto { get; set; }
    }
}

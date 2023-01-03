namespace FurnitureCompany.DTO
{
    public class CustomerUpdateOrderDto
    {
        public string Address { get; set; } = null!;
        public string? TotalPrice { get; set; }
        public DateTime? ImplementationDate { get; set; }
        public string? ImplementationTime { get; set; }
        public DateTime? UpdateAt { get; set; }
        public List<ServiceForCustomerDto> listService { get; set; }

    }
}

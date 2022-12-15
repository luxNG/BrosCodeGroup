namespace FurnitureCompany.DTO
{
    public class CustomerCreateOrderTestDto
    {
        public int CustomerId { get; set; }
        public string Address { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public string? TotalPrice { get; set; }
        public DateTime? ImplementationDate { get; set; }
        public string? ImplementationTime { get; set; }
        public List<ServiceForCustomerDto> listService { get; set; }


    }
}

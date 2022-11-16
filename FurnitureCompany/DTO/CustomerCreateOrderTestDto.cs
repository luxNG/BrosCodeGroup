namespace FurnitureCompany.DTO
{
    public class CustomerCreateOrderTestDto
    {
        public int CustomerId { get; set; }
        public string Address { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public string? TotalPrice { get; set; }
        public List<ServiceForEmployeeDto> listService { get; set; }


    }
}

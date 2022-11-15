using FurnitureCompany.Models;

namespace FurnitureCompany.DTO
{
    public class CustomerGetDetailOrderInforDto
    {
     
        public string StatusName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? TotalPrice { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? Description { get; set; }
        public List<EmployeeDto> listEmployeeDto { get; set; }
        public List<OrderServiceDto> listOrderServiceDto { get; set; }


    }
}

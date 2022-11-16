using FurnitureCompany.Models;

namespace FurnitureCompany.DTO
{
    public class ManagerAssignDto
    {
        public int OrderId { get; set; }
        public int ManagerId { get; set; }
        public DateTime CreateAssignAt { get; set; }
        public bool? Status { get; set; }
        public List<EmployeeAssignDto> listEmployee { get; set; }
    }
}

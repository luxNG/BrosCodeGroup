using FurnitureCompany.Models;

namespace FurnitureCompany.DTO
{
    public class EmployeeAssignOrderDto
    { 

        public int OrderId { get; set; }
        public string? TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public int? WorkingStatusId { get; set; }
        public string? StatusName { get; set; } 
        public string? Address { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerName { get; set; }
        public string? ServiceName { get; set; }
        public string? Price { get; set; }
        public DateTime? ImplementationDate { get; set; }
        public string? ImplementationTime { get; set; }


    }
}

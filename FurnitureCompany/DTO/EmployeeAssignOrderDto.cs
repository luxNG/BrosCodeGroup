using FurnitureCompany.Models;

namespace FurnitureCompany.DTO
{
    public class EmployeeAssignOrderDto
    { 

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int? WorkingStatusId { get; set; }
        public string StatusName { get; set; } 
        public string Address { get; set; }
        public string CustomerPhone { get; set; }
        public string? CustomerName { get; set; }

        public EmployeeAssignOrderDto(int OrderId, int CustomerId, int WorkingStatusId, string StatusName, string Address, string CustomerPhone, string CustomerName)
        {
            this.OrderId = OrderId;
            this.CustomerId = CustomerId;
            this.WorkingStatusId = WorkingStatusId;
            this.StatusName = StatusName;
            this.Address = Address;
            this.CustomerPhone = CustomerPhone;
            this.CustomerName = CustomerName;
        }

        /*
        orderTime      
   
        */
    }
}

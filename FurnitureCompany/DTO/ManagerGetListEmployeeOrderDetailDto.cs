namespace FurnitureCompany.DTO
{
    public class ManagerGetListEmployeeOrderDetailDto
    {
        public int AssignId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string EmployeePhoneNumber { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public bool? WorkingStatus { get; set; }
        
    }
}

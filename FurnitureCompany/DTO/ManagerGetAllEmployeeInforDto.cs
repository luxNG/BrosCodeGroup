namespace FurnitureCompany.DTO
{
    public class ManagerGetAllEmployeeInforDto
    {
        public int EmployeeId { get; set; }
        public int SpecialtyId { get; set; }
        public string SpecialtyName { get; set; } = null!;
        public string EmployeeName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string EmployeePhoneNumber { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public bool? WorkingStatus { get; set; }
        public bool Status { get; set; }
    }
}

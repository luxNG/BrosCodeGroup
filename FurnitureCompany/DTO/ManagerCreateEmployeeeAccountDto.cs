namespace FurnitureCompany.DTO
{
    public class ManagerCreateEmployeeeAccountDto
    {
       
        public int RoleId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? CreateAt { get; set; }
        public bool AccountStatus { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string EmployeePhoneNumber { get; set; } = null!;
        public int SpecialtyId { get; set; }
    }
}

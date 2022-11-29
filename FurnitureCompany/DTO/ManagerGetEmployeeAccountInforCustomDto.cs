namespace FurnitureCompany.DTO
{
    public class ManagerGetEmployeeAccountInforCustomDto
    {
        public int AccountId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string RoleName { get; set; } = null!;
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string EmployeePhoneNumber { get; set; } = null!;
        public string? ImageUrl { get; set; }




    }
}

namespace FurnitureCompany.DTO
{
    public class EmployeeDto
    {

        public string ImageUrl { get; set; }
        public int AccountId { get; set; }
        public int SpecialtyId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string EmployeePhoneNumber { get; set; } = null!;
        public bool Status { get; set; }

    }
}

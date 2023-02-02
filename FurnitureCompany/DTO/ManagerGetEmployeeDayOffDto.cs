namespace FurnitureCompany.DTO
{
    public class ManagerGetEmployeeDayOffDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string EmployeePhoneNumber { get; set; } = null!;
        public string? Reason { get; set; }
        public DateTime DayOff { get; set; }
        public int? Status { get; set; }

    }
}

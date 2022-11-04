namespace FurnitureCompany.DTO
{
    public class EmployeeDayOffDto
    {
        public int EmployeeId { get; set; }
        public string? Reason { get; set; }
        public DateTime DayOff { get; set; }
    }
}

namespace FurnitureCompany.DTO
{
    public class AssignDto
    {
        public int AssignId { get; set; }
        public int OrderId { get; set; }
        public int ManagerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CreateAssignAt { get; set; }
    }
}

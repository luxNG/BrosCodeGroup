namespace FurnitureCompany.DTO
{
    public class EmployeeCreateOrderImageListDto
    {
        public int OrderId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public bool Status { get; set; }
    }
}

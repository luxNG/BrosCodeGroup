namespace FurnitureCompany.DTO
{
    public class ServiceDto
    {
        public string ServiceName { get; set; }
        public string? ServiceDescription { get; set; }
        public string Price { get; set; }
        public string? Type { get; set; }
        public int CategoryId { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Status { get; set; }
    }
}

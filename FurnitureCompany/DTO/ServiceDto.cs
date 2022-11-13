namespace FurnitureCompany.DTO
{
    public class ServiceDto
    {
        public string ServiceName { get; set; }
        public string? ServiceDescription { get; set; }
        public string Price { get; set; }
        public int? Type { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Status { get; set; }
    }
}

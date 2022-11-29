namespace FurnitureCompany.DTO
{
    public class ServiceGetCustomInforDto
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string? ServiceDescription { get; set; }
        public string Price { get; set; }
        public string? Type { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Status { get; set; }
        public string? CategoryName { get; set; }

    }
}

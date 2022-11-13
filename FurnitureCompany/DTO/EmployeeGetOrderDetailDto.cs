namespace FurnitureCompany.DTO
{
    public class EmployeeGetOrderDetailDto
    {
        public int OrderServiceId { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string? EstimateTimeFinish { get; set; }
        public string? Address { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerName { get; set; }
        public string? TotalPrice { get; set; }
        public string? Price { get; set; }
        public string? StatusName { get; set; }
        public List<OrderServiceDto>? listOrderServiceDto { get; set; }
        public List<EmployeeDto>? listEmployeeDto { get; set; }


    }
}

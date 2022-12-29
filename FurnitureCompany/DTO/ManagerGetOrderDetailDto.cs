namespace FurnitureCompany.DTO
{
    public class ManagerGetOrderDetailDto
    {
        public string? CustomerName { get; set; }
        public string CustomerPhone { get; set; } = null!;
        public int OrderId { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;
        public DateTime? ImplementationDate { get; set; }
        public string? ImplementationTime { get; set; }
        public List<ManagerOrderServiceDetailDto> listOrderServiceInfor { get; set; }
        public List<string> ImageUrl { get; set; } = null!;
        public List<ManagerGetListEmployeeOrderDetailDto> listEmployeeAssign { get; set; }
    }
}

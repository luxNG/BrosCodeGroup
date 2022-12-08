using FurnitureCompany.Models;

namespace FurnitureCompany.DTO
{
    public class EmployeeReportFormDto
    {
        public int OrderId { get; set; }
        public string? Description { get; set; }
        //public string? UrlImage { get; set; }
        public List<ServiceForEmployeeDto> listService { get; set; }             
        public List<EmployeeCreateOrderImageListDto> listEmployeeCreateOrderImageListDto { get; set; }

    }
}

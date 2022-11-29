using FurnitureCompany.DTO;
using FurnitureCompany.Models;

namespace FurnitureCompany.IService
{
    public interface IEmployeeService
    {
        public List<Employee> GetAllEmployeeInformation();
        public Employee GetEmployeeById(int id);
        public List<EmployeeAssignOrderDto> viewAssignByEmployee(int id);

        public Employee addNewEmployeeByManger(EmployeeDto employeeDto);

        public EmployeeGetOrderDetailDto getOrderDetailByEmployee(int orderId);
        public Task<Order> employeeReportOrderAssignByOrderId(int id, EmployeeReportFormDto dto);


    }
}

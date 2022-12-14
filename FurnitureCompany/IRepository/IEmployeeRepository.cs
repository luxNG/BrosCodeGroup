using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface IEmployeeRepository
    {
        public List<Employee> getAllEmployee();
        public Employee getEmployeeById(int id);
        public void addNewEmployee(Employee e);
        public void updateEmployeeUrlImage(Employee employee);
        public Order getOrderDetailByEmployee(int orderId);
        public OrderService testOrderService(int orderService);
        public void updateEmployeeWorkingStatus(Employee employee);

        public Task<Employee> getEmployeeByIdAsync(int employeeId);

       




    }
}

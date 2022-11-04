using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface IEmployeeRepository
    {
        public List<Employee> getAllEmployee();
        public Employee getEmployeeById(int id);
        public void addNewEmployee(Employee e);
        public void updateEmployeeUrlImage(Employee employee);
    }
}

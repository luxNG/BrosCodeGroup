using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface IEmployeeDayOffRepository
    {
        public List<EmployeeDayOff> getAllEmployeeDayOff();
        public EmployeeDayOff getEmployeeDayOffByEmployeeId(int employeeId);
        public EmployeeDayOff getDayOffIdByEmployee(int id);
        public void employeeTakeDayOff(EmployeeDayOff employeeDayOff);
        public void deleteDayOffByEmployee(EmployeeDayOff employeeDayOff);
       // public Employee getEmployeeDayOffByEmployeeIdTest(int employeeId);

    }
}

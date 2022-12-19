using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface IEmployeeDayOffRepository
    {
        public List<EmployeeDayOff> getAllEmployeeDayOff();
        public List<EmployeeDayOff> getAllDayOffByEmployeeId(int employeeId);
        public EmployeeDayOff getDayOffByDayOffId(int dayOffId);
        public EmployeeDayOff getEmployeeDayOffByEmployeeId(int employeeId);
        public EmployeeDayOff getDayOffIdByEmployee(int id);
        public void employeeTakeDayOff(EmployeeDayOff employeeDayOff);
        public void deleteDayOffByEmployee(EmployeeDayOff employeeDayOff);
        public void updateDayOffByEmployee(EmployeeDayOff employeeDayOff);
      

    }
}

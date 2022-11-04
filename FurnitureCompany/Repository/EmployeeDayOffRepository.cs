using FurnitureCompany.Data;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureCompany.Repository
{
    public class EmployeeDayOffRepository : IEmployeeDayOffRepository
    {

        private FurnitureCompanyContext furnitureCompanyContext;
        public EmployeeDayOffRepository(FurnitureCompanyContext furnitureCompanyContext)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
        }

        public void deleteDayOffByEmployee(EmployeeDayOff employeeDayOff)
        {
            furnitureCompanyContext.EmployeeDayOffs.Remove(employeeDayOff);
            furnitureCompanyContext.SaveChanges();
        }

        public void employeeTakeDayOff(EmployeeDayOff employeeDayOff)
        {
            furnitureCompanyContext.EmployeeDayOffs.Add(employeeDayOff);
            furnitureCompanyContext.SaveChanges();
        }

        public List<EmployeeDayOff> getAllEmployeeDayOff()
        {
            List<EmployeeDayOff> listEmployeeDayOff = furnitureCompanyContext.EmployeeDayOffs.ToList();
            return listEmployeeDayOff;
        }

        public EmployeeDayOff getDayOffIdByEmployee(int id)
        {
            EmployeeDayOff e = furnitureCompanyContext.EmployeeDayOffs.FirstOrDefault(x => x.Id == id);
            return e;
        }

      
        public EmployeeDayOff getEmployeeDayOffByEmployeeId(int employeeId)
        {
            //EmployeeDayOff employeeDayoff = furnitureCompanyContext.EmployeeDayOffs..FirstOrDefault(x => x.EmployeeId == employeeId);
            var employeeDayoff = furnitureCompanyContext.EmployeeDayOffs.Where(x => x.EmployeeId == employeeId).Include(x => x.Employee).FirstOrDefault();
            return employeeDayoff;
        }

       /* public Employee getEmployeeDayOffByEmployeeIdTest(int employeeId)
        {

            //FromSqlRaw($"Select e.employee_name, e.employee_phone_number, edo.day_off, edo.reason from employee e join employee_day_off edo on e.employee_id = edo.employee_id where e.employee_id = {employeeId}").;    
            //var sql = Select e.employee_name, e.employee_phone_number, edo.day_off, edo.reason from employee e join employee_day_off edo on e.employee_id = edo.employee_id where e.employee_id = $(id) ;
           
            var employee = furnitureCompanyContext.Employees.Where(x => x.EmployeeId == employeeId).Include(x => x.EmployeeDayOffs).FirstOrDefault();
            return employee;
        }*/
    }
}

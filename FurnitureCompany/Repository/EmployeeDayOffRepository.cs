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

        public List<EmployeeDayOff> getAllDayOffByEmployeeId(int employeeId)
        {
            List<EmployeeDayOff> list = furnitureCompanyContext.EmployeeDayOffs.Where(x => x.EmployeeId == employeeId).ToList();
            return list;
        }

        public List<EmployeeDayOff> getAllEmployeeDayOff()
        {
            List<EmployeeDayOff> listEmployeeDayOff = furnitureCompanyContext.EmployeeDayOffs.ToList();
            return listEmployeeDayOff;
        }

        public EmployeeDayOff getDayOffByDayOffId(int dayOffId)
        {
            EmployeeDayOff employeeDayOff = furnitureCompanyContext.EmployeeDayOffs.FirstOrDefault(x => x.Id == dayOffId);
            return employeeDayOff;
        }

        public EmployeeDayOff getDayOffIdByEmployee(int id)
        {
            EmployeeDayOff e = furnitureCompanyContext.EmployeeDayOffs.FirstOrDefault(x => x.Id == id);
            return e;
        }

      
        public EmployeeDayOff getEmployeeDayOffByEmployeeId(int employeeId)
        {
           
            var employeeDayoff = furnitureCompanyContext.EmployeeDayOffs.Where(x => x.EmployeeId == employeeId).Include(x => x.Employee).FirstOrDefault();
            return employeeDayoff;
        }

        public void updateDayOffByEmployee(EmployeeDayOff employeeDayOff)
        {
            furnitureCompanyContext.EmployeeDayOffs.Update(employeeDayOff);
            furnitureCompanyContext.SaveChanges();
        }

       
    }
}

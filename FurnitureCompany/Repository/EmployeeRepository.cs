using FurnitureCompany.Data;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureCompany.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private FurnitureCompanyContext furnitureCompanyContext;
        public EmployeeRepository(FurnitureCompanyContext furnitureCompanyContext)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
        }

        public void addNewEmployee(Employee e)
        {
            furnitureCompanyContext.Employees.Add(e);
            furnitureCompanyContext.SaveChanges();
        }

        public List<Employee> getAllEmployee()
        {
            List<Employee> listEmployee = furnitureCompanyContext.Employees.ToList();
            return listEmployee;
        }

        public Employee getEmployeeById(int id)
        {
            Employee employee = furnitureCompanyContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            return employee;
        }

        public void updateEmployeeUrlImage(Employee employee)
        {
            furnitureCompanyContext.Employees.Update(employee);
            furnitureCompanyContext.SaveChanges();
        }


        public Order getOrderDetailByEmployee(int orderId)
        {
          Order orderDetail = furnitureCompanyContext.Orders.Where(x => x.OrderId == orderId).Include(x => x.OrderServices).FirstOrDefault();
          return orderDetail;
        }


    }
}

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
            List<Employee> listEmployee = furnitureCompanyContext.Employees.Include(x => x.Specialty).ToList();
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

        public void updateEmployeeWorkingStatus(Employee employee)
        {
            furnitureCompanyContext.Employees.Update(employee);
            furnitureCompanyContext.SaveChanges();
        }


        public Order getOrderDetailByEmployee(int orderId)
        {
            //đang bị lỗi tại đây
              Order orderDetail = furnitureCompanyContext.Orders.Where(x => x.OrderId == orderId).Include(x => x.OrderServices).ThenInclude(x => x.Service).ThenInclude(x => x.Category).Include(x => x.Customer).Include(x => x.WorkingStatus).Include(x=>x.Assigns).ThenInclude(x=>x.Employee).FirstOrDefault();
            //Order orderDetail = furnitureCompanyContext.Orders.FromSqlInterpolated($"select * from[dbo].[order] as o JOIN order_service as os on o.order_id = os.order_id Join[dbo].[service] as s on s.service_id = os.service_id join[dbo].[customer] as c on c.customer_id = o.customer_id join[dbo].[working_status] as ws on ws.status_id = o.working_status_id where o.order_id = {orderId}").FirstOrDefault();
            return orderDetail;
        }

        public OrderService testOrderService(int orderService)
        {
            OrderService orderDetail = furnitureCompanyContext.OrderServices.Where(x => x.OrderServiceId == orderService).Include(x => x.Service).FirstOrDefault();
            return orderDetail;
        }

        public async Task<Employee> getEmployeeByIdAsync(int employeeId)
        {
            Employee employee = await furnitureCompanyContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            return employee;
        }

      
    }
}

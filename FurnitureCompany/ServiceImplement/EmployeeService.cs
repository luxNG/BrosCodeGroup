using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;

namespace FurnitureCompany.ServiceImplement
{
    public class EmployeeService:IEmployeeService
    {
        private IEmployeeRepository employeeRepository;
        private IAssignRepository assignRepository;
        public EmployeeService(IEmployeeRepository employeeRepository, IAssignRepository assignRepository)
        {
            this.employeeRepository = employeeRepository;
            this.assignRepository = assignRepository;
        }

        public Employee addNewEmployeeByManger(EmployeeDto employeeDto)
        {
            Employee employee = new Employee()
            {
                AccountId = 1,
                SpecialtyId = 1,
                EmployeeName = employeeDto.EmployeeName,
                Email = employeeDto.Email,
                EmployeePhoneNumber = employeeDto.EmployeePhoneNumber,
                WorkingStatus = false,
                Status = true
            };
            employeeRepository.addNewEmployee(employee);
            return employee;
        }

        public List<Employee> GetAllEmployeeInformation()
        {
            List<Employee> list = employeeRepository.getAllEmployee();
            return list;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = employeeRepository.getEmployeeById(id);
            return employee;
        }

        public EmployeeGetOrderDetailDto getOrderDetailByEmployee(int orderId)
        {
            Order orderDetail = employeeRepository.getOrderDetailByEmployee(orderId);
            List<OrderServiceDto> listOrderServiceDtoMap = new List<OrderServiceDto>();
            List<EmployeeDto> listEmployeeDto = new List<EmployeeDto>();

            foreach (var item in orderDetail.Assigns)
            {
                listEmployeeDto.Add(new EmployeeDto()
                {
                    EmployeeName = item.Employee.EmployeeName,
                    EmployeePhoneNumber = item.Employee.EmployeePhoneNumber,
                    Email = item.Employee.Email
                });
            }
            foreach (var item in orderDetail.OrderServices)
            {
                listOrderServiceDtoMap.Add(new OrderServiceDto()
                {
                    OrderServiceId = item.OrderServiceId,
                    OrderId = item.OrderId,
                    ServiceId = item.ServiceId,
                    ServiceName = item.Service.ServiceName,
                    EstimateTimeFinish = item.EstimateTimeFinish,
                    Price = item.Service.Price
                });
            }
            EmployeeGetOrderDetailDto order = new EmployeeGetOrderDetailDto()
            {
                OrderId = orderDetail.OrderId,
                TotalPrice = orderDetail.TotalPrice,
                Address = orderDetail.Address,
                StatusName = orderDetail.WorkingStatus.StatusName,
                CustomerName = orderDetail.Customer.CustomerName,
                CustomerPhone = orderDetail.Customer.CustomerPhone,
                listOrderServiceDto = listOrderServiceDtoMap,
                listEmployeeDto = listEmployeeDto

            };
            return order;
        }

        public List<EmployeeAssignOrderDto> viewAssignByEmployee(int id)
        {
            List<Assign> assign = assignRepository.getAllAssignByEmployeeId(id);
            List<EmployeeAssignOrderDto> listDto = new List<EmployeeAssignOrderDto>();
            foreach (Assign assignItem in assign)
            {
                listDto.Add(new EmployeeAssignOrderDto()
                {
                    OrderId = assignItem.OrderId,
                    Address = assignItem.Order.Address,
                    CustomerId = assignItem.Order.CustomerId,
                    CustomerName = assignItem.Order.Customer.CustomerName,
                    StatusName = assignItem.Order.WorkingStatus.StatusName,
                    CustomerPhone = assignItem.Order.Customer.CustomerPhone,
                    WorkingStatusId = assignItem.Order.WorkingStatusId,


                });
            }

            return listDto;
        }
    }
}

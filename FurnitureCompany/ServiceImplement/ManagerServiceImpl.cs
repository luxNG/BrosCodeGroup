using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;

namespace FurnitureCompany.ServiceImplement
{
    public class ManagerServiceImpl:IManagerService
    {
        private IManagerRepository managerRepository;
        private ICategoryRepository categoryRepository;
        private IOrderRepository orderRepository;
        private ICustomerRepository customerRepository;
        private IEmployeeRepository employeeRepository;
        public ManagerServiceImpl(IManagerRepository managerRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository, ICustomerRepository customerRepository, IEmployeeRepository employeeRepository)
        {
            this.managerRepository = managerRepository;
            this.categoryRepository = categoryRepository;
            this.orderRepository = orderRepository;
            this.customerRepository = customerRepository;
            this.employeeRepository = employeeRepository;
        }

        public List<Category> getAllCategoryByManager()
        {
            List<Category> list = categoryRepository.getAllCategory();
            return list;
        }

        public List<ManagerGetAllOrderDto> getOrderByManager()
        {
            List<Order> list = managerRepository.getAllOrder();
            List<ManagerGetAllOrderDto> dto = new List<ManagerGetAllOrderDto>();
            foreach (var item in list)
            {
                dto.Add(new ManagerGetAllOrderDto()
                {
                    OrderId = item.OrderId,
                    CustomerId = item.Customer.CustomerId,
                    CustomerName = item.Customer.CustomerName,
                    CustomerPhone = item.Customer.CustomerPhone,
                    Address = item.Address,
                    ImplementationDate = item.ImplementationDate,
                    ImplementationTime = item.ImplementationTime,
                    StatusId = item.WorkingStatus.StatusId,
                    StatusName = item.WorkingStatus.StatusName,
                    TotalPrice = item.TotalPrice,
                    CreateAt = item.CreateAt,
                    UpdateAt = item.UpdateAt,
                    Description = item.Description,
                    
                });
            }
            return dto;

        }

        public ManagerGetOrderDetailDto managerGetOrderDetailByOrderId(int orderId)
        {
            Order order = managerRepository.managerGetOrderDetailByOrderId(orderId);
            List<string> orderImageUrl = new List<string>();
            List<ManagerOrderServiceDetailDto> listServices = new List<ManagerOrderServiceDetailDto>();
            List<ManagerGetListEmployeeOrderDetailDto> listEmployee = new List<ManagerGetListEmployeeOrderDetailDto>();

            foreach (var item in order.Assigns)
            {
                listEmployee.Add(new ManagerGetListEmployeeOrderDetailDto()
                {
                    AssignId = item.AssignId,
                    EmployeeId = item.EmployeeId,
                    EmployeeName = item.Employee.EmployeeName,
                    Email = item.Employee.Email,
                    EmployeePhoneNumber = item.Employee.EmployeePhoneNumber,
                    ImageUrl = item.Employee.ImageUrl,
                    WorkingStatus = item.Employee.WorkingStatus
                    
                });
            }

            foreach (var item in order.OrderServices)
            {
                listServices.Add(new ManagerOrderServiceDetailDto()
                {
                    ServiceId = item.Service.ServiceId,
                    ServiceName = item.Service.ServiceName,
                    CategoryName = item.Service.Category.CategoryName,
                    Price = item.Service.Price,
                    Quantity = item.Quantity                   
                   
                });
            }
            foreach (var item in order.OrderImages)
            {
                orderImageUrl.Add(item.ImageUrl);
            }
            ManagerGetOrderDetailDto dto = new ManagerGetOrderDetailDto()
            {
                OrderId = order.OrderId,
                CustomerName = order.Customer.CustomerName,
                CustomerPhone = order.Customer.CustomerPhone,
                ImplementationDate = order.ImplementationDate,
                ImplementationTime = order.ImplementationTime,
                StatusId = order.WorkingStatus.StatusId,
                StatusName = order.WorkingStatus.StatusName,
                ImageUrl = orderImageUrl,
                listOrderServiceInfor = listServices,
                listEmployeeAssign = listEmployee
                
            };
            return dto;
        }

        public Order managerGetOrderByOrderId(int id)
        {
            Order order = managerRepository.managerGetOrderByOrderId(id);
            return order;
        }

        public Order updateOrderStatusDoneByManager(int orderId)
        {
            Order order = managerRepository.findandUpdateOrderStatusByManager(orderId);
            order.WorkingStatusId = 6;
            managerRepository.updateOrderStatus(order);
            return order;
        }

        public Order updateOrderWorkingStatusByOrderId(int orderId, int orderWorkingStatusId)
        {
            Order order = orderRepository.managerUpdateOrderWorkingStatusByOrderId(orderId, orderWorkingStatusId);
            return order;
        }

        public Order updateTotalPriceByManager(int orderId, OrderDto orderDto)
        {
            Order order = managerRepository.findandUpdateTotalPrice(orderId);
            order.TotalPrice = orderDto.TotalPrice;
            managerRepository.updateTotalPriceByManager(order);
            return order;
        }

        public List<Customer> managerGetCustomerOrderInforByCustomerPhoneNumber(string phoneNumber)
        {
            List<Customer> customer = customerRepository.managerGetCustomerInforByPhoneNumber(phoneNumber);
            return customer;
        }

        public List<ManagerGetAllEmployeeInforDto> managerGetAllEmployeeInfor()
        {
            List<Employee> list = employeeRepository.getAllEmployee();
            List<ManagerGetAllEmployeeInforDto> dto = new List<ManagerGetAllEmployeeInforDto>();
            foreach (var item in list)
            {
                dto.Add(new ManagerGetAllEmployeeInforDto()
                {
                    EmployeeId = item.EmployeeId,
                    EmployeeName = item.EmployeeName,
                    EmployeePhoneNumber = item.EmployeePhoneNumber,
                    Email = item.Email,
                    ImageUrl = item.ImageUrl,
                    SpecialtyId = item.SpecialtyId,
                    SpecialtyName = item.Specialty.SpecialtyName,
                    WorkingStatus = item.WorkingStatus,
                    Status = item.Status
                });
            }
            return dto;
        }
    }
}

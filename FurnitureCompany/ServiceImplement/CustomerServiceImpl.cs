using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;

namespace FurnitureCompany.ServiceImplement
{
    public class CustomerServiceImpl:ICustomerService
    {
        private ICustomerRepository customerRepository;
        private IServiceRepository serviceRepository;
        private IOrderRepository orderRepository;

        public CustomerServiceImpl(ICustomerRepository customerRepository, IOrderRepository orderRepository, IServiceRepository serviceRepository)
        {
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
            this.serviceRepository = serviceRepository;
        }

        public List<Customer> getAllCustomer()
        {
            List<Customer> list = customerRepository.getAllCustomer();
            return list;
        }

        public CustomerGetDetailOrderInforDto customerGetOrderDetailInformationByOrderId(int orderId)
        {
            Order order = orderRepository.customerGetOrderDetailInformationByOrderId(orderId);
            List<EmployeeDto> listEmployeeDtoMap = new List<EmployeeDto>();
            List<OrderServiceDto> listServiceDtoMap = new List<OrderServiceDto>();

            foreach (var item in order.OrderServices)
            {
                listServiceDtoMap.Add(new OrderServiceDto
                {
                    ServiceName = item.Service.ServiceName,
                    Price = item.Service.Price
                });
            }

            foreach (var item in order.Assigns)
            {
                listEmployeeDtoMap.Add(new EmployeeDto
                {
                    EmployeeName = item.Employee.EmployeeName,
                    EmployeePhoneNumber = item.Employee.EmployeePhoneNumber
                });
            }
            CustomerGetDetailOrderInforDto orderDto = new CustomerGetDetailOrderInforDto()
            {
                Address = order.Address,
                TotalPrice = order.TotalPrice,
                StatusName = order.WorkingStatus.StatusName,
                Description = order.Description,
                CreateAt = order.CreateAt,
                listEmployeeDto = listEmployeeDtoMap,
                listOrderServiceDto = listServiceDtoMap
            };
            return orderDto;
        }

        public Order DeleteOrderByCustomer(int orderId)
        {
            Order order = orderRepository.getOrderById(orderId);
            order.Status = false;
            orderRepository.updateOrder(order);
            return order;
           
        }

        public async Task<Order> customerCreateOrderUsingCustomerIdTest(int id, CustomerCreateOrderTestDto customerCreateOrderTestDto)
        {

            Order order = new Order()
            {
                CustomerId = id,
                WorkingStatusId = 1,
                Address = customerCreateOrderTestDto.Address,
                CreateAt = customerCreateOrderTestDto.CreateAt,
                
            };
            Order orderAsynAwait = await orderRepository.CreateOrderAsync(order);
            if (orderAsynAwait.OrderId != -1)
            {
                foreach (var item in customerCreateOrderTestDto.listService)
                {
                    /* OrderService orderService = new OrderService
                     {
                         OrderId = order.OrderId,
                         ServiceId = item.ServiceId,
                     };*/
                    order.OrderServices.Add(new OrderService
                    {
                        OrderId = order.OrderId,
                        ServiceId = item.ServiceId,
                    });
                };
            }
           
            return order;
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = customerRepository.getCustomerById(id);
            return customer;
        }

        public List<CustomerServiceDetailCategoryDto> CustomerGetServiceAndCategoryInfor()
        {
            List<Service> listService = serviceRepository.GetServiceAndCategoryForCustomer();
            List<CustomerServiceDetailCategoryDto> listServiceCategoryDto = new List<CustomerServiceDetailCategoryDto>();
            foreach (var item in listService)
            {
                listServiceCategoryDto.Add(new CustomerServiceDetailCategoryDto() {
                    ServiceId = item.ServiceId,
                    CategoryId = item.CategoryId,
                    ServiceName = item.ServiceName,
                    CategoryName = item.Category.CategoryName,
                    ServiceDescription = item.ServiceDescription,
                    Price = item.Price,
                    Type = item.Type                
                });
            }
            return listServiceCategoryDto;
        }
    }
}

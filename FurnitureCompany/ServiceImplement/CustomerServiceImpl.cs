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
        private IOrderServiceRepository orderServiceRepository;
        private IAccountRepository accountRepository;

        public CustomerServiceImpl(ICustomerRepository customerRepository, IOrderRepository orderRepository, IServiceRepository serviceRepository, IOrderServiceRepository orderServiceRepository, IAccountRepository accountRepository)
        {
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
            this.serviceRepository = serviceRepository;
            this.orderServiceRepository = orderServiceRepository;
            this.accountRepository = accountRepository;
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
                TotalPrice = customerCreateOrderTestDto.TotalPrice,
                //ngày giờ thực hiện lịch
                ImplementationDate = customerCreateOrderTestDto.ImplementationDate,
                ImplementationTime = customerCreateOrderTestDto.ImplementationTime
                
            };
            Order orderAsynAwait = await orderRepository.CreateOrderAsync(order);
            if (orderAsynAwait.OrderId != -1)
            {
                foreach (var item in customerCreateOrderTestDto.listService)
                {
                    OrderService orderService = new OrderService
                    {
                        OrderId = orderAsynAwait.OrderId,
                        ServiceId = item.ServiceId,
                        Quantity = item.Quantity
                        
                    };
                    orderServiceRepository.addOrderService(orderService);

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

        public async Task<Order> customerUpdateOrderByOrderIdAsync(int orderId, int customerId, CustomerUpdateOrderDto dto)
        {
            Order order = orderRepository.customerUpdateOrderByOrderIdAndCustomerId(orderId, customerId);
            order.TotalPrice = dto.TotalPrice;
            order.Address = dto.Address;
            order.ImplementationDate = dto.ImplementationDate;
            order.ImplementationTime = dto.ImplementationTime;
            order.UpdateAt = dto.UpdateAt;

           
            foreach (var itemDto in dto.listService)
            {
                OrderService orderServiceFind = await orderServiceRepository.EmployeeFindOrderServiceByOrderId(order.OrderId, itemDto.ServiceId);

                if (orderServiceFind != null)
                {
                    orderServiceFind.Quantity += itemDto.Quantity;
                    orderServiceRepository.updateOrderService(orderServiceFind);

                }
                else
                {
                    order.OrderServices.Add(new OrderService
                    {
                        OrderId = order.OrderId,
                        ServiceId = itemDto.ServiceId,
                        Quantity = itemDto.Quantity,
                    });
                }
            }

            orderRepository.updateOrder(order);
            return order;
        }

        public List<CustomerGetListOrderAndOrderServiceDto> customerGetAllOrderByCustomerId(int customerId)
        {
            List<Order> list = orderRepository.customerGetListOrderAndOrderServiceByCustomerId(customerId);
            List<CustomerGetListOrderAndOrderServiceDto> dtoList = new List<CustomerGetListOrderAndOrderServiceDto>();
            List<CustomerGetListOrderServiceDto> dtoListOrderService = new List<CustomerGetListOrderServiceDto>();
           
            foreach (var item in list)
            {
                foreach (var itemDto in item.OrderServices)
                {
                    dtoListOrderService.Add(new CustomerGetListOrderServiceDto()
                    {
                        OrderServiceId = itemDto.OrderServiceId,
                        Quantity = itemDto.Quantity,
                        ServiceId = itemDto.Service.ServiceId,
                        ServiceName = itemDto.Service.ServiceName,
                        Price=itemDto.Service.Price
                    });
                }
            }

            foreach (var item in list)
            {
                dtoList.Add(new CustomerGetListOrderAndOrderServiceDto()
                {
                    OrderId = item.OrderId,
                    WorkingStatusId = item.WorkingStatusId,
                    CustomerId = item.CustomerId,
                    Address = item.Address,
                    CreateAt = item.CreateAt,
                    UpdateAt = item.UpdateAt,
                    Description = item.Description,
                    ImplementationDate = item.ImplementationDate,
                    ImplementationTime = item.ImplementationTime,
                    TotalPrice = item.TotalPrice,
                    listOrderService = dtoListOrderService,
                    
                });
            }
            
            return dtoList;

        }

        public CustomerCreateAccountDto customerCreateAccount(CustomerCreateAccountDto dto)
        {
            bool isCustomerUsernamePhoneExist = accountRepository.findCustomerUserNamePhoneAccountIsExist(dto.Username);

            if (!isCustomerUsernamePhoneExist)
            {
                Account customerAccount = new Account()
                {
                    Username = dto.Username,
                    Password = dto.Password,
                    Customer = new Customer()
                    {
                        CustomerName = dto.CustomerName,
                        CustomerPhone = dto.CustomerPhone
                    },
                    RoleId = dto.RoleId,
                    CreateAt = dto.CreateAt,
                    AccountStatus = true
                };
                accountRepository.customerCreateAccount(customerAccount);
            }
            else
            {
                return null;
            }            
           
            return dto;
        }

        public CustomerUpdateUsernameAndPasswordDto CustomerUpdateUsernameAndPassword(int accountId, CustomerUpdateUsernameAndPasswordDto dto)
        {
            Account account = accountRepository.findAccountByAccountId(accountId);
            bool isPasswordTrue = accountRepository.findPasswordIsTrueInAccount(accountId, dto.OldPassword);
            if (isPasswordTrue)
            {
                account.Password = dto.NewPassword;
                account.UpdateAt = dto.UpdateAt;
                accountRepository.customerUpdateUsernameAndPassword(account);
                return dto;
            }        
            return null;
        }
    }
}

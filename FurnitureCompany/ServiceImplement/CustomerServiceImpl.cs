﻿using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;

namespace FurnitureCompany.ServiceImplement
{
    public class CustomerServiceImpl:ICustomerService
    {
        private ICustomerRepository customerRepository;
        private IOrderRepository orderRepository;

        public CustomerServiceImpl(ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
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
    }
}

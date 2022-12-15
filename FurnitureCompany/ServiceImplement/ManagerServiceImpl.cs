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
        public ManagerServiceImpl(IManagerRepository managerRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository)
        {
            this.managerRepository = managerRepository;
            this.categoryRepository = categoryRepository;
            this.orderRepository = orderRepository;
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
                ImageUrl = orderImageUrl,
                listOrderServiceInfor = listServices                
                
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
    }
}

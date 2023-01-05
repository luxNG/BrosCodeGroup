using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface IOrderServiceRepository
    {
        public void addOrderService(OrderService orderService);
        public void updateOrderService(OrderService orderService);
        public OrderService FindOrderServiceByOrderServiceId(int orderServiceId);
        public Task<OrderService> EmployeeFindOrderServiceByOrderId(int orderId, int serviceId);

        public bool customerDeleteOrderService(int orderId,int orderServiceId);

    }
}

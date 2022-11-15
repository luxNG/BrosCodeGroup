using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface IOrderRepository
    {
        public Task<Order> CreateOrderAsync(Order order);
        public List<Order> getAllOrderByCustomer(int customerId);
        public List<Order> getAllOrderByManager();
        public Order getOrderById(int id);
        public void createOrder(Order order);
        public void updateOrder(Order order);
        public Order findOrderByOrderIdAndCustomerId(int customerId, int orderId);
        public Order customerGetOrderDetailInformationByOrderId(int orderId);
        public List<Customer> getAllOrderUsingCustomerId(int customerId);

    }
}

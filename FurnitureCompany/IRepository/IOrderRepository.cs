using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface IOrderRepository
    {
        public List<Order> getAllOrderByCustomer(int customerId);
        public List<Order> getAllOrderByManager();
        public Order getOrderById(int id);
        public void createOrder(Order order);
        public void updateOrder(Order order);
    }
}

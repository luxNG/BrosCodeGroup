using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface IManagerRepository
    {
        public List<Order> getAllOrder();
        public Order findandUpdateOrderStatusByManager(int orderId);
        public void updateOrderStatus(Order order);
        public void updateTotalPriceByManager(Order order);
        public Order findandUpdateTotalPrice(int orderId);


    }
}

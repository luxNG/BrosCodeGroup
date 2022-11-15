using FurnitureCompany.DTO;
using FurnitureCompany.Models;

namespace FurnitureCompany.IService
{
    public interface IManagerService
    {
        public List<Order> getOrderByManager();

        public List<Category> getAllCategoryByManager();

        public Order managerGetOrderByOrderId(int id);

        public Order updateTotalPriceByManager(int orderId, OrderDto orderDto);
        public Order updateOrderStatusDoneByManager(int id);


    }
}

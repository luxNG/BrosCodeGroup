using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface IOrderServiceRepository
    {
        public void addOrderService(OrderService orderService);
        public void updateOrderService(OrderService orderService);

    }
}

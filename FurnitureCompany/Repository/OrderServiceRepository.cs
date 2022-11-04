using FurnitureCompany.Data;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;

namespace FurnitureCompany.Repository
{
    public class OrderServiceRepository : IOrderServiceRepository
    {
        private FurnitureCompanyContext furnitureCompanyContext;
        public OrderServiceRepository(FurnitureCompanyContext furnitureCompanyContext)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
        }
        public void addOrderService(OrderService orderService)
        {
            furnitureCompanyContext.OrderServices.Add(orderService);
            furnitureCompanyContext.SaveChanges();
        }

        public OrderService findOrderServiceByOrderId(int orderServiceId)
        {
            OrderService orderService = furnitureCompanyContext.OrderServices.Where(x => x.OrderServiceId == orderServiceId).FirstOrDefault();
            return orderService;
        }


        public void updateOrderService(OrderService orderService)
        {
            furnitureCompanyContext.OrderServices.Update(orderService);
            furnitureCompanyContext.SaveChanges();
        }
    }
}

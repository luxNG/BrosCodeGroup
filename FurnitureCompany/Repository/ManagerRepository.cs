using FurnitureCompany.Data;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureCompany.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        private FurnitureCompanyContext furnitureCompanyContext;
        public ManagerRepository(FurnitureCompanyContext furnitureCompanyContext)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
        }

        public Order findandUpdateOrderStatusByManager(int orderId)
        {
            Order order =  furnitureCompanyContext.Orders.Where(x => x.OrderId == orderId).FirstOrDefault();
            return order;
        }

        public List<Order> getAllOrder()
        {
            List<Order> listOrderbyManager = furnitureCompanyContext.Orders.ToList();
            return listOrderbyManager;
        }



        public void updateOrderStatus(Order order)
        {
            furnitureCompanyContext.Orders.Update(order);
            furnitureCompanyContext.SaveChanges();
        }

        public Order findandUpdateTotalPrice(int orderId)
        {
            Order order = furnitureCompanyContext.Orders.Where(x => x.OrderId == orderId).FirstOrDefault();
            return order;
        }

        public void updateTotalPriceByManager(Order order)
        {
            furnitureCompanyContext.Orders.Update(order);
            furnitureCompanyContext.SaveChanges();
        }

       
    }
}

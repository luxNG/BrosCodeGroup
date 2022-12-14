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
            List<Order> listOrderbyManager = furnitureCompanyContext.Orders.Include(x => x.Customer).Include(x => x.WorkingStatus).ToList();
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

       public Order managerGetOrderByOrderId(int orderId)
       {
            Order order = furnitureCompanyContext.Orders.Where(x => x.OrderId == orderId).Include(x=>x.Customer).FirstOrDefault();
            return order;
       }

        public Order managerGetOrderDetailByOrderId(int orderId)
        {
            Order order = furnitureCompanyContext.Orders.Where(x => x.OrderId == orderId).Include(x=>x.WorkingStatus).Include(x => x.Assigns).ThenInclude(x=>x.Employee).Include(x => x.Customer).Include(x=>x.OrderImages).Include(x=>x.OrderServices).ThenInclude(x=>x.Service).ThenInclude(x=>x.Category).FirstOrDefault();
            return order;
        }
    }
}

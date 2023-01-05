using FurnitureCompany.Data;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;
using Microsoft.EntityFrameworkCore;

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

        public OrderService FindOrderServiceByOrderServiceId(int orderServiceId)
        {
            OrderService orderService = furnitureCompanyContext.OrderServices.Where(x => x.OrderServiceId == orderServiceId).FirstOrDefault();
            return orderService;
        }

        public async Task<OrderService> EmployeeFindOrderServiceByOrderId(int orderId, int serviceId)
        {
            OrderService orderService = await furnitureCompanyContext.OrderServices.Where(x => x.OrderId == orderId && x.ServiceId == serviceId).FirstOrDefaultAsync();
            return orderService;
        }


        public void updateOrderService(OrderService orderService)
        {
            furnitureCompanyContext.OrderServices.Update(orderService);
            furnitureCompanyContext.SaveChanges();
        }

        public bool customerDeleteOrderService(int orderId, int orderServiceId)
        {
            OrderService orderService = furnitureCompanyContext.OrderServices.FirstOrDefault(x => x.OrderId == orderId && x.OrderServiceId == orderServiceId); 
            if(orderService != null)
            {
                furnitureCompanyContext.OrderServices.Remove(orderService);
                furnitureCompanyContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}

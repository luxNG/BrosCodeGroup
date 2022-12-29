using FurnitureCompany.Data;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureCompany.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private FurnitureCompanyContext furnitureCompanyContext;
        public OrderRepository(FurnitureCompanyContext furnitureCompanyContext)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
        }
        // ko dùng hàm này vì nó ko xử lí bất đồng bộ
        public void createOrder(Order order)
        {
            furnitureCompanyContext.Orders.Add(order);
            furnitureCompanyContext.SaveChanges();
        }

        //sử dụng hàm này cho việc tạo đơn hàng
        public async Task<Order> CreateOrderAsync(Order order)
        {
          await furnitureCompanyContext.Orders.AddAsync(order);
          await furnitureCompanyContext.SaveChangesAsync();
          return order;
        }

        //get tất cả đơn hàng đã có của customer bằng id của customer
        public List<Order> getAllOrderByCustomer(int customerId)
        {
            List<Order> orders = furnitureCompanyContext.Orders.Where(x => x.CustomerId == customerId).ToList();
            return orders;
        }

      

        //Get tất cả đơn hàng bởi manager
        public List<Order> getAllOrderByManager()
        {
            List<Order> listOrder = furnitureCompanyContext.Orders.ToList();
            return listOrder;
        }

        //customer tìm kiếm lấy thông tin đơn bằng mã số của đơn hàng
        public Order getOrderById(int id)
        {
            Order order = furnitureCompanyContext.Orders.Where(x => x.OrderId == id).FirstOrDefault();
            return order;
        }

        public void updateOrder(Order order)
        {
            furnitureCompanyContext.Orders.Update(order);
            furnitureCompanyContext.SaveChanges();
        }

        public Order findOrderByOrderIdAndCustomerId(int orderId, int customerId)
        {
            Order order = furnitureCompanyContext.Orders.Where(x =>  x.OrderId == orderId && x.CustomerId == customerId).FirstOrDefault();
            return order;
        }

        public List<Customer> getAllOrderUsingCustomerId(int customerId)
        {
            List<Customer> list = furnitureCompanyContext.Customers.Where(x=>x.CustomerId == customerId).Include(x=>x.Orders).ToList();
            return list;
        }

        public Order customerGetOrderDetailInformationByOrderId(int orderId)
        {
            Order order = furnitureCompanyContext.Orders.Include(x => x.OrderServices).ThenInclude(x=>x.Service).Include(x=>x.Assigns).ThenInclude(x=>x.Employee).Include(x=>x.WorkingStatus).Where(x => x.OrderId == orderId).FirstOrDefault();
            return order;
        }

        public Order CustomerGetOrderAndOrderServiceByOrderId(int id)
        {
            Order order = furnitureCompanyContext.Orders.Where(x => x.OrderId == id).Include(x => x.OrderServices).FirstOrDefault();
            return order;
        }

        public Order managerUpdateOrderWorkingStatusByOrderId(int orderId, int orderWorkingStatusId)
        {
            Order order = furnitureCompanyContext.Orders.FirstOrDefault(x => x.OrderId == orderId);
            order.WorkingStatusId = orderWorkingStatusId;
            furnitureCompanyContext.Orders.Update(order);
            furnitureCompanyContext.SaveChanges();
            return order;
        }

        public Order customerUpdateOrderByOrderIdAndCustomerId(int orderId, int customerId)
        {
            Order order = furnitureCompanyContext.Orders.Include(x => x.OrderServices).Where(x => x.OrderId == orderId && x.CustomerId == customerId).FirstOrDefault();
            return order;
        }

        public List<Order> customerGetListOrderAndOrderServiceByCustomerId(int customerId)
        {
            List<Order> orders = furnitureCompanyContext.Orders.Where(x => x.CustomerId == customerId).Include(x=>x.OrderServices).ToList();
            return orders;
        }
    }
}

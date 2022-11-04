using FurnitureCompany.Data;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;

namespace FurnitureCompany.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private FurnitureCompanyContext furnitureCompanyContext;
        public OrderRepository(FurnitureCompanyContext furnitureCompanyContext)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
        }
        public void createOrder(Order order)
        {
            furnitureCompanyContext.Orders.Add(order);
            furnitureCompanyContext.SaveChanges();
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
    }
}

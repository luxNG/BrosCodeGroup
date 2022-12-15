using FurnitureCompany.DTO;
using FurnitureCompany.Models;

namespace FurnitureCompany.IService
{
    public interface IManagerService
    {
        public List<ManagerGetAllOrderDto> getOrderByManager();

        public List<Category> getAllCategoryByManager();

        //ko dùng cái này
        public Order managerGetOrderByOrderId(int id);

        public ManagerGetOrderDetailDto managerGetOrderDetailByOrderId(int orderId);

        public Order updateTotalPriceByManager(int orderId, OrderDto orderDto);
        public Order updateOrderStatusDoneByManager(int id);
        public Order updateOrderWorkingStatusByOrderId(int orderId, int orderWorkingStatusId);


    }
}

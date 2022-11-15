﻿using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;

namespace FurnitureCompany.ServiceImplement
{
    public class ManagerServiceImpl:IManagerService
    {
        private IManagerRepository managerRepository;
        private ICategoryRepository categoryRepository;
        public ManagerServiceImpl(IManagerRepository managerRepository, ICategoryRepository categoryRepository)
        {
            this.managerRepository = managerRepository;
            this.categoryRepository = categoryRepository;
        }

        public List<Category> getAllCategoryByManager()
        {
            List<Category> list = categoryRepository.getAllCategory();
            return list;
        }

        public List<Order> getOrderByManager()
        {
            List<Order> list = managerRepository.getAllOrder();
            return list;

        }

        public Order managerGetOrderByOrderId(int id)
        {
            Order order = managerRepository.managerGetOrderByOrderId(id);
            return order;
        }

        public Order updateOrderStatusDoneByManager(int orderId)
        {
            Order order = managerRepository.findandUpdateOrderStatusByManager(orderId);
            order.WorkingStatusId = 6;
            managerRepository.updateOrderStatus(order);
            return order;
        }

        public Order updateTotalPriceByManager(int orderId, OrderDto orderDto)
        {
            Order order = managerRepository.findandUpdateTotalPrice(orderId);
            order.TotalPrice = orderDto.TotalPrice;
            managerRepository.updateTotalPriceByManager(order);
            return order;
        }
    }
}

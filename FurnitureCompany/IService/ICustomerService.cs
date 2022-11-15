﻿using FurnitureCompany.DTO;
using FurnitureCompany.Models;

namespace FurnitureCompany.IService
{
    public interface ICustomerService
    {
        public CustomerGetDetailOrderInforDto customerGetOrderDetailInformationByOrderId(int orderId);
        public Order DeleteOrderByCustomer(int orderId);

    }
}
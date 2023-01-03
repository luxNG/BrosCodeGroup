using FurnitureCompany.DTO;
using FurnitureCompany.Models;

namespace FurnitureCompany.IService
{
    public interface ICustomerService
    {

        public List<Customer> getAllCustomer();
        public Customer GetCustomerById(int id);
        public CustomerGetDetailOrderInforDto customerGetOrderDetailInformationByOrderId(int orderId);
        public Order DeleteOrderByCustomer(int orderId);
        public Task< Order> customerCreateOrderUsingCustomerIdTest(int id, CustomerCreateOrderTestDto customerCreateOrderTestDto);
        public List<CustomerServiceDetailCategoryDto> CustomerGetServiceAndCategoryInfor();
        public Task<Order> customerUpdateOrderByOrderIdAsync(int orderId, int customerId, CustomerUpdateOrderDto customerUpdateOrderDto);

        public List<CustomerGetListOrderAndOrderServiceDto> customerGetAllOrderByCustomerId(int customerId);

        public CustomerCreateAccountDto customerCreateAccount(CustomerCreateAccountDto dto);

        public CustomerUpdateUsernameAndPasswordDto CustomerUpdateUsernameAndPassword(int accountId, CustomerUpdateUsernameAndPasswordDto dto);


    }
}

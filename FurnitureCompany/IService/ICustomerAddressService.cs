using FurnitureCompany.Models;

namespace FurnitureCompany.IService
{
    public interface ICustomerAddressService
    {
        public List<CustomerAddress> getListAddressByCustomerId(int customerId);
        // public Task<CustomerAddress> changeStatusCustomerAddressDefault(int customerId, int addressId, int oldAddressId);
        public CustomerAddress changeStatusCustomerAddressDefault(int customerId, int addressId, int oldAdress);
    }
}

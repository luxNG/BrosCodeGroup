using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface ICustomerAddressRepository
    {
        public List<CustomerAddress> getListAddressByCustomerId(int id);

        public CustomerAddress findCustomerAddressByCustomerAndAddressId(int customerId, int addressId);
        // public Task<CustomerAddress> updateStatusCustomerAddressDefault(CustomerAddress customerAddress);
        public CustomerAddress updateStatusCustomerAddressDefault(CustomerAddress customerAddress);

        public void customerAddNewAddress(CustomerAddress customerAddress);

        public CustomerAddress findCustomerAddressById(int customerAddressId);

        public void updateCustomerAddress(CustomerAddress customerAddress);

    }
}

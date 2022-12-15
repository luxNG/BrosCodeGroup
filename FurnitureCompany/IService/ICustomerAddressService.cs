using FurnitureCompany.DTO;
using FurnitureCompany.Models;

namespace FurnitureCompany.IService
{
    public interface ICustomerAddressService
    {
        public List<CustomerAddress> getListAddressByCustomerId(int customerId);
        // public Task<CustomerAddress> changeStatusCustomerAddressDefault(int customerId, int addressId, int oldAddressId);
        public List<CustomerAddress> changeStatusCustomerAddressDefault(int customerId, int addressId);

        public CustomerAddress addNewAddressByCustomerId(CustomerCreateNewAddress customerCreatenewAddress);

        public CustomerAddress updateAddressInformation(int customerAddressId, CustomerAddressDto customerAddressDto);

        public CustomerAddress customerDeleteAddress(int addressId);
    }
}

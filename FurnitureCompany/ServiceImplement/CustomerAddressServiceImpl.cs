using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;

namespace FurnitureCompany.ServiceImplement
{
    public class CustomerAddressServiceImpl:ICustomerAddressService
    {
        private ICustomerAddressRepository customerAddressRepository;
        public CustomerAddressServiceImpl(ICustomerAddressRepository customerAddressRepository)
        {
            this.customerAddressRepository = customerAddressRepository;
        }

        public CustomerAddress changeStatusCustomerAddressDefault(int customerId, int addressId, int oldAddress)
        {
            CustomerAddress customerAddress = customerAddressRepository.findCustomerAddressByCustomerAndAddressId(customerId, addressId);
            customerAddress.IsDefault = true;
            customerAddressRepository.updateStatusCustomerAddressDefault(customerAddress);

            CustomerAddress oldCustomerAddress = customerAddressRepository.findCustomerAddressByCustomerAndAddressId(customerId, oldAddress);
            oldCustomerAddress.IsDefault = false;
            customerAddressRepository.updateStatusCustomerAddressDefault(oldCustomerAddress);
            /*List<CustomerAddress> list = customerAddressRepository.getListAddressByCustomerId(customerId);
            foreach (var item in list)
            {
                if(item.AddressId == addressId)
                {
                    item.IsDefault = true;

                }
                    item.IsDefault = false;
              
                customerAddressRepository.updateStatusCustomerAddressDefault(item);

            }*/
            return customerAddress;
        }

        public List<CustomerAddress> getListAddressByCustomerId(int customerId)
        {
            List<CustomerAddress> list = customerAddressRepository.getListAddressByCustomerId(customerId);
            return list;
        }

       /* public  async Task< CustomerAddress> changeStatusCustomerAddressDefault(int customerId, int addressId, int oldAddressId)
        {
            CustomerAddress customerAddress =  customerAddressRepository.findCustomerAddressByCustomerAndAddressId(customerId, addressId);
            customerAddress.IsDefault = true;
            await customerAddressRepository.updateStatusCustomerAddressDefault(customerAddress);
            CustomerAddress oldCustomerAddress = customerAddressRepository.findCustomerAddressByCustomerAndAddressId(customerId, oldAddressId);
            oldCustomerAddress.IsDefault = false;
            await customerAddressRepository.updateStatusCustomerAddressDefault(oldCustomerAddress);
            return null;

        }*/
    }
}

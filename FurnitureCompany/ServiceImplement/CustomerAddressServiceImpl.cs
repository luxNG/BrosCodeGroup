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

        public List<CustomerAddress> changeStatusCustomerAddressDefault(int customerId, int addressId)
        {
            
            List<CustomerAddress> list = customerAddressRepository.getListAddressByCustomerId(customerId);
            foreach (var item in list)
            {
                if (item.AddressId == addressId)
                {
                    item.IsDefault = true;
                    customerAddressRepository.updateStatusCustomerAddressDefault(item);
                }
                else
                {
                    item.IsDefault = false;
                    customerAddressRepository.updateStatusCustomerAddressDefault(item);
                }               

            }
            return list;
        }

        public List<CustomerAddress> getListAddressByCustomerId(int customerId)
        {
            List<CustomerAddress> list = customerAddressRepository.getListAddressByCustomerId(customerId);
            return list;
        }

     
    }
}

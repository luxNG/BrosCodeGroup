using FurnitureCompany.DTO;
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

        public CustomerAddress addNewAddressByCustomerId(CustomerCreateNewAddress dto)
        {
            CustomerAddress customerAddress = new CustomerAddress()
            {
                
                CustomerId = dto.CustomerId,
                HomeNumber = dto.HomeNumber,
                Street = dto.Street,
                Ward = dto.Ward,
                District = dto.District,
                City = dto.City,
                CustomerNameOrder = dto.CustomerNameOrder,
                CustomerPhoneOrder = dto.CustomerPhoneOrder,
                IsDefault = false,
                Status = true
                
                
            };
            customerAddressRepository.customerAddNewAddress(customerAddress);
            return customerAddress;
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

        public CustomerAddress customerDeleteAddress(int addressId)
        {
            CustomerAddress customerAddress = customerAddressRepository.findCustomerAddressById(addressId);
            customerAddress.Status = false;
            customerAddressRepository.updateCustomerAddress(customerAddress);
            return customerAddress;
        }

        public List<CustomerAddress> getListAddressByCustomerId(int customerId)
        {
            List<CustomerAddress> list = customerAddressRepository.getListAddressByCustomerId(customerId);
            return list;
        }

        public CustomerAddress updateAddressInformation(int customerAddressId, CustomerAddressDto dto)
        {
            CustomerAddress customerAddress = customerAddressRepository.findCustomerAddressById(customerAddressId);
            customerAddress.HomeNumber = dto.HomeNumber;
            customerAddress.Street = dto.Street;
            customerAddress.Ward = dto.Ward;
            customerAddress.District = dto.District;
            customerAddress.City = dto.City;
            customerAddress.CustomerNameOrder = dto.CustomerNameOrder;
            customerAddress.CustomerPhoneOrder = dto.CustomerPhoneOrder;
            customerAddressRepository.updateCustomerAddress(customerAddress);
            return customerAddress;

        }
    }
}

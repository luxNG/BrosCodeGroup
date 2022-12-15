using FurnitureCompany.Data;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;

namespace FurnitureCompany.Repository
{
    public class CustomerAddressRepository:ICustomerAddressRepository
    {
        private FurnitureCompanyContext furnitureCompanyContext;
        public CustomerAddressRepository(FurnitureCompanyContext furnitureCompanyContext)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
        }

        public List<CustomerAddress> getListAddressByCustomerId(int customerId)
        {
            List<CustomerAddress> list = furnitureCompanyContext.CustomerAddresses.Where(x => x.CustomerId == customerId && x.Status == true).ToList();
            return list;
        }

        public  CustomerAddress updateStatusCustomerAddressDefault(CustomerAddress customerAddress)
        {
            furnitureCompanyContext.CustomerAddresses.Update(customerAddress);
            furnitureCompanyContext.SaveChanges();
            return customerAddress;
        }

        public CustomerAddress findCustomerAddressByCustomerAndAddressId(int customerId, int addressId)
        {
            CustomerAddress customerAddress = furnitureCompanyContext.CustomerAddresses.Where(x => x.CustomerId == customerId && x.AddressId == addressId).FirstOrDefault();
            return customerAddress;
        }

        public void customerAddNewAddress(CustomerAddress customerAddress)
        {
            furnitureCompanyContext.CustomerAddresses.Add(customerAddress);
            furnitureCompanyContext.SaveChanges();
        }

        public CustomerAddress findCustomerAddressById(int addressId)
        {
            CustomerAddress customerAddress = furnitureCompanyContext.CustomerAddresses.FirstOrDefault(x => x.AddressId == addressId);
            return customerAddress;
        }

        public void updateCustomerAddress(CustomerAddress customerAddress)
        {
            furnitureCompanyContext.CustomerAddresses.Update(customerAddress);
            furnitureCompanyContext.SaveChanges();
        }
    }
}

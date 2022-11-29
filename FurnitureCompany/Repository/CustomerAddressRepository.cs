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
            List<CustomerAddress> list = furnitureCompanyContext.CustomerAddresses.Where(x => x.CustomerId == customerId).ToList();
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

    
    }
}

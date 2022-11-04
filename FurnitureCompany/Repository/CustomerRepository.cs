using FurnitureCompany.Data;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;

namespace FurnitureCompany.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private FurnitureCompanyContext furnitureCompanyContext;
        public CustomerRepository(FurnitureCompanyContext furnitureCompanyContext)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
        }
        public List<Customer> getAllCustomer()
        {
                List<Customer> lisCustomer = furnitureCompanyContext.Customers.ToList();
                return lisCustomer;
        }

        public Customer getCustomerById(int id)
        {
            Customer findCustomer = furnitureCompanyContext.Customers.FirstOrDefault(x => x.CustomerId == id);
            return findCustomer;
        }

        public void updateCustomerStatus(Customer customer)
        {
            furnitureCompanyContext.Customers.Update(customer);
            furnitureCompanyContext.SaveChanges();
        }
    }
}

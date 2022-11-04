using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface ICustomerRepository
    {
        public List<Customer> getAllCustomer();
        public Customer getCustomerById(int id);       
        public void updateCustomerStatus(Customer customer);
       
    }
}

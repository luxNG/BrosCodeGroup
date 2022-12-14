using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface IServiceRepository
    {
        public List<Service> getAllService();
        public Service GetServiceById(int id);
        public int addService(Service service);
        public void updateService( Service service);
        public int deleteService(int service);
        public List<Service> GetServiceAndCategoryForCustomer();
        public List<Service> getServiceAndCategoryInformationForManager();
        public Service getServiceAndCategoryInformationForManagerByServiceId(int id);
        public List<Service> managerGetAllServiceByCategoryId(int categoryId);

    }
}

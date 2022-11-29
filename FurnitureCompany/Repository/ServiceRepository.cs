using FurnitureCompany.Data;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureCompany.Repository
{
    public class ServiceRepository : IServiceRepository
    {

        private FurnitureCompanyContext furnitureCompanyContext;
        public ServiceRepository(FurnitureCompanyContext furnitureCompanyContext)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
        }

        public int addService(Service service)
        {
            furnitureCompanyContext.Services.Add(service);
            int isSuccess = furnitureCompanyContext.SaveChanges();
            return isSuccess;
        }

        public int deleteService(int serviceId)
        {
           Service service = furnitureCompanyContext.Services.FirstOrDefault(x => x.ServiceId == serviceId);
            if(service == null)
            {
                return -1;
            }
            furnitureCompanyContext.Remove(service);
            furnitureCompanyContext.SaveChanges();
            return 1;
            
        }

        public List<Service> getAllService()
        {
           List<Service> listService = furnitureCompanyContext.Services.ToList();
            return listService;
        }

        public Service GetServiceById(int id)
        {
           Service service = furnitureCompanyContext.Services.FirstOrDefault(x => x.ServiceId == id);
           return service;
        }

      

        public void updateService( Service service)
        {
           
            if (service != null)
            {
                furnitureCompanyContext.Services.Update(service);
                furnitureCompanyContext.SaveChanges();
            }
           
        }

        public List<Service> GetServiceAndCategoryForCustomer()
        {
            List<Service> service = furnitureCompanyContext.Services.Include(x => x.Category).ToList();
            return service;
        }

        public List<Service> getServiceAndCategoryInformationForManager()
        {
            List<Service> list = furnitureCompanyContext.Services.Include(x => x.Category).ToList();
            return list;
        }

        public Service getServiceAndCategoryInformationForManagerByServiceId(int id)
        {
            Service service = furnitureCompanyContext.Services.Include(x => x.Category).FirstOrDefault(x => x.ServiceId == id);
            return service;
        }
    }
}

using FurnitureCompany.Data;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;

namespace FurnitureCompany.Repository
{
    public class ServiceDetailRepository:IServiceDetailRepository
    {
        private FurnitureCompanyContext furnitureCompanyContext;
        public ServiceDetailRepository(FurnitureCompanyContext furnitureCompanyContext)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
        }

        public void addNewServiceDetail(ServiceDetail serviceDetail)
        {
            furnitureCompanyContext.ServiceDetails.Add(serviceDetail);
            furnitureCompanyContext.SaveChanges();
        }

        public void deleteServiceDetail(int service)
        {
            throw new NotImplementedException();
        }

        public List<ServiceDetail> getAllServiceDetail()
        {
           List<ServiceDetail> listServiceDetail = furnitureCompanyContext.ServiceDetails.ToList();
            return listServiceDetail;
        }

        public ServiceDetail GetServiceDetailById(int id)
        {
             ServiceDetail serviceDetail = furnitureCompanyContext.ServiceDetails.FirstOrDefault(x => x.ServiceDetailId == id);
             return serviceDetail;
        }

        public void updateServiceDetail(ServiceDetail serviceDetail)
        {
            furnitureCompanyContext.ServiceDetails.Update(serviceDetail);
            furnitureCompanyContext.SaveChanges();
        }

        public void updateServiceDetailStatus(ServiceDetail serviceDetail)
        {
            furnitureCompanyContext.ServiceDetails.Update(serviceDetail);
            furnitureCompanyContext.SaveChanges();
        }
    }
}

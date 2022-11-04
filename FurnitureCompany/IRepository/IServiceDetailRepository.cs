using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface IServiceDetailRepository
    {
        public List<ServiceDetail> getAllServiceDetail();
        public ServiceDetail GetServiceDetailById(int id);
        public void addNewServiceDetail(ServiceDetail serviceDetail);
        public void updateServiceDetail(ServiceDetail serviceDetail);
        public void updateServiceDetailStatus(ServiceDetail serviceDetail);
    }
}

using FurnitureCompany.DTO;
using FurnitureCompany.Models;

namespace FurnitureCompany.IService
{
    public interface IFurnitureServiceService
    {
        public List<ServiceGetCustomInforDto> getAllService();
        public ServiceGetCustomInforDto getServiceInformationByServiceId(int serviceId);
        public ServiceDto managerCreateNewService(ServiceDto serviceDto);
        public Service managerRemoveServiceById(int id);
        public Service managerUpdateServiceInformation(int id, ServiceDto serviceDto);
        public List<ManagerGetListServiceDto> managerGetServiceByCategoryId(int categoryId);
    }
}

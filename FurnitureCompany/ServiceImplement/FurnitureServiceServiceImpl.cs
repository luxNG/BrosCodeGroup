using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;

namespace FurnitureCompany.ServiceImplement
{
    public class FurnitureServiceServiceImpl:IFurnitureServiceService
    {
        private IServiceRepository serviceRepository;
        public FurnitureServiceServiceImpl(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }

        public List<ServiceGetCustomInforDto> getAllService()
        {
            List<Service> listService = serviceRepository.getServiceAndCategoryInformationForManager();
            List<ServiceGetCustomInforDto> listMap = new List<ServiceGetCustomInforDto>();
            foreach (var item in listService)
            {
                listMap.Add(new ServiceGetCustomInforDto()
                {
                    ServiceId = item.ServiceId,
                    ServiceName = item.ServiceName,
                    ServiceDescription = item.ServiceDescription,
                    Price = item.Price,
                    Type = item.Type,
                    CreateAt = item.CreateAt,
                    UpdateAt = item.UpdateAt,
                    Status = item.Status,
                    CategoryName = item.Category.CategoryName,
                });
            }
            return listMap;
        }

        public ServiceGetCustomInforDto getServiceInformationByServiceId(int serviceId)
        {
            Service service = serviceRepository.getServiceAndCategoryInformationForManagerByServiceId(serviceId);
            ServiceGetCustomInforDto serviceGetCustomInforDto = new ServiceGetCustomInforDto()
            {
                ServiceId=service.ServiceId,
                ServiceName = service.ServiceName,
                ServiceDescription = service.ServiceDescription,
                Status = service.Status,
                Price = service.Price,
                Type = service.Type,
                CategoryName = service.Category.CategoryName,
                CreateAt = service.CreateAt,
                UpdateAt = service.UpdateAt
            };
            return serviceGetCustomInforDto;
        }

        public ServiceDto managerCreateNewService(ServiceDto serviceDto)
        {
            
            Service service = new Service
            {
                ServiceName = serviceDto.ServiceName,
                ServiceDescription = serviceDto.ServiceDescription,
                Price = serviceDto.Price,
                CreateAt = serviceDto.CreateAt,
                CategoryId = serviceDto.CategoryId,
                Status = true,
                Type = serviceDto.Type,                
            };
            serviceRepository.addService(service);
            return serviceDto;
        }

        public List<ManagerGetListServiceDto> managerGetServiceByCategoryId(int categoryId)
        {
            List<Service> list = serviceRepository.managerGetAllServiceByCategoryId(categoryId);
            List<ManagerGetListServiceDto> listDto = new List<ManagerGetListServiceDto>();
            foreach (var item in list)
            {
                listDto.Add(new ManagerGetListServiceDto()
                {
                    CategoryId = item.Category.CategoryId,
                    CategoryName = item.Category.CategoryName,
                    ServiceId = item.ServiceId,
                    ServiceName = item.ServiceName,
                    Price = item.Price,
                    ServiceDescription = item.ServiceDescription,
                    CreateAt = item.CreateAt,
                    UpdateAt = item.UpdateAt,
                    Type = item.Type,
                    ServiceStatus = item.Status                    
                });
            }
            return listDto;
        }

        public Service managerRemoveServiceById(int id)
        {
            Service service = serviceRepository.GetServiceById(id);
            service.Status = false;
            serviceRepository.updateService(service);
            return service;
        }

        public Service managerUpdateServiceInformation(int id, ServiceDto serviceDto)
        {
            Service service = serviceRepository.GetServiceById(id);
            //map from dto to model
            service.ServiceName = serviceDto.ServiceName;
            service.ServiceDescription = serviceDto.ServiceDescription;
            service.Price = serviceDto.Price;
            service.UpdateAt = serviceDto.UpdateAt;
            service.Status = serviceDto.Status;
            service.Type = serviceDto.Type;
            serviceRepository.updateService(service);
            return service;
        }
    }
}

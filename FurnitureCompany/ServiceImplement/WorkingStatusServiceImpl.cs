using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;

namespace FurnitureCompany.ServiceImplement
{
    public class WorkingStatusServiceImpl : IWorkingStatusService
    {
        private IWorkingStatusRepository workingStatusRepository;
        public WorkingStatusServiceImpl(IWorkingStatusRepository workingStatusRepository)
        {
            this.workingStatusRepository = workingStatusRepository;
        }

        public List<WorkingStatus> getAllWorkingStatus()
        {
           List<WorkingStatus> list = workingStatusRepository.getAllWorkingStatus();
           return list;
        }
    }
}

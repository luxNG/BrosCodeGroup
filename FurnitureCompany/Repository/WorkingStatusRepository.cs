using FurnitureCompany.Data;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;

namespace FurnitureCompany.Repository
{
    public class WorkingStatusRepository : IWorkingStatusRepository
    {
        private FurnitureCompanyContext furnitureCompanyContext;
        public WorkingStatusRepository(FurnitureCompanyContext furnitureCompanyContext)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
        }

        public List<WorkingStatus> getAllWorkingStatus()
        {
            List<WorkingStatus> list = furnitureCompanyContext.WorkingStatuses.ToList();
            return list;
        }

        
    }
}

using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface IWorkingStatusRepository
    {
        public List<WorkingStatus> getAllWorkingStatus();
    }
}

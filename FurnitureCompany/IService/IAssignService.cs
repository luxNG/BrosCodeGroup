using FurnitureCompany.DTO;
using FurnitureCompany.Models;

namespace FurnitureCompany.IService
{
    public interface IAssignService
    {
        public List<Assign> managerGetAllAssign();
        public Assign managerUpdateAssignStatusByAssignId(int id, AssignDto assignDto);
    }
}

using FurnitureCompany.DTO;
using FurnitureCompany.Models;

namespace FurnitureCompany.IService
{
    public interface IAssignService
    {
        public List<Assign> managerGetAllAssign();
        public Assign managerUpdateAssignStatusByAssignId(int id, AssignDto assignDto);

        public Task<ManagerAssignDto> createAssignByManager(int id, ManagerAssignDto assignDto);

        public Assign deleteEmployeeFromAssignByAssignIdAndEmployeeId(int assignId, int employeeId);
    }
}

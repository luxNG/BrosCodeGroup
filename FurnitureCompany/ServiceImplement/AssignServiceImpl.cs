using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;

namespace FurnitureCompany.ServiceImplement
{
    public class AssignServiceImpl : IAssignService
    {
        private IAssignRepository assignRepository;
        public AssignServiceImpl(IAssignRepository assignRepository)
        {
            this.assignRepository = assignRepository;
        }
        public List<Assign> managerGetAllAssign()
        {
            List<Assign> listAssign = assignRepository.getAllAssign();
            return listAssign;
        }

        public Assign managerUpdateAssignStatusByAssignId(int id, AssignDto assignDto)
        {
            Assign assign = assignRepository.findAssignByManager(id);
            assign.Status = assignDto.Status;
            assign.CreateAssignAt = assignDto.CreateAssignAt;
            assignRepository.updateAssign(assign);                        
            
            return assign;
        }
    }
}

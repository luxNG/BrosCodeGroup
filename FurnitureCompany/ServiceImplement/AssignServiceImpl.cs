using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;

namespace FurnitureCompany.ServiceImplement
{
    public class AssignServiceImpl : IAssignService
    {
        private IAssignRepository assignRepository;
        private IEmployeeRepository employeeRepository;
        public AssignServiceImpl(IAssignRepository assignRepository, IEmployeeRepository employeeRepository)
        {
            this.assignRepository = assignRepository;
            this.employeeRepository = employeeRepository;
        }

        public async Task<ManagerAssignDto> createAssignByManager(int id, ManagerAssignDto assignDto)
        {
            foreach (var item in assignDto.listEmployee)
            {
                Employee employee = await employeeRepository.getEmployeeByIdAsync(item.EmployeeId);
                employee.WorkingStatus = true;
                employeeRepository.updateEmployeeWorkingStatus(employee);
                Assign assign = new Assign()
                {
                    OrderId = id,
                    ManagerId = assignDto.ManagerId,
                    EmployeeId = item.EmployeeId,
                    CreateAssignAt = assignDto.CreateAssignAt,
                    Status = true,
                };               
                assignRepository.createAssign(assign);
            }
           
            return assignDto;
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

        public Assign deleteEmployeeFromAssignByAssignIdAndEmployeeId(int id, int employeeId)
        {

            Assign assign = assignRepository.getAssignByIdAndEmployeeId(id, employeeId);
            assign.Employee.WorkingStatus = false;
            assign.Status = false;
            assignRepository.updateAssign(assign);
            return assign;
        }
        
    }
}

using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;

namespace FurnitureCompany.ServiceImplement
{
    public class EmployeeDayOffServiceImpl : IEmployeeDayOffService
    {
        private IEmployeeDayOffRepository employeeDayOffRepository;
        public EmployeeDayOffServiceImpl(IEmployeeDayOffRepository employeeDayOffRepository)
        {
            this.employeeDayOffRepository = employeeDayOffRepository;
        }

        public EmployeeDayOff cancelAbsentFormByFormId(int employeeDayOffId)
        {
            EmployeeDayOff employeeDayOff = employeeDayOffRepository.getDayOffByDayOffId(employeeDayOffId);
            employeeDayOff.Status = 2;
            employeeDayOffRepository.updateDayOffByEmployee(employeeDayOff);
            return employeeDayOff;
        }

        public EmployeeDayOff employeeCreateAbsentForm(EmployeeDayOffDto employeeDayOffDto)
        {
            EmployeeDayOff employeeDayOff = new EmployeeDayOff()
            {
                EmployeeId = employeeDayOffDto.EmployeeId,
                Reason = employeeDayOffDto.Reason,
                DayOff = employeeDayOffDto.DayOff,
                Status = employeeDayOffDto.Status,
            };
            employeeDayOffRepository.employeeTakeDayOff(employeeDayOff);
            return employeeDayOff;
        }

        public EmployeeDayOff employeeUpdateDayOffDayOffId(int dayOffId, EmployeeUpdateDayOffDto dto)
        {
            EmployeeDayOff employeeDayOff = employeeDayOffRepository.getDayOffByDayOffId(dayOffId);
            employeeDayOff.DayOff = dto.DayOff;
            employeeDayOff.Reason = dto.Reason;
            employeeDayOffRepository.updateDayOffByEmployee(employeeDayOff);
            return employeeDayOff;
        }

      

        public List<EmployeeDayOff> getAllDayOffByEmployeeId(int employeeId)
        {
            List<EmployeeDayOff> list = employeeDayOffRepository.getAllDayOffByEmployeeId(employeeId);
            return list;
        }

        public List<ManagerGetEmployeeDayOffDto> managerGetListEmployeeDayOff()
        {
            List<EmployeeDayOff> listEmployeeDayOff = employeeDayOffRepository.getAllEmployeeDayOff();
            List<ManagerGetEmployeeDayOffDto> dto = new List<ManagerGetEmployeeDayOffDto>();
            foreach (var item in listEmployeeDayOff)
            {
                dto.Add(new ManagerGetEmployeeDayOffDto()
                {
                    Id = item.Id,
                    EmployeeId = item.EmployeeId,
                    EmployeeName = item.Employee.EmployeeName,
                    EmployeePhoneNumber = item.Employee.EmployeePhoneNumber,
                    Email = item.Employee.Email,
                    DayOff = item.DayOff,
                    Reason = item.Reason,
                    Status = item.Status
                });
            }

            return dto;
        }

        public EmployeeDayOff managerUpdateEmployeeDayOffStatus(int employeeDayOffId, ManagerUpdateEmployeeDayOffStatusDto dto)
        {
            EmployeeDayOff employeeDayOff = employeeDayOffRepository.getDayOffByDayOffId(employeeDayOffId);
            employeeDayOff.Status = dto.Status;
            // lưu ý function này
            employeeDayOffRepository.updateDayOffByEmployee(employeeDayOff);
            return employeeDayOff;
        }
    }
}

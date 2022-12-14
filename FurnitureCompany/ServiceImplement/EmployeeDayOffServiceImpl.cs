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
            employeeDayOff.Status = false;
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
    }
}

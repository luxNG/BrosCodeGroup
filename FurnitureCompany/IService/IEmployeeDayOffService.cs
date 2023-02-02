using FurnitureCompany.DTO;
using FurnitureCompany.Models;

namespace FurnitureCompany.IService
{
    public interface IEmployeeDayOffService
    {
        public List<EmployeeDayOff> getAllDayOffByEmployeeId(int employeeId);
        public EmployeeDayOff employeeUpdateDayOffDayOffId(int dayOffId, EmployeeUpdateDayOffDto dto);
        public EmployeeDayOff employeeCreateAbsentForm(EmployeeDayOffDto employeeDayOffDto);
        public EmployeeDayOff cancelAbsentFormByFormId(int employeeDayOffId);
        public List<ManagerGetEmployeeDayOffDto> managerGetListEmployeeDayOff();
        public EmployeeDayOff managerUpdateEmployeeDayOffStatus(int employeeDayOffId, ManagerUpdateEmployeeDayOffStatusDto dto);

    }
}

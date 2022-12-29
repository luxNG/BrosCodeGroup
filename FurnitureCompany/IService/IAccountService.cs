using FurnitureCompany.DTO;
using FurnitureCompany.Models;

namespace FurnitureCompany.IService
{
    public interface IAccountService
    {
        public List<ManagerGetEmployeeAccountInforCustomDto> managerGetAllAccountInformationOfEmployee();
        public ManagerCreateEmployeeeAccountDto managerCreateEmployeeeAccountDto(ManagerCreateEmployeeeAccountDto managerCreateEmployeeeAccountDto);
        public UserTokenDto loginIntoServer(LoginDto loginDto);
        public Account userLogoutAccount(int accountId);

        
    }
}

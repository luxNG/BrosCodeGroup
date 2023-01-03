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

        //tạo mới 1 token với tham số đầu vào là refreshtoken
       // public UserTokenDto RenewToken(RefreshTokenDto refreshTokenDto);


    }
}

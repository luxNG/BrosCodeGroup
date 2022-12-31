using FurnitureCompany.DTO;
using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface IAccountRepository
    {
        public List<Account> getAllAccountInformationOfEmployee();
        public void managerCreateEmployeeAccountDto(Account account);
        public Account findUsernameAndPasswordToLogin(LoginDto loginDto);
        public bool findRefreshTokenIsUsing(string refreshTokenAfterEncode);
        public Account insertRefreshTokenToDb(int accountId, string refreshToken);
        public Account logoutAccountByDeleteRefreshToken(int accountId);
        public void customerCreateAccount(Account account);
        public Manager findAccountDetailByRoleManager(int accountId);
        public Employee findAccountDetailByRoleEmployee(int accountId);
        public Customer findAccountDetailByRoleCustomer(int accountId);
        public bool findCustomerUserNamePhoneAccountIsExist(string customerUsernamePhone);
        public void customerUpdateUsernameAndPassword(Account account);

        public Account findAccountByAccountId(int accountId);
    }
}

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
    }
}

using FurnitureCompany.Data;
using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureCompany.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private FurnitureCompanyContext furnitureCompanyContext;

        public AccountRepository(FurnitureCompanyContext  furnitureCompanyContext)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
        }

        public void customerCreateAccount(Account account)
        {
            furnitureCompanyContext.Accounts.Add(account);
            furnitureCompanyContext.SaveChanges();
        }

        public Customer findAccountDetailByRoleCustomer(int accountId)
        {
            Customer accountDetail = furnitureCompanyContext.Customers.Include(x => x.Account).ThenInclude(x=>x.Role).FirstOrDefault(x => x.AccountId == accountId);
            return accountDetail;
        }

        public Employee findAccountDetailByRoleEmployee(int accountId)
        {
            Employee accountDetail = furnitureCompanyContext.Employees.Include(x => x.Account).ThenInclude(x => x.Role).FirstOrDefault(x => x.AccountId == accountId);
            return accountDetail;
        }

        public Manager findAccountDetailByRoleManager(int accountId)
        {
            Manager accountDetail = furnitureCompanyContext.Managers.Include(x => x.Account).ThenInclude(x => x.Role).FirstOrDefault(x => x.AccountId == accountId);
            return accountDetail;
        }

        public bool findCustomerUserNamePhoneAccountIsExist(string customerUsernamePhone)
        {
            bool isExist = furnitureCompanyContext.Accounts.Any(x => x.Username.Equals(customerUsernamePhone));
            return isExist;
        }

        public bool findRefreshTokenIsUsing(string refreshTokenAfterEncode)
        {
            bool isExist = furnitureCompanyContext.Accounts.Any(x => x.RefreshToken == refreshTokenAfterEncode);
            return isExist;
        }

       

        public Account findUsernameAndPasswordToLogin(LoginDto loginDto)
        {
            Account account = furnitureCompanyContext.Accounts.Include(x=>x.Role).FirstOrDefault(x => x.Username == loginDto.Username && x.Password == loginDto.Password);
            return account;
        }

        public List<Account> getAllAccountInformationOfEmployee()
        {
            List<Account> listAccount = furnitureCompanyContext.Accounts.Include(x => x.Role).Include(x => x.Employee).ThenInclude(x => x.EmployeeName).ToList();
            return listAccount;
        }

        public Account insertRefreshTokenToDb(int accountId, string refreshToken)
        {
            Account account = furnitureCompanyContext.Accounts.FirstOrDefault(x => x.AccountId == accountId);
            account.RefreshToken = refreshToken;
            furnitureCompanyContext.SaveChanges();
            return account;
        }

        public Account logoutAccountByDeleteRefreshToken(int accountId)
        {
            Account account = furnitureCompanyContext.Accounts.FirstOrDefault(x => x.AccountId == accountId);
            account.RefreshToken = null;
            furnitureCompanyContext.SaveChanges();
            return account;
        }

        public void managerCreateEmployeeAccountDto(Account account)
        {
            furnitureCompanyContext.Accounts.Add(account);
            furnitureCompanyContext.SaveChanges();
        }

        public bool findPasswordIsTrueInAccount(int accountId, string password)
        {
            bool isExist = furnitureCompanyContext.Accounts.Any(x => x.AccountId == accountId && x.Password.Equals(password));
            return isExist;
        }

        public void customerUpdateUsernameAndPassword(Account account)
        {
            furnitureCompanyContext.Accounts.Update(account);
            furnitureCompanyContext.SaveChanges();
        }

        public Account findAccountByAccountId(int accountId)
        {
            Account account = furnitureCompanyContext.Accounts.FirstOrDefault(x => x.AccountId == accountId);
            return account;
        }

       /* public bool findRefreshTokenIsInUse(string refreshTokenCheck)
        {
            bool checkIsInUse = furnitureCompanyContext.Accounts.Any(x => x.RefreshToken == refreshTokenCheck);
            return checkIsInUse;
        }*/

       /* public bool findRefreshTokenIsExist(RefreshTokenDto refreshtokenDto)
        {
            //kiểm tra mã refresh nhập vào có đúng với mã đã lưu trong database
            //và ngày hết hạn phải lớn hơn ngày nhập vào tức là mã này còn hạn sử dụng hay ko hay ko (expire = tháng 12 và ngày sử dụng là tháng 11 tức là còn hạn)
            //nếu đúng thì trả về thông tin của refresh token 
           // Account refresh_Token = furnitureCompanyContext.Accounts.Where(x => x.RefreshToken == refreshtokenDto.Token && x.ExperationDate >= DateTime.Now).FirstOrDefault();
            Account refresh_Token = furnitureCompanyContext.Accounts.Where(x => x.RefreshToken == refreshtokenDto.Token).FirstOrDefault();
            return refresh_Token;
        }*/

       
    }
}

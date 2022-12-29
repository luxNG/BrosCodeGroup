﻿using FurnitureCompany.Data;
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
    }
}

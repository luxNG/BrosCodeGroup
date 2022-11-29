﻿using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FurnitureCompany.ServiceImplement
{
    public class AccountServiceImpl:IAccountService
    {
        private IAccountRepository accountRepository;
        public AccountServiceImpl(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public List<ManagerGetEmployeeAccountInforCustomDto> managerGetAllAccountInformationOfEmployee()
        {
            List<Account> listAccount = accountRepository.getAllAccountInformationOfEmployee();
            List<ManagerGetEmployeeAccountInforCustomDto> listMapDto = new List<ManagerGetEmployeeAccountInforCustomDto>();
            foreach (var item in listAccount)
            {
                listMapDto.Add(new ManagerGetEmployeeAccountInforCustomDto()
                {
                    AccountId = item.AccountId,
                    Username = item.Username,
                    Password = item.Password,                   
                    CreateAt = item.CreateAt,
                    UpdateAt = item.UpdateAt,

                });
            }
            return listMapDto;
        }

        public ManagerCreateEmployeeeAccountDto managerCreateEmployeeeAccountDto(ManagerCreateEmployeeeAccountDto managerCreateEmployeeeAccountDto)
        {
            Account account = new Account()
            {
                Username = managerCreateEmployeeeAccountDto.Username,
                Password = managerCreateEmployeeeAccountDto.Password,
                CreateAt = managerCreateEmployeeeAccountDto.CreateAt,
                RoleId = managerCreateEmployeeeAccountDto.RoleId,
                AccountStatus = true,
                Employee = new Employee()
                {
                    EmployeeName = managerCreateEmployeeeAccountDto.EmployeeName,
                    Email = managerCreateEmployeeeAccountDto.Email,
                    EmployeePhoneNumber = managerCreateEmployeeeAccountDto.EmployeePhoneNumber,
                    SpecialtyId = managerCreateEmployeeeAccountDto.SpecialtyId
                }
              
            };

            accountRepository.managerCreateEmployeeAccountDto(account);
            return managerCreateEmployeeeAccountDto ;
        }

        //Login 
        public UserTokenDto loginIntoServer(LoginDto loginDto)
        {
            Account account = accountRepository.findUsernameAndPasswordToLogin(loginDto);
            if (account != null)
            {
                var access_Token = createJwtToken(account);
                var refresh_Token = createRefreshToken();
                InsertRefreshToken(account.AccountId, refresh_Token);
                UserTokenDto userTokenDto = new UserTokenDto()
                {
                    accessToken = access_Token,
                    refreshToken = refresh_Token
                };
                return userTokenDto;
            }
            return null;
        }

        public string createJwtToken(Account account)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("helloearththisismysecrectkeyforjwt123456789")
            );
            var credentials = new SigningCredentials(
                symmetricSecurityKey,
                SecurityAlgorithms.HmacSha256
            );
            /*var userCliams = new Claim[]{
                new Claim("email", user.Email),
                new Claim("phone", user.PhoneNumber),

             };*/
            var userCliams = new List<Claim>();
            userCliams.Add(new Claim("username", account.Username));
            userCliams.Add(new Claim("password", account.Password));
            userCliams.Add(new Claim(ClaimTypes.Role, account.Role.RoleName));

            var jwtToken = new JwtSecurityToken(
                issuer: "https://furnituremanagementservice.azurewebsites.net",
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials,
                claims: userCliams,
                audience: "https://furnituremanagementservice.azurewebsites.net"
            );
            string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }

        private string createRefreshToken()
        {
            var selectByteToEncode = RandomNumberGenerator.GetBytes(64);
            var convertToBase64Encode_RefreshToken = Convert.ToBase64String(selectByteToEncode);
            var refreshTokenIsUsing = accountRepository.findRefreshTokenIsUsing(convertToBase64Encode_RefreshToken);
            //Nếu trùng nhau thì gọi lại hàm này để tạo ra 1 token mới
            if (refreshTokenIsUsing)
            {
                return createRefreshToken();
            }
            // ko thì trả về chuỗi refresh token
            return convertToBase64Encode_RefreshToken;
        }

        // lưu trữ refresh token vào table refreshtoken trong database
        public void InsertRefreshToken(int accountId, string refreshtoken)
        {
           accountRepository.insertRefreshTokenToDb(accountId, refreshtoken); 
        }

        public Account userLogoutAccount(int accountId)
        {
            Account account = accountRepository.logoutAccountByDeleteRefreshToken(accountId);
            return account;
        }
    }
}
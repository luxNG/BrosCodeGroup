﻿namespace FurnitureCompany.DTO
{
    public class UserLoginBasicInformationDto
    {
        /*public int AccountId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string RoleName { get; set; } = null!;*/

        public int AccountId { get; set; }
        public int UserId { get; set; }
        public string FullUserName { get; set; }
        public string UserPhone { get; set; }
        public string RoleName { get; set; } = null!;
        public string UsernameLogin { get; set; } = null!;
        public string PasswordLogin { get; set; } = null!;
    }
}

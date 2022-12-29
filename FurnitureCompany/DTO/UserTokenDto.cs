namespace FurnitureCompany.DTO
{
    public class UserTokenDto
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
        public UserLoginBasicInformationDto userLoginBasicInformationDto { get; set; }

    }
}

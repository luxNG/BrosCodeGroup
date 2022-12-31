namespace FurnitureCompany.DTO
{
    public class CustomerUpdateUsernameAndPasswordDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? UpdateAt { get; set; }
    }
}

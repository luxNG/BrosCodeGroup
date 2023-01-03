namespace FurnitureCompany.DTO
{
    public class CustomerUpdateUsernameAndPasswordDto
    {
        public string OldPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
        public DateTime? UpdateAt { get; set; }
    }
}

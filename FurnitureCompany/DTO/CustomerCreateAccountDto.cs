namespace FurnitureCompany.DTO
{
    public class CustomerCreateAccountDto
    {
        public string? CustomerName { get; set; }
        public string CustomerPhone { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public DateTime? CreateAt { get; set; }
        public bool AccountStatus { get; set; }
    }
}

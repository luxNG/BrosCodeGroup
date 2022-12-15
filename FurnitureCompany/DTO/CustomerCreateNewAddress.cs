namespace FurnitureCompany.DTO
{
    public class CustomerCreateNewAddress
    {
        public int CustomerId { get; set; }
        public string? HomeNumber { get; set; }
        public string? Street { get; set; }
        public string? Ward { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? CustomerNameOrder { get; set; }
        public string? CustomerPhoneOrder { get; set; }
        public bool IsDefault { get; set; }
    }
}

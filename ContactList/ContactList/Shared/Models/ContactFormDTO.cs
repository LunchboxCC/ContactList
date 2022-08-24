namespace ContactList.Shared.Models
{
    public class ContactFormDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? EmailAddress { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
    }
}

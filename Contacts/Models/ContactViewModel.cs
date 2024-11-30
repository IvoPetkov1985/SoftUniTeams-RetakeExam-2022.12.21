namespace Contacts.Models
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string? Address { get; set; } = string.Empty;

        public string Website { get; set; } = string.Empty;
    }
}

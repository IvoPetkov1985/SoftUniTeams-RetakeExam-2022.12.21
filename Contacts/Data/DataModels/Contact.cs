using System.ComponentModel.DataAnnotations;
using static Contacts.Data.Common.DataConstants;

namespace Contacts.Data.DataModels
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(ContactEmailMaxLength)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(AddressMaxLength)]
        public string? Address { get; set; }

        [Required]
        [MaxLength(WebsiteMaxLength)]
        public string Website { get; set; } = string.Empty;

        public IEnumerable<ApplicationUserContact> ApplicationUsersContacts { get; set; } = new List<ApplicationUserContact>();
    }
}

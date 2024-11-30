using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Contacts.Data.Common.DataConstants;

namespace Contacts.Data.DataModels
{
    [Comment("Contact information with details")]
    public class Contact
    {
        [Key]
        [Comment("Contact identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        [Comment("First name in the contact form")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(LastNameMaxLength)]
        [Comment("Last name in the contact form")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(EmailMaxLength)]
        [Comment("Valid e-mail address")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        [Comment("Phone number for correspondation and contact confirmation")]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(AddressMaxLength)]
        [Comment("Optional - address for correspondation")]
        public string? Address { get; set; }

        [Required]
        [MaxLength(WebsiteMaxLength)]
        [Comment("Web address")]
        public string Website { get; set; } = string.Empty;

        public IEnumerable<ApplicationUserContact> ApplicationUsersContacts { get; set; } = new List<ApplicationUserContact>();
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Contacts.Data.Common.DataConstants;

namespace Contacts.Data.DataModels
{
    [Comment("The main entry of the contact table")]
    public class Contact
    {
        [Key]
        [Comment("Contact identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        [Comment("Contact first name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(LastNameMaxLength)]
        [Comment("Contact last name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(EmailMaxLength)]
        [Comment("Email of the contact person")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        [Comment("Mobile phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(AddressMaxLength)]
        [Comment("Address for correspondation")]
        public string? Address { get; set; }

        [Required]
        [MaxLength(WebsiteMaxLength)]
        [Comment("Website for more information")]
        public string Website { get; set; } = string.Empty;

        public IEnumerable<ApplicationUserContact> ApplicationUsersContacts { get; set; } = new List<ApplicationUserContact>();
    }
}

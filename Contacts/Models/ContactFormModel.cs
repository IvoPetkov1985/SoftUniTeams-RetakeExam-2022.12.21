using System.ComponentModel.DataAnnotations;
using static Contacts.Data.Common.DataConstants;

namespace Contacts.Models
{
    public class ContactFormModel
    {
        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(ContactEmailMaxLength, MinimumLength = ContactEmailMinLength)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [RegularExpression(PhoneRegex, ErrorMessage = PhoneInvalidMessage)]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(AddressMaxLength)]
        public string? Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(WebsiteMaxLength)]
        [RegularExpression(WebsiteRegex, ErrorMessage = WebsiteInvalidMessage)]
        public string Website { get; set; } = string.Empty;
    }
}

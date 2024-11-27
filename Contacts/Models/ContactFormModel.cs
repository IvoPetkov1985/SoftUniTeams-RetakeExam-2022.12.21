using System.ComponentModel.DataAnnotations;
using static Contacts.Data.Common.DataConstants;

namespace Contacts.Models
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = FirstNameRequiredMsg)]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = FirstNameLengthMsg)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = LastNameRequiredMsg)]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = LastNameLengthMsg)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(ContactEmailMaxLength, MinimumLength = ContactEmailMinLength)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = PhoneRequiredMsg)]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = PhoneLengthMsg)]
        [RegularExpression(PhoneRegex, ErrorMessage = PhoneInvalidMessage)]
        public string PhoneNumber { get; set; } = string.Empty;

        [StringLength(AddressMaxLength)]
        public string? Address { get; set; }

        [Required]
        [RegularExpression(WebsiteRegex, ErrorMessage = WebsiteInvalidMessage)]
        public string Website { get; set; } = string.Empty;
    }
}

//•	Has Id – a unique integer, Primary Key
//•	Has FirstName – a string with min length 2 and max length 50 (required)
//•	Has LastName – a string with min length 5 and max length 50 (required)
//•	Has Email – a string with min length 10 and max length 60 (required)
//•	Has PhoneNumber – a string with min length 10 and max length 13 (required). The phone number must start with "+359" or '0' (zero), followed by four sets of digits, separated by a space, '-' (dash) or nothing between the sets. The first group must have exactly three digits and the others exactly two digits. Valid examples: 0 875 23 45 15, +359 - 883 - 15 - 12 - 10, 0889552217.
//•	Has Address – a string 
//•	Has Website – a string. First four characters are "www.", followed by letters, digits or '-' and last three characters are ".bg" (required)
//•	Has ApplicationUsersContacts – a collection of type ApplicationUserContact

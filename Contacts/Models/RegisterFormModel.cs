using System.ComponentModel.DataAnnotations;
using static Contacts.Data.Common.DataConstants;

namespace Contacts.Models
{
    public class RegisterFormModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength, ErrorMessage = LengthErrorMsg)]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = LengthErrorMsg)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = LengthErrorMsg)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        [Compare(nameof(Password), ErrorMessage = PasswordNotMatchingMsg)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

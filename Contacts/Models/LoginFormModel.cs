using System.ComponentModel.DataAnnotations;
using static Contacts.Data.Common.DataConstants;

namespace Contacts.Models
{
    public class LoginFormModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}

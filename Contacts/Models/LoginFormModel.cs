using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Contacts.Data.Common.DataConstants;

namespace Contacts.Models
{
    public class LoginFormModel
    {
        [Required]
        [DisplayName(UsernameDisplay)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}

using Microsoft.AspNetCore.Identity;

namespace Contacts.Data.DataModels
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<ApplicationUserContact> ApplicationUsersContacts { get; set; } = new List<ApplicationUserContact>();
    }
}

using Contacts.Models;

namespace Contacts.Contracts
{
    public interface IContactService
    {
        Task AddContactToTeamAsync(string userId, int id);

        Task CreateContactAsync(ContactFormModel model);

        Task<ContactFormModel> CreateEditModelAsync(int id);

        Task EditContactAsync(ContactFormModel model, int id);

        Task<IEnumerable<ContactViewModel>> GetAllContactsAsync();

        Task<IEnumerable<ContactViewModel>> GetAllTeamContactsAsync(string userId);

        Task<bool> IsContactExistingAsync(int id);

        bool IsEditPermitted(int id);

        Task RemoveContactFromTeamAsync(string userId, int id);
    }
}

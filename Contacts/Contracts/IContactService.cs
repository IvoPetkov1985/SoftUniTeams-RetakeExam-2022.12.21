using Contacts.Models;

namespace Contacts.Contracts
{
    public interface IContactService
    {
        Task AddContactToTeamAsync(string userId, int id);

        Task<ContactFormModel> CreateEditModelAsync(int id);

        Task CreateNewContactAsync(ContactFormModel model);

        Task EditContactAsync(ContactFormModel model, int id);

        Task<IEnumerable<ContactViewModel>> GetAllContactsAsync();

        Task<IEnumerable<ContactViewModel>> GetAllTeamContactsAsync(string userId);

        Task<bool> IsContactExisting(int id);

        bool IsContactPredefinedAsync(int id);

        Task<bool> IsUserEntryExisting(string userId, int id);

        Task RemoveContactFromTeamAsync(string userId, int id);
    }
}

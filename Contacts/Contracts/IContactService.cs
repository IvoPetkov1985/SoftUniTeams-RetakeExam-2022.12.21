using Contacts.Models;

namespace Contacts.Contracts
{
    public interface IContactService
    {
        Task AddContactToTeamAsync(string userId, int id);

        bool CheckDeleteOrEditByIdAsync(int id);

        Task<ContactFormModel> CreateEditContactModelAsync(int id);

        Task CreateNewContactEntityAsync(ContactFormModel model);

        Task DeleteContactAsync(int id);

        Task EditExistingContactAsync(int id, ContactFormModel model);

        Task<IEnumerable<ContactViewModel>> GetAllContactsAsync();

        Task<IEnumerable<ContactViewModel>> GetTeamContactsAsync(string userId);

        Task<bool> IsContactExisting(int id);

        Task RemoveContactFromTeamAsync(string userId, int id);
    }
}

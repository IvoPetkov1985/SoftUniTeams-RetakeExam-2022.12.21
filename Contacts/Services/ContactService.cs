using Contacts.Contracts;
using Contacts.Data;
using Contacts.Data.DataModels;
using Contacts.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactsDbContext context;

        public ContactService(ContactsDbContext _context)
        {
            context = _context;
        }

        public async Task AddContactToTeamAsync(string userId, int id)
        {
            if (await context.ApplicationUsersContacts
                .AnyAsync(uc => uc.ApplicationUserId == userId && uc.ContactId == id) == false)
            {
                ApplicationUserContact entry = new()
                {
                    ApplicationUserId = userId,
                    ContactId = id
                };

                await context.ApplicationUsersContacts.AddAsync(entry);

                await context.SaveChangesAsync();
            }
        }

        public bool CheckDeleteOrEditByIdAsync(int id)
        {
            if (id <= 3)
            {
                return false;
            }

            return true;
        }

        public async Task<ContactFormModel> CreateEditContactModelAsync(int id)
        {
            Contact entity = await context.Contacts
                .AsNoTracking()
                .FirstAsync(c => c.Id == id);

            ContactFormModel editModel = new()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                Address = entity.Address,
                Website = entity.Website
            };

            return editModel;
        }

        public async Task CreateNewContactEntityAsync(ContactFormModel model)
        {
            Contact entity = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Website = model.Website
            };

            await context.Contacts.AddAsync(entity);

            await context.SaveChangesAsync();
        }

        public async Task DeleteContactAsync(int id)
        {
            Contact contactToDelete = await context.Contacts
                .FirstAsync(c => c.Id == id);

            context.Remove(contactToDelete);

            await context.SaveChangesAsync();
        }

        public async Task EditExistingContactAsync(int id, ContactFormModel model)
        {
            Contact entity = await context.Contacts
                .FirstAsync(c => c.Id == id);

            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            entity.PhoneNumber = model.PhoneNumber;
            entity.Address = model.Address;
            entity.Website = model.Website;

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ContactViewModel>> GetAllContactsAsync()
        {
            IEnumerable<ContactViewModel> allContacts = await context.Contacts
                .AsNoTracking()
                .Select(c => new ContactViewModel()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    Website = c.Website
                })
                .ToListAsync();

            return allContacts;
        }

        public async Task<IEnumerable<ContactViewModel>> GetTeamContactsAsync(string userId)
        {
            IEnumerable<ContactViewModel> teamContacts = await context.ApplicationUsersContacts
                .AsNoTracking()
                .Where(uc => uc.ApplicationUserId == userId)
                .Select(uc => new ContactViewModel()
                {
                    Id = uc.Contact.Id,
                    FirstName = uc.Contact.FirstName,
                    LastName = uc.Contact.LastName,
                    Email = uc.Contact.Email,
                    PhoneNumber = uc.Contact.PhoneNumber,
                    Address = uc.Contact.Address,
                    Website = uc.Contact.Website
                })
                .ToListAsync();

            return teamContacts;
        }

        public async Task<bool> IsContactExisting(int id)
        {
            Contact? contact = await context.Contacts
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            return contact != null;
        }

        public async Task RemoveContactFromTeamAsync(string userId, int id)
        {
            if (await context.ApplicationUsersContacts
                .AnyAsync(uc => uc.ApplicationUserId == userId && uc.ContactId == id))
            {
                ApplicationUserContact entry = await context.ApplicationUsersContacts
                    .FirstAsync(uc => uc.ApplicationUserId == userId && uc.ContactId == id);

                context.ApplicationUsersContacts.Remove(entry);

                await context.SaveChangesAsync();
            }
        }
    }
}

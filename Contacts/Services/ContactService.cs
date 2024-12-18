﻿using Contacts.Contracts;
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
            ApplicationUserContact teamEntry = new()
            {
                ApplicationUserId = userId,
                ContactId = id
            };

            if (await context.ApplicationUsersContacts.ContainsAsync(teamEntry) == false)
            {
                await context.ApplicationUsersContacts.AddAsync(teamEntry);

                await context.SaveChangesAsync();
            }
        }

        public async Task CreateContactAsync(ContactFormModel model)
        {
            Contact contact = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Website = model.Website
            };

            await context.Contacts.AddAsync(contact);

            await context.SaveChangesAsync();
        }

        public async Task<ContactFormModel> CreateEditModelAsync(int id)
        {
            ContactFormModel editModel = await context.Contacts
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new ContactFormModel()
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    Website = c.Website
                })
                .SingleAsync();

            return editModel;
        }

        public async Task EditContactAsync(ContactFormModel model, int id)
        {
            Contact contactToEdit = await context.Contacts
                .SingleAsync(c => c.Id == id);

            contactToEdit.FirstName = model.FirstName;
            contactToEdit.LastName = model.LastName;
            contactToEdit.Email = model.Email;
            contactToEdit.PhoneNumber = model.PhoneNumber;
            contactToEdit.Address = model.Address;
            contactToEdit.Website = model.Website;

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

        public async Task<IEnumerable<ContactViewModel>> GetAllTeamContactsAsync(string userId)
        {
            IEnumerable<ContactViewModel> teamContacts = await context.ApplicationUsersContacts
                .AsNoTracking()
                .Where(uc => uc.ApplicationUserId == userId)
                .Select(uc => new ContactViewModel()
                {
                    Id = uc.ContactId,
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

        public async Task<bool> IsContactExistingAsync(int id)
        {
            Contact? contact = await context.Contacts
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == id);

            return contact != null;
        }

        public bool IsEditPermitted(int id)
        {
            return id > 3;
        }

        public async Task RemoveContactFromTeamAsync(string userId, int id)
        {
            ApplicationUserContact teamEntry = new()
            {
                ApplicationUserId = userId,
                ContactId = id
            };

            if (await context.ApplicationUsersContacts.ContainsAsync(teamEntry))
            {
                context.ApplicationUsersContacts.Remove(teamEntry);

                await context.SaveChangesAsync();
            }
        }
    }
}
